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
    public partial class EditCompany : UserFile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    IUC_Town itown = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_TownDaoService"] as IUC_Town;
                    UC_Town company = itown.FindById(int.Parse(Request.QueryString["id"]));
                    txtzhenqu.Value = company.UserName;
                    txtpwd.Value = company.Password;
                    txtzhenqu.Value = company.CompanyName;
                    txtadd.Value = company.Address;
                    DRlist.SelectedValue = company.State.ToString();
                    txttel.Value = company.Phone;
                    txtfdren.Value = company.Email;
                    txtWebUrl.Value = company.WebUrl;
                    txtOrdering.Value = company.Ordering.ToString();
                    if (company.Synopsis == null)
                    {
                        FCKConten.Text = "";
                    }
                    else
                        FCKConten.Text = company.Synopsis.ToString();

                }
                if (Request.QueryString["type"] == "xiugai")
                {
                    IUC_Town itown = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_TownDaoService"] as IUC_Town;
                    UC_Town company = itown.FindByName(user.UserName);
                    if (company != null)
                    {
                        txtzhenqu.Value = company.UserName;
                        txtpwd.Value = company.Password;
                        txtzhenqu.Value = company.CompanyName;
                        txtadd.Value = company.Address;
                        txttel.Value = company.Phone;
                        txtfdren.Value = company.Email;
                        txtWebUrl.Value = company.WebUrl;
                        txtOrdering.Value = company.Ordering.ToString();
                        FCKConten.Text = company.Synopsis.ToString();
                    }
                    else
                    {
                        WebUtility.ShowMsg(this, "你无法使用改功能");
                        return;
                    }
                }
            }

        }
        public UC_Town company;
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //txtname.Value = txtzhenqu.Value;
            IUC_Town itown = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_TownDaoService"] as IUC_Town; 
            UC_Town company1 = itown.FindByName(WebUtility.InputTextForSql(txtzhenqu.Value.Trim()));
            //T_User user = iuser.FindByName(txtname.Value.Trim());
            if (Request.QueryString["id"] != null)
                company = itown.FindById(int.Parse(Request.QueryString["id"]));
            else if (Request.QueryString["type"] == "xiugai")
                company = itown.FindByName(user.UserName);
            else
            {
                company = new UC_Town();
            }
            //if (user != null || (company1 != null&&company1.CompanyID!=company.CompanyID))
            //{
            //    WebUtility.ShowMsg(this, "用户名已存在");
            //    txtname.Focus();
            //}
            if (company1 != null && company1.CompanyID != company.CompanyID)
            {
                WebUtility.ShowMsg(this, "镇区名已存在");
                txtzhenqu.Focus();
            }
            else
            {
                company.UserName = WebUtility.InputTextForSql(txtzhenqu.Value.Trim());
                company.Password = "123456";
                company.CompanyName = WebUtility.InputTextForSql(txtzhenqu.Value.Trim());
                company.Address = txtadd.Value.Trim();
                company.Phone = txttel.Value.Trim();
                company.Email = txtfdren.Value.Trim();
                company.State = int.Parse(DRlist.SelectedValue);
                company.Ordering = int.Parse(txtOrdering.Value.Trim());
                company.Addtime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                company.Synopsis = FCKConten.Text.Trim();
                company.WebUrl = txtWebUrl.Value.Trim();
                if (Request.QueryString["type"] == "xiugai")
                {
                    itown.Update(company);
                    WebUtility.ShowMsg(this, "修改成功");
                    return;
                }
                if (Request.QueryString["id"] != null)
                {
                    itown.Update(company);
                    SZM.Utility.Library.MessageHelper.ShowRedirect("修改成功", "CompanyList.aspx");
                    return;
                }
                else
                {
                    itown.Insert(company);
                    SZM.Utility.Library.MessageHelper.ShowRedirect("增加成功", "CompanyList.aspx");
                    return;
                }
            }
        }
    }
}
