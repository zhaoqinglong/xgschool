using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XGSchool.commercial
{
    public partial class commercialShow : System.Web.UI.Page
    {
        //学院简介页面
        protected string passageName = "学院简介";
        protected string passageCaption = "学院简介";
        protected string passageDetail = "学院简介的详细信息";
        protected string showImgsrc = CommonHelper.ReadSetting("商演培训顶部背景图片").Trim();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select TrainName,TrainCaption,TrainDetail from GWYTrain where TrainId=10;";
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