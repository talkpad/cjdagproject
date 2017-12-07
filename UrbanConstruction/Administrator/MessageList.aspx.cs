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
    public partial class MessageList : UserFile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindInfo();
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
            //IUC_Message imessage = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_MessageDaoService"] as IUC_Message;
            IUC_Guestbook imessage = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_GuestbookDaoService"] as IUC_Guestbook;
            Rplist.DataSource = imessage.FindAll(pageSize, pageIndex, 1, GetFindValue(), "ID").ToList();
            Rplist.DataBind();

            int Count = imessage.FindAll(GetFindValue());
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
                    str += " and Title like N'%" + WebUtility.InputTextForSql(txttitle.Value.Trim()) + "%'";
                }
                if (ddlist.SelectedValue != "")
                {
                    str += " and State=" + ddlist.SelectedValue + "";
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

                if (txthl.Value.Trim() != "")
                {
                    string dataHl = Convert.ToDateTime(txthl.Value.Trim()).ToString("yyyy-MM-dd");
                    str += " and convert(varchar(10),AnswerTime,20)>='" + dataHl + "'";
                }
                if (txthd.Value.Trim() != "")
                {
                    string dataHd = Convert.ToDateTime(txthd.Value.Trim()).ToString("yyyy-MM-dd");
                    str += " and convert(varchar(10),AnswerTime,20)<='" + dataHd + "'";
                }

                if (Hlist.SelectedValue != "")
                {
                    if (Hlist.SelectedValue == "1")
                        str += " and Convert(varchar(10),isnull(answer,''))!='' ";
                    if (Hlist.SelectedValue != "" && Hlist.SelectedValue == "2")
                        str += " and Convert(varchar(10),isnull(answer,''))='' ";
                }
                //if (drpType.SelectedValue != "")
                //{
                //    if (drpType.SelectedValue == "1")
                //        str += " and Type=1";
                //    if (drpType.SelectedValue == "2")
                //        str += " and Type=0";
                //}
            }
            catch { }
            return str;
        }
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindInfo();
        }

        #region rpt事件
        protected void Rplist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex > -1)
            {
                int State = int.Parse(DataBinder.Eval(e.Item.DataItem, "State").ToString());
                //HyperLink lbtnEdit = e.Item.FindControl("lbtnEdit") as HyperLink;
                //LinkButton lbtnCheck = e.Item.FindControl("lbtnCheck") as LinkButton;
                //LinkButton lbtnCancel = e.Item.FindControl("lbtnCancel") as LinkButton;
                LinkButton lbtnDel = e.Item.FindControl("lbtnDel") as LinkButton;
                //ControlRight(State, lbtnEdit, lbtnCheck, lbtnCancel, lbtnDel);
            }
        }
        //public static void ControlRight(int state, HyperLink lbnEdit, LinkButton lbnCheck, LinkButton lbnCanel, LinkButton lbnDel)
        //{
        //    lbnEdit.Enabled = false;
        //    lbnCheck.Enabled = false;
        //    lbnCanel.Enabled = false;
        //    lbnDel.Enabled = false;

        //    if (state == (int)EnumType.StateType.未审核)
        //    {
        //        lbnEdit.Enabled = true;
        //        lbnCheck.Enabled = true;
        //        lbnDel.Enabled = true;
        //    }
        //    else
        //    {
        //        lbnCanel.Enabled = true;
        //    }

        //}
        protected void Rplist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName != null)
            {
                //IUC_Message imessage = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_MessageDaoService"] as IUC_Message;
                IUC_Guestbook imessage = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_GuestbookDaoService"] as IUC_Guestbook;
                int ID = int.Parse(e.CommandArgument.ToString());
                UC_Guestbook news = imessage.FindById(ID);
                if (news != null)
                {
                    if (e.CommandName.Equals("del"))
                    {

                        imessage.Delete(ID);
                        WebUtility.ShowMsg(this, "删除成功");
                        BindInfo();


                    }
                    else if (e.CommandName.Equals("check"))
                    {
                        news.State = (int)EnumType.StateType.已审核;
                        imessage.Examine(news);
                        WebUtility.ShowMsg(this, "审核成功");
                        BindInfo();
                    }
                    else if (e.CommandName.Equals("cancel"))
                    {
                        news.State = (int)EnumType.StateType.未审核;
                        imessage.Examine(news);
                        WebUtility.ShowMsg(this, "取消审核成功");
                        BindInfo();

                    }
                }

            }

        }
        #endregion
    }
}
