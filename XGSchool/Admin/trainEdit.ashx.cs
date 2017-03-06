using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace XGSchool.Admin
{
    /// <summary>
    /// trainEdit 的摘要说明
    /// 公务员培训，三级栏目
    /// </summary>
    public class trainEdit : IHttpHandler
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
                    string id = context.Request.Form["TrainId"];
                    string caption = context.Request.Form["TrainCaption"].Trim();//标题
                    string detail = context.Request.Form["TrainDetail"].Trim();//详细
                    if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(caption) || string.IsNullOrEmpty(detail))
                    {
                        context.Response.Write("内容为空，修改失败！");
                        context.Response.Write("<input type='button' value='返回' onclick='javascript:history.back();'/>");
                    }
                    else
                    {
                        string sql = @"update GWYTrain 
                    set TrainCaption=@caption,TrainDetail=@detail where TrainId=@id";
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
                //展示网页，编辑展示
                if (action == "Edit")
                {
                    //获取要编辑数据的ID
                    long id = Convert.ToInt64(context.Request.QueryString["TrainId"]);
                    //从数据库中查询此ID的数据
                    DataTable train = SqlHelper.ExecuteDataTable("select * from GWYTrain where TrainId=@id", new SqlParameter("@id", id));

                    if (train.Rows.Count <= 0)
                    {
                        context.Response.Write("没有找到此ID的记录！");
                    }
                    else if (train.Rows.Count > 1)
                    {
                        context.Response.Write("找到多条此ID的记录！");
                    }
                    else
                    {
                        var data = new
                        {
                            Title = "编辑",
                            Action = action,
                            Train = train.Rows[0]
                        };
                        string html = CommonHelper.RenderHtml("/admin/trainEdit.htm", data);
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