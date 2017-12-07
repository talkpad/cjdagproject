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
using System.Collections.Generic;
using UrbanConstruction.Model;
using UrbanConstruction.Service;
using UrbanConstruction.Component;

namespace UrbanConstruction
{
    public partial class Books : System.Web.UI.Page
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
        public List<UC_NewsList> booklist = null;
        public string bookpages = null;
        public void Bindinfo()
        {
            IUC_NewsList ibook = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
            booklist = ibook.GetAllList(string.Format("kind={0} and type != {1} and state = {2}", (int)EnumType.KindType.编研成果, (int)EnumType.NewsType.视频, (int)EnumType.StateType.已审核)).ToList();
            book = ibook.FindById(int.Parse(Request.QueryString["FID"]));
            if (book != null)
            {
                string[] arr = book.Pictures.Split(',');
                pageCount = int.Parse(arr[0]);
                type = arr[1];
                for (int i = 0; i < pageCount; i++)
                {
                    bookpages += "'ResearchResults/" + book.PictureURL + "/p" + i.ToString() + type + "',";
                }
            }
        }
    }
}
