using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using UrbanConstruction.Component;
using UrbanConstruction.Service;
using UrbanConstruction.Model;
using System.Reflection;
using log4net;

namespace UrbanConstruction.Administrator
{
    public partial class EditMessage : UserFile
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Request.QueryString["id"] != null)
                {
                    //IUC_Message imessage = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_MessageDaoService"] as IUC_Message;
                    IUC_Guestbook imessage = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_GuestbookDaoService"] as IUC_Guestbook;
                    UC_Guestbook message = imessage.FindById(int.Parse(Request.QueryString["id"]));
                    txtname.Value = message.Name;
                    //rbgk.Text = message.Type.ToString();
                    txtaddress.Value = message.Address;
                    txtemail.Value = message.Email;
                    txttel.Value = message.Phone;
                    txtzhuti.Value = message.Title;
                    content_1.Value = message.Content.ToString();
                    FCKConten.Text = message.WriteContent;
                    rlistState.SelectedValue = message.State.Equals(1) ? "1" : "0";
                }
            }
            FCKConten.Height = Unit.Pixel(200);
        }
        protected void BtSava_onserverclick(object sender, EventArgs e)
        {
            try
            {
                if (FCKConten.Text == null || FCKConten.Text == "")
                {
                    WebUtility.ShowMsgDelay(this, "回复内容不能为空");
                    return;
                }
                //IUC_Message imessage = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_MessageDaoService"] as IUC_Message;
                IUC_Guestbook imessage = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_GuestbookDaoService"] as IUC_Guestbook;
                UC_Guestbook message = imessage.FindById(int.Parse(Request.QueryString["id"]));
                message.WriteBackDate = DateTime.Now;
                message.WriteContent = FCKConten.Text;
                message.WriteBackUser = user.UserName;
                message.State = int.Parse(rlistState.SelectedValue);
                imessage.Update(message);
                WebUtility.ShowMsg(this, "回复成功");
                return;
            }
            catch (Exception ex)
            {
                log.Error("回复失败", ex);
                WebUtility.ShowMsg(this, "回复失败");
            }
        }

    }
}
