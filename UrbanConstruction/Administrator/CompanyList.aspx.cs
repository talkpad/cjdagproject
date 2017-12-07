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

namespace UrbanConstruction.Administrator
{
    public partial class CompanyList : UserFile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bindinfo();
                if (Request.QueryString["id"] != null)
                {
                    IUC_Town icompany = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_TownDaoService"] as IUC_Town;
                    UC_Town company = icompany.FindById(int.Parse(Request.QueryString["id"]));
                    if (company != null)
                    {
                        if (Request.QueryString["type"] == "qiyong")
                        {
                            company.State = 1;
                            icompany.Update(company);
                            SZM.Utility.Library.MessageHelper.ShowRedirect("启用成功", "CompanyList.aspx");
                            return;
                        }
                        if (Request.QueryString["type"] == "jinyong")
                        {
                            company.State = 2;
                            icompany.Update(company);
                            SZM.Utility.Library.MessageHelper.ShowRedirect("禁用成功", "CompanyList.aspx");
                            return;
                        }
                        if (Request.QueryString["type"] == "del")
                        {
                            icompany.Delete(int.Parse(Request.QueryString["id"]));
                            SZM.Utility.Library.MessageHelper.ShowRedirect("删除成功", "CompanyList.aspx");
                            return;
                        }
                    }
                }
            }
        }
        public int pageIndex = 1;
        public int pageCount = 0;
        public int pageSize = 12;

        public void Bindinfo()
        {
            if (Request.QueryString["pageIndex"] != null)
            {
                pageIndex = int.Parse(Request.QueryString["pageIndex"]);
            }
            IUC_Town icompany = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_TownDaoService"] as IUC_Town;
            UC_Town company = icompany.FindByName(UserName);
            Rplist.DataSource = icompany.FindAll(pageSize, pageIndex, 0, "1=1", "CompanyID").ToList();
            Rplist.DataBind();

            int Count = icompany.FindAll("1=1");
            pageCount = (int)Math.Ceiling((double)Count / pageSize);
            if (pageCount == 0)
                pageIndex = 0;         
        }
        public string Url(object state, int id)
        {
            if (int.Parse(state.ToString()) == 2)
            {
                return "&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"../img/Loginimages/icon_qssh.png\" height=\"16px\"/><a id='jinyong' href='CompanyList.aspx?id=" + id + "&type=qiyong'>启用</a>";
            }
            else
            {
                return "&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"../img/Loginimages/icon_sh.png\" height=\"16px\"/><a id='qiyong' href='CompanyList.aspx?id=" + id + "&type=jinyong'>禁用</a>";
            }
        }
        public string UserName
        {
            get { return Page.User.Identity.Name; }
        }
        public string StateName(int type)
        {
            string str = string.Empty;
            if (type == 1)
            {
                str = "启用";
            }
            else
            {
                str = "禁用";
            }
            return str;
        }
    }
}
