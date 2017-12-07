using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.Configuration;

namespace UrbanConstruction.Component
{
    public class Datatablebind
    {

        //public static DataTable GetSumHit()
        //{
        //    DataTable dt = SZM.Utility.Library.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, "select t1.m_name,sum(t2.hits) hits from dbo.v_Menu t1 join dbo.T_NewsInformation t2 on t2.m_id=t1.m_id group by m_name ");
        //    return dt;
        //}

        //public static DataTable GetAddNum(string Date_S, String Date_E)
        //{
        //    StringBuilder o_sql = new StringBuilder();
        //    o_sql.Append("  select t1.m_name,(select count(t2.ID)  from dbo.V_NewsInformation t2 where t2.m_id=t1.m_id    ");
        //    if (Date_S.Length > 0)
        //    {
        //        o_sql.Append(string.Format("and convert(varchar(10),ReleaseTime,20)>='{0}'", Date_S));
        //    }
        //    if (Date_E.Length > 0)
        //    {
        //        o_sql.Append(string.Format("and convert(varchar(10),ReleaseTime,20)<='{0}'", Date_E));
        //    }
        //    o_sql.Append(" ) AddNum from dbo.v_Menu t1 ");

        //    DataTable dt = SZM.Utility.Library.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, o_sql.ToString());
        //    return dt;
        //}
    
        //private Datatablebind() { }
        private static readonly string ConnectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        ////public static DataTable GetPClassDataTable(string String)
        ////{
        ////    DataTable dt = SZM.Utility.Library.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, "select distinct(PClass) from T_Parent where " + String + "");
        ////    return dt;
        ////}
        public static DataTable GetUC_Menu(string String)
        {
            DataTable dt = SZM.Utility.Library.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, "select M_ID,M_NAME from uc_menu where 1=1 " + String + " order by ordering ");
            return dt;
        }
        /// <summary>
        /// 获得镇区列表
        /// </summary>
        /// <param name="String"></param>
        /// <returns></returns>
        public static DataTable GetUC_Town(string String)
        {
            DataTable dt = SZM.Utility.Library.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, "select Companyid,CompanyName from dbo.UC_Town where state=1 order by ordering ");
            return dt;
        }
        ///// <summary>
        ///// 获取镇区名称
        ///// </summary>
        ///// <param name="Companyid"></param>
        ///// <returns></returns>
        public static string GetCompanyName(string Companyid)
        {
            object obj = SZM.Utility.Library.SqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, "select top 1 CompanyName from dbo.UC_Town where Companyid=" + Companyid);
            if (obj != null)
                return obj.ToString();
            else
                return "";
        }

        /// <summary>
        /// 获取功能菜单名称
        /// </summary>
        /// <param name="Companyid"></param>
        /// <returns></returns>
        public static string GetMenuItemName(string m_itemid)
        {
            object obj = SZM.Utility.Library.SqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, string.Format("select M_NAME+'-'+M_ItemName Name from dbo.UC_MenuItem MI,dbo.UC_Menu M where m_itemid={0} and MI.M_ID = M.M_ID",  m_itemid));
            if (obj != null)
                return obj.ToString();
            else
                return "";
        }
    
        public static DataTable GetUC_MenuItem(string String)
        {
            DataTable dt = SZM.Utility.Library.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, "select M_ItemID,M_itemNAME from uc_MenuItem where status=1  " + String + "");
            return dt;
        }
        //public static int GetMaxID(string ItemName, String TabelName)
        //{
        //    object obj = SZM.Utility.Library.SqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, "select  max(" + ItemName + ")+1  From " + TabelName + " ");
        //    return int.Parse(obj.ToString());
        //}
        //public static DataTable GetUserDataTable(string String)
        //{
        //    DataTable dt = SZM.Utility.Library.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, "select * from T_User where " + String + "");
        //    return dt;
        //}

        //public static DataTable GetNewsInformationDataTable(string String)
        //{
        //    DataTable dt = SZM.Utility.Library.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, "select * from T_NewsInformation where " + String + "");
        //    return dt;
        //}

        //public static DataTable GetMessageDataTable(string String)
        //{
        //    DataTable dt = SZM.Utility.Library.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, "select * from T_Message where " + String + "");
        //    return dt;
        //}

        //public static DataTable GetLinkDataTable(string String)
        //{
        //    DataTable dt = SZM.Utility.Library.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, "select * from T_Link where " + String + "");
        //    return dt;
        //}

        //public static DataTable GetDownLoadDataTable(string String)
        //{
        //    DataTable dt = SZM.Utility.Library.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, "select * from T_DownLoad where " + String + "");
        //    return dt;
        //}
    }
}
