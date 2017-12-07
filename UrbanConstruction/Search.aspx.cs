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
using System.Text;
using UrbanConstruction.Component;
using System.Diagnostics;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.CN;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.QueryParsers;
using Lucene.Net.Highlight;
using System.IO;

namespace UrbanConstruction
{
    public partial class Search : BasePage
    {
        protected string keyword = string.Empty;
        protected string sort = string.Empty;
        public int count = 0;
        public float time = 0;
        protected StringBuilder builder = new StringBuilder();
        protected UrbanConstruction.Component.Pager pager = new Pager();

        private string MenuSQL = " and m_id in(select m_id from dbo.UC_MenuItem)";
        private string MenuItemSQL = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BandMenu(this.Xdlist, MenuSQL);
                BandMenuItem(this.Ldlist, Xdlist.SelectedValue, MenuItemSQL);
                try
                {
                    if (Request.QueryString["m_id"] != null)
                    {
                        Xdlist.SelectedValue = Request.QueryString["m_id"];
                    }
                }
                catch { }
                try
                {
                    if (Request.QueryString["m_itemid"] != null)
                    {
                        BandMenuItem(this.Ldlist, Xdlist.SelectedValue, MenuItemSQL);
                        Ldlist.SelectedValue = Request.QueryString["m_itemid"];
                        btnSearch_Click(null, null);
                    }
                }
                catch { }
                DefaultLeft1.M_NAME = "网站搜索";
                if (Convert.ToInt32(Request.QueryString["advsearch"]) == 1)
                {
                    this.SearchResult.Text = "返回普通搜索";
                    this.SearchResult.NavigateUrl = "Seach.aspx?advsearch=0";
                    this.divWhere.Visible = true;
                    this.divResult.Visible = false;
                    this.Xdlist.SelectedValue = Request.QueryString["m_id"];
                    this.Ldlist.SelectedValue = Request.QueryString["m_itemid"];
                }
                else if (Convert.ToInt32(Request.QueryString["advsearch"]) == 0)
                {
                    this.SearchResult.Text = "高级搜索";
                    this.SearchResult.NavigateUrl = "Seach.aspx?advsearch=1";
                    this.divWhere.Visible = false;
                    this.Xdlist.Visible = true;
                }
                else
                {
                    WebUtility.ShowMsg(this, "无效参数");
                    Response.Redirect("Seach.aspx?advsearch=0");
                }

