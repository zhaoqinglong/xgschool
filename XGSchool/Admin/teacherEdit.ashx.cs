using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace XGSchool.Admin
{
    /// <summary>
    /// teacherEdit 的摘要说明
    /// </summary>
    public class teacherEdit : IHttpHandler
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
                    string TeacherName = context.Request.Form["TeacherName"].Trim();//获取姓名
                    string TeacherTitle = context.Request.Form["TeacherTitle"].Trim();//职称
                    string TeacherDetail = context.Request.Form["TeacherDetail"].Trim();//详细
                    string TeacherBelongTo = context.Request.Form["TeacherBelongTo"].Trim();//部门

                    //获取上传的图片
                    HttpPostedFile file = context.Request.Files["Pic"];
                    //设置上传图片的文件名称，获取当前时间为图片名，获取上传图片的拓展名
                    string filename = DateTime.Now.ToString("yyyyMMddhhmmssfff") + Path.GetExtension(file.FileName);
                    if (CommonHelper.HasFile(file))//判断是否有图片
                    {
                        //保存图片文件
                        file.SaveAs(context.Server.MapPath("~/Skins/uploadfiles/" + filename));
                    }
                    else
                    {
                        context.Response.Write("图像未上传成功，请重新上传！");
                        context.Response.Write("<input type='button' value='返回' onclick='javascript:history.back();'/>");
                        return;
                    }

                    if (string.IsNullOrEmpty(TeacherName) || string.IsNullOrEmpty(TeacherTitle) || string.IsNullOrEmpty(TeacherDetail) || string.IsNullOrEmpty(TeacherBelongTo))
                    {
                        context.Response.Write("添加的内容为空，请检查后重新添加！");
                        context.Response.Write("<input type='button' value='返回' onclick='javascript:history.back();'/>");
                        return;
                    }
                    else
                    {
                        string sql = @"insert into XGTeachers(TeacherName,TeacherTitle,TeacherDetail,TeacherImgSrc,TeacherBelongTo) 
                                            values(@TeacherName,@TeacherTitle,@TeacherDetail,@TeacherImgSrc,@TeacherBelongTo);";
                        SqlHelper.ExecuteNonQuery(sql,
                            new SqlParameter("@TeacherName", TeacherName),
                            new SqlParameter("@TeacherTitle", TeacherTitle),
                            new SqlParameter("@TeacherDetail", TeacherDetail),
                            new SqlParameter("@TeacherImgSrc", "../Skins/uploadfiles/" + filename),
                            new SqlParameter("@TeacherBelongTo", TeacherBelongTo)
                            );
                      //  context.Response.Redirect("teacherEdit.ashx?Action=Show");
                        context.Response.Write("添加成功！   <input type='button' value='返回' onclick='javascript:history.back();'/>");
                    }
                }
                //保存修改的数据
                else if (action == "Edit")
                {
                    string id = context.Request.Form["teacherId"].Trim();
                    string TeacherName = context.Request.Form["TeacherName"].Trim();//获取姓名
                    string TeacherTitle = context.Request.Form["TeacherTitle"].Trim();//职称
                    string TeacherDetail = context.Request.Form["TeacherDetail"].Trim();//详细
                    string TeacherBelongTo = context.Request.Form["TeacherBelongTo"].Trim();//部门

                    //获取上传的图片
                    HttpPostedFile file = context.Request.Files["Pic"];
                    if (string.IsNullOrEmpty(TeacherName) || string.IsNullOrEmpty(TeacherTitle) || string.IsNullOrEmpty(TeacherDetail) || string.IsNullOrEmpty(TeacherBelongTo))
                    {
                        context.Response.Write("修改的内容为空，请检查后再修改！");
                        context.Response.Write("<input type='button' value='返回' onclick='javascript:history.back();'/>");
                    }
                    else
                    {
                        //判断是否有上传的文件 
                        if (CommonHelper.HasFile(file))
                        {
                            //设置上传图片的文件名称，获取当前时间为图片名，获取上传图片的拓展名称
                            string filename = DateTime.Now.ToString("yyyyMMddhhmmssfff") + Path.GetExtension(file.FileName);
                            //保存文件
                            file.SaveAs(context.Server.MapPath("../Skins/uploadfiles/" + filename));

                            string sql = @"update XGTeachers 
                        set TeacherName=@TeacherName,TeacherTitle=@TeacherTitle,TeacherDetail=@TeacherDetail,TeacherImgSrc=@TeacherImgSrc,TeacherBelongTo=@TeacherBelongTo where TeacherId=@id";
                            SqlHelper.ExecuteNonQuery(sql,
                                 new SqlParameter("@TeacherName", TeacherName),
                                 new SqlParameter("@TeacherTitle", TeacherTitle),
                                 new SqlParameter("@TeacherDetail", TeacherDetail),
                                 new SqlParameter("@TeacherImgSrc", "../Skins/uploadfiles/" + filename),
                                 new SqlParameter("@TeacherBelongTo", TeacherBelongTo),
                                 new SqlParameter("@id", id)
                                );

                         //   context.Response.Redirect("teacherEdit.ashx?Action=Show");
                            context.Response.Write("修改成功！ <input type='button' value='返回' onclick='javascript:history.back();'/>");
                        }
                        else//没有文件上传
                        {
                            string sql = @"update XGTeachers 
                        set TeacherName=@TeacherName,TeacherTitle=@TeacherTitle,TeacherDetail=@TeacherDetail,TeacherBelongTo=@TeacherBelongTo where TeacherId=@id";
                            SqlHelper.ExecuteNonQuery(sql,
                                new SqlParameter("@TeacherName", TeacherName),
                                new SqlParameter("@TeacherTitle", TeacherTitle),
                                new SqlParameter("@TeacherDetail", TeacherDetail),
                                new SqlParameter("@TeacherBelongTo", TeacherBelongTo),
                                new SqlParameter("@id", id)
                                );
                           // context.Response.Redirect("teacherEdit.ashx?Action=Show");
                            context.Response.Write("修改成功！ <input type='button' value='返回' onclick='javascript:history.back();'/>");
                        }
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
                        Title = "添加教师信息",
                        Action = action,
                        Teachers = new { TeacherId = "1", TeacherName = "", TeacherTitle = "", TeacherDetail = "", TeacherBelongTo = "新革公务员" }
                    };
                    string html = CommonHelper.RenderHtml("/admin/teacherEdit.htm", data);
                    context.Response.Write(html);
                }
                //编辑展示
                else if (action == "Edit")
                {
                    //获取要编辑数据的ID
                    long id = Convert.ToInt64(context.Request.QueryString["teacherId"]);
                    //从数据库中查询此ID的数据
                    DataTable dt = SqlHelper.ExecuteDataTable("select * from XGTeachers where TeacherId=@id", new SqlParameter("@id", id));

                    if (dt.Rows.Count <= 0)
                    {
                        context.Response.Write("没有找到此ID的教师信息！");
                        context.Response.Write("<input type='button' value='返回' onclick='javascript:history.back();'/>");
                    }
                    else if (dt.Rows.Count > 1)
                    {
                        context.Response.Write("找到多条此ID的教师信息，请检查数据库！");
                        context.Response.Write("<input type='button' value='返回' onclick='javascript:history.back();'/>");
                    }
                    else
                    {
                        var data = new
                        {
                            Title = "编辑教师信息",
                            Action = action,
                            Teachers = dt.Rows[0]
                        };
                        string html = CommonHelper.RenderHtml("/admin/teacherEdit.htm", data);
                        context.Response.Write(html);
                    }
                }
                else if (action == "Delete")
                {
                    //获取要删除数据的ID
                    long id = Convert.ToInt64(context.Request.QueryString["teacherId"]);
                    string sql = "delete from XGTeachers where TeacherId=@id";
                    SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@id", id));
                    context.Response.Write(id);
                    context.Response.Write("删除成功！");
                    context.Response.Write("<input type='button' value='返回' onclick='javascript:history.back();'/>");
                }
                else if (action == "Show")//列表展示
                {
                    string teacherBelongTo = context.Request.QueryString["teacherBelongTo"];//列表展示的教师信息属于哪个部门
                    if (string.IsNullOrEmpty(teacherBelongTo) || teacherBelongTo.Trim() == null)
                    {
                        teacherBelongTo = "新革公务员";
                    }
                    string sql = "select * from XGTeachers where TeacherBelongTo=@teacherBelongTo;";
                    DataTable dt = SqlHelper.ExecuteDataTable(sql, new SqlParameter("@teacherBelongTo", teacherBelongTo));
                    var data = new
                    {
                        Title = "新革师资",
                        Teachers = dt.Rows
                    };
                    string html = CommonHelper.RenderHtml("admin/teacherList.htm", data);
                    context.Response.Write(html);
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