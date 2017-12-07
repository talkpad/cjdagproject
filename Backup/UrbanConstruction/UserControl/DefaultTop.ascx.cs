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
using UrbanConstruction.Service;
using UrbanConstruction.Component;
using UrbanConstruction.Model;
using System.Collections.Generic;

namespace UrbanConstruction.UserControl
{
    public partial class DefaultTop : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bind();
            }
        }
        public int n = 0;
        public int count = 0;
        public int countSon = 0;
        public List<UC_Menu> listMenuBig = null;
        public List<UC_MenuItem> listMenuSon = null;
        public void Bind()
        {
            IUC_Menu idal = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_MenuDaoService"] as IUC_Menu;
            listMenuBig = idal.FindAll(100, 1, 0, "1=1 and status=1 and Is_Menu=1 and parentId=0").ToList();
            count = listMenuBig.Count;
        }
        public int GetMenuSon(UC_Menu item)
        {
            if (item.IsPulldown == 1)
            {
                IUC_MenuItem idal_item = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_MenuItemDaoService"] as IUC_MenuItem;
                string where = String.Format("1=1 and status=1 AND M_ID={0} and is_menu =1 ", item.M_ID);
                listMenuSon = idal_item.FindAll(1000, 1, 0, where, "Ordering").ToList();
                countSon = listMenuSon.Count;
                return countSon;
            }
            else
                return 0;
        }

        //public void Bind()
        //{
        //    IUC_Menu idal = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_MenuDaoService"] as IUC_Menu;
        //    rptMenu.DataSource = idal.FindAll(100, 1, 0, "1=1 and status=1 and Is_Menu=1 and parentId=0");
        //    rptMenu.DataBind();
        //}

        //protected void rptMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemIndex > -1)
        //    {
        //        string M_ID = DataBinder.Eval(e.Item.DataItem, "M_ID").ToString();
        //        Repeater rptMenuItem = e.Item.FindControl("rptMenuItem") as Repeater;
        //        if (rptMenuItem != null)
        //        {
        //            IUC_Menu idal = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_MenuDaoService"] as IUC_Menu;

        //            rptMenuItem.DataSource = idal.FindAll(100, 1, 0, String.Format("1=1 and status=1 and Is_Menu=1 and parentId={0}", Convert.ToInt32(M_ID)), "Ordering");
        //            rptMenuItem.DataBind();
        //        }
        //    }
        //}

        //protected void reptSon_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemIndex > -1)
        //    {
        //        string M_ID = DataBinder.Eval(e.Item.DataItem, "M_ID").ToString();
        //        Repeater rptSon = e.Item.FindControl("reptSonItem") as Repeater;
        //        if (rptSon != null)
        //        {
        //            IUC_MenuItem idal_item = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_MenuItemDaoService"] as IUC_MenuItem;
        //            string where = String.Format("1=1 and status=1 AND M_ID={0}  ", M_ID);
        //            rptSon.DataSource = idal_item.FindAll(1000, 1, 0, where, "Ordering");
        //            rptSon.DataBind();
        //        }
        //    }
        //}

        public int i = 1;
    }
}