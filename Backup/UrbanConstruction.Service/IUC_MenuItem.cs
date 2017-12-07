using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanConstruction.Model;

namespace UrbanConstruction.Service
{
     public interface IUC_MenuItem
    {
        IList<UC_MenuItem> GetFindByIdList();
        UC_MenuItem FindById(int id);
        void Update(UC_MenuItem uc_menuItem);
        void Insert(UC_MenuItem uc_menuItem);
        IList<UC_MenuItem> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere);
        IList<UC_MenuItem> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere, string OrderingFldName);
        IList<UC_MenuItem> GetAllList(string strWhere);
        int FindAll(string strWhere);
    }
}
