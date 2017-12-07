using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrbanConstruction.Model
{  
    [Serializable]
    public class UC_Link
    {
        private int _linkid;
        private string _linkname;
        private string _linkurl;
        private DateTime _addtime;
        private int _state;
        private int _sort;

        ///<sumary>
        /// 
        ///</sumary>
        public int LinkID
        {
            get { return _linkid; }
            set { _linkid = value; }
        }
        ///<sumary>
        /// 友情链接名称
        ///</sumary>
        public string LinkName
        {
            get { return _linkname; }
            set { _linkname = value; }
        }
        ///<sumary>
        /// 友情链接地址
        ///</sumary>
        public string LinkURL
        {
            get { return _linkurl; }
            set { _linkurl = value; }
        }
        ///<sumary>
        /// 添加时间
        ///</sumary>
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }
        ///<sumary>
        /// 状态
        ///</sumary>
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
        ///<sumary>
        /// 排序
        ///</sumary>
        public int Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }
    }
}
