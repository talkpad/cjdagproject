using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanConstruction.Model;

namespace UrbanConstruction.Service
{
     public interface IUC_Pictures
    {
         void Insert(UC_Pictures uc_pictures);
         void Update(UC_Pictures uc_pictures);
         UC_Pictures FindById(int ID);
        void Delete(int ID);
        IList<UC_Pictures> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere);
        IList<UC_Pictures> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere, string fildName);
        int FindAll(string strWhere);
        IList<UC_Pictures> GetAllList(string strWhere);
        IList<UC_Pictures> GetList(int Num, string strWhere);
    }
}
