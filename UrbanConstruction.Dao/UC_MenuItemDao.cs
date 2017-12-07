using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanConstruction.Service;
using UrbanConstruction.Model;
using System.Collections;

namespace UrbanConstruction.Dao
{
    public class UC_MenuItemDao : BaseSqlMapDao, IUC_MenuItem
    {

        /// <summary>
        /// 得到列表
        /// </summary>
        public IList<UC_MenuItem> GetFindByIdList()
        {
            return ExecuteQueryForList<UC_MenuItem>("UC_MenuItem.Select", null);
        }
        /// <summary>
        /// 新建
        /// </summary>
        public void Insert(UC_MenuItem uc_menuitem)
        {
            //int id = GetId("T_MenuItem");
            //t_menuitem.M_ItemID = id;

            ExecuteInsert("UC_MenuItem.Insert", uc_menuitem);
        }
        /// <summary>
        /// 修改
        /// </summary>
        public void Update(UC_MenuItem uc_menuitem)
        {
            ExecuteUpdate("UC_MenuItem.Update", uc_menuitem);
        }

        /// <summary>
        /// 得到明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UC_MenuItem FindById(System.Int32 M_ItemID)
        {
            return ExecuteQueryForObject<UC_MenuItem>("UC_MenuItem.Select", M_ItemID);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void Delete(System.Int32 M_ItemID)
        {
            ExecuteDelete("UC_MenuItem.Delete", M_ItemID);
        }
        public IList<UC_MenuItem> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_MenuItem");
            ht.Add("fldName", "M_ItemID");
            ht.Add("PageSize", PageSize);
            ht.Add("PageIndex", PageIndex);
            ht.Add("IsCount", 0);
            ht.Add("OrderType", OrderType);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForList<UC_MenuItem>("UC_MenuItem.PageFindAll", ht);
        }
        /// <summary>
        /// 获取对象列表
        /// </summary>
        public IList<UC_MenuItem> GetAllList(string strWhere)
        {
            Hashtable ht = null;
            if (!string.IsNullOrEmpty(strWhere))
            {
                ht = new Hashtable();
                ht["strWhere"] = strWhere;
            }

            return ExecuteQueryForList<UC_MenuItem>("UC_MenuItem.GetAllList", ht);
        }

        /// <summary>
        /// 得到列表,分页
        /// </summary>
        public IList<UC_MenuItem> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere, string OrderfldName)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_MenuItem");
            ht.Add("fldName", OrderfldName);
            ht.Add("PageSize", PageSize);
            ht.Add("PageIndex", PageIndex);
            ht.Add("IsCount", 0);
            ht.Add("OrderType", OrderType);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForList<UC_MenuItem>("UC_MenuItem.PageFindAll", ht);
        }
        /// <summary>
        /// 得到条数
        /// </summary>
        public int FindAll(string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_MenuItem");
            ht.Add("fldName", "M_ItemID");
            ht.Add("PageSize", 0);
            ht.Add("PageIndex", 0);
            ht.Add("IsCount", 1);
            ht.Add("OrderType", 1);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForObject<int>("UC_MenuItem.PageFindAllCount", ht);
        }
    }
}
