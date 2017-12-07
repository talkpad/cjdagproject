using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.Common;
using IBatisNet.DataMapper;
using IBatisNet.Common.Exceptions;
using UrbanConstruction.Model;
using UrbanConstruction.Service;
using System.Data;
using System.Collections;

namespace UrbanConstruction.Dao
{
    public class UC_DownLoadDao :BaseSqlMapDao,IUC_DownLoad
    {
        /// <summary>
        /// 得到列表
        /// </summary>
        public IList<UC_DownLoad> GetUC_DownLoadList()
        {
            return ExecuteQueryForList<UC_DownLoad>("Select", null);
        }
        /// <summary>
        /// 获取对象列表
        /// </summary>
        public IList<UC_DownLoad> GetList(int Num, string strWhere)
        {
            Hashtable ht = null;
            if (!string.IsNullOrEmpty(strWhere))
            {
                ht = new Hashtable();
                ht["strWhere"] = strWhere;
            }
            ht["strNum"] = Num;

            return ExecuteQueryForList<UC_DownLoad>("UC_DownLoad.GetList", ht);
        }
        /// <summary>
        /// 获取对象列表
        /// </summary>
        public IList<UC_DownLoad> GetAllList(string strWhere)
        {
            Hashtable ht = null;
            if (!string.IsNullOrEmpty(strWhere))
            {
                ht = new Hashtable();
                ht["strWhere"] = strWhere;
            }

            return ExecuteQueryForList<UC_DownLoad>("UC_DownLoad.GetAllList", ht);
        }
        /// <summary>
        /// 新建
        /// </summary>
        public void Insert(UC_DownLoad uc_download)
        {

            ExecuteInsert("UC_DownLoad.Insert", uc_download);
        }
        /// <summary>
        /// 修改
        /// </summary>
        public void Update(UC_DownLoad uc_download)
        {
            ExecuteUpdate("UC_DownLoad.Update", uc_download);
        }
        /// <summary>
        /// 批次修改
        /// </summary>
        public void BatchUpdate(UC_DownLoad uc_download)
        {
            ExecuteUpdate("UC_DownLoad.BatchUpdate", uc_download);
        }
        /// <summary>
        /// 得到明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UC_DownLoad FindById(int ID)
        {
            return ExecuteQueryForObject<UC_DownLoad>("UC_DownLoad.FindById", ID);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int ID)
        {
            ExecuteDelete("UC_DownLoad.Delete", ID);
        }
        /// <summary>
        /// 得到列表,分页
        /// </summary>
        public IList<UC_DownLoad> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere, string fldName)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_DownLoad");
            ht.Add("fldName", fldName);
            ht.Add("PageSize", PageSize);
            ht.Add("PageIndex", PageIndex);
            ht.Add("IsCount", 0);
            ht.Add("OrderType", OrderType);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForList<UC_DownLoad>("UC_DownLoad.PageFindAll", ht);
        }
        /// <summary>
        /// 得到列表,分页
        /// </summary>
        public IList<UC_DownLoad> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_DownLoad");
            ht.Add("fldName", "ID");
            ht.Add("PageSize", PageSize);
            ht.Add("PageIndex", PageIndex);
            ht.Add("IsCount", 0);
            ht.Add("OrderType", OrderType);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForList<UC_DownLoad>("UC_DownLoad.PageFindAll", ht);
        }
        /// <summary>
        /// 得到分页，按时间排序
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="OrderType"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public IList<UC_DownLoad> FindAllByTime(int PageSize, int PageIndex, int OrderType, string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_DownLoad");
            ht.Add("fldName", "AddTime");
            ht.Add("PageSize", PageSize);
            ht.Add("PageIndex", PageIndex);
            ht.Add("IsCount", 0);
            ht.Add("OrderType", OrderType);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForList<UC_DownLoad>("UC_DownLoad.PageFindAll", ht);
        }
        /// <summary>
        /// 得到条数
        /// </summary>
        public int FindAll(string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_DownLoad");
            ht.Add("fldName", "ID");
            ht.Add("PageSize", 0);
            ht.Add("PageIndex", 0);
            ht.Add("IsCount", 1);
            ht.Add("OrderType", 1);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForObject<int>("UC_DownLoad.PageFindAllCount", ht);
        }
        /// <summary>
        /// 得到Datatable
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string strWhere)
        {
            return ExecuteQueryForDataTable("UC_DownLoad.BaseSelect", strWhere);
        }

    }
}
