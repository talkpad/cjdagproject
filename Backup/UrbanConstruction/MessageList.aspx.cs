using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Text;
using UrbanConstruction.Service;
using UrbanConstruction.Component;
using System.Web.UI.MobileControls;
using System.Collections.Generic;
using UrbanConstruction.Model;

namespace UrbanConstruction
{
    public partial class MessageList : BasePage
    {
        //protected int RescordCount = 0;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                int kind;
                if (Request.QueryString["pageIndex"] != null)
                {
                    if (int.TryParse(Request["pageIndex"], out kind) == false)
                    {
                        Response.Redirect("Error.htm");
                    }
                    else
                        Bind();
                }
                else
                    Bind();
            }
        }

        public int pageIndex = 1;
        public int pageCount = 0;
        public List<IUC_Guestbook> newsList = null;
        //public int videotype = 0;
        public void Bind()
        {
            //videotype = (int)EnumType.NewsType.视频;
            //获取新闻
            IUC_Guestbook idal = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_GuestbookDaoService"] as IUC_Guestbook;
            if (Request.QueryString["pageIndex"] != null)
            {
                pageIndex = int.Parse(Request.QueryString["pageIndex"]);
            }
            this.GridView1.DataSource = idal.FindAll(10, pageIndex, 1, string.Format(" (WriteContent is not null) and state={0}", (int)EnumType.StateType.已审核), "ID").ToList();
            this.GridView1.DataBind();
            int Count = idal.FindAll(string.Format("(WriteContent is not null) and state={0}", (int)EnumType.StateType.已审核));
            pageCount = (int)Math.Ceiling((double)Count / 10);
            if (pageCount == 0)
                pageIndex = 0;
        }
        public void BandGridData()
        {
            //StringBuilder sb = new StringBuilder();
            //sb.Append("State=1 and (WriteContent is not null)");

            //if (!string.IsNullOrEmpty(tbDate1.Text.Trim()))
            //    sb.Append(" and PostDate>='" + tbDate1.Text.Trim() + "'");

            //if (!string.IsNullOrEmpty(tbDate2.Text.Trim()))
            //    sb.Append(" and PostDate<='" + tbDate2.Text.Trim() + "'");

            //this.RescordCount = imessage.FindAll(sb.ToString());
        }
    }
}

