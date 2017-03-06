using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XGSchool.commercial
{
    
    public partial class showClasses : System.Web.UI.Page
    {
        protected string showImgsrc = CommonHelper.ReadSetting("商演培训顶部背景图片").Trim();
        public string[] imgSrc={ };//保存图片路径的数组,空数组
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable imgInfo = SqlHelper.ExecuteDataTable("select  imgSrc from imgTable  where colsBelong='新革商演培训' and pagesBelong='课堂瞬间';");
            //对imgsrc数组赋值
            imgSrc = new string[imgInfo.Rows.Count];
            for (int i = 0; i < imgInfo.Rows.Count; i++)
            {
                string mylink;
                mylink = imgInfo.Rows[i]["imgSrc"].ToString().Trim();
                imgSrc[i] = mylink;
            }
        }
    }
}