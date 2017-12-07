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
using UrbanConstruction.Service;
using System.Collections.Generic;
using UrbanConstruction.Model;
using UrbanConstruction.Component;

namespace UrbanConstruction
{
    public partial class ResearchResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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
        public List<UC_NewsList> newsList = null;
        public int videotype = 0;
        public void Bind()
        {
            videotype = (int)EnumType.NewsType.视频;
            //获取新闻
            IUC_NewsList idal = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
            if (Request.QueryString["pageIndex"] != null)
            {
                pageIndex = int.Parse(Request.QueryString["pageIndex"]);
            }
            string newtype = "(" + (int)EnumType.NewsType.展览视频 + "," + (int)EnumType.NewsType.首页视频 + ")";
            newsList = idal.FindAll(15, pageIndex, 1, string.Format("kind={0} and state={1} and type not in {2}", (int)EnumType.KindType.编研成果, (int)EnumType.StateType.已审核,newtype), "ID").ToList();

            int Count = idal.FindAll(string.Format("kind={0} and state={1}", (int)EnumType.KindType.编研成果, (int)EnumType.StateType.已审核));
            pageCount = (int)Math.Ceiling((double)Count / 15);
            if (pageCount == 0)
                pageIndex = 0;
        }
    }
}