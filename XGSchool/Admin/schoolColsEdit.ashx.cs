using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace XGSchool.Admin
{
    /// <summary>
    /// schoolColsEdit 的摘要说明
    /// 二级栏目
    /// </summary>
    public class schoolColsEdit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //获取隐藏域，如果没有值，则为展示，否则为保存数据
            string isPostBack = context.Request.Form["isPostBack"];
            string action = context.Request["Action"];
            //不为空，保存数据
            if (!string.IsNullOrEmpty(isPostBack))
            {

                //保存修改的数据
                if (action == "Edit")
                {
                    string id = context.Request.Form["SchoolColId"].Trim();
                    string caption = context.Request.Form["SchoolColTitle"].Trim();//标题
                    string detail = context.Request.Form["SchoolColDetail"].Trim();//详细
                    if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(caption) || string.IsNullOrEmpty(detail))
                    {
                        context.Response.Write("提交的修改中有内容为空，修改失败！");
                        context.Response.Write("<input type='button' value='返回' onclick='javascript:history.back();'/>");
                    }
                    else
                    {
                        string sql = @"update XGSchoolCols 
                    set SchoolColTitle=@caption,SchoolColDetail=@detail where SchoolColId=@id";
                        SqlHelper.ExecuteNonQuery(sql,
                            new SqlParameter("@caption", caption),
                            new SqlParameter("@detail", detail),
                            new SqlParameter("@id", id)
                            );
                        context.Response.Write("恭喜你，修改成功！");
                        context.Response.Write("<input type='button' value='返回' onclick='javascript:history.back();'/>");
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
                //展示网页主要是编辑展示
                if (action == "Edit")
                {
                    //获取要编辑数据的ID
                    long id = 1;
                    id = Convert.ToInt64(context.Request.QueryString["Id"].Trim());
                    //从数据库中查询此ID的数据
                    DataTable SchoolCols = SqlHelper.ExecuteDataTable("select * from XGSchoolCols where SchoolColId=@id", new SqlParameter("@id", id));

                    if (SchoolCols.Rows.Count <= 0)
                    {
                        context.Response.Write("没有找到此ID的记录，请检查你的请求是否正确！");
                    }
                    else if (SchoolCols.Rows.Count > 1)
                    {
                        context.Response.Write("找到多条此ID的记录，请检查数据库记录是否正确！");
                    }
                    else
                    {
                        var data = new
                        {
                            Title = "编辑",
                            Action = action,
                            SchoolCols = SchoolCols.Rows[0]
                        };
                        string html = CommonHelper.RenderHtml("/admin/schoolColsEdit.htm", data);
                        context.Response.Write(html);
                    }
                }
                //参数错误
                else
                {
                    context.Response.Write("Action参数值为" + action + "，参数错误！！！");
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