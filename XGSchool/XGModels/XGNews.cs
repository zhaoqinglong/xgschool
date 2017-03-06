using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XGSchool.XGModels
{
    public class XGNews
    {
        public string newsId { set; get; }
        public string newsTitle { set; get; }
        public string newsImage { set; get; }
        public string newsContent { set; get; }
        public string author { set; get; }
        public string newDate { set; get; }
        //所属板块
        public string newsBelong { set; get; }
    }
}