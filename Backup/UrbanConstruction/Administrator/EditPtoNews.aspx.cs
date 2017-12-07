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
using System.Reflection;
using UrbanConstruction.Component;
using UrbanConstruction.Service;
using UrbanConstruction.Model;
using log4net;

namespace UrbanConstruction.Administrator
{
    public partial class EditPtoNews : UserFile
    {
        private readonly string MenuSQL = "and  status=1 ";
        private readonly string MenuItemSQL = "and status=1 ";
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BandMenu(this.Xdlist, MenuSQL);

                txtzuoz.Value = user.UserName;
                txtdate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                if (Request.QueryString["id"] != null)
                {
                    IUC_NewsList inews = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
                    UC_NewsList news = inews.FindById(int.Parse(Request.QueryString["id"]));
                    txtSoure.Value = news.Source;
                    txttitle.Value = news.Title;
                    txtdate.Value = news.ReleaseTime.ToString("yyyy-MM-dd HH:mm:ss");
                    txtzuoz.Value = news.Author;
                    FCKConten.Text = news.Content;
                    Xdlist.SelectedValue = news.M_ID.ToString();
                    BandMenuItem(this.Ldlist, Xdlist.SelectedValue, MenuItemSQL);
                    Ldlist.SelectedValue = news.M_ItemID.ToString();
                    txtNewsUrl.Text = news.PictureURL;
                    if (news.StayTop == 1)
                    {
                        txtZhi.Checked = true;
                    }
                    if (news.Zngg == 1)
                    {
                        txtzhan.Checked = true;
                    }
                    ddlist.SelectedValue = news.State.ToString();
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
                UC_NewsList news;
                //if (txtWebUrl.Value.Trim() == "")
                //{
                if (FCKConten.Text == "")
                {
                    SZM.Utility.Library.MessageHelper.ShowRedirect("新闻内容不能为空", "EditPtoNews.aspx");
                    return;
                }
                //}
                IUC_NewsList inews = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
                IUC_MenuItem item = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_MenuItemDaoService"] as IUC_MenuItem;
                if (Request.QueryString["id"] != null)
                {
                    news = inews.FindById(int.Parse(Request.QueryString["id"]));
                }
                else
                {
                    news = new UC_NewsList();
                }
                news.Title = txttitle.Value.Trim();
                news.Author = txtzuoz.Value.Trim();
                news.Content = FCKConten.Text.Trim();
                news.ReleaseTime = DateTime.Parse(txtdate.Value.Trim());
                news.Source = txtSoure.Value.Trim();
                news.M_ID = int.Parse(Xdlist.SelectedValue);
                news.M_ItemID = int.Parse(Ldlist.SelectedValue);
                news.PictureURL = txtNewsUrl.Text.Trim();
                news.UpdateUserName = user.UserName;
                news.Kind = item.FindById(int.Parse(Ldlist.SelectedValue)).Kind;
                if (ddlist.SelectedValue == "")
                {
                    WebUtility.ShowMsg(this, "请选择状态");
                }
                else
                {
                    news.State = int.Parse(ddlist.SelectedValue);
                }
                if (txtZhi.Checked != false)
                      news.StayTop  = 1;
                else
                   news.StayTop = 0;

                if (txtzhan.Checked != false)
                    news.Zngg = 1;
                else
                    news.Zngg = 0;


                if (Request.QueryString["id"] != null)
                {
                    inews.Update(news);
                    WebUtility.ShowMsg(this, "修改成功!");

                }
                else
                {
                    news.State = int.Parse(ddlist.SelectedValue);
                    news.Type = 2;
                    inews.Insert(news);
                    WebUtility.ShowMsg(this, "增加成功!");
                    txttitle.Value = "";
                    txtNewsUrl.Text = "";
                    //txtWebUrl.Value = "";
                    txtdate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    FCKConten.Text = "";

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

        protected void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_filTitleImg.HasFile)
                {
                    string Extends = GetFileExtends(m_filTitleImg.FileName);
                    if (Extends.ToLower() == "exe")
                    {
                        WebUtility.ShowMsg(this, "请不要上传非法文件！");
                    }
                    else
                    {
                        string Msg = "";
                        if (CheckUploadImg(m_filTitleImg, out Msg))
                        {

                            int i = m_filTitleImg.PostedFile.ContentLength;//获取上传文件的大小
                            if (i > 10485760)
                            {
                                WebUtility.ShowMsg(this, "上传文件不能超过10M,请压缩后上传,或者联系管理员处理！");
                                return;
                            }
                            string path = Server.MapPath("../NewsFile/images/News/");
                            if (System.IO.Directory.Exists(path) == false)
                            {
                                System.IO.Directory.CreateDirectory(path);
                            }
                            m_filTitleImg.SaveAs(path + m_filTitleImg.FileName);
                            this.txtNewsUrl.Text = m_filTitleImg.FileName;
                            WebUtility.ShowMsg(this, "文件上传成功！");
                        }
                        else
                        {
                            WebUtility.ShowMsg(this, Msg);
                            return;
                        }

                    }
                }
                else
                {
                    WebUtility.ShowMsg(this, "上传文件不能为空！");
                }
            }
            catch
            {
                WebUtility.ShowMsg(this, "文件上传失败！");
            }
        }

        public static string GetFileExtends(string filename)
        {
            string ext = null;
            if (filename.IndexOf('.') > 0)
            {
                string[] fs = filename.Split('.');
                ext = fs[fs.Length - 1];
            }
            return ext;
        } 
    }
}
