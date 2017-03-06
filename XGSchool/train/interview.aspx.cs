using System;
using System.Data;
using System.Data.SqlClient;
using XGSchool.XGModels;

namespace XGSchool.train
{
    public partial class interview : System.Web.UI.Page
    {
        public Link[] Links={};//超链接数组
        protected string passageName = "面试专区";
        protected string passageCaption = "面试技巧";
        protected string passageDetail = "面试的技巧";
        public string gkcopyright = CommonHelper.ReadSetting("公考培训版权信息").Trim();
        public string gksiteAds = CommonHelper.ReadSetting("公考培训学校地址").Trim();//艺考培训学校地址
        public string Phone1 = "15723197680";
       // public string Phone2 = "18602825088  1";
        protected void Page_Load(object sender, EventArgs e)
        {
            string colsId = Request.QueryString["Id"];//获取二级栏目下的div的id   
            int Id=1;//默认为1
            if (!string.IsNullOrEmpty(colsId))
            {
                Id = Convert.ToInt32(colsId);
            }
            string sql = "select TrainName,TrainCaption,TrainDetail from GWYTrain where TrainId=@Id;";
            DataTable passage = SqlHelper.ExecuteDataTable(sql, new SqlParameter("@Id", Id));
            if (passage != null && passage.Rows.Count > 0) 
            {
                passageName = passage.Rows[0][0].ToString().Trim();
                passageCaption = passage.Rows[0][1].ToString().Trim();
                passageDetail = passage.Rows[0][2].ToString();
            }

            DataTable LinkInfo = SqlHelper.ExecuteDataTable("select top 8 LinkName,LinkString from FriendLink;");
            Links = new Link[LinkInfo.Rows.Count];
            for (int i = 0; i < LinkInfo.Rows.Count; i++)
            {
                Link mylink = new Link();
                mylink.LinkName = LinkInfo.Rows[i]["LinkName"].ToString();
                mylink.LinkString = LinkInfo.Rows[i]["LinkString"].ToString();
                Links[i] = mylink;
            }

            
            Phone1 = CommonHelper.ReadSetting("公务员培训电话").Trim();
        }
    }
}