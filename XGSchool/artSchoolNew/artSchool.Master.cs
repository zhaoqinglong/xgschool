using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XGSchool.XGModels;
using System.Data;

namespace XGSchool.artSchoolNew
{
    public partial class artSchool : System.Web.UI.MasterPage
    {
        public Link[] Links = { };//超链接数组
        public string Address = "渝中区上清寺";
        public string artPhone = "15723197680";
        public string topPhone = "023-87635498";
        public string artcopyright = CommonHelper.ReadSetting("艺考培训版权信息").Trim();
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取超级链接的内容
            DataTable LinkInfo = SqlHelper.ExecuteDataTable("select top 8 LinkName,LinkString from FriendLink;");
            Links = new Link[LinkInfo.Rows.Count];
            for (int i = 0; i < LinkInfo.Rows.Count; i++)
            {
                Link mylink = new Link();
                mylink.LinkName = LinkInfo.Rows[i]["LinkName"].ToString();
                mylink.LinkString = LinkInfo.Rows[i]["LinkString"].ToString();
                Links[i] = mylink;
            }

            Address = CommonHelper.ReadSetting("艺考培训学校地址").Trim();
            artPhone = CommonHelper.ReadSetting("艺术考试电话").Trim();
            topPhone = CommonHelper.ReadSetting("新革艺术学校首页顶部电话").Trim();

        }
    }
}