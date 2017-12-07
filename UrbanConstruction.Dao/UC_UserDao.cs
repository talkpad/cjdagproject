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
    public class UC_UserDao : BaseSqlMapDao, IUC_User
    {
        public UC_UserDao()
        {
            //
            // TODO: 此处添加T_UserSqlMapDao的构造函数
            //
        }

        /// <summary>
        /// 得到列表
        /// </summary>
        public IList<UC_User> GetUC_UserList()
        {
            return ExecuteQueryForList<UC_User>("Select", null);
        }

        /// <summary>
        /// 新建
        /// </summary>
        public void Insert(UC_User t_user)
        {

            ExecuteInsert("UC_User.Insert", t_user);
        }
        /// <summary>
        /// 得到明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UC_User FindById(int ID)
        {
            return ExecuteQueryForObject<UC_User>("UC_User.FindById", ID);
        }
        public UC_User FindByName(string name)
        {
            return ExecuteQueryForObject<UC_User>("UC_User.FindByName", name);
        }
        /// <summary>
        /// 修改
        /// </summary>
        public void Update(UC_User t_user)
        {
            ExecuteUpdate("UC_User.Update", t_user);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int ID)
        {
            ExecuteDelete("UC_User.Delete", ID);
        }
        /// <summary>
        /// 得到列表,分页
        /// </summary>
        public IList<UC_User> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_User");
            ht.Add("fldName", "UserID");
            ht.Add("PageSize", PageSize);
            ht.Add("PageIndex", PageIndex);
            ht.Add("IsCount", 0);
            ht.Add("OrderType", OrderType);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForList<UC_User>("UC_User.PageFindAll", ht);
        }
        /// <summary>
        /// 得到条数
        /// </summary>
        public int FindAll(string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_User");
            ht.Add("fldName", "UserID");
            ht.Add("PageSize", 0);
            ht.Add("PageIndex", 0);
            ht.Add("IsCount", 1);
            ht.Add("OrderType", 1);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForObject<int>("UC_User.PageFindAllCount", ht);
        }
        /// <summary>
        /// 得到Datatable
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string strWhere)
        {
            return ExecuteQueryForDataTable("UC_User.BaseSelect", strWhere);
        }

    }
}
