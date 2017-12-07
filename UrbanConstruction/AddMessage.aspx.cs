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
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace UrbanConstruction
{
    public partial class AddMessage : System.Web.UI.Page
    {
        //邮箱正则表达式
        public void IsValidEmail(string strIn)
        {
            string Msg = "true";
            string pattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(strIn))
                Msg = "false";
            Response.Write(Msg);
            Response.End();
        }    

        protected void Page_Load(object sender, EventArgs e)
        {
            string token = CreateToken();
            PutTokenToClient(token);
            SaveTokenInServer(token);
            string action = SqlFilterHelper.Filter(Request.Params["action"]);
            string VerifyCodeValue = SqlFilterHelper.Filter(Request.Params["VerifyCode"]);
            string name = SqlFilterHelper.Filter(Request.Params["name"]);
            string title = SqlFilterHelper.Filter(Request.Params["title"]);
            string email = SqlFilterHelper.Filter(Request.Params["email"]);
            string dian = SqlFilterHelper.Filter(Request.Params["dian"]);
            string content = SqlFilterHelper.Filter(Request.Params["content"]);
            string sex = SqlFilterHelper.Filter(Request.Params["sex"]);
            switch (action)
            {
                case "comparisonEmail": IsValidEmail(email); break;       
                case "comparisonCode":
                    {
                        string Msg = "true";
                        //对session中存储的验证码对比
                        string a = Session["message_yzm"].ToString();
                        if (HttpContext.Current.Session["message_yzm"] == null || VerifyCodeValue.ToLower() != HttpContext.Current.Session["message_yzm"].ToString().ToLower())
                        {
                            Msg = "false";//验证码输入不正确
                        }
                        Response.Write(Msg);
                        Response.End();
                    }; break;
                case "btnsubmit": btnclick(name, title, email, dian, content, sex); break;
            }
        }     

        public void ShowRedirect(string MSG, string Url)
        {
            SZM.Utility.Library.MessageHelper.ShowRedirect(MSG, Url);
        }

        public void btnclick(string name, string title, string email, string dian, string content, string sex)
        {
            string token = GetTokenFromRequest();
            //需要csrf保护的地方就check才放行
            if (TokenIsOK(token))
            {
                IUC_Guestbook imessage = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_GuestbookDaoService"] as IUC_Guestbook;
                UC_Guestbook message = new UC_Guestbook();
                //if (txtxing.Value == "")
                //{
                //    WebUtility.ShowMsg(this, "姓名不能为空！");
                //    return;
                //}
                //if (txtYan.Value.Trim().ToUpper() != Session["message_yzm"].ToString())
                //{
                //    WebUtility.ShowMsg(this, "验证码错误,请重新输入");
                //    return;
                //}
                string Msg = "true";
                message.Sex = int.Parse(sex);
                message.Name = name;
                message.Phone = dian;
                message.Address = where_field.SelectedValue;
                message.Email = email;
                message.Title = title;
                message.PostDate = DateTime.Now;
                message.Content = content;
                message.State = (int)EnumType.StateType.未审核;
                message.WriteBackDate = DateTime.MaxValue;
                message.Icon = rbl_face.SelectedValue;
                message.Is_SendEmail = '0';
                imessage.Insert(message);
                //ShowRedirect("留言成功", "MessageList.aspx");
                Response.Write(Msg);
                Response.End();
            }
            else
            {
                Response.Write("false");
                Response.End();
            }
        }

        public string GetTokenFromRequest()
        {
            return  SqlFilterHelper.Filter(Request.Params["token"]);
        }

        private void PutTokenToClient(string token)
        {
            ssid.Value = token;
        }

        private void SaveTokenInServer(string token)
        {
            //一般保存在session中
            Session["CRSFToken"] = token;
        }

        private bool TokenIsOK(string token)
        {
            string tokenInServer = Session["CRSFToken"].ToString();         
            return tokenInServer == token ? true : false;
        }

        public string _salt = "asdfkl@,.;#sss13131313";

        public string CreateToken()
        {
            return MD5(Session.SessionID + _salt);
        }

        private void ClearToken()
        {
            Session["CRSFToken"] = string.Empty;
        }

        private string MD5(string p)
        {
            p += "!@#<A8?";
            byte[] bytes = new UnicodeEncoding().GetBytes(p);
            byte[] buffer2 = new MD5CryptoServiceProvider().ComputeHash(bytes);
            StringBuilder builder = new StringBuilder();
            foreach (byte num in buffer2)
            {
                builder.AppendFormat("{0:X2}", num);
            }
            return builder.ToString();
        }
    }
}
