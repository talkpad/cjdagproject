using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrbanConstruction.Model
{
    [Serializable]
    public class UC_MenuItem
    {
        private int _m_itemid;
        private int _m_id;
        private string _m_itemname;
        private int _is_sysdata;
        private int _type;
        private int _status;
        private int _ordering;
        private string _url;
        private string _linkurl;
        private int _kind;
        private int _picturetype;
        private int _is_menu;
 

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
        /// 
        ///</sumary>
        public string M_ItemName
        {
            get { return _m_itemname; }
            set { _m_itemname = value; }
        }
        ///<sumary>
        /// 0 非系统预设菜单，允许修改；1-非系统预设菜单，不允许修改。
        ///</sumary>
        public int Is_SysData
        {
            get { return _is_sysdata; }
            set { _is_sysdata = value; }
        }
        ///<sumary>
        /// 1-普通新闻；2-图片新闻;3-文件下载
        ///</sumary>
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
        ///<sumary>
        /// 0-停用；1-启用
        ///</sumary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        ///<sumary>
        /// 显示排序
        ///</sumary>
        public int Ordering
        {
            get { return _ordering; }
            set { _ordering = value; }
        }
        ///<sumary>
        /// 默认url，由系统生成。
        ///</sumary>
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        ///<sumary>
        /// 嵌入页面链接url
        ///</sumary>
        public string LinkUrl
        {
            get { return _linkurl; }
            set { _linkurl = value; }
        }
        /// <summary>
        /// 新闻类别
        /// </summary>
        public int Kind
        {
            get { return _kind; }
            set { _kind = value; }
        }
        /// <summary>
        /// 图片类型
        /// </summary>
        public int PictureType
        {
            get { return _picturetype; }
            set { _picturetype = value; }
        }
        /// <summary>
        /// 是否是菜单
        /// </summary>
        public int Is_Menu
        {
            get { return _is_menu; }
            set { _is_menu = value; }
        }
    }
}
