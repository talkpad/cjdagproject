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
using UrbanConstruction.Model;
using System.Collections.Generic;
using UrbanConstruction.Service;
using UrbanConstruction.Component;
using System.Web.UI.MobileControls;

namespace UrbanConstruction
{
    public partial class NewsDetail : System.Web.UI.Page
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
                        Bind();
                }
                else
                    Response.Redirect("Error.htm");
            }
        }
        public UC_NewsList news = null;
        public List<UC_NewsList> pre = null;
        public List<UC_NewsList> next = null;
        public UC_Menu menu = null;
        public void Bind()
        {
            //获取新闻
            IUC_NewsList idal = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
            news = idal.FindById(int.Parse(Request.QueryString["FID"]));
            //获取新闻父类菜单
            if (news!=null && news.M_ID > 0)
            {
                IUC_Menu Mdal = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_MenuDaoService"] as IUC_Menu;
                menu = Mdal.FindById(news.M_ID);
                //上一篇
                pre = idal.GetList(1, string.Format("id=(select min(id) from UC_NewsList where id>{0} and kind={1})", news.ID, news.Kind)).ToList();
                //下一篇
                next = idal.GetList(1, string.Format("id=(select max(id) from UC_NewsList where id<{0} and kind={1})", news.ID, news.Kind)).ToList();
            }
        
        }
    }
}
