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
using UrbanConstruction.Service;
using UrbanConstruction.Model;

namespace UrbanConstruction.Administrator
{
    public partial class VideoList : UserFile
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
            IUC_NewsList ivideo = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
            string newtype = "(" + (int)EnumType.NewsType.视频 + "," + (int)EnumType.NewsType.首页视频 + "," + (int)EnumType.NewsType.展览视频 + ")";
            Rplist.DataSource = ivideo.FindAll(pageSize, pageIndex, 1, string.Format("kind={0} and type in {1}",(int)EnumType.KindType.编研成果,newtype), "ID").ToList();
            Rplist.DataBind();

            int Count = ivideo.FindAll(string.Format("kind={0} and type={1}", (int)EnumType.KindType.编研成果, (int)EnumType.NewsType.视频));
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
                IUC_NewsList ivideo = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
                UC_NewsList video = ivideo.FindById(ID);

                if (video != null)
                {
                    if (e.CommandName.Equals("del"))
                    {

                        ivideo.Delete(ID);
                        WebUtility.ShowMsg(this, "删除成功");
                        BindInfo();


                    }

                }

            }

        }
        #endregion
    }
}
