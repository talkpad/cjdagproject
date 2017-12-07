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
using System.Reflection;
using UrbanConstruction.Service;
using UrbanConstruction.Model;
using log4net;

namespace UrbanConstruction.Administrator
{
    public partial class EditNews : UserFile
    {
        private readonly string MenuSQL = "and  status=1 ";
        private readonly string MenuItemSQL = "and status=1 ";
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BandMenu(this.Xdlist, MenuSQL);
                txtdate.Value = DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                txtzuoz.Value = user.UserName;
                if (Request.QueryString["id"] != null)
                {
                    IUC_NewsList inews = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;

                    UC_NewsList newsInformation = inews.FindById(int.Parse(Request.QueryString["id"]));
                    if (newsInformation != null)
                    {
                        txttitle.Value = newsInformation.Title;
                        txtSoure.Value = newsInformation.Source;
                        txtzuoz.Value = newsInformation.Author;
                        txtdate.Value = newsInformation.ReleaseTime.ToString("yyyy-MM-dd HH:mm:ss");
                        Xdlist.SelectedValue = newsInformation.M_ID.ToString();
                        BandMenuItem(this.Ldlist, Xdlist.SelectedValue, MenuItemSQL);
                      
                        Ldlist.SelectedValue = newsInformation.M_ItemID.ToString();
                        FCKConten.Text = newsInformation.Content;
                        if (newsInformation.Kind == (int)EnumType.KindType.通知公告)
                        {
                            this.txtzhan.Checked = true;
                        }
                        if (newsInformation.StayTop.ToString() == "1")
                        {
                            this.txtZhi.Checked = true;
                        }
                        ddlist.SelectedValue = newsInformation.State.ToString();
                    }
                }
                else
                {
                    BandMenuItem(this.Ldlist, Xdlist.SelectedValue, MenuItemSQL);
                }
            }
        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UC_NewsList newsInformation;
                if (FCKConten.Text == "")
                {
                    WebUtility.ShowMsgDelay(this, "文章内容不能为空");
                    return;
                }
                
                IUC_NewsList inews = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
                IUC_MenuItem item = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_MenuItemDaoService"] as IUC_MenuItem;
                if (Request.QueryString["id"] != null)
                {
                    newsInformation = inews.FindById(int.Parse(Request.QueryString["id"]));
                }
                else
                {
                    newsInformation = new UC_NewsList();
                }

                newsInformation.Author = txtzuoz.Value.Trim();
                newsInformation.Content = FCKConten.Text.Trim();
                newsInformation.UpdateUserName = user.UserName;
                newsInformation.M_ID = int.Parse(Xdlist.SelectedValue);
                newsInformation.M_ItemID = int.Parse(Ldlist.SelectedValue);
                newsInformation.ReleaseTime = DateTime.Parse(txtdate.Value.Trim());
                newsInformation.Source = txtSoure.Value.Trim();
                newsInformation.Title = txttitle.Value.Trim();
                newsInformation.Kind = item.FindById(int.Parse(Ldlist.SelectedValue)).Kind;
                if (ddlist.SelectedValue == "")
                {
                    WebUtility.ShowMsg(this, "请选择状态");
                }
                else
                {
                    newsInformation.State = int.Parse(ddlist.SelectedValue);
                }
                if (txtzhan.Checked != false)
                    newsInformation.Zngg = 1;
                else
                    newsInformation.Zngg = 0;
                if (txtZhi.Checked != false)
                    newsInformation.StayTop = 1;
                else
                    newsInformation.StayTop = 0;
                //string Url = "NewsList.aspx?Title="+txttitle.Value.Trim();
                if (Request.QueryString["id"] != null)
                {
                    inews.Update(newsInformation);
                    WebUtility.ShowMsg(this, "修改成功");
                    return;
                }
                else
                {
                    newsInformation.State = int.Parse(ddlist.SelectedValue);
                    newsInformation.Type = 1;
                    inews.Insert(newsInformation);
                    WebUtility.ShowMsg(this, "添加成功");
                    txttitle.Value = "";

                    txtdate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    FCKConten.Text = "";
                    txtzhan.Checked = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                log.Error("提交失败", ex);
                WebUtility.ShowMsg(this, "提交失败");
            }

        }
        /// <summary>
        /// 下拉框联动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Xdlistonclick(object sender, EventArgs e)
        {
            BandMenuItem(this.Ldlist, Xdlist.SelectedValue, MenuItemSQL);
        }
    }
}
