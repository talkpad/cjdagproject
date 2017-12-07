using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrbanConstruction.Model
{
    [Serializable]
    public class UC_Town
    {
         private int _companyid;
        private string _companyname;
        private string _username;
        private string _password;
        private string _address;
        private string _phone;
        private string _email;
        private int _ordering;
        private int _state;
        private DateTime _addtime;
        private string _synopsis;
        private string _weburl;
        ///<sumary>
        /// 
        ///</sumary>
        public int CompanyID
        {
            get { return _companyid; }
            set { _companyid = value; }
        }
        ///<sumary>
        /// 镇区全称
        ///</sumary>
        public string CompanyName
        {
            get { return _companyname; }
            set { _companyname = value; }
        }
        ///<sumary>
        /// 用户名
        ///</sumary>
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        ///<sumary>
        /// 用户密码
        ///</sumary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        ///<sumary>
        /// 地址
        ///</sumary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
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
        /// 邮箱
        ///</sumary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
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
        /// 状态
        ///</sumary>
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
        ///<sumary>
        /// 添加时间
        ///</sumary>
        public DateTime Addtime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }
        ///<sumary>
        /// 简介
        ///</sumary>
        public string Synopsis
        {
            get { return _synopsis; }
            set { _synopsis = value; }
        }
        ///<sumary>
        /// 网址
        ///</sumary>
        public string WebUrl
        {
            get { return _weburl; }
            set { _weburl = value; }
        }
    }
}
