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
    public partial class UpLoadFileList : UserFile
    {
        private readonly string MenuSQL = "and  status=1 ";
        private readonly string MenuItemSQL = "and status=1 ";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BandMenu(this.Xdlist, MenuSQL);
                BandMenuItem(this.Ldlist, Xdlist.SelectedValue, MenuItemSQL);
                Bindinfo();


            }
        }

        public int pageIndex = 1;
        public int pageCount = 0;
        public int pageSize = 12;
        public void Bindinfo()
        {
            if (Request.QueryString["pageIndex"] != null)
            {
                pageIndex = int.Parse(Request.QueryString["pageIndex"]);
            }
            IUC_DownLoad idownload = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_DownLoadDaoService"] as IUC_DownLoad;
            Rplist.DataSource = idownload.FindAll(pageSize, pageIndex, 1, GetFindValue(), "ID").ToList();
            Rplist.DataBind();

            int Count = idownload.FindAll(GetFindValue());
            pageCount = (int)Math.Ceiling((double)Count / pageSize);
            if (pageCount == 0)
                pageIndex = 0;
        }

        public string GetFindValue()
        {
            string str = string.Empty;
            str = "1=1";
            try
            {
                if (txttitle.Value.Trim() != "")
                {
                    str += " and FileName like N'%" + WebUtility.InputTextForSql(txttitle.Value.Trim()) + "%'";
                }
                if (Xdlist.SelectedValue != "" && Xdlist.SelectedValue != "-1")
                {
                    str += " and M_ID=" + Xdlist.SelectedValue + "";
                }
                if (Ldlist.SelectedValue != "" && Ldlist.SelectedValue != "-1")
                {
                    str += " and M_ItemID=" + Ldlist.SelectedValue + "";
                }
                if (txtdate.Value.Trim() != "")
                {
                    string dataS = Convert.ToDateTime(txtdate.Value.Trim()).ToString("yyyy-MM-dd");
                    str += " and convert(varchar(10),AddTime,20)>='" + dataS + "'";
                }
                if (txtdao.Value.Trim() != "")
                {
                    string dataE = Convert.ToDateTime(txtdao.Value.Trim()).ToString("yyyy-MM-dd");
                    str += " and convert(varchar(10),AddTime,20)<='" + dataE + "'";
                }
            }
            catch { }
            return str;
        }


        protected void btnQuery_Click(object sender, EventArgs e)
        {
            Bindinfo();
        }
        protected void Xdlistonclick(object sender, EventArgs e)
        {
            BandMenuItem(this.Ldlist, Xdlist.SelectedValue, MenuItemSQL);
        }
        #region rpt事件
        protected void Rplist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex > -1)
            {
                //int State = int.Parse(DataBinder.Eval(e.Item.DataItem, "State").ToString());
                //LinkButton lbtnEdit = e.Item.FindControl("lbtnEdit") as LinkButton;

                //LinkButton lbtnDel = e.Item.FindControl("lbtnDel") as LinkButton;
                //  UserType.ControlRight(user.UserType, State, lbtnEdit, lbtnCheck, lbtnCancel, lbtnDel);
            }
        }

        protected void Rplist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName != null)
            {
                int ID = int.Parse(e.CommandArgument.ToString());
                IUC_DownLoad idownload = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_DownLoadDaoService"] as IUC_DownLoad;
                UC_DownLoad download = idownload.FindById(ID);

                if (download != null)
                {
                    if (e.CommandName.Equals("del"))
                    {

                        idownload.Delete(ID);
                        WebUtility.ShowMsg(this, "删除成功");
                        Bindinfo();


                    }

                }

            }

        }
        #endregion

    }
}

