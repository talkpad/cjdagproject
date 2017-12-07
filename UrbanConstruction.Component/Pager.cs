using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace UrbanConstruction.Component
{
    public class Pager
    { 
        #region 成员变量
        private int _PageSize;
        private int _RecordCount;
        private int _CurrentPageIndex;
        private int _Offset;//偏移量

        private ArrayList _Urls;
        #endregion

        #region 属性

        public int PageSize
        {
            get
            {
                return _PageSize;
            }
            set
            {
                _PageSize = value;
            }
        }

        public int RecordCount
        {
            get
            {
                return _RecordCount;
            }
            set
            {
                _RecordCount = value;
            }
        }

        public int CurrentPageIndex
        {
            get
            {
                return _CurrentPageIndex;
            }
            set
            {
                _CurrentPageIndex = value;
            }
        }

        public ArrayList Urls
        {
            get
            {
                return _Urls;
            }
        }

        private string keyword;

        public string Keyword
        {
            set { keyword = value; }
        }

        private string advsearch;
        public string Advsearch  
        {
            set { advsearch = value; }
        }   
        private string m_id;

        public string M_Id
        {
            set { m_id = value; }
        }

        private string m_itemid;

        public string M_Itemid
        {
            set { m_itemid = value; }
        }

        private string sort;

        public string Sort
        {
            set { sort = value; }
        }
        #endregion

        #region 方法
        public Pager()
        {
            _Offset = 10;
            _CurrentPageIndex = 1;
        }
        private void CreateUrls()
        {
            if (_PageSize == 0)
            {
                //new Exception("请设置每页显示记录数！");
                _PageSize = 10;//默认10条

            }
            _Urls = new ArrayList();
            int crrentPageIndex = _CurrentPageIndex;
            int startNum = 0;
            int endNum = 0;
            if (_CurrentPageIndex <= _Offset)//偏移量为10
            {
                startNum = 1;
            }
            else
            {
                startNum = _CurrentPageIndex - _Offset;
            }
            endNum = _CurrentPageIndex + _Offset - 1;//以后可能需要修改；因为限于查出来的总页
            if (endNum > (int)Math.Ceiling((double)_RecordCount / (double)_PageSize))
            {
                endNum = (int)Math.Ceiling((double)_RecordCount / (double)_PageSize);//有余数就加1
            }

            for (int i = startNum; i <= endNum; i++)
            {
                _Urls.Add(i);
            }
        }
        public void DataBind()
        {
            CreateUrls();
        }

        public string Show()
        {
            CreateUrls();
            StringBuilder sb = new StringBuilder();
            if (_CurrentPageIndex > 1)
            {
                int index = _CurrentPageIndex - 1;
                sb.Append("<a href='?advsearch=" + advsearch + "&keyword=" + keyword + "&m_id=" + m_id + "&m_itemid=" + m_itemid + "&sort=" + sort + "&PageIndex=" + index + "'>上一页</a>");
            }
            foreach (int pageIndex in Urls)
            {
                if (_CurrentPageIndex == pageIndex)
                {//当前选中页

                    sb.Append("&nbsp;<font color='red'>" + pageIndex + "</font>");
                }
                else
                {//其他没被选中的页码

                    sb.Append("&nbsp;<a href='?advsearch=" + advsearch + "&keyword=" + keyword + "&m_id=" + m_id + "&m_itemid=" + m_itemid + "&sort=" + sort + "&PageIndex=" + pageIndex + "'>[" + pageIndex + "]</a>");
                }
            }
            int pageCount = (int)Math.Ceiling((double)_RecordCount / (double)_PageSize);
            if (_CurrentPageIndex < pageCount)
            {
                int index = _CurrentPageIndex + 1;
                sb.Append("&nbsp;<a href='?advsearch=" + advsearch + "&keyword=" + keyword + "&m_id=" + m_id + "&m_itemid=" + m_itemid + "&sort=" + sort + "&PageIndex=" + index + "'>下一页</a>");
            }

            return sb.ToString();
        }

        #endregion

    }
}
