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
using System.Collections.Generic;
using UrbanConstruction.Model;

namespace UrbanConstruction
{
    public partial class VideoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int kind;
                if (Request.QueryString["FID"] != null)
                {
                    if (int.TryParse(Request["FID"], out kind) == false)
                    {
                        Response.Redirect("Error.htm");
                    }
                    else
                        Bindinfo();
                }
                else
                    Response.Redirect("Error.htm");
            }
        }
        public UC_NewsList book = null;
        public int pageCount = 0;
        public string type = null;
        public void Bindinfo()
        {
            IUC_NewsList ivideo = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
            book = ivideo.FindById(int.Parse(Request.QueryString["FID"]));

            string[] arr = book.Pictures.Split(',');
            pageCount = int.Parse(arr[0]);
            type = arr[1];

        }
      
    }
}