using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanConstruction.Model;

namespace UrbanConstruction.Service
{
     public interface IUC_NewsList
     {
         void Insert(UC_NewsList uc_newsinformation);
         void Update(UC_NewsList uc_newsinformation);
         /// <summary>
         /// 通过M_ItemID,修改的M_ID
         /// </summary>
         /// <param name="t_newsinformation"></param>
         void BatchUpdate(UC_NewsList uc_newsinformation);
         UC_NewsList FindById(int ID);
         void Delete(int ID);
         IList<UC_NewsList> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere);
         IList<UC_NewsList> FindAll(int PageSize, int PageIndex, int OrderType, string strWhere, string fildName);
         int FindAll(string strWhere);
         void Examine(UC_NewsList uc_newsinformation);
         IList<UC_NewsList> GetList(int Num, string strWhere);
         IList<UC_NewsList> GetAllList(string strWhere);
    }
}
