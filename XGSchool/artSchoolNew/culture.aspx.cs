using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XGSchool.artSchoolNew
{
    public partial class culture : System.Web.UI.Page
    {
        protected string SchoolColName = "校园文化";
        protected string SchoolColDetail = "校园文化";
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select SchoolColName,SchoolColDetail from XGSchoolCols where SchoolColId=7;";
            DataTable passage = SqlHelper.ExecuteDataTable(sql);
            if (passage != null && passage.Rows.Count > 0)
            {
                SchoolColName = passage.Rows[0][0].ToString().Trim();
                SchoolColDetail = passage.Rows[0][1].ToString();
            }
        }
    }
}