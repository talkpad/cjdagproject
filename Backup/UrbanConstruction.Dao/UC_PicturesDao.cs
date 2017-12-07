using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanConstruction.Service;
using UrbanConstruction.Model;
using System.Collections;

namespace UrbanConstruction.Dao
{
    public class UC_PicturesDao : BaseSqlMapDao, IUC_Pictures
    {
        /// <summary>
        /// 新建
        /// </summary>
        public void Insert(UC_Pictures uc_pictures)
        {

            ExecuteInsert("UC_Pictures.Insert", uc_pictures);
        }   
        /// <summary>
        /// 获取对象列表
        /// </summary>
        public IList<UC_Pictures> GetList(int Num, string strWhere)
        {
            Hashtable ht = null;
            if (!string.IsNullOrEmpty(strWhere))
            {
                ht = new Hashtable();
                ht["strWhere"] = strWhere;
            }
            ht["strNum"] = Num;

            return ExecuteQueryForList<UC_Pictures>("UC_Pictures.GetList", ht);
        }
        /// <summary>
        /// 获取对象列表
        /// </summary>
        public IList<UC_Pictures> GetAllList(string strWhere)
        {
            Hashtable ht = null;
            if (!string.IsNullOrEmpty(strWhere))
            {
                ht = new Hashtable();
                ht["strWhere"] = strWhere;
            }

            return ExecuteQueryForList<UC_Pictures>("UC_Pictures.GetAllList", ht);
        }
        /// <summary>
        /// 修改
        /// </summary>
        public void Update(UC_Pictures uc_pictures)
        {
            ExecuteUpdate("UC_Pictures.Update", uc_pictures);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Delete(int id)
        {
            ExecuteDelete("UC_Pictures.Delete", id);
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UC_Pictures FindById(int id)
        {
            return ExecuteQueryForObject<UC_Pictures>("UC_Pictures.FindById", id);
        }
        /// <summary>
        /// 得到列表,分页
        /// </summary>
        public IList<UC_Pictures> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere, string fldName)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_Pictures");
            ht.Add("fldName", fldName);
            ht.Add("PageSize", PageSize);
            ht.Add("PageIndex", PageIndex);
            ht.Add("IsCount", 0);
            ht.Add("OrderType", OrderType);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForList<UC_Pictures>("UC_Pictures.PageFindAll", ht);
        }
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="OrderType"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public IList<UC_Pictures> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_Pictures");
            ht.Add("fldName", "AddTime");
            ht.Add("PageSize", PageSize);
            ht.Add("PageIndex", PageIndex);
            ht.Add("IsCount", 0);
            ht.Add("OrderType", OrderType);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForList<UC_Pictures>("UC_Pictures.PageFindAll", ht);
        }
        /// <summary>
        /// 得到条数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int FindAll(string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_Pictures");
            ht.Add("fldName", "AddTime");
            ht.Add("PageSize", 0);
            ht.Add("PageIndex", 0);
            ht.Add("IsCount", 1);
            ht.Add("OrderType", 1);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForObject<int>("UC_Pictures.PageFindAllCount", ht);
        }
    }
}
