using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace XGSchool.Admin
{
    /// <summary>
    /// linkEdit 的摘要说明
    /// </summary>
    public class linkEdit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string isPostBack = context.Request.Form["isPostBack"];
            string action = context.Request["Action"];
            //获取隐藏域的值不为空，保存数据
            if (!string.IsNullOrEmpty(isPostBack))
            {
                //保存新增加的数据
                if (action == "AddNew")
                {
                    string LinkName = context.Request.Form["LinkName"].Trim();//获取超链接名称
                    string LinkString = context.Request.Form["LinkString"].Trim();//获取超链接地址
                    if (string.IsNullOrEmpty(LinkName) || string.IsNullOrEmpty(LinkString))
                    {
                        context.Response.Write("添加的链接为空，请检查后重新添加！");
                        context.Response.Write("<input type='button' value='返回' onclick='javascript:history.back();'/>");
                    }
                    else
                    {
                        string sql = "insert into FriendLink(LinkName,LinkString) values(@linkname,@linkstring);";
                        SqlHelper.ExecuteNonQuery(sql,
                            new SqlParameter("@linkname", LinkName),
                            new SqlParameter("@linkstring", LinkString));
                        context.Response.Redirect("LinkList.ashx");
                    }
                }
                //保存修改的数据
                else if (action == "Edit")
                {
                    string id = context.Request.Form["Id"].Trim();
                    string LinkName = context.Request.Form["LinkName"].Trim();
                    string LinkString = context.Request.Form["LinkString"].Trim();
                    if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(LinkName) || string.IsNullOrEmpty(LinkString))
                    {
                        context.Response.Write("修改的链接为空，请检查后重新添加！");
                        context.Response.Write("<input type='button' value='返回' onclick='javascript:history.back();'/>");
                    }
                    else
                    {
                        string sql = @"update FriendLink 
                        set LinkName=@linkname,LinkString=@linkstring where LinkId=@id";
                        SqlHelper.ExecuteNonQuery(sql,
                            new SqlParameter("@linkname", LinkName),
                            new SqlParameter("@id", id),
                            new SqlParameter("@linkstring", LinkString)
                            );
                        context.Response.Redirect("LinkList.ashx");
                    }
                }
                //参数错误
                else
                {
                    context.Response.Write("Action参数错误:" + action);
                    context.Response.Write("<input type='button' value='返回' onclick='javascript:history.back();'/>");
                }

            }
            //isPostBack为空，展示网页
            else
            {
                //新增初始展示
                if (action == "AddNew")
                {
                    var data = new
                    {
                        Title = "添加超链接",
                        Action = action,
                        Linkherfs = new { LinkId = "1", LinkName = "", LinkString = "" },
                    };
                    string html = CommonHelper.RenderHtml("/admin/LinkEdit.htm", data);
                    context.Response.Write(html);
                }
                //编辑展示
                else if (action == "Edit")
                {
                    //获取要编辑数据的ID
                    long id = Convert.ToInt64(context.Request.QueryString["LinkId"]);
                    //从数据库中查询此ID的数据
                    DataTable dt = SqlHelper.ExecuteDataTable("select * from FriendLink where LinkId=@id", new SqlParameter("@id", id));

                    if (dt.Rows.Count <= 0)
                    {
                        context.Response.Write("没有找到此ID的友情链接信息！");
                        context.Response.Write("<input type='button' value='返回' onclick='javascript:history.back();'/>");
                    }
                    else if (dt.Rows.Count > 1)
                    {
                        context.Response.Write("找到多条此ID的友情链接信息！");
                        context.Response.Write("<input type='button' value='返回' onclick='javascript:history.back();'/>");
                    }
                    else
                    {
                        var data = new
                        {
                            Title = "编辑友情链接",
                            Action = action,
                            Linkherfs = dt.Rows[0]
                        };
                        string html = CommonHelper.RenderHtml("/admin/LinkEdit.htm", data);
                        context.Response.Write(html);
                    }
                }
                else if (action == "Delete")
                {
                    //获取要删除数据的ID
                    long id = Convert.ToInt64(context.Request.QueryString["LinkId"]);
                    string sql = "delete from FriendLink where LinkId=@id";
                    SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@id", id));
                    context.Response.Write(id);
                    context.Response.Write("删除成功！");
                    context.Response.Write("<input type='button' value='返回' onclick='javascript:history.back();'/>");
                }
                //参数错误
                else
                {
                    context.Response.Write("Action参数值为" + action + "，参数错误！！！");
                    context.Response.Write("<input type='button' value='返回' onclick='javascript:history.back();'/>");
                }

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