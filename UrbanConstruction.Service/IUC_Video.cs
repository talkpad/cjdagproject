using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanConstruction.Model;

namespace UrbanConstruction.Service
{
    public interface IUC_Video
    {
        void Insert(UC_Video uc_video);
        void Update(UC_Video uc_video);
        UC_Video FindById(int ID);
        void Delete(int ID);
        IList<UC_Video> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere);
        IList<UC_Video> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere, string fildName);
        int FindAll(string strWhere);
    }
}
