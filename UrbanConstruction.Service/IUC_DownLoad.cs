using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanConstruction.Model;

namespace UrbanConstruction.Service
{
    public interface IUC_DownLoad
    {
        void Insert(UC_DownLoad uc_download);
        void Update(UC_DownLoad uc_download);
        /// <summary>
        /// 通过M_ItemID,修改的M_ID
        /// </summary>
        /// <param name="t_download"></param>
        void BatchUpdate(UC_DownLoad uc_download);
        UC_DownLoad FindById(int ID);
        void Delete(int ID);
        IList<UC_DownLoad> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere);
        IList<UC_DownLoad> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere, string fildName);
        IList<UC_DownLoad> FindAllByTime(int PageSize, int PageIndex, int OrderType, string strWhere);
        int FindAll(string strWhere);
        IList<UC_DownLoad> GetList(int Num, string strWhere);
        IList<UC_DownLoad> GetAllList(string strWhere);
    }
}
