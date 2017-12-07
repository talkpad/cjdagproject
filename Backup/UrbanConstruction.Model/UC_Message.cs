using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrbanConstruction.Model
{
    [Serializable]
    public class UC_Message
    {
        private int _messageid;
        private string _name;
        private string _email;
        private string _phone;
        private string _title;
        private string _content;
        private string _answer;
        private int _state;
        private DateTime _addtime;
        private DateTime _answertime;
        private int _type;
        private string _address;

        ///<sumary>
        /// 
        ///</sumary>
        public int MessageID
        {
            get { return _messageid; }
            set { _messageid = value; }
        }
        ///<sumary>
        /// 留言者姓名
        ///</sumary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        ///<sumary>
        /// 邮箱
        ///</sumary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        ///<sumary>
        /// 电话
        ///</sumary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
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
        /// 类容
        ///</sumary>
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        ///<sumary>
        /// 回复
        ///</sumary>
        public string Answer
        {
            get { return _answer; }
            set { _answer = value; }
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
        /// 留言时间
        ///</sumary>
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }
        ///<sumary>
        /// 回复时间
        ///</sumary>
        public DateTime AnswerTime
        {
            get { return _answertime; }
            set { _answertime = value; }
        }
        ///<sumary>
        ///公开类型
        ///</sumary>
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
    }
}
