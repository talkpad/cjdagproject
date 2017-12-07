using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrbanConstruction.Model
{
    [Serializable]
    public class UC_DownLoad
    {
        private int _id;
        private int _m_itemid;
        private int _m_id;
		private string _filename;
		private DateTime _addtime;
		private string _remark;
		private int _state;
        private string _filefact;
		
		///<sumary>
		/// 
		///</sumary>
		public int ID
		{
			get{return _id;}
			set{_id = value;}
		}
        ///<sumary>
        /// 
        ///</sumary>
        public int M_ItemID
        {
            get { return _m_itemid; }
            set { _m_itemid = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public int M_ID
        {
            get { return _m_id; }
            set { _m_id = value; }
        }
		///<sumary>
		/// 文件名称
		///</sumary>
		public string FileName
		{
			get{return _filename;}
			set{_filename = value;}
		}
		///<sumary>
		/// 添加时间
		///</sumary>
		public DateTime AddTime
		{
			get{return _addtime;}
			set{_addtime = value;}
		}
		///<sumary>
		/// 备注
		///</sumary>
		public string Remark
		{
			get{return _remark;}
			set{_remark = value;}
		}
		///<sumary>
		/// 状态
		///</sumary>
		public int State
		{
			get{return _state;}
			set{_state = value;}
        }
        ///<sumary>
        /// 文件路径
        ///</sumary>
        public string FileFact
        {
            get { return _filefact; }
            set { _filefact = value; }
        }
    }
}
