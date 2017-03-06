using System;
using XGSchool.XGModels;
using System.Data;
using System.Data.SqlClient;

namespace XGSchool.train
{
    public partial class advantages : System.Web.UI.Page
    {
        public Link[] Links = { };//超链接数组
        protected string SchoolColName = "办学优势";
        protected string SchoolColDetail = "办学优势";
        public string gkcopyright = CommonHelper.ReadSetting("公考培训版权信息").Trim();
        public string gksiteAds = CommonHelper.ReadSetting("公考培训学校地址").Trim();//艺考培训学校地址
        public string Phone1 = "15723197680  2";
      //  public string Phone2 = "18602825088  1";
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

            string colsId = Request.QueryString["colsId"];//获取二级栏目id
            int Id = 3;//默认为3
            if (!string.IsNullOrEmpty(colsId))
            {
                Id = Convert.ToInt32(colsId);
            }
            string sql = "select SchoolColName,SchoolColDetail from XGSchoolCols where SchoolColId=@Id;";
            DataTable passage = SqlHelper.ExecuteDataTable(sql, new SqlParameter("@Id", Id));
            if (passage != null && passage.Rows.Count > 0)
            {
                SchoolColName = passage.Rows[0][0].ToString().Trim();
                SchoolColDetail = passage.Rows[0][1].ToString();
            }


            Phone1 = CommonHelper.ReadSetting("公务员培训电话").Trim();
        }
    }
}