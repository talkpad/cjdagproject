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
using UrbanConstruction.Component;
using UrbanConstruction.Service;
using System.IO;

namespace UrbanConstruction
{
    public partial class DownLoadField : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int kind;
                if (Request.QueryString["DID"] != null)
                {
                    if (int.TryParse(Request["DID"], out kind) == false)
                    {
                        Response.Redirect("Error.htm");
                    }
                    else
                        DownLoadFile(int.Parse(Request.QueryString["DID"]));
                }
                else
                {
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
        }
        public string kindid = "";
        public int pageIndex = 1;
        public int pageCount = 0;
        public List<UC_DownLoad> newsList = null;
        public List<UC_MenuItem> menulist = null;
        public string menuname = "下载中心";
        public void Bind()
        {
            int Count = 0;
            string kindtype = "(" + (int)EnumType.KindType.业务表格 + "," + (int)EnumType.KindType.规范标准 + ")";
            //获取子菜单
            //获取子菜单
            IUC_MenuItem imenu = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_MenuItemDaoService"] as IUC_MenuItem;
            menulist = imenu.GetAllList(string.Format("kind in {0}", kindtype)).ToList();
            //获取新闻
            IUC_DownLoad idal = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_DownLoadDaoService"] as IUC_DownLoad;
            if (Request.QueryString["pageIndex"] != null)
            {
                pageIndex = int.Parse(Request.QueryString["pageIndex"]);
            }
            if (Request.QueryString["kind"] != null)
            {
                switch (int.Parse(Request.QueryString["kind"]))
                {
                    case 22: menuname = "业务表格"; break;
                    case 23: menuname = "规范标准"; break;                
                }
                UC_MenuItem menu = imenu.GetAllList(string.Format("kind = {0}", int.Parse(Request.QueryString["kind"]))).ToList().FirstOrDefault(); ;
                newsList = idal.FindAll(15, pageIndex, 1, string.Format("m_itemid = {0} and state={1}", menu.M_ItemID, (int)EnumType.StateType.已审核), "ID").ToList();
                Count = idal.FindAll(string.Format("m_itemid = {0} and state={1}", menu.M_ItemID, (int)EnumType.StateType.已审核));
            }
            else
            {
                newsList = idal.FindAll(15, pageIndex, 1, string.Format("state={0}", (int)EnumType.StateType.已审核), "ID").ToList();  
                Count = idal.FindAll(string.Format("state={0}", (int)EnumType.StateType.已审核));
            }
          
            pageCount = (int)Math.Ceiling((double)Count / 15);
            if (pageCount == 0)
                pageIndex = 0;
        }

        public void DownLoadFile(int ID)
        {
            IUC_DownLoad idal = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_DownLoadDaoService"] as IUC_DownLoad;
            UC_DownLoad down = idal.FindById(ID);
            if (down != null)
            {
                string filePath = Server.MapPath("NewsFile/upload/" + down.FileFact);
                if (File.Exists(filePath))
                {
                    FileInfo file = new FileInfo(filePath);
                    Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8"); //解决中文乱码
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(down.FileFact)); //解决中文文件名乱码    
                    Response.AddHeader("Content-length", file.Length.ToString());
                    Response.ContentType = "appliction/octet-stream";
                    Response.WriteFile(file.FullName);
                    Response.End();
                }
                else
                {
                    WebUtility.ShowMsg(this, "下载的文件不存在!");
                }
            }
            else
            {
                WebUtility.ShowMsg(this, "下载的文件不存在!");
            }        
        }

    }
}