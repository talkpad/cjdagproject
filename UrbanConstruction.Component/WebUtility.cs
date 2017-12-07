using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UrbanConstruction.Component
{
    //public interface IBindData
    //{
    //    void BindData();
    //}


    public static class WebUtility
    {
    //    #region 常量

    //    /// <summary>
    //    /// 表示选择无，对应没有数据存到db的情况
    //    /// </summary>
    //    public const string DATA_NULL = "_NULL";//长度不要超过5

    //    /// <summary>
    //    /// 表示查询的时候没有限制此查询条件
    //    /// </summary>
    //    public const string DATA_NO_LIMITED = "_ALL";//长度不要超过5

    //    /// <summary>
    //    /// 表示修改动作
    //    /// </summary>
    //    public const string COMMAND_UPDATE = "U";
    //    /// <summary>
    //    /// 表示新增动作
    //    /// </summary>
    //    public const string COMMAND_ADD = "A";
    //    /// <summary>
    //    /// 表示删除动作
    //    /// </summary>
    //    public const string COMMAND_DELETE = "D";

    //    /// <summary>
    //    /// 因为c#中和sql中预设datetime初始值不同,
    //    /// 故用此字符串对每一个datetime型赋初值
    //    /// 如果datetime值等于此值,表示用户没有更改过这个值
    //    /// 应显示为空
    //    /// </summary>
    //    public static DateTime INIT_DATETIME
    //    {
    //        get { return DateTime.Parse("1/1/1753"); }
    //    }

    //    public const string CstMaxRecordReturn = "1000"; //默认返回的记录数
    //    #endregion

    //    #region 随机数
    //    /// <summary>
    //    /// 产生一个随机文件名称
    //    /// </summary>
    //    /// <returns></returns>
    //    public static string GenerRndFileName()
    //    {
    //        Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
    //        string result = DateTime.Now.ToString("yyyyMMddhhmmss") + rnd.Next(0, 9999).ToString();//(时间+随机数)
    //        return result;
    //    }
    //    #endregion

    //    #region 从URL中取得参数值
    //    /// <summary>
    //    ///  从 QueryString 集合中安全的取得一个 string类型. (总是不会有 null，所以叫做 'Safe')
    //    /// </summary>
    //    /// <param name="page">页面Page对象,可以利用this</param>
    //    /// <param name="key">URL参数名字</param>
    //    /// <returns></returns>
    //    public static string GetQueryStr(Page page, string key)
    //    {
    //        string value = page.Request.QueryString[key];
    //        return (value == null) ? string.Empty : value;
    //    }


    //    /// <summary>
    //    /// 从 QueryString 集合中安全的取得一个 int类型的值.
    //    /// </summary>
    //    /// <param name="page">页面Page对象,可以利用this</param>
    //    /// <param name="key">URL参数名字</param>
    //    /// <param name="defaultValue">默认值</param>
    //    /// <returns></returns>
    //    public static int GetQueryInt(Page page, string key, int defaultValue)
    //    {
    //        string value = GetQueryStr(page, key);
    //        int i = defaultValue;
    //        try
    //        {
    //            i = int.Parse(value);
    //        }
    //        catch { }
    //        return i;
    //    }
    //    /// <summary>
    //    /// 取得文件后缀
    //    /// </summary>
    //    /// <param name="filename">文件名称</param>
    //    /// <returns></returns>
    //    public static string GetFileExtends(string filename)
    //    {
    //        string ext = null;
    //        if (filename.IndexOf('.') > 0)
    //        {
    //            string[] fs = filename.Split('.');
    //            ext = fs[fs.Length - 1];
    //        }
    //        return ext;
    //    }
    //    /// <summary>
    //    /// 获取IP
    //    /// </summary>
    //    /// <returns></returns>

    //    /// <summary>
    //    /// 从 QueryString 集合中安全的取得一个 long类型的值.
    //    /// </summary>
    //    /// <param name="page">页面Page对象,可以利用this</param>
    //    /// <param name="key">URL参数名字</param>
    //    /// <param name="defaultValue">默认值</param>
    //    /// <returns></returns>
    //    public static long GetQueryLong(Page page, string key, long defaultValue)
    //    {
    //        string value = GetQueryStr(page, key);
    //        long i = defaultValue;
    //        try
    //        {
    //            i = long.Parse(value);
    //        }
    //        catch { }
    //        return i;
    //    }

    //    /// <summary>
    //    /// 从 QueryString 集合中安全的取得一个 double类型的值.
    //    /// </summary>
    //    /// <param name="page">页面Page对象,可以利用this</param>
    //    /// <param name="key">URL参数名字</param>
    //    /// <param name="defaultValue">默认值</param>
    //    /// <returns></returns>
    //    public static double GetQueryDouble(Page page, string key, double defaultValue)
    //    {
    //        string value = GetQueryStr(page, key);
    //        double d = defaultValue;
    //        try
    //        {
    //            d = double.Parse(value);
    //        }
    //        catch { }
    //        return d;
    //    }

    //    /// <summary>
    //    /// 从 QueryString 集合中安全的取得一个 double类型的值.
    //    /// </summary>
    //    /// <param name="page">页面Page对象,可以利用this</param>
    //    /// <param name="key">URL参数名字</param>
    //    /// <param name="defaultValue">默认值</param>
    //    /// <returns></returns>
    //    public static decimal GetQueryDecimal(Page page, string key, decimal defaultValue)
    //    {
    //        string value = GetQueryStr(page, key);
    //        decimal d = defaultValue;
    //        try
    //        {
    //            d = decimal.Parse(value);
    //        }
    //        catch { }
    //        return d;
    //    }
    //    #endregion

    //    #region 过滤
    //    /// <summary>过滤用户输入中会带来不测的字符
    //    /// </summary>
    //    /// <param name="text">用户输入的文本</param>
    //    /// <param name="maxLength">截取的长度</param>
    //    /// <returns>过滤不测字符后的文本</returns>
    //    public static string InputText(string text, int maxLength)
    //    {
    //        if (text == null)
    //            return string.Empty;
    //        text = text.Trim();
    //        if (string.IsNullOrEmpty(text))
    //            return string.Empty;
    //        if (text.Length > maxLength)
    //            text = text.Substring(0, maxLength);
    //        text = Regex.Replace(text, "[\\s]{2,}", " ");	//two or more spaces
    //        text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	//<br>
    //        text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//&nbsp;
    //        text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);	//any other tags
    //        text = text.Replace("'", "''");
    //        return text;
    //    }

    //    /// <summary>过滤用户输入中会带来不测的字符
    //    /// 去掉最大程度限制(定为4000)
    //    /// </summary>
    //    /// <param name="text">用户输入的文本</param>
    //    /// <returns>过滤不测字符后的文本</returns>
    //    public static string InputText(string text)
    //    {
    //        return InputText(text, 4000);
    //    }
    //    #endregion


        #region 过滤sql敏感字符，防止sql注入

        /// <summary>
        /// 过滤sql敏感字符，防止sql注入
        /// </summary>
        /// <param name="text">查询条件</param>
        /// <returns></returns>
        public static string InputTextForSql(string text)
        {

            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            text = Regex.Replace(text, @"[\s]{2,}", " ");    //two or more spaces
            text = Regex.Replace(text, @"(<[b|B][r|R]/*>)+|(<[p|P](.|\n)*?>)", "n");    //<br>
            text = Regex.Replace(text, @"(\s*&[n|N][b|B][s|S][p|P];\s*)+", " ");    //&nbsp;
            text = Regex.Replace(text, @"<(.|\n)*?>", string.Empty);    //any other tags
            text = text.Replace("'", "''");
            text = text.Replace("xp_cmdshell", "");
            text = text.Replace("exec master.dbo.xp_cmdshell", "");
            text = text.Replace("net localgroup administrators", "");
            text = text.Replace("delete from", "");
            text = text.Replace("net user", "");
            text = text.Replace("/add", "");
            text = text.Replace("drop table", "");
            text = text.Replace("update", "");

            text = text.Replace("select", "");
            text = text.Replace(";and", "");
            text = text.Replace(";exec", "");
            text = text.Replace(";create", "");
            text = text.Replace(";insert", "");
            text = text.Replace("and", "");
            text = text.Replace("exec", "");
            text = text.Replace("create", "");
            text = text.Replace("insert", "");
            text = text.Replace("master.dbo", "");
            text = text.Replace(";--", "");
            text = text.Replace("--", "");
            text = text.Replace("1=", "");
            return text;
        }
        #endregion

    //    #region html
    //    /// <summary>
    //    /// 将文本编辑器中的文本转化为对应的Html标记,如"\n"->"br"
    //    /// </summary>
    //    /// <param name="value">要转换的文本</param>
    //    /// <returns>已转换了的文本</returns>
    //    public static string EditorToHtml(string value)
    //    {
    //        value = value.Replace("\n", "<br>").Replace(" ", "&nbsp;&nbsp;");
    //        return value;
    //    }

    //    /// <summary>
    //    /// 将Html标记转换为编辑器中的文本，如"br"->"\n"
    //    /// </summary>
    //    /// <param name="value"></param>
    //    /// <returns></returns>
    //    public static string HtmlToEditor(string value)
    //    {
    //        value = value.Replace("<br>", "\n").Replace("&nbsp;&nbsp;", " ");
    //        return value;
    //    }
    //    #endregion

    //    #region 字符串处理
    //    /// <summary>
    //    /// 字符截取：
    //    /// SubstringEx("干得好不如嫁得好",3)->"干得好..."
    //    /// </summary>
    //    /// <param name="value">处理的字符串</param>
    //    /// <param name="length">保留的长度</param>
    //    /// <returns></returns>
    //    public static string SubstringEx(string value, int length)
    //    {
    //        if (value.Length > length)
    //        {
    //            value = value.Substring(0, length) + "<span style='font-size:20px'>...</span>";
    //        }
    //        return value;
    //    }

    //    /// <summary>
    //    /// 去除头尾的分隔符：
    //    /// "1,2,"或",1,2"或",1,2,"->"1,2"
    //    /// </summary>
    //    /// <param name="value">处理的字符串</param>
    //    /// <param name="separator">分隔符</param>
    //    /// <returns>去除后的字符串</returns>
    //    public static string DelHeadTrailSeparator(string value, string separator)
    //    {
    //        if (!string.IsNullOrEmpty(value))
    //        {
    //            if (value.StartsWith(separator) == true)
    //            {
    //                value = value.Substring(1);
    //            }
    //            if (value.EndsWith(separator) == true)
    //            {
    //                value = value.Substring(0, value.Length - 1);
    //            }
    //        }
    //        return value;
    //    }
    //    /// <summary>
    //    /// 处理成SQL语句需要的格式
    //    /// "1,2"->"'1','2'"
    //    /// </summary>
    //    /// <param name="value">处理字符串</param>
    //    /// <param name="separator">分隔符</param>
    //    /// <returns>去除后的字符串</returns>
    //    public static string GetSqlCharBySeparator(string value, string separator)
    //    {
    //        string strResult = string.Empty;
    //        strResult += "'";
    //        if (!string.IsNullOrEmpty(value))
    //        {
    //            strResult += value.Replace(separator, "'" + separator + "'");
    //        }
    //        strResult += "'";
    //        return strResult;
    //    }
    //    /// <summary>
    //    /// 将List《int》处理成用分隔符间隔的字符串
    //    /// {1,2,3}->"1,2,3"
    //    /// </summary>
    //    /// <param name="list">待处理的List int 类型数组</param>
    //    /// <param name="separator">分隔字符</param>
    //    /// <returns>处理后的返回字符串</returns>
    //    public static string ConvertListBySeparator(IList<int> list, string separator)
    //    {
    //        string strResult = string.Empty;
    //        foreach (int id in list)
    //        {
    //            strResult += "," + id;
    //        }
    //        if (strResult.Length > 0)
    //        {
    //            strResult = strResult.Substring(1);
    //        }
    //        return strResult;
    //    }
    //    /// <summary>
    //    /// 将List《string》处理成用分隔符间隔的字符串
    //    /// {1,2,3}->"1,2,3"
    //    /// </summary>
    //    /// <param name="list">待处理的List string 类型数组</param>
    //    /// <param name="separator">分隔字符</param>
    //    /// <returns>处理后返回的字符串</returns>
    //    public static string ConvertListBySeparator(IList<string> list, string separator)
    //    {
    //        string strResult = string.Empty;
    //        foreach (string id in list)
    //        {
    //            strResult += "," + id;
    //        }
    //        if (strResult.Length > 0)
    //        {
    //            strResult = strResult.Substring(1);
    //        }
    //        return strResult;
    //    }
    //    #endregion

    //    #region 信息提示
    //    /// <summary>显示消息提示对话框
    //    /// </summary>
    //    /// <param name="page">当前页面指针，一般为this</param>
    //    /// <param name="msg">提示信息</param>
        public static void ShowMsg(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert(\"" + msg.Replace("\"", "“").Replace(System.Environment.NewLine, " ") + "\");</script>");
        }

        /// <summary>
        /// 调用前台JS的fuanction()
        /// </summary>
        /// <param name="page">this</param>
        /// <param name="msg">function()</param>
        public static void ShowFunction(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "function", msg, true);
        }

    //    /// <summary>显示消息提示对话框
    //    /// </summary>
    //    /// <param name="page">当前页面指针，一般为this</param>
    //    /// <param name="msg">提示信息</param>
    //    public static void ShowMsg(System.Web.UI.Page page, string msg, string pagePath)
    //    {
    //        string strScript = string.Empty;
    //        strScript += "<script language='javascript' defer>";
    //        strScript += "alert(\"" + msg.Replace("\"", "“").Replace(System.Environment.NewLine, " ") + "\");";
    //        strScript += "setTimeout( function() {window.location.href='" + pagePath + "';}, 500); </script>";
    //        strScript += "</script>";
    //        page.ClientScript.RegisterStartupScript(page.GetType(), "message", strScript);
    //    }
    //    /// <summary>显示消息提示对话框
    //    /// </summary>
    //    /// <param name="page">当前页面指针，一般为this</param>
    //    /// <param name="msg">提示信息</param>
    //    public static void ShowParentMsg(System.Web.UI.Page page, string msg, string pagePath)
    //    {
    //        string strScript = string.Empty;
    //        strScript += "<script language='javascript' defer>";
    //        strScript += "alert(\"" + msg.Replace("\"", "“").Replace(System.Environment.NewLine, " ") + "\");";
    //        strScript += "setTimeout( function() {window.parent.location.href='" + pagePath + "';}, 500); </script>";
    //        strScript += "</script>";
    //        page.ClientScript.RegisterStartupScript(page.GetType(), "message", strScript);
    //    }

        /// <summary>显示消息提示对话框，延时
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void ShowMsgDelay(System.Web.UI.Page page, string msg)
        {
            string strScript = string.Empty;
            string alertMsg = "alert(\"" + msg.Replace("\"", "“").Replace(System.Environment.NewLine, " ") + "\");";
            strScript += "<script language='javascript' defer>";
            strScript += "setTimeout( function() {" + alertMsg + "}, 50); </script>";
            strScript += "</script>";
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", strScript);
        }
       //#endregion

    //    #region 运行javascript
    //    public static string Alert(string message)
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        sb.Append("<script type=\"text/javascript\">");
    //        sb.Append("\n alert('" + message + "');");
    //        sb.Append("\n </script>");
    //        return sb.ToString();
    //    }


    //    public static void JQuerySetFocus(Page page, string _id, string _alert_msg)
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        sb.Append("<script type=\"text/javascript\">\n");
    //        sb.Append(" if(typeof($) !='undefined') {\n");
    //        sb.Append("      $(document).ready(function(){ \n");
    //        sb.Append("             alert('" + _alert_msg + "');\n");
    //        sb.Append("             $('#" + _id + "').focus();\n");
    //        sb.Append("      });\n");
    //        sb.Append(" }\n");
    //        sb.Append("</script>\n");
    //        page.Header.Controls.Add(new LiteralControl(sb.ToString()));
    //    }

    //    public static void JQueryScrollInView(Page page, string _scroll_id, string _focus_id, string _msg)
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        sb.Append("<script type=\"text/javascript\">");
    //        sb.Append(" if(typeof($) !='undefined') { \n");
    //        sb.Append("      $(document).ready(function(){ \n");
    //        sb.Append("             alert('" + _msg + "');\n");
    //        sb.Append("             document.getElementById('" + _scroll_id + "').scrollIntoView();\n");
    //        sb.Append("             document.getElementById('" + _focus_id + "').focus();\n");
    //        sb.Append("      });\n");
    //        sb.Append(" }\n");
    //        sb.Append("</script>\n");
    //        page.Header.Controls.Add(new LiteralControl(sb.ToString()));
    //    }

    //    public static void JQueryScrollInView(Page page, string _scroll_id, string _focus_id)
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        sb.Append("<script type=\"text/javascript\">");
    //        sb.Append("\n if(typeof($) !='undefined') {");
    //        sb.Append("\n      $(document).ready(function(){ ");
    //        sb.Append("\n             document.getElementById('" + _scroll_id + "').scrollIntoView();");
    //        sb.Append("\n             document.getElementById('" + _focus_id + "').focus();");
    //        sb.Append("\n      });");
    //        sb.Append("\n }");
    //        sb.Append("\n </script>");
    //        page.Header.Controls.Add(new LiteralControl(sb.ToString()));
    //    }

    //    public static void JQueryScript(Page page, string script)
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        sb.Append("<script type=\"text/javascript\">\n");
    //        sb.Append(" if(typeof($) !='undefined') {\n");
    //        sb.Append("      $(document).ready(function(){ \n");
    //        sb.Append(script);
    //        sb.Append("\n   });");
    //        sb.Append("\n }");
    //        sb.Append("\n </script>");

    //        //
    //        //page.ClientScript.RegisterStartupScript(page.GetType(), "message2", sb.ToString());
    //        page.Header.Controls.Add(new LiteralControl(sb.ToString()));
    //    }
    //    #endregion

    //    #region 时间中文转换

    //    /// <summary>
    //    /// 将时间转换为中文
    //    /// </summary>
    //    /// <param name="span">时间间隔</param>
    //    /// <returns>转换后的中文字符串</returns>
    //    public static string GetTimeSpan(TimeSpan span)
    //    {
    //        if (span.Days > 0)
    //        {
    //            string day = span.ToString().Substring(0, 1);
    //            string time = span.ToString().Substring(2, 8);
    //            return day + "天" + DateTime.Parse(time).ToString("H时m分s秒");
    //        }
    //        else if (span.Minutes > 0)
    //        {
    //            return DateTime.Parse(span.ToString()).ToString("m分s秒");
    //        }
    //        else
    //        {
    //            string seconds = span.ToString().Substring(6, 2);
    //            if (seconds.StartsWith("0"))
    //                return seconds.Substring(1, 1) + "秒";
    //            else
    //                return seconds + "秒";
    //        }
    //    }
    //    #endregion

    //    #region 导入Excel 通用方法
    //    /// <summary>
    //    /// 获取制定路径文件名Excel内容
    //    /// </summary>
    //    /// <param name="excelName">Excel路径文件名</param>
    //    /// <returns></returns>
    //    public static DataSet GetExcelData_OLEDB(string excelName)
    //    {

    //        DataSet myDs = new DataSet();
    //        string firstSheetName = string.Empty;//表的第一个sheet
    //        string sConn = "provider=Microsoft.ACE.OleDb.12.0; Data Source ='" + excelName + "';Extended Properties='Excel 12.0;HDR=yes;IMEX=1';";//2007
    //        string myConnString = "Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = '" + excelName + "';Extended Properties=Excel 8.0";//2003
    //        System.Data.OleDb.OleDbConnection cnnxls = new System.Data.OleDb.OleDbConnection(sConn);

    //        try
    //        {
    //            cnnxls.Open();
    //            DataTable dt = cnnxls.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
    //            firstSheetName = dt.Rows[0][2].ToString().Trim();//找到表的第一个sheet
    //            System.Data.OleDb.OleDbDataAdapter myDa = new System.Data.OleDb.OleDbDataAdapter("select * from [" + firstSheetName + "]", cnnxls);
    //            myDa.Fill(myDs);
    //        }
    //        catch (Exception err)
    //        {
    //            throw err;
    //            //err.ToString();
    //            //return null;
    //        }
    //        finally
    //        {
    //            cnnxls.Close();
    //        }
    //        return myDs;
    //    }


    //    #endregion

    //    #region Ilist与DataSet之间的转换
    //    /// <summary>Ilist 转换成 DataSet</summary>
    //    /// <param name="list"></param>
    //    /// <param name="type">要转化的list中元素类型</param>
    //    /// <returns></returns>
    //    public static DataSet ConvertToDataSet(IList list, Type type)
    //    {
    //        if (list == null || list.Count <= 0)
    //        {
    //            return null;
    //        }
    //        DataSet ds = new DataSet();
    //        DataTable dt = new DataTable();
    //        DataRow row;
    //        System.Reflection.PropertyInfo[] myPropertyInfo = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

    //        //create colum
    //        foreach (System.Reflection.PropertyInfo pi in myPropertyInfo)
    //        {
    //            dt.Columns.Add(pi.Name, System.Type.GetType(pi.PropertyType.ToString()));
    //        }

    //        foreach (object t in list)
    //        {
    //            if (t == null)
    //            {
    //                continue;
    //            }
    //            row = dt.NewRow();
    //            for (int i = 0; i < myPropertyInfo.Length; i++)
    //            {
    //                System.Reflection.PropertyInfo pi = myPropertyInfo[i];
    //                string name = pi.Name;
    //                row[name] = pi.GetValue(t, null);
    //            }
    //            dt.Rows.Add(row);
    //        }
    //        ds.Tables.Add(dt);
    //        return ds;
    //    }

    //    /// <summary>把DataSet转化为IList</summary>
    //    /// <param name="ds"></param>
    //    /// <param name="type">要转化为的list中的元素类型</param>
    //    /// <returns></returns>
    //    public static IList ConvertToIList(DataSet ds, Type type)
    //    {
    //        if (ds == null || ds.Tables.Count <= 0)
    //            return null;
    //        IList list = new ArrayList();

    //        System.Reflection.PropertyInfo[] myPropertyInfo = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

    //        foreach (DataRow dr in ds.Tables[0].Rows)
    //        {
    //            object l = type.Assembly.CreateInstance(type.FullName);
    //            for (int i = 0, j = myPropertyInfo.Length; i < j; i++)
    //            {
    //                System.Reflection.PropertyInfo pi = myPropertyInfo[i];
    //                object value = dr[pi.Name];
    //                if (value is System.DBNull == false)
    //                {
    //                    pi.SetValue(l, value, null);
    //                }
    //            }
    //            list.Add(l);
    //        }
    //        return list;
    //    }
    //    #endregion

    //    #region DropDownList绑定
    //    /// <summary>对下拉列表框填充数据，便于统一修改样式    
    //    /// </summary>
    //    /// <param name="sel">列表框对象</param>
    //    /// <param name="list">数据源IList</param>
    //    /// <param name="type">EnumSelType枚举类型</param>
    //    /// <param name="dataTextField">绑定到text属性的字段名</param>
    //    /// <param name="dataValueField">绑定到Value属性的字段名</param>
    //    /// <param name="joinChar">下拉列表value和text之间的连接符号，null表示只显示text值</param>
    //    public static void setSel(DropDownList sel, IList list, EnumSelType type, string dataTextField, string dataValueField, string joinChar)
    //    {
    //        sel.DataSource = list;
    //        sel.DataTextField = dataTextField;
    //        sel.DataValueField = dataValueField;
    //        sel.DataBind();


    //        switch (type)
    //        {
    //            case EnumSelType.OnlyData:
    //                break;

    //            case EnumSelType.WithNullOption:
    //                sel.Items.Insert(0, new ListItem("无", DATA_NULL));
    //                break;

    //            case EnumSelType.WithNoLimitedOption:
    //                sel.Items.Insert(0, new ListItem("不限", DATA_NO_LIMITED));
    //                break;

    //            case EnumSelType.WithNullAndNoLimitedOption:
    //                sel.Items.Insert(0, new ListItem("无", DATA_NULL));
    //                sel.Items.Insert(0, new ListItem("不限", DATA_NO_LIMITED));
    //                break;

    //            case EnumSelType.WithPleaseOption:
    //                sel.Items.Insert(0, new ListItem("请选择", DATA_NULL));
    //                break;

    //            default:
    //                break;
    //        }

    //        if (joinChar != null)
    //        {
    //            foreach (ListItem li in sel.Items)
    //            {
    //                li.Text = li.Value + "-" + li.Text;
    //            }
    //        }
    //    }
    //    #endregion

    //    #region 分析异常
    //    /// <summary>
    //    /// 获取异常原因
    //    /// </summary>
    //    /// <param name="ex"></param>
    //    /// <returns></returns>
    //    public static ExceptionType AnalyzeException(Exception ex)
    //    {
    //        System.Data.SqlClient.SqlException sqlException = null;
    //        if (ex is System.Data.SqlClient.SqlException)
    //        {
    //            sqlException = (System.Data.SqlClient.SqlException)ex;
    //        }
    //        if (ex.InnerException is System.Data.SqlClient.SqlException)
    //        {
    //            sqlException = (System.Data.SqlClient.SqlException)ex.InnerException;
    //        }
    //        if (sqlException == null)
    //            return ExceptionType.UNKNOW;

    //        switch (int.Parse(sqlException.State.ToString()))
    //        {
    //            case 1:
    //                return ExceptionType.REPEAT_PK;
    //            case 2:
    //                return ExceptionType.REPEAT_UNIQUE;
    //            case 3:
    //                return ExceptionType.REPEAT_UNIQUE_INDEX;
    //            default:
    //                return ExceptionType.UNKNOW;
    //        }
    //    }
    //    #endregion

    //    #region Guid产生
    //    /// <summary>
    //    /// 返回一个唯一的GUID
    //    /// </summary>
    //    /// <returns>返回一个唯一的GUID</returns>
    //    public static string GenerateId()//http://www.cnblogs.com/yqm/archive/2007/05/26/760856.html
    //    {
    //        long i = 1;
    //        foreach (byte b in Guid.NewGuid().ToByteArray())
    //        {
    //            i *= ((int)b + 1);
    //        }
    //        return string.Format("{0:x}", i - DateTime.Now.Ticks);
    //    }
    //    #endregion

    //    #region 常用判断
    //    /// <summary>
    //    /// 判断ds里面是否有数据
    //    /// </summary>
    //    /// <param name="ds"></param>
    //    /// <returns></returns>
    //    public static bool HasDataRow(DataSet ds)
    //    {
    //        bool result = true;
    //        if (ds != null && ds.Tables.Count > 0)
    //        {
    //            if (ds.Tables[0].Rows.Count == 0)
    //            {
    //                result = false;
    //            }
    //            else
    //            {
    //                result = true;
    //            }
    //        }
    //        else
    //        {
    //            result = false;
    //        }
    //        return result;
    //    }
    //    #endregion

    //    #region enum：下拉列表框样式、异常种类
    //    /// <summary>下拉列表框样式</summary>
    //    public enum EnumSelType
    //    {
    //        /// <summary>
    //        /// 只有数据，不加任何其他选项
    //        /// </summary>
    //        OnlyData = 1,// only data
    //        /// <summary>
    //        /// 无
    //        /// </summary>
    //        WithNullOption = 2,// have a empty
    //        /// <summary>
    //        /// 不限
    //        /// </summary>
    //        WithNoLimitedOption = 3,
    //        /// <summary>
    //        /// 不限 + 无
    //        /// </summary>
    //        WithNullAndNoLimitedOption = 4,

    //        /// <summary>
    //        /// 请选择
    //        /// </summary>
    //        WithPleaseOption = 5
    //    }

    //    /// <summary>
    //    /// 异常种类
    //    /// </summary>
    //    public enum ExceptionType
    //    {
    //        /// <summary>
    //        /// 未知异常
    //        /// </summary>
    //        UNKNOW = 0,

    //        /// <summary>
    //        /// 主键重复//state=1,number 2627,ErrorCode=-2146232060
    //        /// </summary>
    //        REPEAT_PK = 1,

    //        /// <summary>
    //        /// 或唯一列约束2
    //        /// </summary>
    //        REPEAT_UNIQUE = 2,//state=2 ,number 2627

    //        /// <summary>
    //        /// 唯一性索引重复3 , 
    //        /// </summary>
    //        REPEAT_UNIQUE_INDEX = 3  //state = 3,number=2601   
    //    }
    //    #endregion

    //    #region 表单页面
    //    /// <summary>
    //    /// 返回无查询记录时的表头信息
    //    /// </summary>
    //    /// <param name="aGridView"></param>
    //    public static string GetEmptyDataText(GridView aGridView)
    //    {
    //        string temp = "margin-top:-5px;color: #006699;font-size:9pt;font-weight:bold;width:100%;";
    //        string emptytext = "<table align='top' border='0' cellpadding='0' cellspacing='0'  style ='" + temp + "'>"; //class='GridView' 
    //        emptytext += "<tr class='button05' style='width:100%;' >"; //
    //        for (int i = 0; i < aGridView.Columns.Count; i++)
    //        {
    //            emptytext += "<td align='top'>" + aGridView.Columns[i].HeaderText + "</td>" + "\r\n";
    //        }
    //        emptytext += "</tr>";
    //        emptytext += "</table>";
    //        emptytext += "<br/><font  class='button07'>无查询记录</font>";
    //        return emptytext;
    //    }

    //    //新增;style=1为总数;style=2时为前多少条记录
    //    public static string ColorFont(int style, int count)
    //    {
    //        if (style == 1)
    //        {
    //            return "共<font color=red>" + count + "</font>条记录";
    //        }
    //        else
    //        {
    //            return "前<font color=red>" + count + "</font>条记录";
    //        }

    //    }
    //    #endregion

    //    #region 数据校验
    //    /// <summary>
    //    /// 防止Sql注入
    //    /// </summary>
    //    public static string CheckStr(string aStr)
    //    {
    //        string strtemp = "";
    //        if (aStr != null)
    //        {
    //            strtemp = aStr.Replace("/*", "");
    //            strtemp = strtemp.Replace("--", "");
    //            strtemp = strtemp.Replace("'", "");
    //        }
    //        return strtemp;
    //    }

    //    //用来判断是否合法手机号码数字
    //    public static bool IsSimpleNumber(string str)
    //    {
    //        if (str == null || str.Length == 0) return false;
    //        foreach (char c in str)
    //        {
    //            if (!Char.IsNumber(c))
    //            {
    //                return false;
    //            }
    //        }
    //        return true;
    //    }
    //    //用来判断最末的6位是否数字0-9
    //    public static bool IsSimpleNumberEnd(string str)
    //    {
    //        if (str == null || str.Length == 0) return false;

    //        int i = str.Length;
    //        if (i < 6) return false;

    //        for (int k = 1; k < 6; k++)
    //        {
    //            if (!Char.IsNumber(str[i - k]))
    //            {
    //                return false;
    //            }
    //        }
    //        return true;
    //    }
    //    #endregion

    //    #region 时间处理
    //    public static int GetRemainTime(DateTime theDate)
    //    {
    //        int remainDay = 0;
    //        if (theDate != null)
    //        {
    //            TimeSpan ts = theDate - DateTime.Now;
    //            remainDay = ts.Days;
    //        }
    //        return remainDay;
    //    }
    //    #endregion

    //    #region
    //    public static string GetYearMonth()
    //    {
    //        return DateTime.Now.ToString("yyyyMM");
    //    }

    //    public static string GetYearMonthHourTime()
    //    {
    //        return DateTime.Now.ToString("yyyyMMddhhmm");
    //    }
    //    /// <summary>
    //    /// 获取本年月的后三位数
    //    /// </summary>
    //    /// <param name="yearAndMonth"></param>
    //    /// <returns></returns>
    //    public static string GeOrderNo(string prefix, string code)
    //    {
    //        string orderNo = string.Empty;
    //        string datetime = string.Empty;
    //        datetime = GetYearMonthHourTime();
    //        if (!string.IsNullOrEmpty(datetime) && !string.IsNullOrEmpty(prefix))
    //        {
    //            orderNo = prefix + datetime + code;
    //        }
    //        return orderNo;

    //    }

    //    #endregion


    //    /// <summary>
    //    /// 得到文件的名称
    //    /// </summary>
    //    public static string GetFileName(string url)
    //    {
    //        string fileName = string.Empty;
    //        if (url.LastIndexOf("/") > 0)
    //        {
    //            fileName = url.Substring(url.LastIndexOf("/") + 1);
    //        }
    //        else
    //        {
    //            fileName = url.Substring(url.LastIndexOf(@"\") + 1);
    //        }
    //        return fileName;
    //    }

    //    #region 图片缩放
    //    /// <summary>
    //    /// 把图片缩小后输出
    //    /// </summary>
    //    /// <param name="sourceFile">图片路径，全路径</param>
    //    /// <param name="response">页面响应</param>
    //    /// <param name="destHeight">缩小后的高</param>
    //    /// <param name="destWidth">缩小后的宽</param>
    //    /// <returns></returns>
    //    public static bool GetThumbnail(string sourceFile, HttpResponse response, int destHeight, int destWidth)
    //    {
    //        System.Drawing.Image imgSource = System.Drawing.Image.FromFile(sourceFile);
    //        System.Drawing.Imaging.ImageFormat thisFormat = imgSource.RawFormat;
    //        int sW = 0, sH = 0;
    //        // 按比例缩放
    //        int sWidth = imgSource.Width;
    //        int sHeight = imgSource.Height;

    //        if (sHeight > destHeight || sWidth > destWidth)
    //        {
    //            if ((sWidth * destHeight) > (sHeight * destWidth))
    //            {
    //                sW = destWidth;
    //                sH = (destWidth * sHeight) / sWidth;
    //            }
    //            else
    //            {
    //                sH = destHeight;
    //                sW = (sWidth * destHeight) / sHeight;
    //            }
    //        }
    //        else
    //        {
    //            sW = sWidth;
    //            sH = sHeight;
    //        }

    //        Bitmap outBmp = new Bitmap(destWidth, destHeight);
    //        Graphics g = Graphics.FromImage(outBmp);
    //        g.Clear(Color.White);

    //        // 设置画布的描绘质量
    //        g.CompositingQuality = CompositingQuality.HighQuality;
    //        g.SmoothingMode = SmoothingMode.HighQuality;
    //        g.InterpolationMode = InterpolationMode.HighQualityBicubic;

    //        g.DrawImage(imgSource, new Rectangle((destWidth - sW) / 2, (destHeight - sH) / 2, sW, sH), 0, 0, imgSource.Width, imgSource.Height, GraphicsUnit.Pixel);
    //        g.Dispose();

    //        // 以下代码为保存图片时，设置压缩质量
    //        EncoderParameters encoderParams = new EncoderParameters();
    //        long[] quality = new long[1];
    //        quality[0] = 100;

    //        EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
    //        encoderParams.Param[0] = encoderParam;

    //        try
    //        {
    //            //获得包含有关内置图像编码解码器的信息的ImageCodecInfo 对象。
    //            ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
    //            ImageCodecInfo jpegICI = null;
    //            for (int x = 0; x < arrayICI.Length; x++)
    //            {
    //                if (arrayICI[x].FormatDescription.Equals("JPEG"))
    //                {
    //                    jpegICI = arrayICI[x];//设置JPEG编码
    //                    break;
    //                }
    //            }

    //            if (jpegICI != null)
    //            {
    //                outBmp.Save(response.OutputStream, jpegICI, encoderParams);
    //            }
    //            else
    //            {
    //                outBmp.Save(response.OutputStream, thisFormat);
    //            }

    //            return true;
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //        finally
    //        {
    //            imgSource.Dispose();
    //            outBmp.Dispose();
    //        }
    //    }

    //    /// <summary>
    //    /// 把图片缩小，并得到缩小后的图片名
    //    /// </summary>
    //    /// <param name="sourceFile">图片路径，全路径</param>
    //    /// <param name="response">页面响应</param>
    //    /// <param name="destHeight">缩小后的高</param>
    //    /// <param name="destWidth">缩小后的宽</param>
    //    /// <returns></returns>
    //    public static string GetThumbnailName(string sourceFile, int destHeight, int destWidth)
    //    {
    //        System.Drawing.Image imgSource = System.Drawing.Image.FromFile(sourceFile);
    //        System.Drawing.Imaging.ImageFormat thisFormat = imgSource.RawFormat;
    //        int sW = 0, sH = 0;
    //        // 按比例缩放
    //        int sWidth = imgSource.Width;
    //        int sHeight = imgSource.Height;

    //        if (sHeight > destHeight || sWidth > destWidth)
    //        {
    //            if ((sWidth * destHeight) > (sHeight * destWidth))
    //            {
    //                sW = destWidth;
    //                sH = (destWidth * sHeight) / sWidth;
    //            }
    //            else
    //            {
    //                sH = destHeight;
    //                sW = (sWidth * destHeight) / sHeight;
    //            }
    //        }
    //        else
    //        {
    //            sW = sWidth;
    //            sH = sHeight;
    //        }

    //        Bitmap outBmp = new Bitmap(destWidth, destHeight);
    //        Graphics g = Graphics.FromImage(outBmp);
    //        g.Clear(Color.White);

    //        // 设置画布的描绘质量
    //        g.CompositingQuality = CompositingQuality.HighQuality;
    //        g.SmoothingMode = SmoothingMode.HighQuality;
    //        g.InterpolationMode = InterpolationMode.HighQualityBicubic;

    //        g.DrawImage(imgSource, new Rectangle((destWidth - sW) / 2, (destHeight - sH) / 2, sW, sH), 0, 0, imgSource.Width, imgSource.Height, GraphicsUnit.Pixel);
    //        g.Dispose();

    //        // 以下代码为保存图片时，设置压缩质量
    //        EncoderParameters encoderParams = new EncoderParameters();
    //        long[] quality = new long[1];
    //        quality[0] = 100;

    //        EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
    //        encoderParams.Param[0] = encoderParam;

    //        //得到缩小后的图片名称
    //        string fileName = string.Empty;
    //        string filePath = string.Empty;
    //        if (sourceFile.LastIndexOf("/") < 0)
    //        {
    //            fileName = sourceFile.Substring(sourceFile.LastIndexOf(@"\") + 1);
    //        }
    //        else
    //        {
    //            fileName = sourceFile.Substring(sourceFile.LastIndexOf("/") + 1);
    //        }
    //        if (sourceFile.LastIndexOf("/") < 0)
    //        {
    //            filePath = sourceFile.Substring(0, sourceFile.LastIndexOf(@"\") + 1);
    //        }
    //        else
    //        {
    //            filePath = sourceFile.Substring(0, sourceFile.LastIndexOf("/") + 1);
    //        }
    //        string smallFileName = fileName.Substring(0, fileName.LastIndexOf(".")) + "_small" + fileName.Substring(fileName.LastIndexOf("."));
    //        try
    //        {
    //            //获得包含有关内置图像编码解码器的信息的ImageCodecInfo 对象。
    //            ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
    //            ImageCodecInfo jpegICI = null;
    //            for (int x = 0; x < arrayICI.Length; x++)
    //            {
    //                if (arrayICI[x].FormatDescription.Equals("JPEG"))
    //                {
    //                    jpegICI = arrayICI[x];//设置JPEG编码
    //                    break;
    //                }
    //            }

    //            if (jpegICI != null)
    //            {
    //                outBmp.Save(filePath + smallFileName, jpegICI, encoderParams);
    //            }
    //            else
    //            {
    //                outBmp.Save(filePath + smallFileName, thisFormat);
    //            }

    //            return smallFileName;
    //        }
    //        catch
    //        {
    //            return null;
    //        }
    //        finally
    //        {
    //            imgSource.Dispose();
    //            outBmp.Dispose();
    //        }
    //    }
    //    #endregion

    //    #region 生成验证码
    //    /// <summary>
    //    /// 生成随机码图片
    //    /// </summary>
    //    /// <param name="checkCode">随机码</param>
    //    /// <param name="context">上下文</param>
    //    public static void CreateCheckCodeImage(string checkCode, HttpContext context, int lineCount, int pointCount)
    //    {
    //        if (checkCode == null || checkCode.Trim() == String.Empty)
    //            return;
    //        System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 12.5)), 22);
    //        Graphics g = Graphics.FromImage(image);

    //        try
    //        {
    //            Random random = new Random(); // //生成随机生成器
    //            g.Clear(Color.White);   //清空图片背景色
    //            for (int i = 0; i < lineCount; i++)   //画图片的背景噪音线
    //            {
    //                int x1 = random.Next(image.Width);
    //                int x2 = random.Next(image.Width);
    //                int y1 = random.Next(image.Height);
    //                int y2 = random.Next(image.Height);

    //                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
    //            }
    //            Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
    //            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
    //            g.DrawString(checkCode, font, brush, 2, 2);
    //            for (int i = 0; i < pointCount; i++)  //画图片的前景噪音点
    //            {
    //                int x = random.Next(image.Width);
    //                int y = random.Next(image.Height);

    //                image.SetPixel(x, y, Color.FromArgb(random.Next()));
    //            }
    //            g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1); //画图片的边框线
    //            System.IO.MemoryStream ms = new System.IO.MemoryStream();
    //            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
    //            context.Response.ClearContent();
    //            context.Response.ContentType = "image/Gif";
    //            context.Response.BinaryWrite(ms.ToArray());
    //        }
    //        finally
    //        {
    //            g.Dispose();
    //            image.Dispose();
    //        }

    //    }


    //    /// <summary>
    //    /// 生成随机码
    //    /// </summary>
    //    /// <param name="context">上下文</param>
    //    /// <param name="type">如果随机码保存在Cookie里，那么填写Cookie ； 如果保存在Session里，那么填写Session</param>
    //    /// <returns></returns>
    //    public static string GenerateCheckCode(HttpContext context, string type, bool onlyNumber, int length)
    //    {
    //        int number;
    //        char code;
    //        string checkCode = String.Empty;
    //        System.Random random = new Random();
    //        for (int i = 0; i < length; i++)
    //        {
    //            number = random.Next();

    //            if (onlyNumber)
    //            {
    //                code = (char)('0' + (char)(number % 10));
    //            }
    //            else
    //            {
    //                if (number % 2 == 0)
    //                    code = (char)('0' + (char)(number % 10));
    //                else if (number % 3 == 0)
    //                    code = (char)('A' + (char)(number % 26));
    //                else
    //                    code = (char)('a' + (char)(number % 26));
    //            }

    //            checkCode += code.ToString();
    //        }


    //        if (type == "Cookie")
    //        {
    //            context.Response.Cookies.Add(new HttpCookie("CheckCode", checkCode));//存到Cookie里．
    //        }
    //        else if (type == "Session")
    //        {
    //            context.Session["CheckCode"] = checkCode;  //存到Seesion里．
    //        }


    //        return checkCode;
    //    }
    //    #endregion


    //    /// <summary>
    //    /// 从列表中抽取一定数量的记录
    //    /// </summary>
    //    /// <param name="list">被抽取的列表</param>
    //    /// <param name="size">抽取数</param>
    //    /// <returns>被抽取的记录</returns>
    //    public static ArrayList GetRandomArrayList(ArrayList list, int size)
    //    {
    //        //随机数生成种子
    //        ArrayList seekList = new ArrayList();
    //        try
    //        {
    //            Random random = new Random(unchecked((int)DateTime.Now.Ticks));//定义随机类
    //            for (int i = 0; i < size; i++)
    //            {
    //                int seek = 0;
    //                seek = random.Next(list.Count);
    //                seekList.Add(list[seek]);
    //                list.RemoveAt(seek);
    //            }
    //        }
    //        catch { Console.Write("获取随机数字失败"); }
    //        return seekList;
    //    }

    //    #region 导出Excel
    //    /// <summary> 导出Excel文件到客户端</summary>
    //    /// <param name="fileName">excel文件名</param>
    //    /// <param name="gridView">页面中gridview对象，用来复制其栏位，作为excel列</param>
    //    /// <param name="ds">要导出的数据集(IList)</param>
    //    /// <param name="Response">页面输出</param>
    //    ///<remarks>调用页面必须加入 public override void VerifyRenderingInServerForm(Control control) { }</remarks>
    //    public static void ExportExcel(string fileName, GridView gridView, IList ds, HttpResponse Response, int limit_num)
    //    {
    //        if (ds == null || ds.Count == 0)
    //        {
    //            Response.Write("<script language='javascript' >alert(\"没有资料可以导出！\");</script>");
    //            return;
    //        }
    //        int total = ds.Count;



    //        if (total > limit_num)
    //        {
    //            Response.Write("<script language='javascript' >alert(\"符合条件的数据太多超出系统限制（" + limit_num + "条)，请缩小查询范围!\");</script>");
    //            return;
    //        }

    //        Response.Clear();
    //        Response.Buffer = true;
    //        Response.Charset = "GB2312";
    //        Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(fileName.ToString(), System.Text.Encoding.UTF8) + ".xls\"");
    //        Response.ContentEncoding = System.Text.Encoding.UTF7;
    //        Response.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。
    //        StringWriter oStringWriter = new StringWriter();
    //        HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);

    //        //此部分代码待优化研究begin
    //        gridView.AllowPaging = false;
    //        gridView.ShowFooter = false;
    //        gridView.DataSource = ds;
    //        gridView.DataBind();

    //        gridView.RenderControl(oHtmlTextWriter);
    //        //此部分代码待优化研究end

    //        Response.Output.Write(oStringWriter.ToString());
    //        Response.Flush();
    //        Response.End();
    //    }


    //    /// <summary> 导出Excel文件到客户端</summary>
    //    /// <param name="fileName">excel文件名</param>
    //    /// <param name="gridView">页面中gridview对象，用来复制其栏位，作为excel列</param>
    //    /// <param name="ds">要导出的数据集(DataSet)</param>
    //    /// <param name="Response">页面输出</param>
    //    ///<remarks>调用页面必须加入 public override void VerifyRenderingInServerForm(Control control) { }</remarks>
    //    public static void ExportExcel(string fileName, GridView gridView, DataSet ds, HttpResponse Response)
    //    {
    //        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
    //        {
    //            Response.Write("<script language='javascript' >alert(\"没有资料可以导出！\");</script>");
    //            return;
    //        }
    //        Response.Clear();
    //        Response.Buffer = true;
    //        Response.Charset = "GB2312";
    //        Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(fileName.ToString(), System.Text.Encoding.UTF8) + ".xls\"");
    //        Response.ContentEncoding = System.Text.Encoding.UTF7;
    //        Response.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。
    //        StringWriter oStringWriter = new StringWriter();
    //        HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);

    //        //此部分代码待优化研究begin
    //        gridView.AllowPaging = false;
    //        gridView.DataSource = ds;
    //        gridView.DataBind();
    //        gridView.RenderControl(oHtmlTextWriter);
    //        //此部分代码待优化研究end

    //        Response.Output.Write(oStringWriter.ToString());
    //        Response.Flush();
    //        Response.End();
    //    }


    //    public static void ExportExcel(string fileName, Repeater repeater, IList ds, HttpResponse Response, int limit_num)
    //    {
    //        if (ds == null || ds.Count == 0)
    //        {
    //            Response.Write("<script language='javascript' >alert(\"没有资料可以导出！\");</script>");
    //            return;
    //        }
    //        int total = ds.Count;



    //        if (total > limit_num)
    //        {
    //            Response.Write("<script language='javascript' >alert(\"符合条件的数据太多超出系统限制（" + limit_num + "条)，请缩小查询范围!\");</script>");
    //            return;
    //        }

    //        Response.Clear();
    //        Response.Buffer = true;
    //        Response.Charset = "GB2312";
    //        Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(fileName.ToString(), System.Text.Encoding.UTF8) + ".xls\"");
    //        Response.ContentEncoding = System.Text.Encoding.UTF7;
    //        Response.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。
    //        StringWriter oStringWriter = new StringWriter();
    //        HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);

    //        //此部分代码待优化研究begin


    //        repeater.DataSource = ds;
    //        repeater.DataBind();

    //        repeater.RenderControl(oHtmlTextWriter);
    //        //此部分代码待优化研究end

    //        Response.Output.Write(oStringWriter.ToString());
    //        Response.Flush();
    //        Response.End();
    //    }

    //    /// <summary>
    //    /// 导出Repeater， 可输入动态Header 和 Footer
    //    /// </summary>
    //    /// <param name="fileName">文件名</param>
    //    /// <param name="repeater">Repeater</param>
    //    /// <param name="ds">数据源</param>
    //    /// <param name="Response">输出</param>
    //    /// <param name="limit_num">最大导出记录数</param>
    //    /// <param name="headerCtlIndx">header信息列表索引</param>
    //    /// <param name="headerCtlText">header信息列表，键值对： 控件名 -- InnerHtml， 数量必须等于header信息列表索引的数量</param>
    //    /// <param name="footerCtlIndx">footer信息列表索引</param>
    //    /// <param name="footerCtlText">footer信息列表，键值对： 控件名 -- InnerHtml， 数量必须等于footer信息列表索引的数量</param>
    //    public static void ExportExcel(string fileName, Repeater repeater, DataSet ds, HttpResponse Response, int limit_num, Dictionary<string, string> headerCtlText, Dictionary<string, string> footerCtlText)
    //    {
    //        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
    //        {
    //            Response.Write("<script language='javascript' >alert(\"没有资料可以导出！\");</script>");
    //            return;
    //        }
    //        int total = ds.Tables[0].Rows.Count;



    //        if (total > limit_num)
    //        {
    //            Response.Write("<script language='javascript' >alert(\"符合条件的数据太多超出系统限制（" + limit_num + "条)，请缩小查询范围!\");</script>");
    //            return;
    //        }

    //        Response.Clear();
    //        Response.Buffer = true;
    //        Response.Charset = "GB2312";
    //        Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(fileName.ToString(), System.Text.Encoding.UTF8) + ".xls\"");
    //        Response.ContentEncoding = System.Text.Encoding.UTF7;
    //        Response.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。
    //        StringWriter oStringWriter = new StringWriter();
    //        HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);

    //        //此部分代码待优化研究begin


    //        repeater.DataSource = ds;
    //        repeater.DataBind();

    //        //header
    //        if (headerCtlText != null && headerCtlText.Count > 0)
    //        {
    //            foreach (KeyValuePair<string, string> kv in headerCtlText)
    //            {
    //                ((HtmlContainerControl)repeater.Controls[0].FindControl(kv.Key)).InnerText = kv.Value;
    //            }
    //        }

    //        //footer
    //        if (footerCtlText != null && footerCtlText.Count > 0)
    //        {
    //            foreach (KeyValuePair<string, string> kv in footerCtlText)
    //            {
    //                ((HtmlContainerControl)repeater.Controls[repeater.Controls.Count - 1].FindControl(kv.Key)).InnerText = kv.Value;
    //            }
    //        }
    //        repeater.RenderControl(oHtmlTextWriter);
    //        //此部分代码待优化研究end

    //        Response.Output.Write(oStringWriter.ToString());
    //        Response.Flush();
    //        Response.End();
    //    }

    //    /// <summary>
    //    /// 导出Repeater， 可输入动态Header 和 Footer
    //    /// </summary>
    //    /// <param name="fileName">文件名</param>
    //    /// <param name="repeater">Repeater</param>
    //    /// <param name="ds">数据源</param>
    //    /// <param name="Response">输出</param>
    //    /// <param name="limit_num">最大导出记录数</param>
    //    /// <param name="headerCtlIndx">header信息列表索引</param>
    //    /// <param name="headerCtlText">header信息列表，键值对： 控件名 -- InnerHtml， 数量必须等于header信息列表索引的数量</param>
    //    /// <param name="footerCtlIndx">footer信息列表索引</param>
    //    /// <param name="footerCtlText">footer信息列表，键值对： 控件名 -- InnerHtml， 数量必须等于footer信息列表索引的数量</param>
    //    public static void ExportExcel(string fileName, Repeater repeater, DataView ds, HttpResponse Response, int limit_num, Dictionary<string, string> headerCtlText, Dictionary<string, string> footerCtlText)
    //    {
    //        if (ds == null || ds.Table.Rows.Count == 0)
    //        {
    //            Response.Write("<script language='javascript' >alert(\"没有资料可以导出！\");</script>");
    //            return;
    //        }
    //        int total = ds.Table.Rows.Count;



    //        if (total > limit_num)
    //        {
    //            Response.Write("<script language='javascript' >alert(\"符合条件的数据太多超出系统限制（" + limit_num + "条)，请缩小查询范围!\");</script>");
    //            return;
    //        }

    //        Response.Clear();
    //        Response.Buffer = true;
    //        Response.Charset = "GB2312";
    //        Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(fileName.ToString(), System.Text.Encoding.UTF8) + ".xls\"");
    //        Response.ContentEncoding = System.Text.Encoding.UTF7;
    //        Response.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。
    //        StringWriter oStringWriter = new StringWriter();
    //        HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);

    //        //此部分代码待优化研究begin


    //        repeater.DataSource = ds;
    //        repeater.DataBind();

    //        //header
    //        if (headerCtlText != null && headerCtlText.Count > 0)
    //        {
    //            foreach (KeyValuePair<string, string> kv in headerCtlText)
    //            {
    //                ((HtmlContainerControl)repeater.Controls[0].FindControl(kv.Key)).InnerText = kv.Value;
    //            }
    //        }

    //        //footer
    //        if (footerCtlText != null && footerCtlText.Count > 0)
    //        {
    //            foreach (KeyValuePair<string, string> kv in footerCtlText)
    //            {
    //                ((HtmlContainerControl)repeater.Controls[repeater.Controls.Count - 1].FindControl(kv.Key)).InnerText = kv.Value;
    //            }
    //        }
    //        repeater.RenderControl(oHtmlTextWriter);
    //        //此部分代码待优化研究end

    //        Response.Output.Write(oStringWriter.ToString());
    //        Response.Flush();
    //        Response.End();
    //    }

    //    public static void ExportExcel(string fileName, Repeater repeater, DataSet ds, HttpResponse Response, int limit_num)
    //    {
    //        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
    //        {
    //            Response.Write("<script language='javascript' >alert(\"没有资料可以导出！\");</script>");
    //            return;
    //        }
    //        int total = ds.Tables[0].Rows.Count;
    //        if (total > limit_num)
    //        {
    //            Response.Write("<script language='javascript' >alert(\"符合条件的数据太多超出系统限制（" + limit_num + "条)，请缩小查询范围!\");</script>");
    //            return;
    //        }

    //        Response.Clear();
    //        Response.Buffer = true;
    //        Response.Charset = "GB2312";
    //        Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(fileName.ToString(), System.Text.Encoding.UTF8) + ".xls\"");
    //        Response.ContentEncoding = System.Text.Encoding.UTF7;
    //        Response.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。
    //        StringWriter oStringWriter = new StringWriter();
    //        HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);

    //        //此部分代码待优化研究begin


    //        repeater.DataSource = ds;
    //        repeater.DataBind();

    //        repeater.RenderControl(oHtmlTextWriter);
    //        //此部分代码待优化研究end

    //        Response.Output.Write(oStringWriter.ToString());
    //        Response.Flush();
    //        Response.End();
    //    }

    //    /// <summary> 导出Excel文件到客户端</summary>
    //    /// <param name="fileName">excel文件名</param>
    //    /// <param name="gridView">页面中gridview对象，用来复制其栏位，作为excel列</param>
    //    /// <param name="ds">要导出的数据集(DataSet)</param>
    //    /// <param name="Response">页面输出</param>
    //    ///<remarks>调用页面必须加入 public override void VerifyRenderingInServerForm(Control control) { }</remarks>
    //    public static void ExportExcel(string fileName, GridView gridView, DataSet ds, HttpResponse Response, int limit_num)
    //    {

    //        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
    //        {
    //            Response.Write("<script language='javascript' >alert(\"没有资料可以导出！\");</script>");
    //            return;
    //        }
    //        int total = ds.Tables[0].Rows.Count;
    //        if (total > limit_num)
    //        {
    //            Response.Write("<script language='javascript' >alert(\"符合条件的数据太多超出系统限制（" + limit_num + "条)，请缩小查询范围!\");</script>");
    //            return;
    //        }
    //        Response.Clear();
    //        Response.Buffer = true;
    //        Response.Charset = "GB2312";
    //        Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(fileName.ToString(), System.Text.Encoding.UTF8) + ".xls\"");
    //        Response.ContentEncoding = System.Text.Encoding.UTF7;
    //        Response.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。
    //        StringWriter oStringWriter = new StringWriter();
    //        HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);

    //        //此部分代码待优化研究begin
    //        gridView.AllowPaging = false;
    //        gridView.DataSource = ds;
    //        gridView.DataBind();
    //        gridView.RenderControl(oHtmlTextWriter);
    //        //此部分代码待优化研究end

    //        Response.Output.Write(oStringWriter.ToString());
    //        Response.Flush();
    //        Response.End();
    //    }

    //    /// <summary> 导出Excel文件到客户端</summary>
    //    /// <param name="fileName">excel文件名</param>
    //    /// <param name="gridView">页面中gridview对象，用来复制其栏位，作为excel列</param>
    //    /// <param name="ds">要导出的数据集(DataView)</param>
    //    /// <param name="Response">页面输出</param>
    //    ///<remarks>调用页面必须加入 public override void VerifyRenderingInServerForm(Control control) { }</remarks>
    //    public static void ExportExcel(string fileName, GridView gridView, DataView ds, HttpResponse Response)
    //    {
    //        if (ds == null || ds.Count == 0)
    //        {
    //            Response.Write("<script language='javascript' >alert(\"没有资料可以导出！\");</script>");
    //            return;
    //        }
    //        Response.Clear();
    //        Response.Buffer = true;
    //        Response.Charset = "GB2312";
    //        Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(fileName.ToString(), System.Text.Encoding.UTF8) + ".xls\"");
    //        Response.ContentEncoding = System.Text.Encoding.UTF7;
    //        Response.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。
    //        StringWriter oStringWriter = new StringWriter();
    //        HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);

    //        //此部分代码待优化研究begin
    //        gridView.AllowPaging = false;
    //        gridView.DataSource = ds;
    //        gridView.DataBind();
    //        gridView.RenderControl(oHtmlTextWriter);
    //        //此部分代码待优化研究end

    //        Response.Output.Write(oStringWriter.ToString());
    //        Response.Flush();
    //        Response.End();
    //    }
    //    #endregion


    //    /// <summary>
    //    /// 传入要匹配的角色Id
    //    /// </summary>
    //    /// <param name="roleId">角色id</param>
    //    /// <returns></returns>
    //    public static bool IsRole(int roleId)
    //    {
    //        if (HttpContext.Current.Session["RoleID"] != null)
    //        {
    //            string[] roleIds = HttpContext.Current.Session["RoleID"].ToString().Split(',');
    //            for (int i = 0; i < roleIds.Length; i++)
    //            {
    //                if (Int32.Parse(roleIds[i]) == roleId)
    //                {
    //                    return true;
    //                }
    //            }

    //            if (roleIds.Length < 1)
    //            {
    //                if (Int32.Parse(HttpContext.Current.Session["RoleIds"].ToString()) == roleId)
    //                {
    //                    return true;
    //                }
    //            }

    //            return false;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }


    //    public static string get_batch()
    //    {
    //        string bacth = System.DateTime.Now.Year.ToString();
    //        int month = System.DateTime.Now.Month;
    //        if (month < 10)
    //        {
    //            bacth += "0" + month;
    //        }
    //        else
    //        {
    //            bacth += month;
    //        }
    //        return bacth;
    //    }
    }
}
