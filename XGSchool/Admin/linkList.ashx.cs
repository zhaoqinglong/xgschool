using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace XGSchool.Admin
{
    /// <summary>
    /// linkList 的摘要说明
    /// </summary>
    public class linkList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string sql = "select top 5 * from FriendLink;";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            var data = new
            {
                Title = "友情链接",
                Linkherfs = dt.Rows
            };
            string html = CommonHelper.RenderHtml("admin/LinkList.htm", data);
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