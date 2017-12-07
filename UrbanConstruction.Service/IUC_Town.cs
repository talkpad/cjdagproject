using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanConstruction.Model;

namespace UrbanConstruction.Service
{
    public interface IUC_Town
    {

        /// <summary>
        /// 得到列表
        /// </summary>
        IList<UC_Town> GetList();


        /// <summary>
        /// 新建
        /// </summary>
        void Insert(UC_Town uc_town);

        /// <summary>
        /// 修改
        /// </summary>
        void Update(UC_Town uc_town);


        /// <summary>
        /// 得到明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UC_Town FindById(System.Int32 CompanyID);

        UC_Town FindByName(string Name);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        void Delete(System.Int32 CompanyID);



        /// <summary>
        /// 翻页查询
        /// </summary>
        /// <param name="PageSize">每页笔数</param>
        /// <param name="PageIndex">当前页从1开始</param>
        /// <param name="OrderType">排序方向，0 升序；1 降序</param>
        /// <param name="strWhere">查询条件</param>
        IList<UC_Town> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere);
        /// <summary>
        /// 翻页查询笔数
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        int FindAll(string strWhere);


        /// <summary>
        /// 翻页查询
        /// </summary>
        /// <param name="PageSize">每页笔数</param>
        /// <param name="PageIndex">当前页从1开始</param>
        /// <param name="OrderType">排序方向，0 升序；1 降序</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="fldName">查询排序栏位名称</param>
        IList<UC_Town> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere, string fldName);
        /// <summary>
        /// 翻页查询笔数
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="fldName">查询排序栏位名称</param>
        int FindAll(string strWhere, string fldName);
    }
}