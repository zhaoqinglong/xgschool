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
    /// imgEdit 的摘要说明
    /// </summary>
    public class imgEdit : IHttpHandler
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
                    string imgDescription = context.Request.Form["imgDescription"].Trim();//图片描述
                    string colsBelong = context.Request.Form["colsBelong"].Trim();//所属栏目
                    string pagesBelong = context.Request.Form["pagesBelong"].Trim();//所属页面
                   // string TeacherBelongTo = context.Request.Form["TeacherBelongTo"].Trim();//部门

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

                    if (string.IsNullOrEmpty(imgDescription) || string.IsNullOrEmpty(colsBelong) || string.IsNullOrEmpty(pagesBelong) )
                    {
                        context.Response.Write("添加的内容为空，请检查后重新添加！");
                        context.Response.Write("<input type='button' value='返回' onclick='javascript:history.back();'/>");
                    }
                    else
                    {
                        string sql = @"insert into imgTable(imgSrc,imgDescription,colsBelong,pagesBelong) 
                                            values(@imgSrc,@imgDescription,@colsBelong,@pagesBelong);";
                        SqlHelper.ExecuteNonQuery(sql,
                            new SqlParameter("@imgSrc", "../Skins/uploadfiles/" + filename),
                            new SqlParameter("@imgDescription", imgDescription),
                            new SqlParameter("@colsBelong", colsBelong),
                            new SqlParameter("@pagesBelong", pagesBelong)
                        //    new SqlParameter("@TeacherBelongTo", TeacherBelongTo)
                            );
                    //    context.Response.Redirect("teacherEdit.ashx?Action=Show");
                        context.Response.Write("图片添加成功！  <input type='button' value='返回' onclick='javascript:history.back();'/>");
                    }
                }
                //保存修改的数据
                else if (action == "Edit")
                {
                    string id = context.Request.Form["imgId"].Trim();
                    string imgDescription = context.Request.Form["imgDescription"].Trim();//图片描述
                    string colsBelong = context.Request.Form["colsBelong"].Trim();//所属栏目
                    string pagesBelong = context.Request.Form["pagesBelong"].Trim();//所属页面

                    //获取上传的图片
                    HttpPostedFile file = context.Request.Files["Pic"];
                    if (string.IsNullOrEmpty(imgDescription) || string.IsNullOrEmpty(colsBelong) || string.IsNullOrEmpty(pagesBelong) )
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

                            string sql = @"update imgTable 
                        set imgDescription=@imgDescription,colsBelong=@colsBelong,pagesBelong=@pagesBelong,imgSrc=@imgSrc where imgId=@id";
                            SqlHelper.ExecuteNonQuery(sql,
                                 new SqlParameter("@imgDescription", imgDescription),
                                 new SqlParameter("@colsBelong", colsBelong),
                                 new SqlParameter("@pagesBelong", pagesBelong),
                                 new SqlParameter("@imgSrc", "../Skins/uploadfiles/" + filename),
                                 new SqlParameter("@id", id)
                                );

                            //   context.Response.Redirect("teacherEdit.ashx?Action=Show");
                            context.Response.Write("修改成功！ <input type='button' value='返回' onclick='javascript:history.back();'/>");
                        }
                        else//没有文件上传
                        {
                            string sql = @"update imgTable 
                        set imgDescription=@imgDescription,colsBelong=@colsBelong,pagesBelong=@pagesBelong where imgId=@id";
                            SqlHelper.ExecuteNonQuery(sql,
                                 new SqlParameter("@imgDescription", imgDescription),
                                 new SqlParameter("@colsBelong", colsBelong),
                                 new SqlParameter("@pagesBelong", pagesBelong),                                 
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
                    string colsBelong = context.Request["colsBelong"].Trim() == null ? String.Empty : context.Request["colsBelong"].Trim();//所属栏目
                    string pagesBelong = context.Request["pagesBelong"].Trim() == null ? String.Empty : context.Request["pagesBelong"].Trim();//所属页面
                    var data = new
                    {
                        Title = "添加图片信息",
                        Action = action,
                        Imgs = new { imgId = "1", imgDescription = "", colsBelong = colsBelong, pagesBelong = pagesBelong }
                    };
                    string html = CommonHelper.RenderHtml("/admin/imgEdit.htm", data);
                    context.Response.Write(html);
                }
                //编辑展示
                else if (action == "Edit")
                {
                    //获取要编辑数据的ID
                    long id = Convert.ToInt64(context.Request.QueryString["imgId"]);
                    //从数据库中查询此ID的数据
                    DataTable dt = SqlHelper.ExecuteDataTable("select * from imgTable where imgId=@id", new SqlParameter("@id", id));

                    if (dt.Rows.Count <= 0)
                    {
                        context.Response.Write("没有找到此ID的图片信息！");
                        context.Response.Write("<input type='button' value='返回' onclick='javascript:history.back();'/>");
                    }
                    else if (dt.Rows.Count > 1)
                    {
                        context.Response.Write("找到多条此ID的图片信息，请检查数据库！");
                        context.Response.Write("<input type='button' value='返回' onclick='javascript:history.back();'/>");
                    }
                    else
                    {
                        var data = new
                        {
                            Title = "编辑图片信息",
                            Action = action,
                            Imgs = dt.Rows[0]
                        };
                        string html = CommonHelper.RenderHtml("/admin/imgEdit.htm", data);
                        context.Response.Write(html);
                    }
                }
                else if (action == "Delete")
                {
                    //获取要删除数据的ID
                    long id = Convert.ToInt64(context.Request.QueryString["imgId"]);
                    string sql = "delete from imgTable where imgId=@id";
                    SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@id", id));
                    context.Response.Write(id);
                    context.Response.Write("删除成功！");
                    context.Response.Write("<input type='button' value='返回' onclick='javascript:history.back();'/>");
                }
                else if (action == "Show")//列表展示
                {
                    //string teacherBelongTo = context.Request.QueryString["teacherBelongTo"];//列表展示的教师信息属于哪个部门
                    //if (string.IsNullOrEmpty(teacherBelongTo) || teacherBelongTo.Trim() == null)
                    //{
                    //    teacherBelongTo = "新革公务员";
                    //}
                    string sql = "select * from imgTable where colsBelong='新革商演培训' and pagesBelong='课堂瞬间' ";
                    DataTable dt = SqlHelper.ExecuteDataTable(sql);
                    var data = new
                    {
                        Title = "图片展示",
                        Imgs = dt.Rows
                    };
                    string html = CommonHelper.RenderHtml("admin/imgList.htm", data);
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