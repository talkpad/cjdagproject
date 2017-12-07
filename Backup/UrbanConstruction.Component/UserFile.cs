using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.UI;
using System.Web;

namespace UrbanConstruction.Component
{
    public class UserFile : System.Web.UI.Page
    {
        int i;
        bool transfer = false;
        public UserFile()
        {
            this.PreInit += new System.EventHandler(this.User_Default_PreInit);
        }
        protected override void OnInit(EventArgs e)
        {
            try
            {         
                if (user == null)
                {
                    Response.Write("<script language='javascript'>");
                    Response.Write("alert('请先登录');top.location.href='Login.aspx';");
                    Response.Write("</" + "script>");
                }               
            }
            catch { }
        }

        private void User_Default_PreInit(object sender, EventArgs e)
        {

            if (user == null)
            {
                //MessageHelper.ShowRedirect("登陆超时,请重新登陆", "/Login.aspx");
                this.ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "<script>alert('登陆超时,请重新登陆');top.location.href='Login.aspx'</script>");
                i = 1;
                return;
            }
            //if (!User.Identity.IsAuthenticated)
            //{
            //    //权限判断
            //    Response.Redirect("/login.aspx?ReturnUrl=" + Request.Path.ToLower());
            //    Response.End();
            //}
        }

        /// <summary>
        /// 当前登录者
        /// </summary>
        public User user
        {
            get
            {
                HttpCookie cookie = Request.Cookies["User"];
                if (cookie !=null && cookie.Values["username"].Length >0)
                {
                    User bod = new User();
                    bod.UserName = cookie.Values["username"];
                    bod.UserType = int.Parse(cookie.Values["usertype"]);
                    return bod;
                }
                else
                {
                    return null;
                }
            }
        }

        public void BandMenu(DropDownList Xdlist, string sql)
        {
            Xdlist.DataSource = Datatablebind.GetUC_Menu(sql);
            Xdlist.DataTextField = "m_name";
            Xdlist.DataValueField = "m_id";
            Xdlist.DataBind();
            Xdlist.Items.Insert(0, new ListItem("请选择", ""));
        }

        public string GetCompanyName(string Companyid)
        {
            return Datatablebind.GetCompanyName(Companyid);
        }
        public string GetMenuItemName(string m_itemid)
        {
            return Datatablebind.GetMenuItemName(m_itemid);
        }
        public void BandMenuItem(DropDownList Ldlist, object e, string sql)
        {
            Ldlist.DataSource = Datatablebind.GetUC_MenuItem(sql + "  AND M_ID='" + e.ToString() + "'");
            Ldlist.DataTextField = "M_ItemNAME";
            Ldlist.DataValueField = "M_ItemID";
            Ldlist.DataBind();
            Ldlist.Items.Insert(0, new ListItem("请选择", ""));
        }
        public void BandTown(DropDownList drp)
        {
            drp.DataSource = Datatablebind.GetUC_Town("");
            drp.DataTextField = "CompanyName";
            drp.DataValueField = "Companyid";
            drp.DataBind();
            drp.Items.Insert(0, new ListItem("请选择", ""));
        }

        public bool CheckUploadImg(FileUpload m_filTitleImg, out string msg)
        {
            msg = "";
            string img = GetFileExtends(m_filTitleImg.FileName).Trim().ToLower();//获取文件后缀名
            if (img == "jpg" || img == "gif" || img == "png")
            {
                int i = m_filTitleImg.PostedFile.ContentLength;//获取上传文件的大小
                if (i > 10485760)
                {
                    msg = "上传文件不能超过10M,请压缩后上传,或者联系管理员处理";
                    return false;
                }
            }
            else
            {
                msg = "图片格式不正确";
                return false;
            }

            return true;

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

        /// <summary>
        /// 得到用户类型
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string GetUserTypeName(int i)
        {
            string str = string.Empty;

            //if (i == UserType.User)
            //{
            //    str = "普通用户";
            //}
            //else if (i == UserType.Manager)
            //{
            //    str = "部门主管";
            //}
            //if (i == UserType.Administrator)
            //{
            //    str = "管理员";
            //}
            //if (i == UserType.SystemManager)
            //{
            //    str = "系统管理员";
            //}
            str = "管理员";
            return str;
        }

        public IList ListTypeForEnum()
        {
            ArrayList list = new ArrayList();
            ListItem listitem = new ListItem("普通用户", "1");
            list.Add(listitem);
            listitem = new ListItem("部门主管", "2");
            list.Add(listitem);
            listitem = new ListItem("管理员", "3");
            list.Add(listitem);
            listitem = new ListItem("系统管理员", "4");
            list.Add(listitem);

            return list;
        }
        /// <summary>
        /// 获取状态
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string StateName(int state)
        {
            string name = string.Empty;
            if ((int)EnumType.StateType.已审核 == state)
            {
                name = "审核通过";
            }
            if ((int)EnumType.StateType.未审核 == state)
            {
                name = "未审核";
            }
            return name;
        }

        /// <summary>
        /// 获取文件状态 1-停用，3-启用
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string StopStateName(int state)
        {
            string name = string.Empty;
            if ((int)EnumType.StateType.已审核 == state)
            {
                name = "启用";
            }
            else
                if ((int)EnumType.StateType.未审核 == state)
                {
                    name = "停用";
                }
            return name;
        }
        protected override void OnLoad(EventArgs e)
        {
            if (i == 1)
            {
                return;
            }
            RegScriptOrCSS();
            base.OnLoad(e);
        }

        /// <summary>
        /// 获取回复状态
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public string AnswerName(object o)
        {
            string Answer = string.Empty;
            if (o == null || o.ToString() == "")
            {
                Answer = "未回复";
            }
            else
            {
                Answer = "已回复";
            }
            return Answer;
        }

        private void RegScriptOrCSS()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<link rel=\"stylesheet\" type=\"text/css\" />  ");
            this.Header.Controls.AddAt(0, new LiteralControl(sb.ToString()));
        }
    }

    [Serializable]
    public class User
    {
        private string _UserName;
        private int _UserId;
        private int _Type;
        private int _UserType;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        /// <summary>
        /// 用户类型 1-镇区用户，2-系统用户
        /// </summary>
        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UserType
        {
            get { return _UserType; }
            set { _UserType = value; }
        }
    }
}
