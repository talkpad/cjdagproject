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
using log4net;
using UrbanConstruction.Component;
using UrbanConstruction.Service;
using UrbanConstruction.Model;

namespace UrbanConstruction.Administrator
{
    public partial class UpLoadFile : UserFile
    {
        private readonly string MenuSQL = "and  status=1 ";
        private readonly string MenuItemSQL = "and status=1 ";
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BandMenu(this.Xdlist, MenuSQL);
                if (Request.QueryString["id"] != null)
                {
                    IUC_DownLoad idownload = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_DownLoadDaoService"] as IUC_DownLoad;
                    UC_DownLoad download = idownload.FindById(int.Parse(Request.QueryString["id"]));
                    txttitle.Value = download.FileName;
                    txtFileFact.Text = download.FileFact;
                    DrState.Text = download.State.ToString();
                    txtdate.Value = download.AddTime.ToString("yyyy-MM-dd HH:mm:ss");
                    Xdlist.SelectedValue = download.M_ID.ToString();
                    BandMenuItem(this.Ldlist, Xdlist.SelectedValue, MenuItemSQL);
                    Ldlist.SelectedValue = download.M_ItemID.ToString();
                    if (download.Remark == "1")
                    {
                        this.txtZhi.Checked = true;
                    }
                }

                else
                {
                    txtdate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    BandMenuItem(this.Ldlist, Xdlist.SelectedValue, MenuItemSQL);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UC_DownLoad download;
                IUC_DownLoad idownload = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_DownLoadDaoService"] as IUC_DownLoad;
                if (Request.QueryString["id"] != null)
                    download = idownload.FindById(int.Parse(Request.QueryString["id"]));
                else
                    download = new UC_DownLoad();
                download.FileName = txttitle.Value;
                download.M_ID = int.Parse(Xdlist.SelectedValue);
                download.M_ItemID = int.Parse(Ldlist.SelectedValue);
                download.State = int.Parse(DrState.Text);
                if (txtZhi.Checked != false)
                    download.Remark = "1";
                else
                    download.Remark = "0";

                if (txtdate.Value != "")
                    download.AddTime = DateTime.Parse(txtdate.Value);
                else
                    download.AddTime = DateTime.Now;
                download.FileFact = txtFileFact.Text.Trim();
                if (Request.QueryString["id"] != null)
                {
                    idownload.Update(download);
                    WebUtility.ShowMsg(this, "修改成功");
                    //WebUtility.ShowMsg(this, "修改成功", "UpLoadFileList.aspx");
                    return;
                }
                else
                {
                    idownload.Insert(download);

                    WebUtility.ShowMsg(this, "添加成功");
                    //WebUtility.ShowMsg(this, "添加成功", "UpLoadFileList.aspx");
                    return;
                }
            }
            catch (Exception ex)
            {
                log.Error("提交失败", ex);
                WebUtility.ShowMsg(this, "提交失败");
            }

        }
        protected void Xdlistonclick(object sender, EventArgs e)
        {
            BandMenuItem(this.Ldlist, Xdlist.SelectedValue, MenuItemSQL);
        }
        public  string GetFileExtends(string filename)
        {
            string ext = null;
            if (filename.IndexOf('.') > 0)
            {
                string[] fs = filename.Split('.');
                ext = fs[fs.Length - 1];
            }
            return ext;
        } 

        protected void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUp.HasFile)
                {
                    string Extends = GetFileExtends(FileUp.FileName);
                    if (Extends == "exe")
                    {
                        WebUtility.ShowMsg(this, "请不要上传非法文件！");
                    }
                    else
                    {
                        int i = FileUp.PostedFile.ContentLength;//获取上传文件的大小
                        if (i > 104857600)
                        {
                            WebUtility.ShowMsg(this, "上传文件不能超过100M,请压缩后上传,或者联系管理员处理！");
                            return;
                        }

                        string path = Server.MapPath("../NewsFile/upload/");

                        if (System.IO.Directory.Exists(path) == false)
                        {
                            System.IO.Directory.CreateDirectory(path);
                        }
                        FileUp.SaveAs(path + FileUp.FileName);
                        txtFileFact.Text = FileUp.FileName;
                        WebUtility.ShowMsg(this, "文件上传成功！");

                    }
                }
                else
                {
                    WebUtility.ShowMsg(this, "上传文件不能为空！");
                }
            }
            catch (Exception ex)
            {
                log.Error("上传失败", ex);
                WebUtility.ShowMsg(this, "文件上传失败！");
            }
        }


    }
}
