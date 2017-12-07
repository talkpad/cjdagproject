using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using UrbanConstruction.Model;
using System.Collections.Generic;
using UrbanConstruction.Service;
using UrbanConstruction.Component;
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;

namespace UrbanConstruction
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HttpCookieCollection cc = Request.Cookies;
                for (int i = 0; i < cc.Count; i++)
                {
                    cc[i].Expires = DateTime.Now.AddHours(20);
                }
                Bind();
                RecordHit();
                string token = CreateToken();                
                SaveTokenInServer(token);
            }
        }

        public string _salt = "asdfkl@,.;#sss13131313";

        public string CreateToken()
        {
            return MD5(Session.SessionID + _salt);
        }

        private void SaveTokenInServer(string token)
        {
            //一般保存在session中
            Session["CRSFToken"] = token;
        }

        private string MD5(string p)
        {
            p += "!@#<A8?";
            byte[] bytes = new UnicodeEncoding().GetBytes(p);
            byte[] buffer2 = new MD5CryptoServiceProvider().ComputeHash(bytes);
            StringBuilder builder = new StringBuilder();
            foreach (byte num in buffer2)
            {
                builder.AppendFormat("{0:X2}", num);
            }
            return builder.ToString();
        }
        public int kind = (int)EnumType.KindType.档案验收信息公布;
        public string kindid = ((int)EnumType.KindType.本馆工作动态).ToString();
        public string url;
        public StringBuilder content = new StringBuilder();
        public UC_NewsList zhuantiLeft = null;
        public UC_NewsList zhuantiRight = null;
        /// <summary>
        /// 两学一做
        /// </summary>
        public UC_NewsList specialsubject = null;//两学一做
        public List<UC_NewsList> list = null;
        public List<UC_NewsList> listChecked1 = null;
        public List<UC_NewsList> listChecked2 = null;
        public List<UC_NewsList> listWork = null;
        public List<UC_NewsList> listUCNew = null;
        public List<UC_NewsList> listGuide = null;
        public List<UC_DownLoad> listDown = null;
        public List<UC_Pictures> listPic = null;
        public List<UC_NewsList> listLaw = null;
        public List<UC_NewsList> listKnowledge = null;
        public List<UC_MenuItem> menulist = null;
        public void Bind()
        {
            //视频
            IUC_NewsList ivideo = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
            UC_NewsList video = ivideo.GetAllList(string.Format("state={0} and kind={1} and type={2}",(int)EnumType.StateType.已审核,(int)EnumType.KindType.编研成果,(int)EnumType.NewsType.首页视频)).FirstOrDefault(); ;
            if (video != null)
            {
                url = video.PictureURL;
            }
            //公告
            IUC_NewsList idal = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
            list = idal.GetList(4, string.Format("kind={0} and state={1}",(int)EnumType.KindType.通知公告,(int)EnumType.StateType.已审核)).ToList();
            //档案验收信息公布
            listChecked1 = idal.GetList(4, string.Format("kind={0} and state={1} and title like '%1'", (int)EnumType.KindType.档案验收信息公布, (int)EnumType.StateType.已审核)).ToList();
            listChecked2 = idal.GetList(4, string.Format("kind={0} and state={1} and title like '%2'", (int)EnumType.KindType.档案验收信息公布, (int)EnumType.StateType.已审核)).ToList();
            //图片新闻
            Tplist.DataSource = idal.GetList(5, string.Format("Type={0} and PictureURL!='' and state={1} and kind not in ({2},{3})", (int)EnumType.NewsType.图片新闻, (int)EnumType.StateType.已审核,(int)EnumType.KindType.左侧专题,(int)EnumType.KindType.右侧专题));
            Tplist.DataBind();
            //工作动态
            string kindtype = "(" + (int)EnumType.KindType.本馆工作动态 + ")";
            listWork = idal.GetList(7, string.Format("kind in {0} and state={1}",kindtype,(int)EnumType.StateType.已审核)).ToList();
            //中山城建新闻
            listUCNew = idal.GetList(7, string.Format("kind = {0} and state={1}", (int)EnumType.KindType.中山城建新闻, (int)EnumType.StateType.已审核)).ToList();
            ////办事指南
            //string guidetype = "(" + (int)EnumType.KindType.建设工程档案验收 + "," + (int)EnumType.KindType.地下管线档案验收 + "," + (int)EnumType.KindType.档案查阅 + "," + (int)EnumType.KindType.档案征集 + "," + (int)EnumType.KindType.办公电话 + ")";
            //listGuide = idal.GetList(8, string.Format("kind in {0} and state={1}", guidetype, (int)EnumType.StateType.已审核)).ToList();
            ////办事指南新  获取子菜单
            //string typekind = "(" + (int)EnumType.KindType.建设工程档案验收 + "," + (int)EnumType.KindType.地下管线档案验收 + "," + (int)EnumType.KindType.档案查阅 + "," + (int)EnumType.KindType.档案征集 + "," + (int)EnumType.KindType.办公电话 + ")";
            //IUC_MenuItem imenu = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_MenuItemDaoService"] as IUC_MenuItem;
            //menulist = imenu.GetAllList(string.Format("kind in {0}", typekind)).ToList();
            //下载中心
            IUC_DownLoad down = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_DownLoadDaoService"] as IUC_DownLoad;
            listDown = down.GetList(8,"1=1").ToList();
            //网上预览
            IUC_Pictures Pic = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_PicturesDaoService"] as IUC_Pictures;
            string pictype = "(" + (int)EnumType.PictureType.城市记忆 + "," + (int)EnumType.PictureType.城市巨变 + "," + (int)EnumType.PictureType.城市新貌 + "," + (int)EnumType.PictureType.旧城图 + "," + (int)EnumType.PictureType.名胜古迹 + "," + (int)EnumType.PictureType.人居环境 + "," + (int)EnumType.PictureType.伟人故里 + ")";
            listPic = Pic.GetList(9,string.Format("type in {0}",pictype)).ToList();
            //政策法规
            listLaw = idal.GetList(6, string.Format("kind={0} and state={1}",(int)EnumType.KindType.政策法规,(int)EnumType.StateType.已审核)).ToList();
            string reg =  @"[\u4e00-\u9fa5]+";
            MatchCollection Matches = Regex.Matches(listLaw[0].Content.Substring(0,1000), reg, RegexOptions.IgnoreCase);
            foreach (Match m in Matches)
            {
                if (content.Length <= 70)
                {
                    if (m.Value != "宋体")
                        content.Append(m.Value);
                }
                else
                {
                    break;
                }
            }
            content.Append("......");
            //学术研究
            listKnowledge = idal.GetList(4, string.Format("kind={0} and state={1}",(int)EnumType.KindType.学术研究,(int)EnumType.StateType.已审核)).ToList();
            //专题
            zhuantiLeft = idal.GetList(1,string.Format("state={0} and kind = {1}",(int)EnumType.StateType.已审核,(int)EnumType.KindType.左侧专题)).FirstOrDefault();
            zhuantiRight = idal.GetList(1, string.Format("state={0} and kind = {1}", (int)EnumType.StateType.已审核, (int)EnumType.KindType.右侧专题)).FirstOrDefault();
            specialsubject = idal.GetList(1, string.Format("state={0} and kind = {1}", (int)EnumType.StateType.已审核, (int)EnumType.KindType.两学一做)).FirstOrDefault();
        }

        public string GetString(string title)
        {
            if (title.Length > 20)
                return title.Substring(1, 20);
            else
                return title;
        }

        private void RecordHit()
        {
            IUC_HitCount ihits = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_HitCountDaoService"] as IUC_HitCount;
            UC_HitCount hits = ihits.FindById(1);
            if (hits == null)
            {
                UC_HitCount hits1 = new UC_HitCount() { ID = 1, Count = 1 };
                ihits.Insert(hits1);
            }
            else
            {   
                HttpCookie ck = Request.Cookies["UIP"];              
                string ip = string.Empty;
                if (ck != null)
                {
                    ip = Convert.ToString(ck.Values["IP"]);
                    ck.Expires = DateTime.Now.AddMinutes(1);
                }
                if (ip != GetUserIP())
                {
                    hits.Count = hits.Count + 1;
                    ihits.Update(hits);
                    HttpCookie cookie = new HttpCookie("UIP");                   
                    cookie.Expires = DateTime.Now.AddMinutes(1);                   
                    cookie.Values.Add("IP", GetUserIP());
                    Response.Cookies.Add(cookie);                    
                }
              
              
            }
        }

        private string GetUserIP()
        {
            string userIP;
            if (Request.ServerVariables["HTTP_VIA"] == null)
            {
                // userIP = Request.UserHostAddress;
                userIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            else
            {
                userIP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            return userIP;
        }
    }
}
