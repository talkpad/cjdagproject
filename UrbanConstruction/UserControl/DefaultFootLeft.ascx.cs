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
using UrbanConstruction.Model;
using UrbanConstruction.Service;
using UrbanConstruction.Component;
using System.Collections.Generic;

namespace UrbanConstruction.UserControl
{
    public partial class DefaultFootLeft : System.Web.UI.UserControl
    {
        /// <summary>
        /// 功能序号
        /// </summary>
        public string ItemID
        {
            set;
            get;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bind();
            }
        }  
        public int count = 0;
        public List<UC_MenuItem> list = null;
        public void Bind()
        {
            string kindtype = "(" + (int)EnumType.KindType.本馆概况 + "," + (int)EnumType.KindType.本馆职能 + "," + (int)EnumType.KindType.馆藏介绍 + "," + (int)EnumType.KindType.联系我们 + ")";
            IUC_MenuItem idal = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_MenuItemDaoService"] as IUC_MenuItem;
            list = idal.GetAllList(string.Format("kind in {0} and m_id in(select m_id from uc_menu where is_menu=1)",kindtype)).ToList();
            count = list.Count;
        }

        public string cl(object id)
        {
            string yasi = string.Empty;
            if (id.ToString() == ItemID.ToString())
            {
                yasi = "xz";
            }
            return yasi;
        }
    }
}