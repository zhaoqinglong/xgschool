using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace XGSchool.Admin
{
    /// <summary>
    /// newsList 的摘要说明
    /// </summary>
    public class newsList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int pageNum = 1;
            if (context.Request.QueryString["pageNum"] != null)
            {
                pageNum = Convert.ToInt32(context.Request.QueryString["pageNum"]);
            }
            string newsBelong = "新革艺术学校";
            newsBelong = context.Request.QueryString["newsBelong"];
            //先根据是否置顶进行排序，再对添加日期进行排序
            string sql = @"select * from(
                    select *,row_number() over (order by pagesBelong desc ,newsDate desc) as num
	                from   XGNews  where newsBelong=@newsBelong) as s
                    where s.num between @startNum and @endNum order by  pagesBelong desc ,newsDate desc;";
            DataTable dt = SqlHelper.ExecuteDataTable(sql,
                new SqlParameter("@newsBelong",newsBelong),
                new SqlParameter("@startNum", (pageNum - 1) * 10 + 1),
                new SqlParameter("@endNum", pageNum * 10));

            //取数据的总条数，计算分页的页数，页数=ceiling（total/10）
            int total = (int)SqlHelper.ExecuteScalar("select count(*) from XGNews where newsBelong=@newsBelong", new SqlParameter("@newsBelong", newsBelong));
            int pageCount = (int)Math.Ceiling(total / 10.0);
            //分页数据
            object[] pageData = new object[pageCount];
            for (int i = 1; i <= pageData.Length; i++)
            {
                pageData[i - 1] = new { href = "newsList.ashx?pageNum=" + i, newPageNum = i };
            }
            string tit = "新闻列表";
            var data = new
            {
                Title = tit,
                news = dt.Rows,
                PageData = pageData,//分页数据
                totalCount = total,//总数据条数
                currentPageNum = pageNum,//现在的页码
                totalPageNum = pageCount,//总页码
                newsBelong=newsBelong//所属模块
            };
            string html = CommonHelper.RenderHtml("admin/newsList.htm", data);
            context.Response.Write(html);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}