                if (Request.Form["keyword"] != null)
                {
                    if (Request.QueryString["keyword"] != null)
                    {
                        keyword = Request.QueryString["keyword"];
                    }
                    else
                    {
                        keyword = Server.UrlDecode(Request.Form["keyword"]);
                    }
                }
                else
                {
                    if (Request.QueryString["keyword"] != null)
                    {
                        keyword = Request.QueryString["keyword"];
                        btnSearch_Click(null, null);
                    }
                    else
                    {
                        keyword = "";
                    }
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //if (Xdlist.SelectedValue != "" || Ldlist.SelectedValue != "")
            //{
            //this.Search.Text = "高级";
            //this.Search.NavigateUrl = "Seach.aspx?advsearch=1";
            //this.PanelWhere.Visible = false;
            this.divResult.Visible = true;
            string IndexPath = Server.MapPath("~/index");

            Stopwatch watch = new Stopwatch();
            watch.Start();
            /*使用中文分词分析器命中结果，使用StandardAnalyzer分析器作高亮显示（原理：StandardAnalyzer会将所有中文字一个一个地拆分）*/
            IndexReader reader = IndexReader.Open(IndexPath);
            Searcher searcher = new IndexSearcher(reader);
            Analyzer analyzer = new ChineseAnalyzer();//中文分词分析器

            Analyzer highanalyzer = new StandardAnalyzer();//高亮的分析器
            //QueryParser parser = new MultiFieldQueryParser(new string[] { "title", "content" }, highanalyzer);
            //Query highquery = parser.Parse(keyword);//高亮查询条件
            //parser = new MultiFieldQueryParser(new string[] { "title", "content"}, analyzer);
            //Query query = parser.Parse(keyword);//中文分词产生的查询条件

            //2013-05-10
            //String[] querys = { Xdlist.SelectedValue, Ldlist.SelectedValue };  //搜索条件
            //String[] fields = { "m_id", "m_itemid" };
            //BooleanClause.Occur[] clauses = { BooleanClause.Occur.MUST, BooleanClause.Occur.MUST };
            //Query query = MultiFieldQueryParser.Parse(querys, fields, clauses, highanalyzer);


            //2013-05-13
            if (Request.Form["keyword"] != null)
            {
                //if (Request.QueryString["keyword"] != null)
                //{
                //    keyword = Request.QueryString["keyword"];
                //}
                //else
                //{
                //    keyword = Server.UrlDecode(Request.Form["keyword"]);
                //}
                keyword = Server.UrlDecode(Request.Form["keyword"]);
                if (Convert.ToInt32(Request.QueryString["advsearch"]) == 0)
                {
                    Response.Redirect("Seach.aspx?advsearch=0&keyword=" + keyword);
                }
                else if (Convert.ToInt32(Request.QueryString["advsearch"]) == 1)
                {
                    Response.Redirect("Seach.aspx?advsearch=1&keyword=" + keyword + "&m_id=" + Xdlist.SelectedValue + "&m_Itemid=" + Ldlist.SelectedValue);
                }
                else
                {
                    WebUtility.ShowMsg(this, "无效参数");
                    Response.Redirect("Seach.aspx?advsearch=0");
                }
            }
            else
            {
                if (Request.QueryString["keyword"] != null)
                {
                    keyword = Request.QueryString["keyword"];
                }
                else
                {
                    keyword = "";
                }
            }
            pager.Keyword = keyword;
            BooleanQuery query = new BooleanQuery();
            QueryParser parser1 = new QueryParser("title", analyzer);
            QueryParser parser5 = new QueryParser("title", highanalyzer);
            QueryParser parser6 = new QueryParser("content", highanalyzer);
            QueryParser parser2 = new QueryParser("content", analyzer);
            QueryParser parser3 = new QueryParser("m_id", highanalyzer);
            QueryParser parser4 = new QueryParser("m_itemid", highanalyzer);
            if (Xdlist.SelectedValue != "")
            {
                query.Add(parser3.Parse(Xdlist.SelectedValue), BooleanClause.Occur.MUST);
            }
            if (Ldlist.SelectedValue != "")
            {
                query.Add(parser4.Parse(Ldlist.SelectedValue), BooleanClause.Occur.MUST);
            }
            if (keyword != null && keyword != "")
            {
                query.Add(parser1.Parse(keyword), BooleanClause.Occur.MUST);
                query.Add(parser5.Parse(keyword), BooleanClause.Occur.SHOULD);
                query.Add(parser2.Parse(keyword), BooleanClause.Occur.SHOULD);
                query.Add(parser6.Parse(keyword), BooleanClause.Occur.SHOULD);
            }


            Sort o_Sort = new Sort("date", true);//date字段必须建有索引
            Hits hits = null;
            sort = Request.QueryString["sort"];
            if (!string.IsNullOrEmpty(sort) && sort == "about")
            {
                hits = searcher.Search(query);//按相关度排序[默认]，所谓相关度，就是hits.Score(i)的大小

                pager.Sort = "about";
            }
            else
            {
                hits = searcher.Search(query, o_Sort);//按时间排序

                pager.Sort = "time";
                sort = "time";
            }

            watch.Stop();
            count = hits.Length();
            time = (float)watch.ElapsedMilliseconds / 1000;

            //this.PanelWhere.Visible = false;
            //this.PanelResult.Visible = true;
            if (count > 0)
            {//结果显示
                //divFooterSearchBar.Visible = true;
                //highquery
                SimpleHTMLFormatter format = new SimpleHTMLFormatter("<b>", "</b>");
                Highlighter highlighter = new Highlighter(format, new QueryScorer(query));
                highlighter.SetTextFragmenter(new SimpleFragmenter(120));

                pager.RecordCount = hits.Length();

                //=====================================
                int pageSize = 10;
                int pageIndex = 1;
                pager.M_Id = Xdlist.SelectedValue;
                pager.M_Itemid = Ldlist.SelectedValue;
                if (Request.QueryString["advsearch"] == "0" || Request.QueryString["advsearch"] == "1")
                {
                    pager.Advsearch = Request.QueryString["advsearch"];
                }
                else
                {
                    WebUtility.ShowMsg(this, "无效参数");
                    Response.Redirect("Seach.aspx?advsearch=0");
                }

                try
                {
                    pageIndex = int.Parse(Request.QueryString["PageIndex"]);
                }
                catch { ;}
                pager.PageSize = pageSize;
                pager.CurrentPageIndex = pageIndex;


                int startPos, endPost;
                startPos = (pager.CurrentPageIndex - 1) * pager.PageSize;
                endPost = startPos + pager.PageSize;
                endPost = endPost > hits.Length() ? hits.Length() : endPost;

                string tmpTitle, tmpContent, tmpDate, tmpUrl;
                for (int i = startPos; i < endPost; i++)
                {
                    //tmpId = hits.Doc(i).Get("id");
                    //tmpClassId = hits.Doc(i).Get("classid");
                    tmpUrl = hits.Doc(i).Get("url");
                    tmpTitle = hits.Doc(i).Get("title");
                    tmpContent = hits.Doc(i).Get("content");
                    tmpDate = hits.Doc(i).Get("date");

                    TokenStream tokenStreamTitle = highanalyzer.TokenStream("title", new StringReader(tmpTitle));
                    TokenStream tokenStreamContent = highanalyzer.TokenStream("content", new StringReader(tmpContent));

                    builder.Append("<div class=\"article\">");
                    string sTitle = highlighter.GetBestFragments(tokenStreamTitle, tmpTitle, 2, "...");
                    if (string.IsNullOrEmpty(sTitle))
                    {
                        builder.AppendFormat("<div class=\"title\"><a href=\"{0}\" target=\"_blank\">{1}</a></div>", tmpUrl, tmpTitle);
                    }
                    else
                    {
                        builder.AppendFormat("<div class=\"title\"><a href=\"{0}\" target=\"_blank\">{1}</a></div>", tmpUrl, sTitle);
                    }
                    if (keyword != null && keyword != "")
                    {
                        builder.AppendFormat("<div class=\"content1\">{0}</div>", highlighter.GetBestFragments(tokenStreamContent, tmpContent, 2, "..."));
                    }
                    //builder.AppendFormat("<div class=\"content\">{0}</div>", tmpContent);
                    builder.AppendFormat("<div class=\"link\">{0} -  {1}</div>", tmpUrl, tmpDate);
                    builder.Append("</div>");
                }
            }
            else
            {
                //divFooterSearchBar.Visible = false;
                builder.Append("<div class=\"error\">抱歉，没有找到与“<font color='red'>" + keyword + "</font>” 相关的网页。 <br/><br/><br/>");
                builder.Append("<strong>中山市司法局建议您使用下面的搜索技巧：</strong><br/>");
                builder.Append("<ul><li>看看输入的文字是否有误</li><br/>");
                builder.Append("<li>去掉可能不必要的字词，如“的”、“什么”等</li><br/>");
                builder.Append("<li>去掉形容词，例如直接搜索“中山”比“美丽的中山”更有效</li><ul></div>");
            }
            searcher.Close();
            reader.Close();
        }
        public void BandMenu(DropDownList Xdlist, string sql)
        {
            Xdlist.DataSource = Datatablebind.GetUC_Menu(sql);
            Xdlist.DataTextField = "m_name";
            Xdlist.DataValueField = "m_id";
            Xdlist.DataBind();
            Xdlist.Items.Insert(0, new ListItem("请选择", ""));
        }
        public void BandMenuItem(DropDownList Ldlist, object e, string sql)
        {
            Ldlist.DataSource = Datatablebind.GetUC_MenuItem(sql + "  AND M_ID='" + e.ToString() + "'");
            Ldlist.DataTextField = "M_ItemNAME";
            Ldlist.DataValueField = "M_ItemID";
            Ldlist.DataBind();
            Ldlist.Items.Insert(0, new ListItem("请选择", ""));
        }

        protected void Xdlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            BandMenuItem(this.Ldlist, Xdlist.SelectedValue, MenuItemSQL);
        }
        protected void btnSearchForWhere_Click(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }
    }
}

