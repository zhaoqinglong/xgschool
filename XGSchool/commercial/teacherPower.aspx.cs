using System;
using System.Data;
using XGSchool.XGModels;

namespace XGSchool.commercial
{
    public partial class teacherPower : System.Web.UI.Page
    {
        protected string showImgsrc = CommonHelper.ReadSetting("商演培训顶部背景图片").Trim();
        public Teacher[] Teachers = { };
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取教师信息
            DataTable teac = SqlHelper.ExecuteDataTable("select TeacherName,TeacherTitle,TeacherDetail,TeacherImgSrc from XGTeachers where TeacherBelongTo='新革商演培训';");
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
        }
    }
}