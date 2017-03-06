using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using XGSchool.XGModels;
using System.Data.SqlClient;

namespace XGSchool.artSchoolNew
{
    public partial class news : System.Web.UI.Page
    {
        public XGNews[] xgnews = { };
        public int total = 1;//总条数
        public int pageCount = 1;//总页数
        protected void Page_Load(object sender, EventArgs e)
        {
            //新革动态
            //DataTable xgnewsInfo = SqlHelper.ExecuteDataTable("select top 4 newsID, title,newsImage from XGNews where newsBelong='新革艺术学校';");
            //xgnews = new XGNews[xgnewsInfo.Rows.Count];

            //for (int i = 0; i < xgnewsInfo.Rows.Count; i++)
            //{
            //    string mytitle = xgnewsInfo.Rows[i]["title"].ToString().Trim();
            //    string myimage = xgnewsInfo.Rows[i]["newsImage"].ToString().Trim();
            //    string id = xgnewsInfo.Rows[i]["newsID"].ToString().Trim();
            //    XGNews mynews = new XGNews();
            //    mynews.newsTitle = mytitle;
            //    mynews.newsImage = myimage;
            //    mynews.newsId = id;
            //    xgnews[i] = mynews;
            //}

            int pageNum = 1;
            if (Request.QueryString["pageNum"] != null)
            {
                pageNum = Convert.ToInt32(Request.QueryString["pageNum"]);
            }
            string newsBelong = "新革艺术学校";
            string sql = @"select * from(
                    select *,row_number() over (order by pagesBelong desc ,newsDate desc) as num
	                from XGNews where newsBelong='新革艺术学校') as s
                    where s.num between @startNum and @endNum order by pagesBelong desc ,newsDate desc;";
            DataTable xgnewsInfo = SqlHelper.ExecuteDataTable(sql,
              //  new SqlParameter("@newsBelong", newsBelong),
                new SqlParameter("@startNum", (pageNum - 1) * 4 + 1),
                new SqlParameter("@endNum", pageNum * 4));
            xgnews = new XGNews[xgnewsInfo.Rows.Count];

            for (int i = 0; i < xgnewsInfo.Rows.Count; i++)
            {
                string mytitle = xgnewsInfo.Rows[i]["title"].ToString().Trim();
                string myimage = xgnewsInfo.Rows[i]["newsImage"].ToString().Trim();
                string id = xgnewsInfo.Rows[i]["newsID"].ToString().Trim();
                XGNews mynews = new XGNews();
                mynews.newsTitle = mytitle;
                mynews.newsImage = myimage;
                mynews.newsId = id;
                xgnews[i] = mynews;
            }
            //取数据的总条数，计算分页的页数，页数=ceiling（total/10）
            total = (int)SqlHelper.ExecuteScalar("select count(*) from XGNews where newsBelong=@newsBelong", new SqlParameter("@newsBelong", newsBelong));
            pageCount = (int)Math.Ceiling(total / 4.0);
        }
    }
}