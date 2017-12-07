using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrbanConstruction.Model
{
    [Serializable]
     public class UC_NewsList
     {
         private int _id;
         private string _title;
         private string _content;
         private DateTime _releasetime;
         private string _source;
         private string _author;
         private string _updateusername;
         private int _m_id;
         private int _m_itemid;
         private string _pictures;
         private int _state;
         private int _hits;
         private string _pictureurl;
         private int _staytop;
         private int _type;
         private int _kind;
         private int _zngg;
        

         ///<sumary>
         /// 政务公开ID
         ///</sumary>
         public int ID
         {
             get { return _id; }
             set { _id = value; }
         }
         ///<sumary>
         /// 标题
         ///</sumary>
         public string Title
         {
             get { return _title; }
             set { _title = value; }
         }
         ///<sumary>
         /// 内容
         ///</sumary>
         public string Content
         {
             get { return _content; }
             set { _content = value; }
         }
         ///<sumary>
         /// 
         ///</sumary>
         public DateTime ReleaseTime
         {
             get { return _releasetime; }
             set { _releasetime = value; }
         }
         ///<sumary>
         /// 来源
         ///</sumary>
         public string Source
         {
             get { return _source; }
             set { _source = value; }
         }
         ///<sumary>
         /// 作者
         ///</sumary>
         public string Author
         {
             get { return _author; }
             set { _author = value; }
         }
         ///<sumary>
         /// 类型
         ///</sumary>
         public string UpdateUserName
         {
             get { return _updateusername; }
             set { _updateusername = value; }
         }
         ///<sumary>
         /// 点击率
         ///</sumary>
         public int Hits
         {
             get { return _hits; }
             set { _hits = value; }
         }
         ///<sumary>
         /// 子分类
         ///</sumary>
         public int M_ItemID
         {
             get { return _m_itemid; }
             set { _m_itemid = value; }
         }
         ///<sumary>
         /// 父类
         ///</sumary>
         public int M_ID
         {
             get { return _m_id; }
             set { _m_id = value; }
         }
         /// <summary>
         /// 是否审核
         /// </summary>
         public int State
         {
             get { return _state; }
             set { _state = value; }
         }
         /// <summary>
         /// 图片路径
         /// </summary>
         public string PictureURL
         {
             get { return _pictureurl; }
             set { _pictureurl = value; }
         }
         /// <summary>
         /// 图片
         /// </summary>
         public string Pictures
         {
             get { return _pictures; }
             set { _pictures = value; }
         }
      
         /// <summary>
         /// 置顶
         /// </summary>
         public int StayTop
         {
             get { return _staytop; }
             set { _staytop = value; }
         }
        /// <summary>
        /// 新闻类型
        /// </summary>
         public int Type
         {
             get { return _type; }
             set { _type = value; }
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
        /// 站内公告
        /// </summary>
         public int Zngg
         {
             get { return _zngg; }
             set { _zngg = value; }
         }
    }
}
