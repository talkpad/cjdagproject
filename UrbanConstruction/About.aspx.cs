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
using UrbanConstruction.Component;
using UrbanConstruction.Model;
using System.Collections.Generic;

namespace UrbanConstruction
{
    public partial class About : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                int kind;
                if (Request.QueryString["kind"] != null)
               {
                   if (int.TryParse(Request["kind"], out kind) == false)
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
        public UC_NewsList news = null;
        public void Bind()
        {
            int kind = Request.QueryString["kind"]!= null?int.Parse(Request.QueryString["kind"]):(int)EnumType.KindType.本馆概况;
            DefaultFootLeft1.ItemID = "1";
            IUC_NewsList inews = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
            news = inews.GetAllList(string.Format("kind ={0} and state= {1}",kind,(int)EnumType.StateType.已审核)).FirstOrDefault();
            if (news == null)
                Response.Write("<script>alert('没有数据！');location.href='index.aspx';</script>");
        }
    }
}
