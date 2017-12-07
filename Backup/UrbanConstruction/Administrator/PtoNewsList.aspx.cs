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
    public partial class PtoNewsList : UserFile
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
        protected void btnQuery_Click(object sender, EventArgs e)
        {

            pageIndex = 1;
            Bindinfo();
        }

        protected void Xdlistonclick(object sender, EventArgs e)
        {
            BandMenuItem(this.Ldlist, Xdlist.SelectedValue, MenuItemSQL);
        }

        #region 查询事件
        public void Bindinfo()
        { 
            if (Request.QueryString["pageIndex"] != null)
            {
                pageIndex = int.Parse(Request.QueryString["pageIndex"]);
            }
            IUC_NewsList inews = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
            Rplist.DataSource = inews.FindAll(pageSize, pageIndex, 1, GetFindSQL(), "ID").ToList();
            Rplist.DataBind();
          
            int Count = inews.FindAll(GetFindSQL());
            pageCount = (int)Math.Ceiling((double)Count / pageSize);
            if (pageCount == 0)
                pageIndex = 0;
        }
        public string GetFindSQL()
        {
            string str = string.Empty;
            str = string.Format(" Type={0} ",(int)EnumType.NewsType.图片新闻);
            try
            {
                if (txttitle.Value.Trim() != "")
                {
                    str += " and Title like N'%" + WebUtility.InputTextForSql(txttitle.Value.Trim()) + "%'";
                }
                if (ddlist.SelectedValue != "")
                {
                    str += " and State=" + ddlist.SelectedValue + "";
                }
                if (txtdate.Value.Trim() != "")
                {
                    string dataS = Convert.ToDateTime(txtdate.Value.Trim()).ToString("yyyy-MM-dd");
                    str += " and convert(varchar(10),ReleaseTime,20)>='" + dataS + "'";
                }
                if (txtdao.Value.Trim() != "")
                {
                    string dataE = Convert.ToDateTime(txtdao.Value.Trim()).ToString("yyyy-MM-dd");
                    str += " and convert(varchar(10),ReleaseTime,20)<='" + dataE + "'";
                }
                if (Xdlist.SelectedValue != "")
                    str += " and M_ID='" + Xdlist.SelectedValue + "'";

                if (Ldlist.SelectedValue != "")
                    str += " and M_ItemId='" + Ldlist.SelectedValue + "'";
            }
            catch { }
            return str;
        }
        #endregion

        #region rpt事件
        protected void Rplist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex > -1)
            {
                int State = int.Parse(DataBinder.Eval(e.Item.DataItem, "State").ToString());
                HyperLink lbtnEdit = e.Item.FindControl("lbtnEdit") as HyperLink;
                //LinkButton lbtnCheck = e.Item.FindControl("lbtnCheck") as LinkButton;
                //LinkButton lbtnCancel = e.Item.FindControl("lbtnCancel") as LinkButton;
                LinkButton lbtnDel = e.Item.FindControl("lbtnDel") as LinkButton;
                //ControlRight(State, lbtnEdit, lbtnCheck, lbtnCancel, lbtnDel);
            }
            if (user.UserType != 1)
            {
                if (e.Item.ItemType == ListItemType.Header)
                {
                    HtmlTableCell td = e.Item.FindControl("td1") as HtmlTableCell;
                    td.Visible = false;
                }
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HtmlTableCell tr = e.Item.FindControl("td2") as HtmlTableCell;
                    tr.Visible = false;
                }
            }
        }

        /// <summary>
        /// 控制按钮
        /// </summary>
        /// <param name="UserName">当前登录用户</param>
        /// <param name="lbnEdit">修改按钮</param>
        /// <param name="lbnCheck">审核按钮</param>
        /// <param name="lbnCanel">取消审核按钮</param>
        /// <param name="lbnDel">删除按钮</param>
        //public static void ControlRight(int state, HyperLink lbnEdit, LinkButton lbnCheck, LinkButton lbnCanel, LinkButton lbnDel)
        //{
        //    lbnEdit.Enabled = false;
        //    //lbnCheck.Enabled = false;
        //    //lbnCanel.Enabled = false;
        //    lbnDel.Enabled = false;

        //    if (state == (int)EnumType.StateType.未审核)
        //    {
        //        lbnEdit.Enabled = true;
        //        //lbnCheck.Enabled = true;
        //        lbnDel.Enabled = true;
        //    }
        //    else
        //    {
        //        lbnCanel.Enabled = true;
        //    }

        //}

        public string GetMenuName(int id)
        {
            IUC_MenuItem imenu = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_MenuItemDaoService"] as IUC_MenuItem;
            return imenu.FindById(id).M_ItemName;
        }

        public string GetState(int state)
        {
            string str = null;
            if (state == (int)EnumType.StateType.未审核)
                str = "未审核";
            else
                str = "已审核";
            return str;
        }

        bool che = false;
        protected void Rplist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName != null)
            {
                IUC_NewsList inews = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
                int ID = int.Parse(e.CommandArgument.ToString());
                UC_NewsList news = inews.FindById(ID);
                if (news != null)
                {
                    foreach (RepeaterItem item in this.Rplist.Items)
                    {
                        CheckBox cb = (CheckBox)item.FindControl("select");
                        if (cb.Checked)
                        {
                            che = true;
                        }
                    }

                    if (e.CommandName.Equals("del"))
                    {
                        if (che == true)
                        {
                            foreach (RepeaterItem item in this.Rplist.Items)
                            {
                                CheckBox cb = (CheckBox)item.FindControl("select");
                                HiddenField hf = (HiddenField)item.FindControl("hfID");
                                if (cb.Checked)
                                {
                                    inews.Delete(Convert.ToInt32(hf.Value));
                                }
                            }
                        }
                        try
                        {
                            inews.Delete(ID);
                        }
                        catch (Exception ex) { }
                        WebUtility.ShowMsg(this, "删除成功");
                        Bindinfo();

                    }
                    else if (e.CommandName.Equals("check"))
                    {
                        news.State = (int)EnumType.StateType.已审核;
                        if (che == true)
                        {
                            PiLiang((int)EnumType.StateType.已审核);
                        }
                        inews.Examine(news);
                        WebUtility.ShowMsg(this, "审核成功");
                        Bindinfo();
                    }
                    else if (e.CommandName.Equals("cancel"))
                    {
                        if (che == true)
                        {
                            PiLiang((int)EnumType.StateType.已审核);
                        }
                        news.State = (int)EnumType.StateType.未审核;
                        inews.Examine(news);
                        WebUtility.ShowMsg(this, "取消审核成功");
                        Bindinfo();
                    }
                }
            }
        }
        #endregion


        private void PiLiang(int state)
        {
            foreach (RepeaterItem item in this.Rplist.Items)
            {
                CheckBox cb = (CheckBox)item.FindControl("select");
                HiddenField hf = (HiddenField)item.FindControl("hfID");
                if (cb.Checked)
                {
                    IUC_NewsList inew = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
                    UC_NewsList newscheck = inew.FindById(Convert.ToInt32(hf.Value));
                    newscheck.State = state;
                    inew.Examine(newscheck);
                }
            }
        }
    }
}
