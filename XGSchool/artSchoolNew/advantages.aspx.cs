using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XGSchool.artSchoolNew
{
    public partial class advantages : System.Web.UI.Page
    {
        protected string teachEnvironment = "教学环境";
        protected string teachTeam = "师资团队";
        protected string lessonEnvironment = "课堂氛围";
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select TrainDetail from GWYTrain where TrainId=14 or TrainId=15 or TrainId=16;";
            DataTable passage = SqlHelper.ExecuteDataTable(sql);
            if (passage != null && passage.Rows.Count > 0)
            {
                teachEnvironment = passage.Rows[0][0].ToString().Trim();
                teachTeam = passage.Rows[1][0].ToString().Trim();
                lessonEnvironment = passage.Rows[2][0].ToString().Trim();
            }

        }
    }
}