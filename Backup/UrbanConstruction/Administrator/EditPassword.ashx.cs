using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using UrbanConstruction.Service;
using System.Text;
using System.Security.Cryptography;
using UrbanConstruction.Component;
using UrbanConstruction.Model;

namespace UrbanConstruction.Administrator
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class EditPassword : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            IUC_User iuser = (ContainerWebAccessorUtil.ObtainContainer())["UC_UserDaoService"] as IUC_User;
            UC_User userCu = iuser.FindByName("admin");
            userCu.PassWord = Encode( context.Request.QueryString["newpass"]);
            iuser.Update(userCu);
        }

        public bool IsReusable
        {
            get
            {
                return false;
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
