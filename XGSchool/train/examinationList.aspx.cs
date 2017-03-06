using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XGSchool.XGModels;

namespace XGSchool.train
{
    public partial class examinationList : System.Web.UI.Page
    {
        public Link[] Links = { };//超链接数组
        
        public string gkcopyright = CommonHelper.ReadSetting("公考培训版权信息").Trim();
        public string gksiteAds = CommonHelper.ReadSetting("公考培训学校地址").Trim();//艺考培训学校地址
        public string Phone1 = CommonHelper.ReadSetting("公务员培训电话").Trim();
        //试列表
        public XGNews[] xgnews = { };
        public int total = 1;//总条数
        public int pageCount = 1;//总页数
        public string newsBelong = "试题专区";
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable LinkInfo = SqlHelper.ExecuteDataTable("select top 8 LinkName,LinkString from FriendLink;");
            Links = new Link[LinkInfo.Rows.Count];
            for (int i = 0; i < LinkInfo.Rows.Count; i++)
            {
                Link mylink = new Link();
                mylink.LinkName = LinkInfo.Rows[i]["LinkName"].ToString();
                mylink.LinkString = LinkInfo.Rows[i]["LinkString"].ToString();
                Links[i] = mylink;
            }

            //试题列表
            int pageNum = 1;
            if (Request.QueryString["pageNum"] != null)
            {
                pageNum = Convert.ToInt32(Request.QueryString["pageNum"]);
            }
            
            string reqnewsBelong = Request.QueryString["newsBelong"];
            if (!string.IsNullOrEmpty(reqnewsBelong))
                newsBelong = reqnewsBelong;

            string sql = @"select * from(
                    select newsID, title,author,newsDate,row_number() over (order by newsID asc) as num
	                from XGNews where newsBelong=@newsBelong) as s
                    where s.num between @startNum and @endNum;";
            DataTable xgnewsInfo = SqlHelper.ExecuteDataTable(sql,
                  new SqlParameter("@newsBelong", newsBelong),
                new SqlParameter("@startNum", (pageNum - 1) * 10 + 1),
                new SqlParameter("@endNum", pageNum * 10));

            xgnews = new XGNews[xgnewsInfo.Rows.Count];

            for (int i = 0; i < xgnewsInfo.Rows.Count; i++)
            {
                string id = xgnewsInfo.Rows[i]["newsID"].ToString().Trim();
                string mytitle = xgnewsInfo.Rows[i]["title"].ToString().Trim();
                string author = xgnewsInfo.Rows[i]["author"].ToString().Trim();
                string newsDate = xgnewsInfo.Rows[i]["newsDate"].ToString().Trim();
                XGNews mynews = new XGNews();
                mynews.newsId = id;
                mynews.newsTitle = mytitle;
                mynews.author = author;
                //  mynews.newDate = newsDate;
                try
                {
                    mynews.newDate = DateTime.Parse(xgnewsInfo.Rows[i]["newsDate"].ToString().Trim()).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {
                    mynews.newDate = "";
                }
                xgnews[i] = mynews;
            }
            //取数据的总条数，计算分页的页数，页数=ceiling（total/10）
            total = (int)SqlHelper.ExecuteScalar("select count(*) from XGNews where newsBelong=@newsBelong", new SqlParameter("@newsBelong", newsBelong));
            pageCount = (int)Math.Ceiling(total / 10.0);
        }
    }
}