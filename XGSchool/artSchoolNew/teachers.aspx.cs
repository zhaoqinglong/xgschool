using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XGSchool.XGModels;

namespace XGSchool.artSchoolNew
{
    public partial class teachers : System.Web.UI.Page
    {
        public Teacher[] Teachers = { };
        protected void Page_Load(object sender, EventArgs e)
        {
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
        }
    }
}