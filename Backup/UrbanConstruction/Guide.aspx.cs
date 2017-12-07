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
    public partial class Guide : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int kind;
                if (Request.QueryString["pageIndex"] != null)
                {
                    if (int.TryParse(Request["pageIndex"], out kind) == false)
                    {
                        Response.Redirect("Error.htm");
                    }

                }
                if (Request.QueryString["kind"] != null)
                {
                    if (int.TryParse(Request["kind"], out kind) == false)
                    {
                        Response.Redirect("Error.htm");
                    }
                    kindid = Request.QueryString["kind"];
                }
                Bind();
            }
        }
        public string kindid = "";
        public int pageIndex = 1;
        public int pageCount = 0;
        public List<UC_NewsList> newsList = null;
        public List<UC_MenuItem> menulist = null;
        public string menuname = "办事指南";
        public void Bind()
        {
            int Count = 0;
            string kindtype = "(" + (int)EnumType.KindType.建设工程档案验收 + "," + (int)EnumType.KindType.地下管线档案验收 + "," + (int)EnumType.KindType.档案查阅 + "," + (int)EnumType.KindType.档案征集 + "," + (int)EnumType.KindType.办公电话 + ")";
            //获取子菜单
            IUC_MenuItem imenu = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_MenuItemDaoService"] as IUC_MenuItem;
            menulist = imenu.GetAllList(string.Format("kind in {0}", kindtype)).ToList();
            //获取新闻
            IUC_NewsList idal = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;

            if (Request.QueryString["pageIndex"] != null)
            {
                pageIndex = int.Parse(Request.QueryString["pageIndex"]);
            }
            if (Request.QueryString["kind"] != null)
            {
                switch (int.Parse(Request.QueryString["kind"]))
                {
                    case 5: menuname = "建设工程档案验收"; break;
                    case 6: menuname = "地下管线档案验收"; break;
                    case 7: menuname = "档案查阅"; break;
                    case 8: menuname = "档案征集"; break;
                    case 21: menuname = "办公电话"; break;
                }
                newsList = idal.FindAll(15, pageIndex, 1, string.Format("kind = {0} and state={1}", Request.QueryString["kind"], (int)EnumType.StateType.已审核), "ID").ToList();
                Count = idal.FindAll(string.Format("kind = {0} and state={1}", Request.QueryString["kind"], (int)EnumType.StateType.已审核));
            }
            else
            {
                newsList = idal.FindAll(15, pageIndex, 1, string.Format("kind in {0} and state={1}", kindtype, (int)EnumType.StateType.已审核), "ID").ToList();

                Count = idal.FindAll(string.Format("kind in {0} and state={1}", kindtype, (int)EnumType.StateType.已审核));
            }
            pageCount = (int)Math.Ceiling((double)Count / 15);
            if (pageCount == 0)
                pageIndex = 0;
        }
    }
}