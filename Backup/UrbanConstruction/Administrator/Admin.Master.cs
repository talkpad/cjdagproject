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
using System.Text;
using System.Security.Cryptography;

namespace UrbanConstruction.Administrator
{
    public partial class Admin : System.Web.UI.MasterPage
    {  
        /// <summary>
        /// 当前登录者
        /// </summary>
        public User user
        {
            get
            {
                HttpCookie cookie = Request.Cookies["User"];
                if (cookie !=null && cookie.Values["username"].Length >0)                
                {
                    User bod = new User();
                    bod.UserName = cookie.Values["username"];
                    bod.UserType = int.Parse(cookie.Values["usertype"]);
                    return bod;
                }
                else
                {
                    return null;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }      
    }
}
