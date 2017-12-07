using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanConstruction.Model;

namespace UrbanConstruction.Service
{
    public interface IUC_HitCount
    {
        IList<UC_HitCount> GetFindByIdList();
        UC_HitCount FindById(int id);
        void Update(UC_HitCount uc_hitCount);
        void Insert(UC_HitCount uc_hitCount);
    }
}
