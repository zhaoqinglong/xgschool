using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NVelocity.App;
using NVelocity.Runtime;
using NVelocity;
using System.Data;
using System.Data.SqlClient;

    public class CommonHelper
    {
        /// <summary>
        /// 用data数据填充templateName模板，渲染生成html返回
        /// </summary>
        /// <param name="templateName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string RenderHtml(string templateName, object data)
    {
            VelocityEngine vltEngine = new VelocityEngine();
            vltEngine.SetProperty(RuntimeConstants.RESOURCE_LOADER, "file");
            vltEngine.SetProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, System.Web.Hosting.HostingEnvironment.MapPath("~/templates"));//模板文件所在的文件夹
            vltEngine.SetProperty(RuntimeConstants.INPUT_ENCODING, "utf-8");
            vltEngine.SetProperty(RuntimeConstants.OUTPUT_ENCODING, "utf-8");
            vltEngine.Init();

            VelocityContext vltContext = new VelocityContext();
            vltContext.Put("Data", data);//设置参数，在模板中可以通过$data来引用

            Template vltTemplate = vltEngine.GetTemplate(templateName);
            System.IO.StringWriter vltWriter = new System.IO.StringWriter();
            vltTemplate.Merge(vltContext, vltWriter);

            string html = vltWriter.GetStringBuilder().ToString();
            return html;
        }
        /// <summary>
        /// 判断是否有文件上传
        /// </summary>
        /// 
        public static void f(){}

        public static bool f1(string  s){
            if(s!=null){
            return true;
            }
            else
            {
                return true;
            }
        }
        public static bool HasFile(HttpPostedFile file){
            if(file == null){
                return false;
            }
            else{
                return file.ContentLength>0;
            }
        }
        public static object GetSettings()
        {
            string siteAds = CommonHelper.ReadSetting("艺考培训学校地址").Trim();//艺考培训学校地址
            string gksiteAds = CommonHelper.ReadSetting("公考培训学校地址").Trim();//艺考培训学校地址
            string showsiteAds = CommonHelper.ReadSetting("商演培训学校地址").Trim();//艺考培训学校地址
            string email = CommonHelper.ReadSetting("主页邮箱").Trim(); //主页邮箱
            string mainPhone = CommonHelper.ReadSetting("主页电话").Trim(); //主页电话
            string artPhone = CommonHelper.ReadSetting("艺术考试电话").Trim(); //艺术考试电话
            string gwyPhone = CommonHelper.ReadSetting("公务员培训电话").Trim(); //公务员培训电话
            string commercialPhone = CommonHelper.ReadSetting("商演培训电话").Trim(); //商演培训电话
            string msg = CommonHelper.ReadSetting("首页文字").Trim(); //商演培训电话
            string copyright = CommonHelper.ReadSetting("版权信息").Trim();
            string artcopyright = CommonHelper.ReadSetting("艺考培训版权信息").Trim();
            string gkcopyright = CommonHelper.ReadSetting("公考培训版权信息").Trim();
            string showcopyright = CommonHelper.ReadSetting("商演培训版权信息").Trim();
            var data = new { siteAds = siteAds,gksiteAds=gksiteAds,showsiteAds=showsiteAds, email = email, mainPhone = mainPhone,
                artPhone = artPhone, gwyPhone = gwyPhone, commercialPhone = commercialPhone, msg = msg, copyright = copyright,
                artcopyright=artcopyright,gkcopyright=gkcopyright,showcopyright=showcopyright};
            return data;
        }

        public static string ReadSetting(string name)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select setValue from sysSettings where setName=@Name", 
                                                        new SqlParameter("@Name", name));
            if (dt.Rows.Count <= 0)
            {
                throw new Exception("找不到Name=" + name + "的配置项");
            }
            else if (dt.Rows.Count > 1)
            {
                throw new Exception("找到多条Name=" + name + "的配置项");
            }
            return (string)dt.Rows[0]["setValue"];
        }

        public static void WriteSetting(string name, string value)
        {
            SqlHelper.ExecuteNonQuery("Update sysSettings set setValue=@Value where setName=@Name", 
                                        new SqlParameter("@Value", value), 
                                        new SqlParameter("@Name", name));
        }
        //检查后台用户是否登录
        public static void checkLogin() {
            HttpContext context=HttpContext.Current;
           
           if(context.Session["userName"]==null){
                context.Response.Redirect("Login.ashx");
           }
        }

        #region 移除HTML标签
        ///   <summary>
        ///   移除HTML标签
        ///   </summary>
        ///   <param   name="HTMLStr">HTMLStr</param>
        public static string ParseTags(string HTMLStr)
        {
            return System.Text.RegularExpressions.Regex.Replace(HTMLStr, "<[^>]*>", "");
        }

        #endregion


    }
