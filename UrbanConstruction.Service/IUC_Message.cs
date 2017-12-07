using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanConstruction.Model;

namespace UrbanConstruction.Service
{
     public interface IUC_Message
    {
        void Insert(UC_Message uc_message);
        void Update(UC_Message uc_message);
        UC_Message FindById(int ID);
        void Delete(int ID);
        IList<UC_Message> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere);
        IList<UC_Message> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere, string fildName);
        int FindAll(string strWhere);
        void Examine(UC_Message uc_message);
        IList<UC_Message> GetList(int Num, string strWhere);
        IList<UC_Message> GetAllList(string strWhere);
    }
}
