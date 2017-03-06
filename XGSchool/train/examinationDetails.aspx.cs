using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XGSchool.XGModels;

namespace XGSchool.train
{
    public partial class examinationDetails : System.Web.UI.Page
    {
        public Link[] Links = { };//超链接数组

        public string gkcopyright = CommonHelper.ReadSetting("公考培训版权信息").Trim();
        public string gksiteAds = CommonHelper.ReadSetting("公考培训学校地址").Trim();//艺考培训学校地址
        public string Phone1 = CommonHelper.ReadSetting("公务员培训电话").Trim();

        public string newsDeatil = "";
        public XGNews xgnewsDetail = new XGNews { newDate = "", newsTitle = "", newsContent = "", author = "", newsId = "", newsImage = "", newsBelong ="试题专区"};
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable LinkInfo = SqlHelper.ExecuteDataTable("select top 8 LinkName,LinkString from FriendLink;");
            Links = new Link[LinkInfo.Rows.Count];
            for (int i = 0; i < LinkInfo.Rows.Count; i++)
            {
                Link mylink = new Link();
                mylink.LinkName = LinkInfo.Rows[i]["LinkName"].ToString();
                mylink.LinkString = LinkInfo.Rows[i]["LinkString"].ToString();
                Links[i] = mylink;
            }

            int newsID = 1;
            newsID = Convert.ToInt32(Request.QueryString["newsID"]);
            string sql = "select * from XGNews where newsID=@newsID";
            DataTable xgnewsInfo = SqlHelper.ExecuteDataTable(sql, new SqlParameter("@newsID", newsID));

            if (xgnewsInfo.Rows.Count <= 0)
            {
                xgnewsDetail.newsTitle = "没有找到相关的信息！";
            }
            else if (xgnewsInfo.Rows.Count > 1)
            {
                xgnewsDetail.newsTitle = "找到多条相关的信息！";
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
                xgnewsDetail.newsBelong = xgnewsInfo.Rows[0]["newsBelong"].ToString().Trim();
            }
        }
    }
}