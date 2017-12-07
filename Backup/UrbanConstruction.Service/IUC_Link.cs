using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanConstruction.Model;

namespace UrbanConstruction.Service
{
    public interface IUC_Link
    {
        void Insert(UC_Link uc_link);
        void Update(UC_Link uc_link);
        UC_Link FindById(int ID);
        void Delete(int ID);
        IList<UC_Link> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere);
        int FindAll(string strWhere);
    }
}
