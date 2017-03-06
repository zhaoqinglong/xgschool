<%@ WebHandler Language="C#" Class="showSysSettings" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class showSysSettings : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";
        bool isSave = !string.IsNullOrEmpty(context.Request["Save"]);
        if (isSave)
        {
            string about = context.Request["about"].Trim();
            string biandao = context.Request["biandao"].Trim();
            string boyin = context.Request["boyin"].Trim();
           // string news = context.Request["news"];

            HttpPostedFile file = context.Request.Files["showImgsrc"];
            //判断是否有上传的文件 
            if (CommonHelper.HasFile(file))
            {
                //设置上传图片的文件名称，获取当前时间为图片名，获取上传图片的拓展名称
                string filename = DateTime.Now.ToString("yyyyMMddhhmmssfff") + System.IO.Path.GetExtension(file.FileName);
                //保存文件
                file.SaveAs(context.Server.MapPath("../Skins/uploadfiles/" + filename));
                CommonHelper.WriteSetting("商演培训顶部背景图片", "../Skins/uploadfiles/" + filename);//新革简介          
            }
            
            CommonHelper.WriteSetting("商演培训首页学院简介", about);//学校地址
            CommonHelper.WriteSetting("商演培训首页课程设置编导类", biandao); //主页邮箱
            CommonHelper.WriteSetting("商演培训首页课程设置播音主持类", boyin); //主页电话
           // CommonHelper.WriteSetting("商演培训首页新闻资讯", news); //艺术考试电话
            //CommonHelper.WriteSetting("艺术首页编导类", biandao); //公务员培训电话
            //CommonHelper.WriteSetting("艺术首页播音类", boyin); //商演培训电话
            //CommonHelper.WriteSetting("艺术首页表演类", show); //商演培训电话
            //CommonHelper.WriteSetting("艺术首页其它类", other); //商演培训电话
            context.Response.Write("保存成功！");
        }
        else
        {
            
            string about = CommonHelper.ReadSetting("商演培训首页学院简介").Trim();//学校地址
            string biandao = CommonHelper.ReadSetting("商演培训首页课程设置编导类").Trim(); //主页邮箱
            string boyin = CommonHelper.ReadSetting("商演培训首页课程设置播音主持类").Trim(); //主页电话
            string showImgsrc = CommonHelper.ReadSetting("商演培训顶部背景图片").Trim();//学校地址
          //  string news = CommonHelper.ReadSetting("商演培训首页新闻资讯").Trim(); //艺术考试电话
            //string biandao = CommonHelper.ReadSetting("艺术首页编导类").Trim(); //公务员培训电话
            //string boyin = CommonHelper.ReadSetting("艺术首页播音类").Trim(); //商演培训电话
            //string show = CommonHelper.ReadSetting("艺术首页表演类").Trim(); //商演培训电话
            //string other = CommonHelper.ReadSetting("艺术首页其它类").Trim(); //商演培训电话
            var data = new { about = about, biandao = biandao, boyin = boyin, showImgsrc=showImgsrc };
            
            
            string html = CommonHelper.RenderHtml("/admin/showSysSettings.htm", data);
            context.Response.Write(html);
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}