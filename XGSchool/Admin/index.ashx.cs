using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.SessionState;

namespace XGSchool.Admin
{
    /// <summary>
    /// index 的摘要说明
    /// </summary>
    public class index : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string dopost = context.Request.Form["dopost"];
            if (dopost == "login")
            {
                //获取用户的登录信息
                string userName = context.Request.Form["username"].Trim();
                string userPwd = context.Request.Form["userPwd"].Trim();
                string sql = "select count(*) from sysUser where userName=@name and userPwd=@pwd";
                int count = (int)SqlHelper.ExecuteScalar(sql, new SqlParameter("@name", userName), new SqlParameter("@pwd", userPwd));
                if (count <= 0)
                {
                    context.Response.Write("用户名或密码错误！");
                }
                else if (count >= 2)
                {
                    context.Response.Write("用户名有重复！");
                }
                else
                {
                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage(userName, false);//授权
                    context.Session["userName"] = userName;
                    context.Response.Redirect("index.html?userName=" + userName);
                }
            }
            else
            {
                string html = CommonHelper.RenderHtml("admin/index.htm", null);
                context.Response.Write(html);
            }
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