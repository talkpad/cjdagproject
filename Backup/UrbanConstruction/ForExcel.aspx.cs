
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
using System.Data.OleDb;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using UrbanConstruction.Component;
using System.Text;
using System.Security.Cryptography;



namespace UrbanConstruction
{
    public partial class ForExcel : System.Web.UI.Page
    {
        private string filepath
        {
            get
            {
                string path =  ConfigurationManager.AppSettings["XLS"].ToString();
                return Server.MapPath("./") + path;
            }
            set
            {
                filepath = value;
            }
        }

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
                    if (SqlFilterHelper.Filter(Request.QueryString["searchtype"]) != "null")
                    {
                        if (int.TryParse(SqlFilterHelper.Filter(Request["searchtype"]), out kind) == false)
                        {
                            Response.Redirect("Error.htm");
                        }
                        else
                        {
                            searchtype = SqlFilterHelper.Filter(Request.QueryString["searchtype"]);
                            value = SqlFilterHelper.Filter(Request.QueryString["value"]);
                        }
                    }

                    BindGridView();
                }
                else
                    Response.Redirect("index.aspx");
            }
        }
        public string searchtype = "null";
        public string value = "null";
        public int pageIndex = 1;
        public int pageCount = 0;
        public int pageSize = 20;

        private void BindGridView()
        {
            try
            {
                if (SqlFilterHelper.Filter(Request.QueryString["pageIndex"]) != null)
                {
                    pageIndex = int.Parse(SqlFilterHelper.Filter(Request.QueryString["pageIndex"]));
                }
                //根据路径通过已存在的excel来创建HSSFWorkbook，即整个excel文档
                FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                HSSFWorkbook workbook = new HSSFWorkbook(fs);

                //获取excel的第一个sheet
                ISheet sheet = workbook.GetSheetAt(0);

                DataTable table = new DataTable();
                DataTable tableswap = new DataTable();
                //获取sheet的首行
                IRow headerRow = sheet.GetRow(1);

                //一行最后一个方格的编号 即总的列数
                int cellCount = headerRow.LastCellNum;

                for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                {
                    DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                    DataColumn columnswap = new DataColumn(headerRow.GetCell(i).StringCellValue);
                    table.Columns.Add(column);
                    tableswap.Columns.Add(columnswap);
                }
                if (SqlFilterHelper.Filter(Request.QueryString["searchtype"]) == "null" || int.Parse(SqlFilterHelper.Filter(Request.QueryString["searchtype"])) == 0 || SqlFilterHelper.Filter(Request.QueryString["value"]) == "null")
                {
                    //最后一列的标号  即总的行数
                    int rowCount = sheet.LastRowNum;
                    int countneed = pageSize * pageIndex + 2;
                    if (countneed > rowCount)
                        countneed = rowCount;

                    for (int i = (sheet.FirstRowNum + 2 + pageSize * (pageIndex - 1)); i < countneed; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        DataRow dataRow = table.NewRow();

                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (j == 1 && row.GetCell(j) != null)
                                dataRow[j] = DateTime.Parse(row.GetCell(j).ToString()).ToString("yyyy-MM-dd");
                            else
                            {
                                if (row.GetCell(j) != null)
                                    dataRow[j] = row.GetCell(j).ToString();
                            }
                        }

                        table.Rows.Add(dataRow);
                    }
                    pageCount = (int)Math.Ceiling((double)rowCount / pageSize);
                }
                else if (Request.QueryString["searchtype"] != "null" && Request.QueryString["value"] != "null")
                {                  
                    int rowCount = sheet.LastRowNum;
                    for (int i = sheet.FirstRowNum + 2; i < rowCount; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        DataRow dataRow = tableswap.NewRow();

                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (j == 1 && row.GetCell(j) != null)
                                dataRow[j] = DateTime.Parse(row.GetCell(j).ToString()).ToString("yyyy-MM-dd");
                            else
                            {
                                if (row.GetCell(j) != null)
                                    dataRow[j] = row.GetCell(j).ToString();
                            }
                        }
                        switch (int.Parse(SqlFilterHelper.Filter(Request.QueryString["searchtype"])))
                        {
                            case 1:
                                if (dataRow[2].ToString().Contains(SqlFilterHelper.Filter(Request.QueryString["value"])))
                                { tableswap.Rows.Add(dataRow); }
                                break;
                            case 2:
                                if (dataRow[3].ToString().Contains(SqlFilterHelper.Filter(Request.QueryString["value"])))
                                { tableswap.Rows.Add(dataRow); }
                                break;
                            case 3:
                                if (dataRow[4].ToString().Contains(SqlFilterHelper.Filter(Request.QueryString["value"])))
                                { tableswap.Rows.Add(dataRow); }
                                break;
                        }                        
                    }
                    int countneed = pageSize * pageIndex;
                    if (countneed > tableswap.Rows.Count)
                        countneed = tableswap.Rows.Count;
                    for (int k = (pageIndex - 1) * pageSize; k < countneed; k++)
                    {
                        DataRow row = tableswap.NewRow();
                        row = tableswap.Rows[k];
                        table.Rows.Add(row.ItemArray); 
                    }
                    pageCount = (int)Math.Ceiling((double)tableswap.Rows.Count / pageSize); 
                }
                workbook = null;
                sheet = null;
                if (pageCount == 0)
                    pageIndex = 0;

                //dt.DefaultView.Sort = "ID ,Name ASC";
                //dt = dt.DefaultView.ToTable();

                this.GridView1.DataSource = table;
                this.GridView1.DataBind();
            }
            catch
            { throw; }
        }

        protected void search_click(object sender, EventArgs e)
        {
            if (SqlFilterHelper.Filter(valueText.Value).Length > 0)
            {
                Response.Redirect(string.Format(Request.FilePath + "?searchtype={0}&value={1}&token={2}", paramSel.Items[paramSel.SelectedIndex].Value, SqlFilterHelper.Filter(valueText.Value), CreateToken()));
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
