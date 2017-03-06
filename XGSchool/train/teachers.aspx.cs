using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XGSchool.XGModels;
using System.Data;

namespace XGSchool.train
{
    public partial class teachers : System.Web.UI.Page
    {
        public Link[] Links = { };//超链接数组
        public Teacher[] Teachers = { };
        public string gkcopyright = CommonHelper.ReadSetting("公考培训版权信息").Trim();
        public string gksiteAds = CommonHelper.ReadSetting("公考培训学校地址").Trim();//艺考培训学校地址
        public string Phone1 = "15723197680  2";
      //  public string Phone2 = "18602825088  1";
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取超级链接的内容
            DataTable LinkInfo = SqlHelper.ExecuteDataTable("select top 8 LinkName,LinkString from FriendLink;");
            Links = new Link[LinkInfo.Rows.Count];
            for (int i = 0; i < LinkInfo.Rows.Count; i++)
            {
                Link mylink = new Link();
                mylink.LinkName = LinkInfo.Rows[i]["LinkName"].ToString();
                mylink.LinkString = LinkInfo.Rows[i]["LinkString"].ToString();
                Links[i] = mylink;
            }
            //获取教师信息
            DataTable teac = SqlHelper.ExecuteDataTable("select TeacherName,TeacherTitle,TeacherDetail,TeacherImgSrc from XGTeachers where TeacherBelongTo='新革公务员';");
            Teachers = new Teacher[teac.Rows.Count];
            for (int i = 0; i < teac.Rows.Count; i++)
            {
                Teacher teacher = new Teacher();
                teacher.TeacherName = teac.Rows[i]["TeacherName"].ToString().Trim();
                teacher.TeacherTitle = teac.Rows[i]["TeacherTitle"].ToString().Trim();
                teacher.TeacherDetail = teac.Rows[i]["TeacherDetail"].ToString().Trim();
                teacher.TeacherImgSrc = teac.Rows[i]["TeacherImgSrc"].ToString().Trim();
                Teachers[i] = teacher;
            }

            
            Phone1 = CommonHelper.ReadSetting("公务员培训电话").Trim();
        }
    }
}