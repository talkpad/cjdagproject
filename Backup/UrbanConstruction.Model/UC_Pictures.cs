using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrbanConstruction.Model
{
    [Serializable]
    public class UC_Pictures
    {
        private int _pictureid;
        private string _picturename;
        private string _pictureurl;
        private DateTime _addtime;
        private int _state;
        private int _type;

        public int PictureID
        {
            get { return _pictureid; }
            set { _pictureid = value; }
        }
        public string PictureName
        {
            get { return _picturename; }
            set { _picturename = value; }
        }
        public string PictureURL
        {
            get { return _pictureurl; }
            set { _pictureurl = value; }
        }
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
        public int Type     
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
