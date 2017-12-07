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
using System.Collections.Generic;
using UrbanConstruction.Component;
using UrbanConstruction.Model;

namespace UrbanConstruction
{
    public partial class PictureList : System.Web.UI.Page
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

                if (Request.QueryString["picturetype"] != null)
                {
                    if (int.TryParse(Request["picturetype"], out kind) == false)
                    {
                        Response.Redirect("Error.htm");
                    }
                    else
                        Bind();
                }
                else
                    Bind();
            }
        }
        public bool isVideo = false;
        public int typePic = 0;
        public int pageIndex = 1;
        public int pageCount = 0;
        public List<UC_Pictures> newsList = null;
        public List<UC_NewsList> newlist = null;
        public UC_MenuItem menu = null;
        public string pictureurl = null;
        public void Bind()
        {
            typePic = int.Parse(Request.QueryString["picturetype"]);
            if (typePic != (int)EnumType.KindType.编研成果)
            {
                //获取图片
                IUC_Pictures idal = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_PicturesDaoService"] as IUC_Pictures;
                if (Request.QueryString["pageIndex"] != null)
                {
                    pageIndex = int.Parse(Request.QueryString["pageIndex"]);
                }
                newsList = idal.FindAll(12, pageIndex, 0, string.Format("type={0} and state={1}", Request.QueryString["picturetype"], (int)EnumType.StateType.已审核), "PictureID").ToList();

                int Count = idal.FindAll(string.Format("type={0} and state={1}", Request.QueryString["picturetype"], (int)EnumType.StateType.已审核));
                pageCount = (int)Math.Ceiling((double)Count / 12);
                if (pageCount == 0)
                    pageIndex = 0;
                //获取子菜单名
                IUC_MenuItem mentitem = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_MenuItemDaoService"] as IUC_MenuItem;
                menu = mentitem.GetAllList(string.Format("picturetype={0}", Request.QueryString["picturetype"])).ToList().FirstOrDefault();
                int type = int.Parse(Request.QueryString["picturetype"]);
                switch (type)
                {
                    case 1: pictureurl = "OldView"; break;
                    case 2: pictureurl = "Memory"; break;
                    case 3: pictureurl = "Famous"; break;
                    case 4: pictureurl = "BigChange"; break;
                    case 5: pictureurl = "NewScenery"; break;
                    case 6: pictureurl = "GreaterHouse"; break;
                    case 7: pictureurl = "LivingEnvironment"; break;
                    default: pictureurl = "OldView"; break;
                }
            }
            else
            {
                isVideo = true;
                IUC_NewsList idal = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
                if (Request.QueryString["pageIndex"] != null)
                {
                    pageIndex = int.Parse(Request.QueryString["pageIndex"]);
                }
                newlist = idal.FindAll(12, pageIndex, 0, string.Format("kind={0} and state={1} and type={2}", Request.QueryString["picturetype"], (int)EnumType.StateType.已审核, (int)EnumType.NewsType.展览视频), "ID").ToList();

                int Count = idal.FindAll(string.Format("kind={0} and state={1} and type={2}", Request.QueryString["picturetype"], (int)EnumType.StateType.已审核, (int)EnumType.NewsType.展览视频));
                pageCount = (int)Math.Ceiling((double)Count / 12);
                if (pageCount == 0)
                    pageIndex = 0;
            }
        }
    }
}