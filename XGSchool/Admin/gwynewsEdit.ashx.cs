using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace XGSchool.Admin
{
    /// <summary>
    /// gwynewsEdit 的摘要说明
    /// </summary>
    public class gwynewsEdit : IHttpHandler
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
                //保存新增加的数据
                if (action == "AddNew")
                {
                    ////获取上传的图片
                    //HttpPostedFile file = context.Request.Files["newsImage"];
                    ////设置上传图片的文件名称，获取当前时间为图片名，获取上传图片的拓展名
                    //string filename = "";
                    //if (CommonHelper.HasFile(file))//判断是否有图片
                    //{
                    //    //保存图片文件
                    //    filename = DateTime.Now.ToString("yyyyMMddhhmmssfff") + Path.GetExtension(file.FileName);
                    //    file.SaveAs(context.Server.MapPath("~/Skins/uploadfiles/" + filename));

                    //}

                    //string newsId = context.Request.Form["newsID"];
                    string title = context.Request.Form["title"].Trim();
                    string author = context.Request.Form["author"].Trim();
                    string content = context.Request.Form["Msg"].Trim();
                 //   string newsDescription = context.Request.Form["newsDescription"];
                    string newsBelong = context.Request.Form["newsBelong"].Trim();
                    string pagesBelong = context.Request.Form["pagesBelong"].Trim();

                    string sql = @"insert into XGNews(title,author,newsDate,newsContent,newsBelong,pagesBelong) 
                              values(@title,@author,getdate(),@content,@newsBelong,@pagesBelong);";
                    SqlHelper.ExecuteNonQuery(sql,
                        new SqlParameter("@title", title),
                        new SqlParameter("@author", author),
                        new SqlParameter("@content", content),
                        new SqlParameter("@newsBelong", newsBelong),
                        new SqlParameter("@pagesBelong", pagesBelong)
                    //    new SqlParameter("@newsDescription", newsDescription)
                        );
                    //  context.Response.Redirect("newsList.ashx&newsBelong="+newsBelong);
                    context.Response.Write("保存成功！");
                }
                //保存修改的数据
                else if (action == "Edit")
                {
                    ////获取上传的图片
                    //HttpPostedFile file = context.Request.Files["newsImage"];
                    ////设置上传图片的文件名称，获取当前时间为图片名，获取上传图片的拓展名
                    //string filename = "";
                    //if (CommonHelper.HasFile(file))//判断是否有图片
                    //{
                    //    //保存图片文件
                    //    filename = DateTime.Now.ToString("yyyyMMddhhmmssfff") + Path.GetExtension(file.FileName);
                    //    file.SaveAs(context.Server.MapPath("../Skins/uploadfiles/" + filename));

                    //}
                    string newsId = context.Request.Form["newsID"];
                    string title = context.Request.Form["title"].Trim();
                    string author = context.Request.Form["author"].Trim();
                    string content = context.Request.Form["Msg"].Trim();
                   // string newsDescription = context.Request.Form["newsDescription"];
                    string newsBelong = context.Request.Form["newsBelong"].Trim();
                    //置顶
                    string pagesBelong = context.Request.Form["pagesBelong"].Trim();
                    //当有图片上传的时候
                    //                    if (CommonHelper.HasFile(file))
                    //                    {
                    //                        string sql = @"update XGNews 
                    //                        set title=@title,author=@author,newsContent=@content ,newsDescription=@newsDescription,newsImage=@newsImage where newsID=@newsId";
                    //                        SqlHelper.ExecuteNonQuery(sql,
                    //                            new SqlParameter("@title", title),
                    //                            new SqlParameter("@author", author),
                    //                            new SqlParameter("@content", content),
                    //                            new SqlParameter("@newsDescription", newsDescription),
                    //                            new SqlParameter("@newsImage", "../Skins/uploadfiles/" + filename),
                    //                            new SqlParameter("@newsId", newsId)
                    //                            );
                    //                      //  context.Response.Redirect("newsList.ashx&newsBelong=" + newsBelong);
                    //                        context.Response.Write("保存成功！");
                    //                    }
                    //else //没有图片上传时，不修改图片的路径
                    //{
                    string sql = @"update XGNews 
                        set title=@title,author=@author, pagesBelong=@pagesBelong, newsContent=@content,newsDate=getdate()  where newsID=@newsId";
                    SqlHelper.ExecuteNonQuery(sql,
                        new SqlParameter("@title", title),
                        new SqlParameter("@author", author),
                        new SqlParameter("@content", content),
                        new SqlParameter("@pagesBelong", pagesBelong),
                      //  new SqlParameter("@newsDescription", newsDescription),
                        new SqlParameter("@newsId", newsId)
                        );
                    // context.Response.Redirect("newsList.ashx&newsBelong=" + newsBelong);
                    context.Response.Write("保存成功！");
                    //}



                }
                //参数错误
                else
                {
                    context.Response.Write("Action参数错误:" + action);
                }

            }
            //isPostBack为空，展示网页
            else
            {
                //新增初始展示
                if (action == "AddNew")
                {

                    //属于哪一个公告
                    string reqnewsBelong = context.Request.QueryString["newsBelong"];
                    var data = new
                    {
                        Title = "添加新闻",
                        Action = action,
                        news = new { newsID = "0", title = "", author = "", newsDescription = "", newsContent = "",newsBelong=reqnewsBelong },
                    };
                    string html = CommonHelper.RenderHtml("/admin/gwynewsEdit.htm", data);
                    context.Response.Write(html);
                }
                //编辑展示
                else if (action == "Edit")
                {
                    //获取要编辑数据的ID
                    long id = Convert.ToInt64(context.Request.QueryString["newsID"]);
                    //从数据库中查询此ID的数据
                    DataTable dt = SqlHelper.ExecuteDataTable("select * from XGNews where newsID=@id", new SqlParameter("@id", id));

                    if (dt.Rows.Count <= 0)
                    {
                        context.Response.Write("没有找到此ID的新闻公告！");
                    }
                    else if (dt.Rows.Count > 1)
                    {
                        context.Response.Write("找到多条此ID的新闻公告！");
                    }
                    else
                    {
                        var data = new
                        {
                            Title = "编辑新闻公告",
                            Action = action,
                            news = dt.Rows[0]
                        };
                        string html = CommonHelper.RenderHtml("/admin/gwynewsEdit.htm", data);
                        context.Response.Write(html);
                    }
                }
                else if (action == "Delete")
                {
                    //获取要删除数据的ID
                    long id = Convert.ToInt64(context.Request.QueryString["newsID"]);
                    // context.Response.Write(id);
                    SqlHelper.ExecuteNonQuery("delete from XGNews where newsID=@id", new SqlParameter("@id", id));
                    context.Response.Write("删除成功！");
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