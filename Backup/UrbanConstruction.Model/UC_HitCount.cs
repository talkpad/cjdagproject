using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrbanConstruction.Model
{  
    [Serializable]
    public class UC_HitCount
    {
        private int _id;
        private int _count;
        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 点击率
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
    }
}
