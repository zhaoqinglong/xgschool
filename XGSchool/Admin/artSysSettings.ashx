<%@ WebHandler Language="C#" Class="artSysSettings" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class artSysSettings : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";
        bool isSave = !string.IsNullOrEmpty(context.Request["Save"]);
        if (isSave)
        {
            HttpPostedFile file = context.Request.Files["aboutimgSrc"];
            //判断是否有上传的文件 
            if (CommonHelper.HasFile(file))
            {
                //设置上传图片的文件名称，获取当前时间为图片名，获取上传图片的拓展名称
                string filename = DateTime.Now.ToString("yyyyMMddhhmmssfff") + System.IO.Path.GetExtension(file.FileName);
                //保存文件
                file.SaveAs(context.Server.MapPath("../Skins/uploadfiles/" + filename));
                CommonHelper.WriteSetting("艺术首页新革简介图片", "../Skins/uploadfiles/" + filename);//新革简介          
            }
            
            string about = context.Request["about"].Trim();
            string topPhone = context.Request["topPhone"].Trim();
            //string biandao = context.Request["biandao"];
            //string boyin = context.Request["boyin"];
            //string show = context.Request["show"];
            //string other = context.Request["other"];
            HttpPostedFile file1 = context.Request.Files["biandao"];
            if (CommonHelper.HasFile(file1))
            {
                //设置上传图片的文件名称，获取当前时间为图片名，获取上传图片的拓展名称
                string filename = DateTime.Now.ToString("yyyyMMddhhmmssfff") + System.IO.Path.GetExtension(file1.FileName);
                //保存文件
                file1.SaveAs(context.Server.MapPath("../Skins/uploadfiles/" + filename));
                CommonHelper.WriteSetting("艺术首页编导类", "../Skins/uploadfiles/" + filename);//新革简介          
            }

            HttpPostedFile file2 = context.Request.Files["boyin"];
            if (CommonHelper.HasFile(file2))
            {
                //设置上传图片的文件名称，获取当前时间为图片名，获取上传图片的拓展名称
                string filename = DateTime.Now.ToString("yyyyMMddhhmmssfff") + System.IO.Path.GetExtension(file2.FileName);
                //保存文件
                file2.SaveAs(context.Server.MapPath("../Skins/uploadfiles/" + filename));
                CommonHelper.WriteSetting("艺术首页播音类", "../Skins/uploadfiles/" + filename);//新革简介          
            }

            HttpPostedFile file3 = context.Request.Files["show"];
            if (CommonHelper.HasFile(file3))
            {
                //设置上传图片的文件名称，获取当前时间为图片名，获取上传图片的拓展名称
                string filename = DateTime.Now.ToString("yyyyMMddhhmmssfff") + System.IO.Path.GetExtension(file3.FileName);
                //保存文件
                file3.SaveAs(context.Server.MapPath("../Skins/uploadfiles/" + filename));
                CommonHelper.WriteSetting("艺术首页表演类", "../Skins/uploadfiles/" + filename);//新革简介          
            }

            HttpPostedFile file4 = context.Request.Files["other"];
            if (CommonHelper.HasFile(file4))
            {
                //设置上传图片的文件名称，获取当前时间为图片名，获取上传图片的拓展名称
                string filename = DateTime.Now.ToString("yyyyMMddhhmmssfff") + System.IO.Path.GetExtension(file4.FileName);
                //保存文件
                file4.SaveAs(context.Server.MapPath("../Skins/uploadfiles/" + filename));
                CommonHelper.WriteSetting("艺术首页其它类", "../Skins/uploadfiles/" + filename);//新革简介          
            }
            string videoURL = context.Request["videoURL"].Trim();

            CommonHelper.WriteSetting("艺术首页新革简介", about);//新革简介
            CommonHelper.WriteSetting("新革艺术学校首页顶部电话", topPhone); //主页邮箱
            //CommonHelper.WriteSetting("艺术首页编导类", biandao); //公务员培训电话
            //CommonHelper.WriteSetting("艺术首页播音类", boyin); //商演培训电话
            //CommonHelper.WriteSetting("艺术首页表演类", show); //商演培训电话
            //CommonHelper.WriteSetting("艺术首页其它类", other); //商演培训电话
            CommonHelper.WriteSetting("视频地址", videoURL);
            
            context.Response.Write("保存成功！");
        }
        else
        {
            
            string about = CommonHelper.ReadSetting("艺术首页新革简介").Trim();//学校地址
            string topPhone = CommonHelper.ReadSetting("新革艺术学校首页顶部电话").Trim(); //主页邮箱
            string biandao = CommonHelper.ReadSetting("艺术首页编导类").Trim(); //公务员培训电话
            string boyin = CommonHelper.ReadSetting("艺术首页播音类").Trim(); //商演培训电话
            string show = CommonHelper.ReadSetting("艺术首页表演类").Trim(); //商演培训电话
            string other = CommonHelper.ReadSetting("艺术首页其它类").Trim(); //商演培训电话
            string videoURL = CommonHelper.ReadSetting("视频地址").Trim();
            string aboutimgSrc = CommonHelper.ReadSetting("艺术首页新革简介图片").Trim();
            
            var data = new {about=about,  topPhone = topPhone,  videoURL = videoURL,aboutimgSrc=aboutimgSrc,
            biandao=biandao,boyin=boyin,show=show,other=other};
            
            
            string html = CommonHelper.RenderHtml("/admin/artSysSettings.htm", data);
            context.Response.Write(html);
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}