using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrbanConstruction.Model
{
    [Serializable]
    public class UC_User
    {
        private int _userid;
        private string _userhao;
        private string _username;
        private string _password;
        private int _usertype;
        private int _state;

        ///<sumary>
        /// 
        ///</sumary>
        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// 用户帐号
        /// </summary>
        public string UserHao
        {
            get { return _userhao; }
            set { _userhao = value; }
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
        /// 密码
        ///</sumary>
        public string PassWord
        {
            get { return _password; }
            set { _password = value; }
        }
        ///<sumary>
        /// 用户类型
        ///</sumary>
        public int UserType
        {
            get { return _usertype; }
            set { _usertype = value; }
        }
        ///<sumary>
        /// 状态
        ///</sumary>
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
    }
}
