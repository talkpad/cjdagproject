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
using UrbanConstruction.Model;
using UrbanConstruction.Component;

namespace UrbanConstruction.Administrator
{
    public partial class BookList : UserFile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindInfo();
                if (Request.QueryString["id"] != null)
                {

                }
            }
        }
        public int pageIndex = 1;
        public int pageCount = 0;
        public int pageSize = 12;
        public void BindInfo()
        {
            if (Request.QueryString["pageIndex"] != null)
            {
                pageIndex = int.Parse(Request.QueryString["pageIndex"]);
            }
            IUC_NewsList inews = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
            Rplist.DataSource = inews.FindAll(pageSize, pageIndex, 1, string.Format("kind={0} and type!= {1} ", (int)EnumType.KindType.编研成果, (int)EnumType.NewsType.视频), "ID").ToList();
            Rplist.DataBind();

            int Count = inews.FindAll(string.Format("kind={0} and type!= {1} and state={2}", (int)EnumType.KindType.编研成果, (int)EnumType.NewsType.视频, (int)EnumType.StateType.已审核));
            pageCount = (int)Math.Ceiling((double)Count / pageSize);
            if (pageCount == 0)
                pageIndex = 0;
        }
        protected void pager_PageChanged(object sender, EventArgs e)
        {
            BindInfo();
        }

        #region rpt事件
        protected void Rplist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex > -1)
            {

            }
        }

        protected void Rplist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName != null)
            {
                int ID = int.Parse(e.CommandArgument.ToString());
                IUC_NewsList inews = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
                UC_NewsList pic = inews.FindById(ID);

                if (pic != null)
                {
                    if (e.CommandName.Equals("del"))
                    {

                        inews.Delete(ID);
                        WebUtility.ShowMsg(this, "删除成功");
                        BindInfo();


                    }

                }

            }

        }
        #endregion
    }
}

