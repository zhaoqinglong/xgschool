using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XGSchool.XGModels;

namespace XGSchool.commercial
{
    public partial class commercialNews : System.Web.UI.Page
    {
        public XGNews[] xgnews = { };
        public int total = 1;//总条数
        public int pageCount = 1;//总页数
        protected string showImgsrc = CommonHelper.ReadSetting("商演培训顶部背景图片").Trim();
        protected void Page_Load(object sender, EventArgs e)
        {

            int pageNum = 1;
            if (Request.QueryString["pageNum"] != null)
            {
                pageNum = Convert.ToInt32(Request.QueryString["pageNum"]);
            }
            string newsBelong = "新革商演培训";
            string sql = @"select * from(
                    select newsID, title,author,newsDate,row_number() over (order by newsID asc) as num
	                from XGNews where newsBelong='新革商演培训' ) as s
                    where s.num between @startNum and @endNum order by newsDate desc";
            DataTable xgnewsInfo = SqlHelper.ExecuteDataTable(sql,
                //  new SqlParameter("@newsBelong", newsBelong),
                new SqlParameter("@startNum", (pageNum - 1) * 9 + 1),
                new SqlParameter("@endNum", pageNum * 9));

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
            pageCount = (int)Math.Ceiling(total / 9.0);
        }
    }
}