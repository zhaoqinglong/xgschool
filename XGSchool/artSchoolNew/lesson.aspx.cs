using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XGSchool.artSchoolNew
{
    public partial class lesson : System.Web.UI.Page
    {
        protected string lesson1 = "编导类";
        protected string lesson2 = "播音类";
        protected string lesson3 = "表演类";
        protected string lesson4 = "美术类";
        protected string lesson5 = "声乐类";
        protected string lesson6 = "舞蹈类";
        protected string lesson7 = "空乘类";
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select TrainDetail from GWYTrain where TrainId=17 or TrainId=18 or TrainId=19 or TrainId=20 or TrainId=21 or TrainId=22 or TrainId=23;";
            DataTable passage = SqlHelper.ExecuteDataTable(sql);
            if (passage != null && passage.Rows.Count > 0)
            {
                lesson1 = passage.Rows[0][0].ToString().Trim();
                lesson2 = passage.Rows[1][0].ToString().Trim();
                lesson3 = passage.Rows[2][0].ToString().Trim();
                lesson4 = passage.Rows[3][0].ToString().Trim();
                lesson5 = passage.Rows[4][0].ToString().Trim();
                lesson6 = passage.Rows[5][0].ToString().Trim();
                lesson7 = passage.Rows[6][0].ToString().Trim();
            }
        }
    }
}