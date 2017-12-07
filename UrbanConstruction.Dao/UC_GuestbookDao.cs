using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanConstruction.Service;
using UrbanConstruction.Model;
using System.Collections;

namespace UrbanConstruction.Dao
{
    class UC_GuestbookDao : BaseSqlMapDao, IUC_Guestbook
    {
        /// <summary>
        /// 得到列表
        /// </summary>
        public IList<UC_Guestbook> GetUC_GuestbookList()
        {
            return ExecuteQueryForList<UC_Guestbook>("Select", null);
        }

        /// <summary>
        /// 获取对象列表
        /// </summary>
        public IList<UC_Guestbook> GetAllList(string strWhere)
        {
            Hashtable ht = null;
            if (!string.IsNullOrEmpty(strWhere))
            {
                ht = new Hashtable();
                ht["strWhere"] = strWhere;
            }

            return ExecuteQueryForList<UC_Guestbook>("UC_Guestbook.GetAllList", ht);
        }
     
        public List<UC_Guestbook> GetList()
        {
            return GetAllList("State=1 and (WriteContent is not null").ToList();
        }

        /// <summary>
        /// 新建
        /// </summary>
        public void Insert(UC_Guestbook uc_message)
        {

            ExecuteInsert("UC_Guestbook.Insert", uc_message);
        }
        /// <summary>
        /// 修改
        /// </summary>
        public void Update(UC_Guestbook uc_message)
        {
            ExecuteUpdate("UC_Guestbook.Update", uc_message);
        }

        public void Examine(UC_Guestbook uc_message)
        {
            ExecuteUpdate("UC_Guestbook.Examine", uc_message);
        }

        /// <summary>
        /// 得到明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UC_Guestbook FindById(int ID)
        {
            return ExecuteQueryForObject<UC_Guestbook>("UC_Guestbook.FindById", ID);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int ID)
        {
            ExecuteDelete("UC_Guestbook.Delete", ID);
        }

        /// <summary>
        /// 得到列表,分页
        /// </summary>
        public IList<UC_Guestbook> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere, string fldName)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_Guestbook");
            ht.Add("fldName", fldName);
            ht.Add("PageSize", PageSize);
            ht.Add("PageIndex", PageIndex);
            ht.Add("IsCount", 0);
            ht.Add("OrderType", OrderType);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForList<UC_Guestbook>("UC_Guestbook.PageFindAll", ht);
        }
        /// <summary>
        /// 得到列表,分页
        /// </summary>
        public IList<UC_Guestbook> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_Guestbook");
            ht.Add("fldName", "MessageID");
            ht.Add("PageSize", PageSize);
            ht.Add("PageIndex", PageIndex);
            ht.Add("IsCount", 0);
            ht.Add("OrderType", OrderType);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForList<UC_Guestbook>("UC_Guestbook.PageFindAll", ht);
        }
        /// <summary>
        /// 得到条数
        /// </summary>
        public int FindAll(string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_Guestbook");
            ht.Add("fldName", "MessageID");
            ht.Add("PageSize", 0);
            ht.Add("PageIndex", 0);
            ht.Add("IsCount", 1);
            ht.Add("OrderType", 1);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForObject<int>("UC_Guestbook.PageFindAllCount", ht);
        }
    }
}

