using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrbanConstruction.Model
{
    [Serializable]
    public class UC_Video
    {
        private int _videoid;
        private string _videoname;
        private string _videourl;
        private DateTime _addtime;
        private int _state;
        private int _type;

        public int VideoID
        {
            get { return _videoid; }
            set { _videoid = value; }
        }
        public string VideoName
        {
            get { return _videoname; }
            set { _videoname = value; }
        }
        public string VideoURL
        {
            get { return _videourl; }
            set { _videourl = value; }
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
