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
using log4net;
using System.Reflection;
using UrbanConstruction.Service;
using UrbanConstruction.Model;

namespace UrbanConstruction.Administrator
{
    public partial class EditVideo : UserFile
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    IUC_NewsList ivideo = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
                    UC_NewsList video = ivideo.FindById(int.Parse(Request.QueryString["id"]));
                    txttitle.Value = video.Title ;
                    txtdate.Value = video.ReleaseTime.ToString("yyyy-MM-dd HH:mm:ss");
                    DrState.SelectedValue = video.State.ToString();
                    ddl_type.SelectedValue = video.Type.ToString();
                }
                else
                {
                    this.txtdate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
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
        private UC_NewsList video;
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                IUC_NewsList ivideo = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
                if (Request.QueryString["id"] != null)
                    video = ivideo.FindById(int.Parse(Request.QueryString["id"]));
                else
                    video = new UC_NewsList();
                video.Title = txttitle.Value.Trim();
                video.ReleaseTime = DateTime.Parse(txtdate.Value.Trim().ToString());
                video.State = int.Parse(DrState.SelectedValue);
                video.Kind = (int)EnumType.KindType.编研成果;
                video.Type = int.Parse(ddl_type.SelectedValue);
                //上传视频截图
                if (FileUpPic.HasFile)
                {
                    string Extends = GetFileExtends(FileUpPic.FileName);
                    if (Extends.ToLower() == "exe")
                    {
                        WebUtility.ShowMsg(this, "请不要上传非法文件！");
                        return;
                    }
                    else
                    {
                        int i = FileUpPic.PostedFile.ContentLength;//获取上传文件的大小
                        if (i > 1048576)
                        {
                            WebUtility.ShowMsg(this, "上传的图片不能超过1M,请压缩后上传,或者联系管理员处理");
                            return;
                        }
                        string path = Server.MapPath("../NewsFile/images/City/VideoPicture/");
                        if (System.IO.Directory.Exists(path) == false)
                        {
                            System.IO.Directory.CreateDirectory(path);
                        }
                        FileUpPic.SaveAs(path + FileUpPic.FileName);
                        video.Pictures = "NewsFile/images/City/VideoPicture/" + FileUpPic.FileName;
                    }
                }
                else
                {
                    WebUtility.ShowMsg(this, "上传视频截图不能为空");
                    return;
                }
                //上传视频
                if (FileUp.HasFile)
                {
                    string Extends = GetFileExtends(FileUp.FileName);
                    if (Extends.ToLower() == "flv" || Extends.ToLower() == "mp4" || Extends.ToLower() == "3gp")
                    {
                        int i = FileUp.PostedFile.ContentLength;//获取上传文件的大小
                        if (i > 1048576000)
                        {
                            WebUtility.ShowMsg(this, "上传的视频不能超过1000M,请压缩后上传,或者联系管理员处理");
                            return;
                        }
                        string path = Server.MapPath("../VideoFiles/");
                        if (System.IO.Directory.Exists(path) == false)
                        {
                            System.IO.Directory.CreateDirectory(path);
                        }
                        FileUp.SaveAs(path + FileUp.FileName);
                        video.PictureURL = FileUp.FileName;
                    }
                    else
                    {
                        WebUtility.ShowMsg(this, "上传文件格式错误(请转码为此格式：FLV ( .flv )");
                        return;
                    }
                }
                else
                {
                    WebUtility.ShowMsg(this, "上传视频不能为空");
                    return;
                }
                if (Request.QueryString["id"] != null)
                {
                    ivideo.Update(video);
                    WebUtility.ShowMsg(this, "修改成功!");
                    //WebUtility.ShowMsg(this, "修改成功", "VideoList.aspx");
                    return;
                }
                else
                {
                    ivideo.Insert(video);
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
