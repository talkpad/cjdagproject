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
using System.Text;
using System.Security.Cryptography;

namespace UrbanConstruction
{
    public partial class VideoDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                 string token = CreateToken();
                PutTokenToClient(token);
                SaveTokenInServer(token);

                token = GetTokenFromRequest();
                //需要csrf保护的地方就check才放行
                if (TokenIsOK(token))
                {
                    int kind;
                    if (Request.QueryString["FID"] != null)
                    {
                        if (int.TryParse(Request["FID"], out kind) == false)
                        {
                            Response.Redirect("Error.htm");
                        }
                        else
                        {
                            if (Request.QueryString["type"] != null)
                            {
                                if (int.TryParse(Request["type"], out kind) == false)
                                {
                                    Response.Redirect("Error.htm");
                                }
                                else
                                {
                                    picType = Request.QueryString["type"];
                                    menu = "视频展览";
                                }
                            }
                            IUC_NewsList ivideo = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
                            UC_NewsList video = ivideo.FindById(int.Parse(Request.QueryString["FID"]));
                            if (video != null)
                            {
                                url = video.PictureURL;
                                Vtitle = video.Title;
                            }
                        }
                    }
                }
                else
                    Response.Redirect("index.aspx");
            }
        }
        public string url;
        public string Vtitle = "";
        public string menu = null;
        public string picType = "";


        private string GetTokenFromRequest()
        {
            return Request.QueryString["token"];
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