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
using System.Collections.Generic;
using UrbanConstruction.Model;
using UrbanConstruction.Service;
using UrbanConstruction.Component;

namespace UrbanConstruction
{
    public partial class CityPictures : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bind();
            }
        }
        public UC_Pictures BigChange = null;
        public UC_Pictures Famous = null;
        public UC_Pictures GreaterHouse = null;
        public UC_Pictures LivingEnvironment = null;
        public UC_Pictures Memory = null;
        public UC_Pictures NewScenery = null;
        public UC_Pictures OldView = null;
        public UC_NewsList VideoPicture = null;
        public void Bind()
        {
            //获取图片
            IUC_Pictures idal = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_PicturesDaoService"] as IUC_Pictures;
            BigChange = idal.GetAllList(string.Format("type={0} and state = {1}",(int)EnumType.PictureType.城市巨变,(int)EnumType.StateType.已审核)).ToList().FirstOrDefault();
            Famous = idal.GetAllList(string.Format("type={0} and state = {1}", (int)EnumType.PictureType.名胜古迹, (int)EnumType.StateType.已审核)).ToList().FirstOrDefault();
            GreaterHouse = idal.GetAllList(string.Format("type={0} and state = {1}", (int)EnumType.PictureType.伟人故里, (int)EnumType.StateType.已审核)).ToList().FirstOrDefault();
            LivingEnvironment = idal.GetAllList(string.Format("type={0} and state = {1}", (int)EnumType.PictureType.人居环境, (int)EnumType.StateType.已审核)).ToList().FirstOrDefault();
            Memory = idal.GetAllList(string.Format("type={0} and state = {1}", (int)EnumType.PictureType.城市记忆, (int)EnumType.StateType.已审核)).ToList().FirstOrDefault();
            NewScenery = idal.GetAllList(string.Format("type={0} and state = {1}", (int)EnumType.PictureType.城市新貌, (int)EnumType.StateType.已审核)).ToList().FirstOrDefault();
            OldView = idal.GetAllList(string.Format("type={0} and state = {1}", (int)EnumType.PictureType.旧城图, (int)EnumType.StateType.已审核)).ToList().FirstOrDefault();
            IUC_NewsList newList = ((ContainerWebAccessorUtil.ObtainContainer()))["UC_NewsListDaoService"] as IUC_NewsList;
            VideoPicture = newList.GetAllList(string.Format("type={0} and state = {1} and kind={2}", (int)EnumType.NewsType.展览视频, (int)EnumType.StateType.已审核,(int)EnumType.KindType.编研成果)).ToList().FirstOrDefault();
        }
    }
}