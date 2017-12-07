using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanConstruction.Model;

namespace UrbanConstruction.Service
{
    public interface IUC_Guestbook
    {
        void Insert(UC_Guestbook uc_message);
        void Update(UC_Guestbook uc_message);
        UC_Guestbook FindById(int ID);
        void Delete(int ID);
        IList<UC_Guestbook> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere);
        IList<UC_Guestbook> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere, string fildName);
        int FindAll(string strWhere);
        void Examine(UC_Guestbook uc_message);
        IList<UC_Guestbook> GetAllList(string strWhere);
        List<UC_Guestbook> GetList();
    }
}
