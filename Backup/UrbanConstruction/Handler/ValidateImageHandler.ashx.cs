using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Web.SessionState;
using System.Drawing;
using System.Text;
using System.Drawing.Imaging;

namespace UrbanConstruction.Handler
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
   
    public class ValidateImageHandler : IHttpHandler, IRequiresSessionState
    {
        int intLength = 4;               //长度
        public void ProcessRequest(HttpContext hc)
        {
            //设置输出流图片格式

            hc.Response.ContentType = "image/gif";

            Bitmap b = new Bitmap(200, 60);
            Graphics g = Graphics.FromImage(b);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, 200, 60);
            Font font = new Font(FontFamily.GenericSerif, 48, FontStyle.Bold, GraphicsUnit.Pixel);
            Random r = new Random();

            //合法随机显示字符列表
            string strLetters = "1234567890";
            StringBuilder s = new StringBuilder();
            ////将随机生成的字符串绘制到图片上

            for (int i = 0; i < intLength; i++)
            {
                s.Append(strLetters.Substring(r.Next(0, strLetters.Length - 1), 1));
                g.DrawString(s[s.Length - 1].ToString(), font, new SolidBrush(Color.Red), i * 38, r.Next(0, 15));
            }

            ////生成干扰线条
            Pen pen = new Pen(new SolidBrush(Color.MediumSeaGreen), 2);
            for (int i = 0; i < 10; i++)
            {
                g.DrawLine(pen, new Point(r.Next(0, 199), r.Next(0, 59)), new Point(r.Next(0, 199), r.Next(0, 59)));
            }
            hc.Session["picident"] = s.ToString().ToLower();
            b.Save(hc.Response.OutputStream, ImageFormat.Gif);
            HttpContext.Current.Session["picident"] = s.ToString().ToLower();//s.ToString();

            //先保存在Session中，验证与用户输入是否一致

            hc.Response.End();

        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}
