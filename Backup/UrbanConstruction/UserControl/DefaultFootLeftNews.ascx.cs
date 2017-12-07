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
using System.Collections.Generic;
using UrbanConstruction.Service;
using UrbanConstruction.Component;

namespace UrbanConstruction.UserControl
{
    public partial class DefaultFootLeftNews : System.Web.UI.UserControl
    {
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
            IUC_MenuItem idal = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_MenuItemDaoService"] as IUC_MenuItem;
            list = idal.GetAllList("type=2 and m_id in(select m_id from uc_menu where is_menu=1)").ToList();
            count = list.Count;
        }

    }
}