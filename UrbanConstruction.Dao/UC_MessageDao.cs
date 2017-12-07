using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanConstruction.Service;
using UrbanConstruction.Model;
using System.Collections;
using System.Data;

namespace UrbanConstruction.Dao
{
    public class UC_MessageDao : BaseSqlMapDao, IUC_Message
    {
        /// <summary>
        /// 得到列表
        /// </summary>
        public IList<UC_Message> GetUC_MessageList()
        {
            return ExecuteQueryForList<UC_Message>("Select", null);
        }
        /// <summary>
        /// 获取对象列表
        /// </summary>
        public IList<UC_Message> GetList(int Num, string strWhere)
        {
            Hashtable ht = null;
            if (!string.IsNullOrEmpty(strWhere))
            {
                ht = new Hashtable();
                ht["strWhere"] = strWhere;
            }
            ht["strNum"] = Num;

            return ExecuteQueryForList<UC_Message>("UC_Message.GetList", ht);
        }
        /// <summary>
        /// 获取对象列表
        /// </summary>
        public IList<UC_Message> GetAllList(string strWhere)
        {
            Hashtable ht = null;
            if (!string.IsNullOrEmpty(strWhere))
            {
                ht = new Hashtable();
                ht["strWhere"] = strWhere;
            }

            return ExecuteQueryForList<UC_Message>("UC_Message.GetAllList", ht);
        }

        /// <summary>
        /// 新建
        /// </summary>
        public void Insert(UC_Message uc_message)
        {

            ExecuteInsert("UC_Message.Insert", uc_message);
        }
        /// <summary>
        /// 修改
        /// </summary>
        public void Update(UC_Message uc_message)
        {
            ExecuteUpdate("UC_Message.Update", uc_message);
        }

        public void Examine(UC_Message uc_message)
        {
            ExecuteUpdate("UC_Message.Examine", uc_message);
        }

        /// <summary>
        /// 得到明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UC_Message FindById(int ID)
        {
            return ExecuteQueryForObject<UC_Message>("UC_Message.FindById", ID);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int ID)
        {
            ExecuteDelete("UC_Message.Delete", ID);
        }

        /// <summary>
        /// 得到列表,分页
        /// </summary>
        public IList<UC_Message> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere, string fldName)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_Message");
            ht.Add("fldName", fldName);
            ht.Add("PageSize", PageSize);
            ht.Add("PageIndex", PageIndex);
            ht.Add("IsCount", 0);
            ht.Add("OrderType", OrderType);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForList<UC_Message>("UC_Message.PageFindAll", ht);
        }
        /// <summary>
        /// 得到列表,分页
        /// </summary>
        public IList<UC_Message> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_Message");
            ht.Add("fldName", "MessageID");
            ht.Add("PageSize", PageSize);
            ht.Add("PageIndex", PageIndex);
            ht.Add("IsCount", 0);
            ht.Add("OrderType", OrderType);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForList<UC_Message>("UC_Message.PageFindAll", ht);
        }
        /// <summary>
        /// 得到条数
        /// </summary>
        public int FindAll(string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_Message");
            ht.Add("fldName", "MessageID");
            ht.Add("PageSize", 0);
            ht.Add("PageIndex", 0);
            ht.Add("IsCount", 1);
            ht.Add("OrderType", 1);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForObject<int>("UC_Message.PageFindAllCount", ht);
        }
        /// <summary>
        /// 得到Datatable
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string strWhere)
        {
            return ExecuteQueryForDataTable("UC_Message.BaseSelect", strWhere);
        }
    }
}
