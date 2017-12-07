using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanConstruction.Service;
using UrbanConstruction.Model;
using System.Collections;

namespace UrbanConstruction.Dao
{
    class UC_TownDao : BaseSqlMapDao, IUC_Town
    {
        /// <summary>
        /// 得到列表
        /// </summary>
        public IList<UC_Town> GetList()
        {
            return ExecuteQueryForList<UC_Town>("UC_Town.Select", null);
        }

        /// <summary>
        /// 新建
        /// </summary>
        public void Insert(UC_Town uc_town)
        {
            ExecuteInsert("UC_Town.Insert", uc_town);
        }
        /// <summary>
        /// 修改
        /// </summary>
        public void Update(UC_Town uc_town)
        {
            ExecuteUpdate("UC_Town.Update", uc_town);
        }

        /// <summary>
        /// 得到明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UC_Town FindById(System.Int32 CompanyID)
        {
            return ExecuteQueryForObject<UC_Town>("UC_Town.Select", CompanyID);
        }
        /// <summary>
        /// 得到明细
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public UC_Town FindByName(string Name)
        {
            return ExecuteQueryForObject<UC_Town>("UC_Town.FindByName", Name);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void Delete(System.Int32 CompanyID)
        {
            ExecuteDelete("UC_Town.Delete", CompanyID);
        }

        /// <summary>
        /// 翻页查询
        /// </summary>
        /// <param name="PageSize">每页笔数</param>
        /// <param name="PageIndex">当前页从1开始</param>
        /// <param name="OrderType">排序方向，0 升序；1 降序</param>
        /// <param name="strWhere">查询条件</param>
        public IList<UC_Town> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_Town");
            ht.Add("fldName", "CompanyID");
            ht.Add("PageSize", PageSize);
            ht.Add("PageIndex", PageIndex);
            ht.Add("IsCount", 0);
            ht.Add("OrderType", OrderType);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForList<UC_Town>("UC_Town.PageFindAll", ht);
        }
        /// <summary>
        /// 翻页查询笔数
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        public int FindAll(string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_Town");
            ht.Add("fldName", "ordering");
            ht.Add("PageSize", 0);
            ht.Add("PageIndex", 0);
            ht.Add("IsCount", 1);
            ht.Add("OrderType", 1);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForObject<int>("UC_Town.PageFindAllCount", ht);
        }
        /// <summary>
        /// 翻页查询
        /// </summary>
        /// <param name="PageSize">每页笔数</param>
        /// <param name="PageIndex">当前页从1开始</param>
        /// <param name="OrderType">排序方向，0 升序；1 降序</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="fldName">查询排序栏位名称</param>
        public IList<UC_Town> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere, string fldName)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_Town");
            ht.Add("fldName", fldName);
            ht.Add("PageSize", PageSize);
            ht.Add("PageIndex", PageIndex);
            ht.Add("IsCount", 0);
            ht.Add("OrderType", OrderType);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForList<UC_Town>("UC_Town.PageFindAll", ht);
        }
        /// <summary>
        /// 翻页查询笔数
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="fldName">查询排序栏位名称</param>
        public int FindAll(string strWhere, string fldName)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_Town");
            ht.Add("fldName", fldName);
            ht.Add("PageSize", 0);
            ht.Add("PageIndex", 0);
            ht.Add("IsCount", 1);
            ht.Add("OrderType", 1);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForObject<int>("UC_Town.PageFindAllCount", ht);
        }
    }
}
