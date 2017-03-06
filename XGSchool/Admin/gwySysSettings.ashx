<%@ WebHandler Language="C#" Class="gwySysSettings" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class gwySysSettings : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";
        bool isSave = !string.IsNullOrEmpty(context.Request["Save"]);
        if (isSave)
        {
            string xggwy = context.Request["xggwy"].Trim();
            string gkzl = context.Request["gkzl"].Trim();
            string ksdg = context.Request["ksdg"].Trim();
            string mszq = context.Request["mszq"].Trim();
            string xczq = context.Request["xczq"].Trim();
            string slzq = context.Request["slzq"].Trim();
            string ggjc = context.Request["ggjc"].Trim();
            string bank = context.Request["bank"].Trim();

            CommonHelper.WriteSetting("新革公务员公告", xggwy);//学校地址
            CommonHelper.WriteSetting("公考招录公告", gkzl); //主页邮箱
            CommonHelper.WriteSetting("考试大纲", ksdg); //主页电话
            CommonHelper.WriteSetting("面试专区", mszq); //艺术考试电话
            CommonHelper.WriteSetting("行测专区", xczq); //公务员培训电话
            CommonHelper.WriteSetting("申论专区", slzq); //商演培训电话
            CommonHelper.WriteSetting("公共基础知识", ggjc); //商演培训电话
            CommonHelper.WriteSetting("银行考试", bank); //商演培训电话
            context.Response.Write("保存成功！");
        }
        else
        {

            string xggwy = CommonHelper.ReadSetting("新革公务员公告").Trim();//学校地址
            string gkzl = CommonHelper.ReadSetting("公考招录公告").Trim(); //主页邮箱
            string ksdg = CommonHelper.ReadSetting("考试大纲").Trim(); //主页电话
            string mszq = CommonHelper.ReadSetting("面试专区").Trim(); //艺术考试电话
            string xczq = CommonHelper.ReadSetting("行测专区").Trim(); //公务员培训电话
            string slzq = CommonHelper.ReadSetting("申论专区").Trim(); //商演培训电话
            string ggjc = CommonHelper.ReadSetting("公共基础知识").Trim(); //商演培训电话
            string bank = CommonHelper.ReadSetting("银行考试").Trim(); //商演培训电话
            var data = new { xggwy = xggwy, gkzl = gkzl, ksdg = ksdg, mszq = mszq, xczq = xczq, slzq = slzq, ggjc = ggjc, bank = bank };
            
            
            string html = CommonHelper.RenderHtml("/admin/gwySysSettings.htm", data);
            context.Response.Write(html);
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}