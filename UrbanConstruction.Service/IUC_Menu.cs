using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanConstruction.Model;

namespace UrbanConstruction.Service
{
     public interface IUC_Menu
    {  
        IList<UC_Menu> GetFindByIdList();
   
        UC_Menu FindById(int id);
        void Update(UC_Menu uc_menu);
        void Insert(UC_Menu uc_menu);
        IList<UC_Menu> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere, string orderfldName);
        IList<UC_Menu> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere);
        int FindAll(string strWhere);
        IList<UC_Menu> GetFindWhere(string strWhere);
        
    }
}
