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
    public class UC_LinkDao : BaseSqlMapDao, IUC_Link
    {
        /// <summary>
        /// 得到列表
        /// </summary>
        public IList<UC_Link> GetUC_LinkList()
        {
            return ExecuteQueryForList<UC_Link>("Select", null);
        }

        /// <summary>
        /// 新建
        /// </summary>
        public void Insert(UC_Link uc_link)
        {

            ExecuteInsert("UC_Link.Insert", uc_link);
        }
        /// <summary>
        /// 修改
        /// </summary>
        public void Update(UC_Link uc_link)
        {
            ExecuteUpdate("UC_Link.Update", uc_link);
        }
        /// <summary>
        /// 得到明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UC_Link FindById(int ID)
        {
            return ExecuteQueryForObject<UC_Link>("UC_Link.FindById", ID);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int ID)
        {
            ExecuteDelete("UC_Link.Delete", ID);
        }
        /// <summary>
        /// 得到列表,分页
        /// </summary>
        public IList<UC_Link> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_Link");
            ht.Add("fldName", "LinkID");
            ht.Add("PageSize", PageSize);
            ht.Add("PageIndex", PageIndex);
            ht.Add("IsCount", 0);
            ht.Add("OrderType", OrderType);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForList<UC_Link>("UC_Link.PageFindAll", ht);
        }
        /// <summary>
        /// 得到条数
        /// </summary>
        public int FindAll(string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_Link");
            ht.Add("fldName", "LinkID");
            ht.Add("PageSize", 0);
            ht.Add("PageIndex", 0);
            ht.Add("IsCount", 1);
            ht.Add("OrderType", 1);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForObject<int>("UC_Link.PageFindAllCount", ht);
        }
        /// <summary>
        /// 得到Datatable
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string strWhere)
        {
            return ExecuteQueryForDataTable("UC_Link.BaseSelect", strWhere);
        }
    }
}
