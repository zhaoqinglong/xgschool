using System;
using System.Data;
using XGSchool.XGModels;

namespace XGSchool.commercial
{
    public partial class show : System.Web.UI.MasterPage
    {
        public Link[] Links = { };//超链接数组
        public string Phone1 = "15723197680  2";
        public string showsiteAds = CommonHelper.ReadSetting("商演培训学校地址").Trim();
        public string showcopyright = CommonHelper.ReadSetting("商演培训版权信息").Trim();
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取友情链接的内容
            DataTable LinkInfo = SqlHelper.ExecuteDataTable("select top 8 LinkName,LinkString from FriendLink;");
            Links = new Link[LinkInfo.Rows.Count];
            for (int i = 0; i < LinkInfo.Rows.Count; i++)
            {
                Link mylink = new Link();
                mylink.LinkName = LinkInfo.Rows[i]["LinkName"].ToString();
                mylink.LinkString = LinkInfo.Rows[i]["LinkString"].ToString();
                Links[i] = mylink;
            }

            Phone1 = CommonHelper.ReadSetting("商演培训电话").Trim();
        }
    }
}