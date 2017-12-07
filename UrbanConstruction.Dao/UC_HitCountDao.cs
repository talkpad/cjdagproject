using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanConstruction.Service;
using UrbanConstruction.Model;

namespace UrbanConstruction.Dao
{
    public class UC_HitCountDao : BaseSqlMapDao, IUC_HitCount
    {
        public IList<UC_HitCount> GetFindByIdList()
        {
            return ExecuteQueryForList<UC_HitCount>("UC_HitCount.FindById", null);
        }
        public UC_HitCount FindById(int id)
        {
            return ExecuteQueryForObject<UC_HitCount>("UC_HitCount.FindById", id);
        }
        public void Update(UC_HitCount uc_hitCount)
        {
            ExecuteUpdate("UC_HitCount.Update", uc_hitCount);
        }
        public void Insert(UC_HitCount uc_hitCount)
        {
            ExecuteInsert("UC_HitCount.Insert", uc_hitCount);
        }
    }
}
