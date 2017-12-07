using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrbanConstruction.Model
{
    [Serializable]
    public class UC_Menu
    {
        private int _m_id;
        private string _m_name;
        private int _is_menu;
        private int _ordering;
        private int _status;
        private string _url;
        private int _ispulldown;

        ///<sumary>
        /// 
        ///</sumary>
        public int M_ID
        {
            get { return _m_id; }
            set { _m_id = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string M_NAME
        {
            get { return _m_name; }
            set { _m_name = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public int Is_Menu
        {
            get { return _is_menu; }
            set { _is_menu = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public int Ordering
        {
            get { return _ordering; }
            set { _ordering = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        public int ParentId { get; set; }
        public int IsPulldown
        {
            get { return _ispulldown; }
            set { _ispulldown = value; }
        }
    }
}
