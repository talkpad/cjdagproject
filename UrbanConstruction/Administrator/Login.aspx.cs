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
using SZM.Utility.Library;
using UrbanConstruction.Component;
using UrbanConstruction.Service;
using UrbanConstruction.Model;
using System.Text;
using System.Security.Cryptography;

namespace UrbanConstruction.Administrator
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["type"] != null)
                {
                    //退出系统
                    if (Request.QueryString["type"] == "out")
                    {
                        FormsAuthentication.SignOut();
                        Session.Clear();
                        Response.Redirect("Login.aspx");
                    }
                }
                if (Request.QueryString["ReturnUrl"] != "" && Request.QueryString["ReturnUrl"] != null)
                {
                    HidUrl.Value = Request.QueryString["ReturnUrl"];
                }
                else
                {
                    HidUrl.Value = "index.aspx";
                }
            }
        }
        protected void button_onserverclick(object sender, EventArgs e)
        {
            try
            {               

                if (txtname.Value.Trim() == "")
                {
                    MessageHelper.ShowRedirect("用户名不能为空", "Login.aspx");
                    return;
                }

                if (txtpwd.Value.Trim() == "")
                {
                    MessageHelper.ShowRedirect("密码不能为空", "Login.aspx");
                    return;
                }


                if (checkimg.Value.Trim() != Session["picident"].ToString())
                {
                    MessageHelper.ShowRedirect("验证码错误,请重新输入", "Login.aspx");
                    return;
                }

            
                //重置SessionId
                Session.Clear();
                Session.Abandon();
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                HttpCookie cookie = new HttpCookie("User");  

                IUC_User iuser = (ContainerWebAccessorUtil.ObtainContainer())["UC_UserDaoService"] as IUC_User;

                UC_User user = iuser.FindByName(txtname.Value.Trim());
                if (user == null)
                {
                    WebUtility.ShowMsg(this, "用户名不存在");
                    txtname.Focus();
                    return;
                }
                else
                {
                    if (user.State == 2)
                    {
                        txtname.Focus();
                        WebUtility.ShowMsg(this, "你的帐号已经被禁用,请联系网站管理员");
                        return;

                    }
                    if (user.PassWord == Encode(txtpwd.Value.Trim()))
                    {
                        User o_user = new User();
                        o_user.UserId = user.UserID;
                        o_user.UserName = user.UserName;
                        o_user.Type = 2;
                        o_user.UserType = user.UserType;
                        //Session.Add("User", o_user);
                        //Session.Add("username", txtname.Value);
                        cookie.Values.Add("username", txtname.Value.Trim());
                        cookie.Values.Add("usertype", user.UserType.ToString());
                        Response.AppendCookie(cookie);

                        string returnUrl = Request.QueryString["ReturnUrl"];
                        if (returnUrl == null) returnUrl = "index.aspx";
                        Response.Redirect(returnUrl);
                    }
                    else
                    {
                        txtpwd.Focus();
                        WebUtility.ShowMsg(this, "密码错误");
                        return;
                    }
                }              
            }
            catch (Exception ex)
            {
                MessageHelper.ShowRedirect("用户登录失败请重新登录", "Login.aspx");
                Response.Write(ex.Message.ToString());
            }
        }
        public static string Encode(string value)
        {
            value += "!@#<A8?";
            byte[] bytes = new UnicodeEncoding().GetBytes(value);
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
