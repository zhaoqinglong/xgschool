using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XGSchool.commercial
{
    public partial class student : System.Web.UI.Page
    {
        protected string showImgsrc = CommonHelper.ReadSetting("商演培训顶部背景图片").Trim();
        protected string SchoolColName = "学员风采";
        protected string SchoolColDetail = "学员风采";
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select SchoolColName,SchoolColDetail from XGSchoolCols where SchoolColId=10;";
            DataTable passage = SqlHelper.ExecuteDataTable(sql);
            if (passage != null && passage.Rows.Count > 0)
            {
                SchoolColName = passage.Rows[0][0].ToString().Trim();
                SchoolColDetail = passage.Rows[0][1].ToString();
            }
        }
    }
}