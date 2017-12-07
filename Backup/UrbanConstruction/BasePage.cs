using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrbanConstruction.Model;
using UrbanConstruction.Dao;
using UrbanConstruction.Component;
using UrbanConstruction.Service;

namespace UrbanConstruction
{
    public class BasePage : System.Web.UI.Page
    {
        public BasePage()
        {
            this.PreInit += new System.EventHandler(this.BasePage_Default_PreInit);
        }

        private void BasePage_Default_PreInit(object sender, EventArgs e)
        {
            int CID = 0;
            if (int.TryParse(Request.QueryString["CID"], out CID) == true)
            {

                UC_MenuItem menuitem = new UC_MenuItem();
                IUC_MenuItem idal = (ContainerWebAccessorUtil.ObtainContainer())["UC_MenuItemDaoService"] as IUC_MenuItem;
                menuitem = idal.FindById(int.Parse(Request["CID"]));
                if (menuitem != null)
                {
                    UC_Menu uc_menu = new UC_Menu();
                    IUC_Menu idalmenu = (ContainerWebAccessorUtil.ObtainContainer())["UC_MenuDaoService"] as IUC_Menu;
                    uc_menu = idalmenu.FindById(menuitem.M_ID);
                    if (uc_menu != null)
                    {
                        MenuName = uc_menu.M_NAME;
                        MenuItemName = menuitem.M_ItemName;
                        M_ID = menuitem.M_ID;
                        M_ItemId = menuitem.M_ItemID;
                        MenuName = uc_menu.M_NAME;
                    }

                }

            }
        }

        public void ShowRedirectDefault(string msg)
        {
            SZM.Utility.Library.MessageHelper.ShowRedirect(msg, "index.aspx");
        }
        public void ShowRedirect(string MSG, string Url)
        {
            SZM.Utility.Library.MessageHelper.ShowRedirect(MSG, Url);
        }
        private int _pagesize = 20;
        public int PageSize
        {
            set
            {
                _pagesize = value;
            }
            get
            {
                return _pagesize;

            }
        }
        public int M_ID
        {
            set
            {
                ViewState.Add("M_ID", value);
            }
            get
            {
                if (ViewState["M_ID"] == null)
                    return 0;
                else
                    return int.Parse(ViewState["M_ID"].ToString());
            }
        }
        public int M_ItemId
        {
            set
            {
                ViewState.Add("M_ItemId", value);
            }
            get
            {
                if (ViewState["M_ItemId"] == null)
                    return 0;
                else
                    return int.Parse(ViewState["M_ItemId"].ToString());
            }
        }

        public string MenuName
        {
            set
            {
                ViewState.Add("M_NAME", value);
            }
            get
            {
                if (ViewState["M_NAME"] == null)
                    return "";
                else
                    return ViewState["M_NAME"].ToString();
            }
        }
        public string MenuItemName
        {
            set
            {
                ViewState.Add("MenuItemName", value);
            }
            get
            {
                if (ViewState["MenuItemName"] == null)
                    return "";
                else
                    return ViewState["MenuItemName"].ToString();
            }
        }
    }
}
