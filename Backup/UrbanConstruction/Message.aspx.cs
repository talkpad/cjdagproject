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
using UrbanConstruction.Component;
using UrbanConstruction.Service;
using UrbanConstruction.Model;

namespace UrbanConstruction
{
    public partial class Message : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int kind;
                if (Request.QueryString["MID"] != null)
                {
                    if (int.TryParse(Request["MID"], out kind) == false)
                    {
                        Response.Redirect("Error.htm");
                    }
                    else
                        Bind();
                }
                else
                    Response.Redirect("Error.htm");
            }
        }
     
        public void Bind()
        {
            IUC_Message imessage = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_MessageDaoService"] as IUC_Message;
            Rplist.DataSource = imessage.GetAllList(string.Format("messageid={0}",int.Parse(Request.QueryString["MID"])));
            Rplist.DataBind();
        }
    }
}
