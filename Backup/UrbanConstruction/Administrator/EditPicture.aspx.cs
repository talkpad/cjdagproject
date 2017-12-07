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
using log4net;
using UrbanConstruction.Service;
using UrbanConstruction.Model;

namespace UrbanConstruction.Administrator
{
    public partial class EditPicture : UserFile
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    IUC_Pictures ipic= ((ContainerWebAccessorUtil.ObtainContainer()))["UC_PicturesDaoService"] as IUC_Pictures;
                    UC_Pictures pic = ipic.FindById(int.Parse(Request.QueryString["id"]));
                    txttitle.Value = pic.PictureName;
                    txtdate.Value = pic.AddTime.ToString("yyyy-MM-dd HH:mm:ss");
                    DrState.SelectedValue = pic.State.ToString();
                    ddl_type.SelectedValue = pic.Type.ToString();
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
        private UC_Pictures pict;
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                IUC_Pictures ipic = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_PicturesDaoService"] as IUC_Pictures;
                if (Request.QueryString["id"] != null)
                    pict = ipic.FindById(int.Parse(Request.QueryString["id"]));
                else
                    pict = new UC_Pictures();
                pict.PictureName = txttitle.Value.Trim();
                pict.AddTime = DateTime.Parse(txtdate.Value.Trim().ToString());
                pict.State = int.Parse(DrState.SelectedValue);
                pict.Type = int.Parse(ddl_type.SelectedValue);
                if (FileUp.HasFile)
                {
                    string Extends = GetFileExtends(FileUp.FileName);
                    if (Extends.ToLower() == "exe")
                    {
                        WebUtility.ShowMsg(this, "请不要上传非法文件！");
                        return;
                    }
                    else
                    {
                        
                        int i = FileUp.PostedFile.ContentLength;//获取上传文件的大小
                        if (i > 20971520)
                        {
                            WebUtility.ShowMsg(this, "上传的图片不能超过20M,请压缩后上传,或者联系管理员处理");
                            return;
                        }
                        string path = null;// Server.MapPath("VideoFiles/");
                        switch(int.Parse(ddl_type.SelectedValue))
                        {
                            case 1: path = Server.MapPath("../NewsFile/images/City/OldView/"); break;
                            case 2: path = Server.MapPath("../NewsFile/images/City/Memory/"); break;
                            case 3: path = Server.MapPath("../NewsFile/images/City/Famous/"); break;
                            case 4: path = Server.MapPath("../NewsFile/images/City/BigChange/"); break;
                            case 5: path = Server.MapPath("../NewsFile/images/City/NewScenery/"); break;
                            case 6: path = Server.MapPath("../NewsFile/images/City/GreaterHouse/"); break;
                            case 7: path = Server.MapPath("../NewsFile/images/City/LivingEnvironment/"); break;
                            default: break;
                        }
                        
                        if (System.IO.Directory.Exists(path) == false)
                        {
                            System.IO.Directory.CreateDirectory(path);
                        }
                        FileUp.SaveAs(path + FileUp.FileName);
                        switch (int.Parse(ddl_type.SelectedValue))
                        {
                            case 1: path = "NewsFile/images/City/OldView/"; break;
                            case 2: path = "NewsFile/images/City/Memory/"; break;
                            case 3: path = "NewsFile/images/City/Famous/"; break;
                            case 4: path = "NewsFile/images/City/BigChange/"; break;
                            case 5: path = "NewsFile/images/City/NewScenery/"; break;
                            case 6: path = "NewsFile/images/City/GreaterHouse/"; break;
                            case 7: path = "NewsFile/images/City/LivingEnvironment/"; break;
                            default: break;
                        }
                        pict.PictureURL =path+ FileUp.FileName;
                    }
                }
                else
                {
                    WebUtility.ShowMsg(this, "上传图片不能为空");
                    return;
                }
                if (Request.QueryString["id"] != null)
                {
                    ipic.Update(pict);
                    WebUtility.ShowMsg(this, "修改成功!");
                    //WebUtility.ShowMsg(this, "修改成功", "VideoList.aspx");
                    return;
                }
                else
                {
                    ipic.Insert(pict);
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
