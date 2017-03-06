<%@ WebHandler Language="C#" Class="sysSettings" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class sysSettings : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";
//        AdminHelper.CheckLogin();
        bool isSave = !string.IsNullOrEmpty(context.Request["Save"]);
        if (isSave)
        {            
            //string siteName = context.Request["SiteName"];

            string email = context.Request["email"].Trim();
            string mainPhone = context.Request["mainPhone"].Trim();
            string artPhone = context.Request["artPhone"].Trim();
            string gwyPhone = context.Request["gwyPhone"].Trim();
            string commercialPhone = context.Request["commercialPhone"].Trim();
            string msg = context.Request["msg"].Trim();
            string copyright = context.Request["copyright"].Trim();

            string artcopyright = context.Request["artcopyright"].Trim();
            string gkcopyright = context.Request["gkcopyright"].Trim();
            string showcopyright = context.Request["showcopyright"].Trim();

            string SiteAds = context.Request["SiteAds"].Trim();
            string gkSiteAds = context.Request["gkSiteAds"].Trim();
            string showSiteAds = context.Request["showSiteAds"].Trim();
            
        //    CommonHelper.WriteSetting("SiteTitle", siteName);
           
            
            CommonHelper.WriteSetting("主页邮箱",email); //主页邮箱
            CommonHelper.WriteSetting("主页电话",mainPhone); //主页电话
            CommonHelper.WriteSetting("艺术考试电话",artPhone); //艺术考试电话
            CommonHelper.WriteSetting("公务员培训电话",gwyPhone); //公务员培训电话
            CommonHelper.WriteSetting("商演培训电话",commercialPhone); //商演培训电话
            CommonHelper.WriteSetting("首页文字", msg); //商演培训电话
            
            CommonHelper.WriteSetting("版权信息", copyright);
            CommonHelper.WriteSetting("艺考培训版权信息", artcopyright);
            CommonHelper.WriteSetting("公考培训版权信息", gkcopyright);
            CommonHelper.WriteSetting("商演培训版权信息", showcopyright);

            CommonHelper.WriteSetting("艺考培训学校地址", SiteAds);//学校地址
            CommonHelper.WriteSetting("公考培训学校地址", gkSiteAds);
            CommonHelper.WriteSetting("商演培训学校地址", showSiteAds);
            
            context.Response.Write("保存成功！");
        }
        else
        {
            var data = CommonHelper.GetSettings();
            string html = CommonHelper.RenderHtml("/admin/sysSettings.htm", data);
            context.Response.Write(html);
        }

    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}