using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanConstruction.Service;
using UrbanConstruction.Model;
using System.Collections;

namespace UrbanConstruction.Dao
{
    public class UC_VideoDao : BaseSqlMapDao, IUC_Video
    {
        /// <summary>
        /// 新建
        /// </summary>
        public void Insert(UC_Video uc_video)
        {

            ExecuteInsert("UC_Video.Insert", uc_video);
        }
        /// <summary>
        /// 修改
        /// </summary>
        public void Update(UC_Video uc_video)
        {
            ExecuteUpdate("UC_Video.Update", uc_video);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Delete(int id)
        {
            ExecuteDelete("UC_Video.Delete", id);
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UC_Video FindById(int id)
        {
            return ExecuteQueryForObject<UC_Video>("UC_Video.FindById", id);
        }

        /// <summary>
        /// 得到列表,分页
        /// </summary>
        public IList<UC_Video> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere, string fldName)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_Video");
            ht.Add("fldName", fldName);
            ht.Add("PageSize", PageSize);
            ht.Add("PageIndex", PageIndex);
            ht.Add("IsCount", 0);
            ht.Add("OrderType", OrderType);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForList<UC_Video>("UC_Video.PageFindAll", ht);
        }
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="OrderType"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public IList<UC_Video> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_Video");
            ht.Add("fldName", "AddTime");
            ht.Add("PageSize", PageSize);
            ht.Add("PageIndex", PageIndex);
            ht.Add("IsCount", 0);
            ht.Add("OrderType", OrderType);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForList<UC_Video>("UC_Video.PageFindAll", ht);
        }
        public int FindAll(string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tblName", "UC_Video");
            ht.Add("fldName", "AddTime");
            ht.Add("PageSize", 0);
            ht.Add("PageIndex", 0);
            ht.Add("IsCount", 1);
            ht.Add("OrderType", 1);
            ht.Add("strWhere", strWhere);
            return ExecuteQueryForObject<int>("UC_Video.PageFindAllCount", ht);
        }
    }
}
