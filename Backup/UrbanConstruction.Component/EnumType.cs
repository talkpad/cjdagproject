using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrbanConstruction.Component
{
    public class EnumType
    {
        public enum KindType
        {
            通知公告 = 1,
            档案验收信息公布 = 2,
            本馆工作动态 = 3,
            中山城建新闻 = 4,
            建设工程档案验收 = 5,
            地下管线档案验收 = 6,
            档案查阅 = 7,
            档案征集 = 8,
            政策法规 = 9,
            业务知识 = 10,
            本馆概况 = 12,
            本馆职能 = 13,
            馆藏介绍 = 14, 
            联系我们 = 15,
            编研成果 =16,
            学术研究 = 17,
            其他相关工作=18,
            左侧专题 = 19,
            右侧专题 = 20,
            办公电话 = 21,
            业务表格 = 22,
            规范标准 = 23

        }

        public enum StateType
        {
            未审核 = 0,
            已审核 = 1
        }

        public enum TopType
        {
            未置顶 = 0,
            置顶 = 1
        }

        public enum NewsType
        {
            普通新闻 = 1,
            图片新闻 = 2,
            图库新闻 = 3,
            视频=4,
            展览视频=5,
            首页视频=6
        }

        public enum PictureType
        {
            旧城图 = 1,
            城市记忆 = 2,
            名胜古迹 = 3,
            城市巨变 = 4,
            城市新貌 = 5,
            伟人故里 = 6,
            人居环境 = 7
        }

        public enum messageType
        {
            不公开 = 0,
            公开=1
        }
    }
}
