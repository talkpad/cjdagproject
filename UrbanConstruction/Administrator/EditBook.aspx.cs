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
using System.IO;
using log4net;
using System.Reflection;

namespace UrbanConstruction.Administrator
{
    public partial class EditBook : UserFile
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    IUC_NewsList inews = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
                    UC_NewsList news = inews.FindById(int.Parse(Request.QueryString["id"]));
                    txttitle.Value = news.Title;
                    txtdate.Value = news.ReleaseTime.ToString("yyyy-MM-dd HH:mm:ss");
                    DrState.SelectedValue = news.State.ToString();
                }
                else
                {
                    this.txtdate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
        }
        public string GetFileExtends(string filename)
        {
            string ext = null;
            if (filename.IndexOf('.') > 0)
            {
                string[] fs = filename.Split('.');
                ext = fs[fs.Length - 1];
            }
            return ext;
        }
        private UC_NewsList news;
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                IUC_NewsList inews = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
                if (Request.QueryString["id"] != null)
                    news = inews.FindById(int.Parse(Request.QueryString["id"]));
                else
                    news = new UC_NewsList();
                news.Title = txttitle.Value.Trim();
                news.ReleaseTime = DateTime.Parse(txtdate.Value.Trim().ToString());
                news.State = int.Parse(DrState.SelectedValue);
                news.Kind = (int)EnumType.KindType.编研成果;
                if (Request.Files.Count > 0 && Request.Files[0].FileName.Length > 0)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFile PostedFile = Request.Files[i]; 
                        string Extends = GetFileExtends(Request.Files[i].FileName);
                        if (Extends.ToLower() == "exe")
                        {
                            WebUtility.ShowMsg(this, "请不要上传非法文件！");
                            return;
                        }
                        else
                        {

                            int length = Request.Files[i].ContentLength;//获取上传文件的大小
                            if (length > 20971520)
                            {
                                WebUtility.ShowMsg(this, "上传的图片不能超过20M,请压缩后上传,或者联系管理员处理");
                                return;
                            }
                            string path = Server.MapPath("../ResearchResults/" + txttitle.Value.Trim()+"/");

                            if (System.IO.Directory.Exists(path) == false)
                            {
                                System.IO.Directory.CreateDirectory(path);
                            }
                            PostedFile.SaveAs(path+Request.Files[i].FileName);
                            news.PictureURL = txttitle.Value.Trim();
                        }
                    }
                    news.Pictures = Request.Files.Count.ToString() + "," + ".jpg";
                }
                else
                {
                    WebUtility.ShowMsg(this, "上传文件不能为空");
                    return;
                }
                if (Request.QueryString["id"] != null)
                {
                    inews.Update(news);
                    WebUtility.ShowMsg(this, "修改成功!");
                    //WebUtility.ShowMsg(this, "修改成功", "VideoList.aspx");
                    return;
                }
                else
                {
                    inews.Insert(news);
                    WebUtility.ShowMsg(this, "增加成功!");
                    //WebUtility.ShowMsg(this, "增加成功", "VideoList.aspx");
                    return;
                }
            }
            catch (Exception ex)
            {
                log.Error("提交失败", ex);
                WebUtility.ShowMsg(this, "提交失败");
            }
        }
    }
}
