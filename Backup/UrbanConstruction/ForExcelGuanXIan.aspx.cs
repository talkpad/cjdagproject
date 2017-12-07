using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.IO;
using System.Data.OleDb;
using NPOI;
using NPOI.HSSF.UserModel; 　　//2003版本
using NPOI.SS.UserModel;
using System.Text;
using NPOI.SS.Util;
using System.Collections.Generic;
using System.Security.Cryptography;


namespace UrbanConstruction
{
    public partial class ForExcelGuanXIan : System.Web.UI.Page
    {
        private string filepath
        {
            get
            {
                string path = ConfigurationManager.AppSettings["XLSGX"].ToString();
                return Server.MapPath("./") + path;
            }
            set
            {
                filepath = value;
            }
        }
        private HSSFSheet sht;
        protected String excelContent;
        public string searchtype = "null";
        public string value = "null";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                string token = CreateToken();
                PutTokenToClient(token);
                SaveTokenInServer(token);

                token = GetTokenFromRequest();
                //需要csrf保护的地方就check才放行
                if (TokenIsOK(token))
                {
                    int kind;
                    if (Request.QueryString["searchtype"] != "null")
                    {
                        if (int.TryParse(Request["searchtype"], out kind) == false)
                        {
                            Response.Redirect("Error.htm");
                        }
                        else
                        {
                            searchtype = Request.QueryString["searchtype"];
                            value = Request.QueryString["value"];
                        }
                    }

                    GetTable();
                }
                else
                    Response.Redirect("index.aspx");
            }
        }

        public void GetTable()
        {
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            HSSFWorkbook wb = new HSSFWorkbook(fs);
            sht = (HSSFSheet)wb.GetSheetAt(0); 
            //取行Excel的最大行数
            int rowsCount = sht.PhysicalNumberOfRows;
            //为保证Table布局与Excel一样，这里应该取所有行中的最大列数（需要遍历整个Sheet）。
            //为少一交全Excel遍历，提高性能，我们可以人为把第0行的列数调整至所有行中的最大列数。
            int colsCount = sht.GetRow(1).PhysicalNumberOfCells;
            int colSpan;
            int rowSpan;
            int spanCount = 0;   
            bool isByRowMerged;
            List<int> counts = new List<int>();
            StringBuilder table = new StringBuilder();
            table.Append("<table  border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse' bordercolor='#111111'>");
            for (int rowIndex = 1; rowIndex < rowsCount; rowIndex++)
            {               
                table.Append("<tr>");             
                if (Request.QueryString["searchtype"] != "null" && Request.QueryString["value"] != "null")
                {
                    if (rowIndex >= 3)
                    {
                        GetTdMergedInfo(sht, rowIndex, 0, out colSpan, out rowSpan, out isByRowMerged);
                        //如果已经被行合并包含进去了就不输出TD了。
                        //注意被合并的行或列不输出的处理方式不一样，见下面一处的注释说明了列合并后不输出TD的处理方式。
                        if (rowSpan > 1)
                        {
                            counts.Add(spanCount);
                            spanCount = 0;
                        }
                    }
                    switch (int.Parse(Request.QueryString["searchtype"]))
                    {
                        case 1:
                            if (sht.GetRow(rowIndex).GetCell(3).ToString().Contains(Request.QueryString["value"]))
                            { 
                                ++spanCount;
                            }
                            break;
                        case 2:
                            if (sht.GetRow(rowIndex).GetCell(4).ToString().Contains(Request.QueryString["value"]))
                            {
                                ++spanCount;    
                            }
                            break;
                        case 3:
                            if (sht.GetRow(rowIndex).GetCell(6).ToString().Contains(Request.QueryString["value"]))
                            {
                                ++spanCount;                                     
                            }
                            break;
                    }
                } 
                else if (Request.QueryString["searchtype"] == "null" || int.Parse(Request.QueryString["searchtype"]) == 0 || Request.QueryString["value"] == "null")
                {                  
                    for (int colIndex = 0; colIndex < colsCount; colIndex++)
                    {
                        GetTdMergedInfo(sht, rowIndex, colIndex, out colSpan, out rowSpan, out isByRowMerged);
                        //如果已经被行合并包含进去了就不输出TD了。
                        //注意被合并的行或列不输出的处理方式不一样，见下面一处的注释说明了列合并后不输出TD的处理方式。
                        if (isByRowMerged)
                        {
                            continue;
                        }
                        table.Append("<td height='40px'");
                        if (colSpan > 1)
                            table.Append(string.Format(" colSpan={0}", colSpan));
                        if (rowSpan > 1)
                        {
                            table.Append(string.Format(" rowSpan={0}", rowSpan));
                            //table.Append(" width='8%' style='text-align:center'");
                        }
                        switch (colIndex)
                        {
                            case 0:
                                table.Append(" width='8%' style='text-align:center'");
                                break;
                            case 1:
                                table.Append(" width='5%' style='text-align:center'");
                                break;
                            case 2:
                                table.Append(" width='10%' style='text-align:center'");
                                break;
                            case 3:
                                table.Append(" width='16%' style='text-align:center'");
                                break;
                            case 4:
                                table.Append(" width='20%' style='text-align:center'");
                                break;
                            case 5:
                                table.Append(" width='17%' style='text-align:center'");
                                break;
                            case 6:
                                table.Append(" width='14%' style='text-align:center'");
                                break;
                            case 7:
                                table.Append(" width='10%' style='text-align:center'");
                                break;
                        }
                        table.Append(">");
                        if (colIndex == 2 && rowIndex>=3)
                            table.Append(DateTime.Parse(sht.GetRow(rowIndex).GetCell(colIndex).ToString()).ToString("yyyy-MM-dd")); 
                        else
                            table.Append(sht.GetRow(rowIndex).GetCell(colIndex));
                        //列被合并之后此行将少输出colSpan-1个TD。
                        if (colSpan > 1)
                            colIndex += colSpan - 1;
                        table.Append("</td>");
                    }
                }              
                table.Append("</tr>");
            }
            counts.Add(spanCount);
            int Index = 0;
            int rowSpanCount = 1;
            int firstRow = 0;
            string temp = null;
            bool isChange = true;
            if (Request.QueryString["searchtype"] != "null" && Request.QueryString["value"] != "null")
            {
                table = new StringBuilder();
                table.Append("<table  border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse' bordercolor='#111111'>");
                for (int rowIndex = 1; rowIndex < rowsCount; rowIndex++)
                {
                    temp = table.ToString();
                    table.Append("<tr>");                  
                    for (int colIndex = 0; colIndex < colsCount; colIndex++)
                    {
                        if (rowIndex < 3)
                        {
                            GetTdMergedInfo(sht, rowIndex, colIndex, out colSpan, out rowSpan, out isByRowMerged);
                            //如果已经被行合并包含进去了就不输出TD了。
                            //注意被合并的行或列不输出的处理方式不一样，见下面一处的注释说明了列合并后不输出TD的处理方式。
                            if (isByRowMerged)
                            {
                                continue;
                            }
                            table.Append("<td height='40px' ");
                            if (colSpan > 1)
                                table.Append(string.Format(" colSpan={0}", colSpan));
                            if (rowSpan > 1)
                                table.Append(string.Format(" rowSpan={0}", rowSpan));
                            switch (colIndex)
                            {
                                case 0:
                                    table.Append(" width='8%' style='text-align:center'");
                                    break;
                                case 1:
                                    table.Append(" width='5%' style='text-align:center'");
                                    break;
                                case 2:
                                    table.Append(" width='10%' style='text-align:center'");
                                    break;
                                case 3:
                                    table.Append(" width='16%' style='text-align:center'");
                                    break;
                                case 4:
                                    table.Append(" width='20%' style='text-align:center'");
                                    break;
                                case 5:
                                    table.Append(" width='17%' style='text-align:center'");
                                    break;
                                case 6:
                                    table.Append(" width='14%' style='text-align:center'");
                                    break;
                                case 7:
                                    table.Append(" width='10%' style='text-align:center'");
                                    break;
                            }
                            table.Append(">");
                            if (colIndex == 2 && rowIndex >= 3)
                                table.Append(DateTime.Parse(sht.GetRow(rowIndex).GetCell(colIndex).ToString()).ToString("yyyy-MM-dd"));
                            else
                                table.Append(sht.GetRow(rowIndex).GetCell(colIndex));
                            //列被合并之后此行将少输出colSpan-1个TD。
                            if (colSpan > 1)
                                colIndex += colSpan - 1;
                            table.Append("</td>");
                        }
                        else
                        {
                            GetTdMergedInfo(sht, rowIndex, colIndex, out colSpan, out rowSpan, out isByRowMerged);
                            //如果已经被行合并包含进去了就不输出TD了。
                            //注意被合并的行或列不输出的处理方式不一样，见下面一处的注释说明了列合并后不输出TD的处理方式。
                            if (isByRowMerged)
                            {
                                continue;
                            }
                            if (rowSpan > 1)
                            {
                                rowSpanCount = rowSpan;
                                firstRow = rowIndex;
                                Index++;
                            }
                          
                            switch (int.Parse(Request.QueryString["searchtype"]))
                            {
                                case 1:
                                    if (sht.GetRow(rowIndex).GetCell(3).ToString().Contains(Request.QueryString["value"]))
                                    {
                                        isChange = true;
                                        table.Append("<td height='40px' ");
                                        switch (colIndex)
                                        {
                                            case 0:
                                                table.Append(" width='8%' style='text-align:center'");
                                                break;
                                            case 1:
                                                table.Append(" width='5%' style='text-align:center'");
                                                break;
                                            case 2:
                                                table.Append(" width='10%' style='text-align:center'");
                                                break;
                                            case 3:
                                                table.Append(" width='16%' style='text-align:center'");
                                                break;
                                            case 4:
                                                table.Append(" width='20%' style='text-align:center'");
                                                break;
                                            case 5:
                                                table.Append(" width='17%' style='text-align:center'");
                                                break;
                                            case 6:
                                                table.Append(" width='14%' style='text-align:center'");
                                                break;
                                            case 7:
                                                table.Append(" width='10%' style='text-align:center'");
                                                break;
                                        }
                                        if (colSpan > 1)
                                            table.Append(string.Format(" colSpan={0}", colSpan));
                                        if (rowSpanCount > 1 && Index > 0)
                                        {
                                            table.Append(string.Format(" rowSpan={0}", counts[Index]));
                                            rowSpanCount = 1;
                                            table.Append(">");
                                            colIndex = 0;
                                            table.Append(sht.GetRow(firstRow).GetCell(colIndex));
                                        }
                                        else
                                        {
                                            table.Append(">");
                                            if (colIndex == 2 && rowIndex >= 3)
                                                table.Append(DateTime.Parse(sht.GetRow(rowIndex).GetCell(colIndex).ToString()).ToString("yyyy-MM-dd"));
                                            else
                                                table.Append(sht.GetRow(rowIndex).GetCell(colIndex));
                                        }
                                        table.Append("</td>");
                                    }
                                    else
                                    {
                                        table = new StringBuilder(temp);
                                        isChange = false;
                                    }
                                    break;
                                case 2:
                                    if (sht.GetRow(rowIndex).GetCell(4).ToString().Contains(Request.QueryString["value"]))
                                    {
                                        isChange = true;
                                        table.Append("<td height='40px' ");
                                        switch (colIndex)
                                        {
                                            case 0:
                                                table.Append(" width='8%' style='text-align:center'");
                                                break;
                                            case 1:
                                                table.Append(" width='5%' style='text-align:center'");
                                                break;
                                            case 2:
                                                table.Append(" width='10%' style='text-align:center'");
                                                break;
                                            case 3:
                                                table.Append(" width='16%' style='text-align:center'");
                                                break;
                                            case 4:
                                                table.Append(" width='20%' style='text-align:center'");
                                                break;
                                            case 5:
                                                table.Append(" width='17%' style='text-align:center'");
                                                break;
                                            case 6:
                                                table.Append(" width='14%' style='text-align:center'");
                                                break;
                                            case 7:
                                                table.Append(" width='10%' style='text-align:center'");
                                                break;
                                        }
                                        if (colSpan > 1)
                                            table.Append(string.Format(" colSpan={0}", colSpan));
                                        if (rowSpanCount > 1 && Index > 0)
                                        {
                                            table.Append(string.Format(" rowSpan={0}", counts[Index]));
                                            rowSpanCount = 1;
                                            table.Append(">");
                                            colIndex = 0;
                                            table.Append(sht.GetRow(firstRow).GetCell(colIndex));
                                        }
                                        else
                                        {
                                            table.Append(">");
                                            if (colIndex == 2 && rowIndex >= 3)
                                                table.Append(DateTime.Parse(sht.GetRow(rowIndex).GetCell(colIndex).ToString()).ToString("yyyy-MM-dd"));
                                            else
                                                table.Append(sht.GetRow(rowIndex).GetCell(colIndex));
                                        }
                                        table.Append("</td>");
                                    }
                                    else
                                    {
                                        table = new StringBuilder(temp);
                                        isChange = false;
                                    }
                                    break;
                                case 3:
                                    if (sht.GetRow(rowIndex).GetCell(6).ToString().Contains(Request.QueryString["value"]))
                                    {
                                        isChange = true;
                                        table.Append("<td height='40px' ");
                                        switch (colIndex)
                                        {
                                            case 0:
                                                table.Append(" width='8%' style='text-align:center'");
                                                break;
                                            case 1:
                                                table.Append(" width='5%' style='text-align:center'");
                                                break;
                                            case 2:
                                                table.Append(" width='10%' style='text-align:center'");
                                                break;
                                            case 3:
                                                table.Append(" width='16%' style='text-align:center'");
                                                break;
                                            case 4:
                                                table.Append(" width='20%' style='text-align:center'");
                                                break;
                                            case 5:
                                                table.Append(" width='17%' style='text-align:center'");
                                                break;
                                            case 6:
                                                table.Append(" width='14%' style='text-align:center'");
                                                break;
                                            case 7:
                                                table.Append(" width='10%' style='text-align:center'");
                                                break;
                                        }
                                        if (colSpan > 1)
                                            table.Append(string.Format(" colSpan={0}", colSpan));
                                        if (rowSpanCount > 1 && Index > 0)
                                        {
                                            table.Append(string.Format(" rowSpan={0}", counts[Index]));
                                            rowSpanCount = 1;
                                            table.Append(">");
                                            colIndex = 0;
                                            table.Append(sht.GetRow(firstRow).GetCell(colIndex));
                                        }
                                        else
                                        {
                                            table.Append(">");
                                            if (colIndex == 2 && rowIndex >= 3)
                                                table.Append(DateTime.Parse(sht.GetRow(rowIndex).GetCell(colIndex).ToString()).ToString("yyyy-MM-dd"));
                                            else
                                                table.Append(sht.GetRow(rowIndex).GetCell(colIndex));
                                        }
                                        table.Append("</td>");
                                    }
                                    else
                                    {
                                        table = new StringBuilder(temp);
                                        isChange = false;
                                    }
                                    break;
                            }                                                   
                        }
                    }
                    if(isChange)
                        table.Append("</tr>");
                }
            }
            table.Append("</table>");
            this.excelContent = table.ToString();
        }

         /// <summary>
         ///  获取Table某个TD合并的列数和行数等信息。与Excel中对应Cell的合并行数和列数一致。
         /// </summary>
         /// <param name="rowIndex">行号</param>
         /// <param name="colIndex">列号</param>
         /// <param name="colspan">TD中需要合并的行数</param>
         /// <param name="rowspan">TD中需要合并的列数</param>
         /// <param name="isByRowMerged">此单元格是否被某个行合并包含在内。如果被包含在内，将不输出TD。</param>
         /// <returns></returns>
         private void GetTdMergedInfo(HSSFSheet xsheet, int rowIndex, int colIndex, out int colspan, out int rowspan, out bool isByRowMerged)
         {
             colspan = 1;
             rowspan = 1;
             isByRowMerged = false;
             int regionsCuont = xsheet.NumMergedRegions;//取得合并单元格的个数
             //Region region;
             for (int i = 0; i < regionsCuont; i++)
             {
                 //region = xsheet.GetMergedRegionAt(i); 此方法为1.2版本，高版本已去掉
                 CellRangeAddress range = xsheet.GetMergedRegion(i);//取得第i个合并单元格的跨越范围
                 xsheet.IsMergedRegion(range);
                 //region = xsheet.GetMergedRegion(i);
                 if (range.FirstRow == rowIndex && range.FirstColumn == colIndex) 
                 {
                     colspan = range.LastColumn - range.FirstColumn + 1;
                     rowspan = range.LastRow - range.FirstRow + 1;
                     return;
                 }
                 else if (rowIndex > range.FirstRow && rowIndex <= range.LastRow && colIndex >= range.FirstColumn && colIndex <= range.LastColumn)
                 {
                     isByRowMerged = true;
                 }
             }
         }

         protected void search_click(object sender, EventArgs e)
         {
             if (valueText.Value.Length > 0)
             {
                 Response.Redirect(string.Format(Request.FilePath + "?searchtype={0}&value={1}&token={2}", paramSel.Items[paramSel.SelectedIndex].Value, valueText.Value, CreateToken()));
             }
         }

         private string GetTokenFromRequest()
         {
             return Request.QueryString["token"];
         }

         private void PutTokenToClient(string token)
         {
             ssid.Value = token;
         }

         private void SaveTokenInServer(string token)
         {
             //一般保存在session中
             Session["CRSFToken"] = token;
         }

         private bool TokenIsOK(string token)
         {
             string tokenInServer = Session["CRSFToken"].ToString();
             return tokenInServer == token ? true : false;
         }

         public string _salt = "asdfkl@,.;#sss13131313";

         public string CreateToken()
         {
             return MD5(Session.SessionID + _salt);
         }

         private void ClearToken()
         {
             Session["CRSFToken"] = string.Empty;
         }

         private string MD5(string p)
         {
             p += "!@#<A8?";
             byte[] bytes = new UnicodeEncoding().GetBytes(p);
             byte[] buffer2 = new MD5CryptoServiceProvider().ComputeHash(bytes);
             StringBuilder builder = new StringBuilder();
             foreach (byte num in buffer2)
             {
                 builder.AppendFormat("{0:X2}", num);
             }
             return builder.ToString();
         }
    }
}
