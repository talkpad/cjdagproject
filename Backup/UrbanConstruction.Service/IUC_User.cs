using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanConstruction.Model;

namespace UrbanConstruction.Service
{
    public interface IUC_User
    {
        void Insert(UC_User t_user);
        UC_User FindById(int ID);
        UC_User FindByName(string name);
        void Update(UC_User uc_user);
        void Delete(int ID);
        IList<UC_User> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere);
        int FindAll(string strWhere);
    }
}
