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

namespace UrbanConstruction
{
    public partial class MessageAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_onserverclick(object sender, EventArgs e)
        {

            IUC_Message imessage = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_MessageDaoService"] as IUC_Message;
            UC_Message message = new UC_Message();
            if (rblist.SelectedValue == "2")
            {
                if (txtdian.Value == "" && txtmail.Value == "")
                {
                    WebUtility.ShowMsg(this, "电话/手机和E-Mail至少输入一项");
                    return;
                }
            }
            if (txtYan.Value.Trim().ToUpper() != Session["message_yzm"].ToString())
            {
                //WebUtility.ShowMsg(this, "验证码错误,请重新输入");
                
                return;
            }
            message.Type = int.Parse(rblist.SelectedValue.ToString());
            message.Name = txtxing.Value.Trim();
            message.Phone = txtdian.Value;
            message.Address = txtdi.Value;
            message.Email = txtmail.Value;
            message.Title = txttitle.Value;
            message.AddTime = DateTime.Now;
            message.Content = txtcontent.Value;
            message.State = (int)EnumType.StateType.未审核;
            imessage.Insert(message);
            ShowRedirect("留言成功", "MessageList.aspx");

        }
        public void ShowRedirect(string MSG, string Url)
        {
            SZM.Utility.Library.MessageHelper.ShowRedirect(MSG, Url);
        }
    }
}
