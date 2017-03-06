using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XGSchool.XGModels;

namespace XGSchool.artSchoolNew
{
   
    public partial class newsDetail : System.Web.UI.Page
    {
        public string newsDeatil = "";
        public XGNews xgnewsDetail = new XGNews { newDate="",newsTitle="",newsContent="",author="",newsId="",newsImage=""};
        protected void Page_Load(object sender, EventArgs e)
        {
            int newsID = 1;
            newsID = Convert.ToInt32(Request.QueryString["newsID"]);
            string sql = "select * from XGNews where newsID=@newsID";
            DataTable xgnewsInfo = SqlHelper.ExecuteDataTable(sql, new SqlParameter("@newsID", newsID));

            if (xgnewsInfo.Rows.Count <= 0)
            {
               xgnewsDetail.newsTitle="没有找到相关的新革动态！";
            }
            else if (xgnewsInfo.Rows.Count > 1)
            {
                xgnewsDetail.newsTitle = "找到多条相关的新革动态！";
            }
            else
            {
                xgnewsDetail.newsTitle = xgnewsInfo.Rows[0]["title"].ToString().Trim();
                xgnewsDetail.author = xgnewsInfo.Rows[0]["author"].ToString().Trim();
                try
                {
                    xgnewsDetail.newDate = DateTime.Parse(xgnewsInfo.Rows[0]["newsDate"].ToString().Trim()).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {
                    xgnewsDetail.newDate = "";
                }
                xgnewsDetail.newsContent = xgnewsInfo.Rows[0]["newsContent"].ToString().Trim();
            }
        }
    }
}