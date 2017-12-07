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

namespace UrbanConstruction.UserControl
{
    public partial class DefaultLeft : System.Web.UI.UserControl
    {
        /// <summary>
        /// 父功能菜单的的序号

        /// </summary>
        public int M_ID
        {
            set
            {
                this.ViewState.Add("M_ID", value);
            }
            get
            {
                if (ViewState["M_ID"] == null)
                    return 0;
                else
                    return int.Parse(ViewState["M_ID"].ToString());
            }
        }
        /// <summary>
        /// 当前功能菜单的序号

        /// </summary>
        public int M_ItemId
        {
            set
            {
                this.ViewState.Add("M_ItemId", value);
            }
            get
            {
                if (ViewState["M_ItemId"] == null)
                    return 0;
                else
                    return int.Parse(ViewState["M_ItemId"].ToString());
            }

        }
        public string M_NAME
        {
            set
            {
                this.ViewState.Add("M_NAME", value);
            }
            get
            {
                if (ViewState["M_NAME"] == null)
                    return "";
                else
                    return ViewState["M_NAME"].ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bindinfo();

            }
        }
        public void Bindinfo()
        {
            //if (Request.QueryString["CID"] != null)
            //{
            //    if (M_ID == 2)
            //    {
            //        if (M_NAME == null || M_NAME.Trim() == "")
            //            M_NAME = "政务公开";
            //        IT_MenuItem idal_item = ((ContainerWebAccessorUtil.ObtainContainer()))["T_MenuItemDaoService"] as IT_MenuItem;

            //        string Where = "1=1 and status=1 AND M_ID=2";
            //        IList<T_MenuItem> list = idal_item.FindAll(1000, 1, 0, Where);
            //        Rplist2.DataSource = list.OrderBy(o => o.Ordering).ToList();
            //        Rplist2.DataBind();
            //        ZWGK.Visible = true;
            //    }
            //    else
            //    {
            //        IT_MenuItem idal_item = ((ContainerWebAccessorUtil.ObtainContainer()))["T_MenuItemDaoService"] as IT_MenuItem;

            //        string Where = "1=1 and status=1 AND M_ID=" + M_ID;
            //        IList<T_MenuItem> list = idal_item.FindAll(1000, 1, 0, Where);

            //        Rplist.DataSource = list.OrderBy(o => o.Ordering).ToList();
            //        Rplist.DataBind();
            //    }
            //}
            //else if (Request.QueryString["T_TYPE"] != null)
            //{
            //    left1.Visible = false;
            //    left2.Visible = true;
            //}
            //else if (Request.QueryString["T_MID"] != null)
            //{
            //    left1.Visible = false;
            //    left3.Visible = true;
            //}
            //else
            //{
            //    if (this.Page.ToString().ToLower().Contains("politicslist_aspx"))
            //    {
            //        M_NAME = "政务公开";
            //        IT_MenuItem idal_item = ((ContainerWebAccessorUtil.ObtainContainer()))["T_MenuItemDaoService"] as IT_MenuItem;
            //        string Where = "1=1 and status=1 AND M_ID=2";
            //        IList<T_MenuItem> list = idal_item.FindAll(1000, 1, 0, Where);
            //        Rplist2.DataSource = list.OrderBy(o => o.Ordering).ToList();
            //        Rplist2.DataBind();
            //        ZWGK.Visible = true;
            //    }
            //    else
            //        if (this.Page.ToString().ToLower().Contains("ztlist_aspx"))
            //        {
            //            M_NAME = "政务动态";
            //            IT_MenuItem idal_item = ((ContainerWebAccessorUtil.ObtainContainer()))["T_MenuItemDaoService"] as IT_MenuItem;
            //            string Where = "1=1 and status=1 AND M_ID=3";
            //            M_ItemId = 168;
            //            M_ID = 3;
            //            IList<T_MenuItem> list = idal_item.FindAll(1000, 1, 0, Where);
            //            Rplist.DataSource = list.OrderBy(o => o.Ordering).ToList();
            //            Rplist.DataBind();
            //        }
            //}



        }
        public string cl(object id)
        {
            string yasi = string.Empty;
            if (id.ToString() == M_ItemId.ToString())
            {
                yasi = "xz";
            }
            return yasi;
        }

        public string c2(object id)
        {
            string yasi = string.Empty;
            int C_ID;
            if (int.TryParse(Request.QueryString["T_TYPE"], out C_ID) == true)
            {
                if (id.ToString() == C_ID.ToString())
                {
                    yasi = "xz";
                }
            }
            return yasi;
        }
    }
}