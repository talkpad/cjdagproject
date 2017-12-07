using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanConstruction.Service;
using UrbanConstruction.Model;
using System.Collections;

namespace UrbanConstruction.Dao
{
    public class UC_MenuDao : BaseSqlMapDao, IUC_Menu
    {
        /// <summary>
        /// 得到列表
        /// </summary>
        public IList<UC_Menu> GetFindByIdList()
        {
            return ExecuteQueryForList<UC_Menu>("UC_Menu.Select", null);
        }
        public IList<UC_Menu> GetFindWhere(string strWhere)
        {
            return ExecuteQueryForList<UC_Menu>("UC_Menu.SelectByParent", strWhere);
        }

        /// <summary>
        /// 新建
        /// </summary>
        public void Insert(UC_Menu uc_menu)
        {
            //int id = GetId("T_Menu");
            //t_menu.M_ID = id;

            ExecuteInsert("UC_Menu.Insert", uc_menu);
        }
        /// <summary>
        /// 修改
        /// </summary>
        public void Update(UC_Menu uc_menu)
        {
            ExecuteUpdate("UC_Menu.Update", uc_menu);
        }

        /// <summary>
        /// 得到明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UC_Menu FindById(System.Int32 M_ID)
        {
            return ExecuteQueryForObject<UC_Menu>("UC_Menu.Select", M_ID);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void Delete(System.Int32 M_ID)
        {
            ExecuteDelete("UC_Menu.Delete", M_ID);
        }
        /// <summary>
        /// 得到列表,分页
        /// </summary>
        public IList<UC_Menu> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_Menu");
            ht.Add("fldName", "M_ID");
            ht.Add("PageSize", PageSize);
            ht.Add("PageIndex", PageIndex);
            ht.Add("IsCount", 0);
            ht.Add("OrderType", OrderType);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForList<UC_Menu>("UC_Menu.PageFindAll", ht);
        }
        /// <summary>
        /// 得到列表,分页
        /// </summary>
        public IList<UC_Menu> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere, string orderfldName)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_Menu");
            ht.Add("fldName", orderfldName);
            ht.Add("PageSize", PageSize);
            ht.Add("PageIndex", PageIndex);
            ht.Add("IsCount", 0);
            ht.Add("OrderType", OrderType);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForList<UC_Menu>("UC_Menu.PageFindAll", ht);
        }

        /// <summary>
        /// 得到条数
        /// </summary>
        public int FindAll(string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_Menu");
            ht.Add("fldName", "M_ID");
            ht.Add("PageSize", 0);
            ht.Add("PageIndex", 0);
            ht.Add("IsCount", 1);
            ht.Add("OrderType", 1);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForObject<int>("UC_Menu.PageFindAllCount", ht);
        }

    }
}
