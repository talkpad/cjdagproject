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
    public class UC_NewsListDao : BaseSqlMapDao, IUC_NewsList
    {/// <summary>
        /// 得到列表
        /// </summary>
        public IList<UC_NewsList> GetUC_NewsListList()
        {
            return ExecuteQueryForList<UC_NewsList>("Select", null);
        }

        /// <summary>
        /// 新建
        /// </summary>
        public void Insert(UC_NewsList uc_newsList)
        {

            ExecuteInsert("UC_NewsList.Insert", uc_newsList);
        }
        /// <summary>
        /// 修改
        /// </summary>
        public void Update(UC_NewsList uc_newsList)
        {
            ExecuteUpdate("UC_NewsList.Update", uc_newsList);
        }
        /// <summary>
        /// 批次修改
        /// </summary>
        public void BatchUpdate(UC_NewsList uc_newsList)
        {
            ExecuteUpdate("UC_NewsList.BatchUpdate", uc_newsList);
        }
        public void Examine(UC_NewsList uc_newsList)
        {
            ExecuteUpdate("UC_NewsList.Examine", uc_newsList);
        }
        /// <summary>
        /// 得到明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UC_NewsList FindById(int ID)
        {
            return ExecuteQueryForObject<UC_NewsList>("UC_NewsList.FindById", ID);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int ID)
        {
            ExecuteDelete("UC_NewsList.Delete", ID);
        }
        /// <summary>
        /// 获取对象列表
        /// </summary>
        public IList<UC_NewsList> GetList(int Num, string strWhere)
        {
            Hashtable ht = null;
            if (!string.IsNullOrEmpty(strWhere))
            {
                ht = new Hashtable();
                ht["strWhere"] = strWhere;
            }
            ht["strNum"] = Num;

            return ExecuteQueryForList<UC_NewsList>("UC_NewsList.GetList", ht);
        }
        /// <summary>
        /// 获取对象列表
        /// </summary>
        public IList<UC_NewsList> GetAllList(string strWhere)
        {
            Hashtable ht = null;
            if (!string.IsNullOrEmpty(strWhere))
            {
                ht = new Hashtable();
                ht["strWhere"] = strWhere;
            }

            return ExecuteQueryForList<UC_NewsList>("UC_NewsList.GetAllList", ht);
        }


        /// <summary>
        /// 得到列表,分页
        /// </summary>
        public IList<UC_NewsList> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere, string fldName)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_NewsList");
            ht.Add("fldName", fldName);
            ht.Add("PageSize", PageSize);
            ht.Add("PageIndex", PageIndex);
            ht.Add("IsCount", 0);
            ht.Add("OrderType", OrderType);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForList<UC_NewsList>("UC_NewsList.PageFindAll", ht);
        }
        /// <summary>
        /// 得到列表,分页
        /// </summary>
        public IList<UC_NewsList> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_NewsList");
            ht.Add("fldName", "ReleaseTime");
            ht.Add("PageSize", PageSize);
            ht.Add("PageIndex", PageIndex);
            ht.Add("IsCount", 0);
            ht.Add("OrderType", OrderType);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForList<UC_NewsList>("UC_NewsList.PageFindAll", ht);
        }
        /// <summary>
        /// 得到条数
        /// </summary>
        public int FindAll(string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_NewsList");
            ht.Add("fldName", "ID");
            ht.Add("PageSize", 0);
            ht.Add("PageIndex", 0);
            ht.Add("IsCount", 1);
            ht.Add("OrderType", 1);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForObject<int>("UC_NewsList.PageFindAllCount", ht);
        }
        /// <summary>
        /// 得到Datatable
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string strWhere)
        {
            return ExecuteQueryForDataTable("UC_NewsList.BaseSelect", strWhere);
        }
    }
}
