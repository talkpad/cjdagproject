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
using UrbanConstruction.Service;
using System.Collections.Generic;
using UrbanConstruction.Model;
using UrbanConstruction.Component;
using System.Xml.Linq;

namespace UrbanConstruction
{
    public partial class AcademicResearch : System.Web.UI.Page
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
        public void Bind()
        {
            //获取新闻
            IUC_NewsList idal = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
            if (Request.QueryString["pageIndex"] != null)
            {
                pageIndex = int.Parse(Request.QueryString["pageIndex"]);
            }
            newsList = idal.FindAll(15, pageIndex, 1, string.Format("kind={0} and state={1}", (int)EnumType.KindType.学术研究, (int)EnumType.StateType.已审核), "ID").ToList();

            int Count = idal.FindAll(string.Format("kind={0} and state={1}", (int)EnumType.KindType.学术研究, (int)EnumType.StateType.已审核));
            pageCount = (int)Math.Ceiling((double)Count / 15);
            if (pageCount == 0)
                pageIndex = 0;
        }
    }
}
