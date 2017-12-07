using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using Lucene.Net.Analysis;
using Lucene.Net.Store;
using Lucene.Net.Analysis.CN;
using Lucene.Net.Index;
using System.IO;
using System.Data.SqlClient;
using Lucene.Net.Documents;

namespace GetIndex
{
    class InitIndex
    {
        static readonly System.IO.FileInfo INDEX_DIR = new System.IO.FileInfo("index2");
        //索引存放位置
        public static String INDEX_STORE_PATH = ConfigurationSettings.AppSettings["IndexFilePath"].ToString();
        public static String Constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        public static String NewsSql = ConfigurationSettings.AppSettings["NewsSql"].ToString();
        public static String DownFileSql = ConfigurationSettings.AppSettings["DownFileSql"].ToString();
        //合并索引前，内存中最大的文件数量
        public static int DEFAULT_MAX_DOCS_IN_RAM = 1000;

        //最大的字段长度
        public static readonly int DEFAULT_MAX_FIELD_LENGTH = int.MaxValue;

        //单例模式
        private static InitIndex initindex = null;

        //两个索引器

        private IndexWriter ramWriter = null;
        private IndexWriter fsWriter = null;

        //内存中已经有的文档数量

        private int docs_in_ram;
        //内存中最大的文档数量
        private int ramMaxFiles = DEFAULT_MAX_DOCS_IN_RAM;
        //内存是否被刷新过
        private Boolean freshed = true;

        //索引存放的文件系统目录

        FSDirectory fsDir = null;
        //索引存放的内存目录

        RAMDirectory ramDir = null;

        //私有构造函数

        private InitIndex() { }

        // 静态方法构造一个单例

        public static InitIndex getInstance()
        {
            if (initindex == null)
            {
                initindex = new InitIndex();
            }
            return initindex;
        }

        //构造索引器
        public void newWriter()
        {
            if (fsWriter != null || ramWriter != null)
            {
                Console.WriteLine("some indexer has builded");
                return;
            }
            try
            {
                Boolean rebuild = true;
                ramDir = new RAMDirectory();
                Analyzer analyser = new ChineseAnalyzer();
                ramWriter = new IndexWriter(ramDir, analyser, true);
                try
                {
                    fsDir = FSDirectory.GetDirectory(INDEX_STORE_PATH, false);
                    fsWriter = new IndexWriter(fsDir, analyser, false);
                    Console.WriteLine("存在索引,继续添加..............");
                }
                catch
                {
                    fsDir = FSDirectory.GetDirectory(INDEX_STORE_PATH, rebuild);
                    fsWriter = new IndexWriter(fsDir, analyser, rebuild);
                    Console.WriteLine("新建索引..............");
                }
                initWriter();
            }
            catch { }
        }
        //初始化索引器
        private void initWriter()
        {
            Console.WriteLine("初始化索引器...");
            fsWriter.SetMaxFieldLength(DEFAULT_MAX_FIELD_LENGTH);
        }

        //优化索引
        public void optimizeIndex()
        {
            if (fsWriter == null || ramWriter == null)
            {
                Console.WriteLine("initialize a new indexer fist");
                return;
            }
            refreshRam();
            fsWriter.Optimize();
        }
        //创建索引
        public void toIndex()
        {
            if (fsWriter == null || ramWriter == null)
            {
                Console.WriteLine("some indexer has builded");
                return;
            }
            freshed = false;
            DateTime start = DateTime.Now;
            int number = indexFiles();
            DateTime end = DateTime.Now;
            long time = end.Ticks - start.Ticks;
            Console.WriteLine("总共耗时{0}毫秒", Convert.ToString(time));
            Console.WriteLine("一共为{0}个文件建立索引", number);

        }

