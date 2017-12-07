using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrbanConstruction.Model
{
      [Serializable]
    public class UC_Guestbook
    {
        private int _id;
        private string _title;
        private string _content;
        private int _cateid;
        private string _name;
        private int _sex;
        private int _other;
        private string _address;
        private DateTime _postdate;
        private string _ip;
        private string _email;
        private string _phone;
        private string _number;
        private DateTime _writebackdate;
        private string _writecontent;
        private string _writebackuser;
        private int _state;
        private string _icon;
        private char _is_sendemail;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
     
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
 
        public int CateID
        {
            get { return _cateid; }
            set { _cateid = value; }
        }
      
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }

        public DateTime PostDate
        {
            get { return _postdate; }
            set { _postdate = value; }
        }

        public DateTime WriteBackDate
        {
            get { return _writebackdate; }
            set { _writebackdate = value; }
        }

        public int Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public int Other
        {
            get { return _other; }
            set { _other = value; }
        }

        public string IP
        {
            get { return _ip; }
            set { _ip = value; }
        }

        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public string WriteContent
        {
            get { return _writecontent; }
            set { _writecontent = value; }
        }

        public string WriteBackUser
        {
            get { return _writebackuser; }
            set { _writebackuser = value; }
        }

        public string Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        public char Is_SendEmail
        {
            get { return _is_sendemail; }
            set { _is_sendemail = value; }
        }
    }
}
