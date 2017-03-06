using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using XGSchool.XGModels;

namespace XGSchool
{
    public partial class index : System.Web.UI.Page
    {
        public string email = "huang.suo@qq.com";
        public string phone = "18602825088";
        public string msg = "在中国";
        public Pic[] pics = { };
        public string copyright = CommonHelper.ReadSetting("版权信息").Trim();
        protected void Page_Load(object sender, EventArgs e)
        {
            email = CommonHelper.ReadSetting("主页邮箱").Trim();
            phone = CommonHelper.ReadSetting("主页电话").Trim();
            msg = CommonHelper.ReadSetting("首页文字").Trim();

            DataTable imgInfo = SqlHelper.ExecuteDataTable("select top 3 imgSrc,imgDescription from imgTable where colsBelong='网站首页' and pagesBelong='网站首页';");
            //对imgsrc数组赋值
            pics = new Pic[imgInfo.Rows.Count];
            for (int i = 0; i < imgInfo.Rows.Count; i++)
            {
                //string mylink;
                //mylink = imgInfo.Rows[i]["imgSrc"].ToString().Trim();
                //imgSrc[i] = mylink;

                Pic mypic=new Pic();
                mypic.imgPath = imgInfo.Rows[i]["imgSrc"].ToString().Trim();
                mypic.detail = imgInfo.Rows[i]["imgDescription"].ToString().Trim();
                pics[i] = mypic;
            }
        }
    }
}