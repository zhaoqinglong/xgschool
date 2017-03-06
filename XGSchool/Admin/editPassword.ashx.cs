using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.SessionState;


namespace XGSchool.Admin
{
    /// <summary>
    /// editPassword 的摘要说明
    /// </summary>
    public class editPassword : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string newpass = context.Request.QueryString["newpass"].Trim();
            string userName = (string)context.Session["userName"];
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(newpass))
            {
                string newsql = "update sysUser set userPwd=@pwd where  userName=@userName";
                SqlHelper.ExecuteNonQuery(newsql,
                    new SqlParameter("@pwd", newpass),
                    new SqlParameter("@userName", userName));
                context.Response.Write("修改成功！");
            }
            else
                context.Response.Write("修改失败！");
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