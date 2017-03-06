using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace XGSchool.Admin
{
    /// <summary>
    /// gwynewsList 的摘要说明
    /// </summary>
    public class gwynewsList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int pageNum = 1;
            if (context.Request.QueryString["pageNum"] != null)
            {
                pageNum = Convert.ToInt32(context.Request.QueryString["pageNum"]);
            }

            string newsBelong = "新革公务员公告";
            string reqnewsBelong = context.Request.QueryString["newsBelong"];
            if (!string.IsNullOrEmpty(reqnewsBelong))
                newsBelong = reqnewsBelong;

            string sql = @"select * from(
                    select *,row_number() over (order by pagesBelong desc ,newsDate desc) as num
	                from XGNews where newsBelong=@newsBelong) as s
                    where s.num between @startNum and @endNum;";
            DataTable dt = SqlHelper.ExecuteDataTable(sql,
                new SqlParameter("@newsBelong", newsBelong),
                new SqlParameter("@startNum", (pageNum - 1) * 10 + 1),
                new SqlParameter("@endNum", pageNum * 10));

            //取数据的总条数，计算分页的页数，页数=ceiling（total/10）
            int total = (int)SqlHelper.ExecuteScalar("select count(*) from XGNews where newsBelong=@newsBelong", new SqlParameter("@newsBelong", newsBelong));
            int pageCount = (int)Math.Ceiling(total / 10.0);
            //分页数据
            object[] pageData = new object[pageCount];
            for (int i = 1; i <= pageData.Length; i++)
            {
                pageData[i - 1] = new { href = "gwynewsList.ashx?pageNum=" + i, newPageNum = i };
            }
            string tit = "列表";
            var data = new
            {
                Title = tit,
                news = dt.Rows,//餐厅信息
                PageData = pageData,//分页数据
                totalCount = total,//总数据条数
                currentPageNum = pageNum,//现在的页码
                totalPageNum = pageCount,//总页码
                newsBelong = newsBelong//所属模块
            };
            string html = CommonHelper.RenderHtml("admin/gwynewsList.htm", data);
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