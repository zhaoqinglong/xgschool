using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XGSchool.commercial
{
    
    public partial class xgabout : System.Web.UI.Page
    {
        protected string showImgsrc = CommonHelper.ReadSetting("商演培训顶部背景图片").Trim();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}