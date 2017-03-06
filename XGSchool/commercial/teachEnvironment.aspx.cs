using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XGSchool.commercial
{
    public partial class teachEnvironment : System.Web.UI.Page
    {
        //教学环境
        protected string passageName = "教学环境";
        protected string passageCaption = "教学环境";
        protected string passageDetail = "教学环境的详细信息";
        protected string showImgsrc = CommonHelper.ReadSetting("商演培训顶部背景图片").Trim();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select TrainName,TrainCaption,TrainDetail from GWYTrain where TrainId=11;";
            DataTable passage = SqlHelper.ExecuteDataTable(sql);
            if (passage != null && passage.Rows.Count > 0)
            {
                passageName = passage.Rows[0][0].ToString().Trim();
                passageCaption = passage.Rows[0][1].ToString().Trim();
                passageDetail = passage.Rows[0][2].ToString();
            }
        }
    }
}