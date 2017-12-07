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

namespace UrbanConstruction
{
    public partial class Message_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bind();
            }
        }
        public int pageIndex = 1;
        public int pageCount = 0;
        public void Bind()
        {
            IUC_Message imessage = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_MessageDaoService"] as IUC_Message;
          
            if (Request.QueryString["pageIndex"] != null)
            {
                pageIndex = int.Parse(Request.QueryString["pageIndex"]);
            }
            Rplist.DataSource = imessage.FindAll(15, pageIndex, 0, string.Format("type={0} and state={1}", (int)EnumType.messageType.公开, (int)EnumType.StateType.已审核), "MessageID").ToList();
            Rplist.DataBind();
            int Count = imessage.FindAll(string.Format("type={0} and state={1}", (int)EnumType.messageType.公开, (int)EnumType.StateType.已审核));
            pageCount = (int)Math.Ceiling((double)Count / 15);
            if (pageCount == 0)
                pageIndex = 0;

        }
    }
}