        //关闭索引
        public void close()
        {
            if (fsWriter == null || ramWriter == null)
            {
                Console.WriteLine("use newwriter() method to initialize a new indexerfirsrt");
                return;
            }
            refreshRam();
            ramWriter.Close();
            fsWriter.Close();

        }
        //刷新内存
        private void refreshRam()
        {
            if (!freshed)
            {
                Console.WriteLine("Refreshing");
                fsWriter.AddIndexes(new Lucene.Net.Store.Directory[] { ramDir });
            }

            ramDir.Close();
            ramDir = new RAMDirectory();
            ramWriter = new IndexWriter(ramDir, new ChineseAnalyzer(), true);

            docs_in_ram = 0;
            freshed = true;
        }
        //向索引中加入文档  
        private void addDocument(float boost, string url, string title, string content, string date, string m_id, string m_itemid)
        {
            if (docs_in_ram >= ramMaxFiles)
            {
                refreshRam();
            }
            ramWriter.AddDocument(FileDocument.getDocument(boost, url, title, content, date, m_id, m_itemid));
            docs_in_ram++;
            freshed = false;

        }
        /// <summary>
        /// 读取最大ID
        /// </summary>
        /// <param name="recordPath"></param>
        private int GetIndexId(string recordPath)
        {
            int id = 0;
            if (File.Exists(INDEX_STORE_PATH + "\\" + recordPath))
            {
                try
                {
                    id = int.Parse(File.ReadAllText(INDEX_STORE_PATH + "\\" + recordPath));
                }
                catch
                {

                }
            }
            return id;
        }
        /// <summary>
        /// 设置最大ID
        /// </summary>
        /// <param name="recordPath"></param>
        /// <param name="indexid"></param>
        private void SetIndexId(string recordPath, string indexid)
        {
            File.WriteAllText(INDEX_STORE_PATH + "\\" + recordPath, indexid);
        }
        //遍历数据库,建立索引文件
        private int indexFiles()
        {
            int i = 0;
            int indexid = 0;
            int num = 0;
            int j = 0;

            using (SqlConnection con = new SqlConnection(Constr))
            {
                num = GetIndexId("News_Record");
                con.Open();
                SqlCommand cmd = new SqlCommand(NewsSql, con);
                using (SqlDataReader SqlReader = cmd.ExecuteReader())
                {

                    while (SqlReader.Read())
                    {
                        indexid = int.Parse(SqlReader["ID"].ToString());
                        if (indexid > num)
                        {
                            addDocument((float)1.0, "../NewsDetail.aspx?FID=" + SqlReader["ID"].ToString(), SqlReader["Title"].ToString(), ReplaceHtml(SqlReader["Content"].ToString()), (DateTime.Parse(SqlReader["ReleaseTime"].ToString())).ToString("yyyy-MM-dd"), SqlReader["M_ID"].ToString(), SqlReader["M_ItemID"].ToString());
                            if (indexid > j)
                            {
                                j = indexid;
                            }
                            else
                            {
                                j = j + 0;
                            }
                            i++;
                            Console.WriteLine("add document to index.ID:" + SqlReader["ID"].ToString() + "...");
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (i == 0)
                    {
                        SetIndexId("News_Record", num.ToString());
                    }
                    else
                    {
                        SetIndexId("News_Record", j.ToString());
                    }
                }
            }


            Console.WriteLine("**********************************更新闻动态索引*******************************");
            return i;
        }
        private static string ReplaceHtml(string value)
        {
            System.Text.RegularExpressions.Regex regx = new System.Text.RegularExpressions.Regex(@"(<.+?>|</.+?>|<img.+?>|\s)");
            return regx.Replace(value, "");
        }
        [STAThread]
        static void Main(string[] args)
        {
            InitIndex test = InitIndex.getInstance();
            test.newWriter();
            test.toIndex();
            test.close();
        }
    }
    //构建Document 在建立索引之前,首先要构建Document类型,它把文本文档转变成lucene可以识别的Document格式.
    class FileDocument
    {
        public static Lucene.Net.Documents.Document getDocument(float boost, string url, string title, string content, string date, string m_id, string m_itemid)
        {
            Document doc = new Document();
            doc.Add(new Field("url", url, Field.Store.YES, Field.Index.NO));
            doc.Add(new Field("title", title, Field.Store.YES, Field.Index.TOKENIZED));
            doc.Add(new Field("content", content, Field.Store.YES, Field.Index.TOKENIZED));
            doc.Add(new Field("date", date, Field.Store.YES, Field.Index.UN_TOKENIZED));
            doc.Add(new Field("m_id", m_id, Field.Store.YES, Field.Index.UN_TOKENIZED));
            doc.Add(new Field("m_itemid", m_itemid, Field.Store.YES, Field.Index.UN_TOKENIZED));
            doc.SetBoost(boost);
            return doc;

        }
    }
}
