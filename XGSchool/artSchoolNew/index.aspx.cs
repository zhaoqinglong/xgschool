using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using XGSchool.XGModels;

namespace XGSchool.artSchoolNew
{
    public partial class index : System.Web.UI.Page
    {
        public string[] imgSrc = { };//保存顶部图片路径的数组,空数组,
        public string[] teaimgSrc = { };//保存优秀教师图片路径的数组,空数组,
        public string[] resultimgSrc = { };//保存优秀教师图片路径的数组,空数组,
        public XGNews[] xgnews = { };
        public string aboutImgsrc = "../Skins/artimages/school.png";
        public string aboutXG = "";
        public string biandao = "";
        public string boyin = "";
        public string show = "";
        public string other = "";

        public string biandaoimg = "../Skins/artimages/class_001.png";
        public string boyinimg = "../Skins/artimages/class_002.png";
        public string showimg = "../Skins/artimages/class_003.png";
        public string otherimg = "../Skins/artimages/class_004.png";

        public string videoURL = "";
        protected void Page_Load(object sender, EventArgs e)
        {
              biandaoimg = CommonHelper.ReadSetting("艺术首页编导类").Trim();
              boyinimg = CommonHelper.ReadSetting("艺术首页播音类").Trim();
              showimg = CommonHelper.ReadSetting("艺术首页表演类").Trim();
              otherimg = CommonHelper.ReadSetting("艺术首页其它类").Trim();

            DataTable imgInfo = SqlHelper.ExecuteDataTable("select  imgSrc from imgTable where colsBelong='艺术考试' and pagesBelong='首页';");
            //对imgsrc数组赋值
            imgSrc = new string[imgInfo.Rows.Count];
            for (int i = 0; i < imgInfo.Rows.Count; i++)
            {
                string mylink= imgInfo.Rows[i]["imgSrc"].ToString().Trim();
                imgSrc[i] = mylink;
            }

            //优秀教师图片
            DataTable teaimgInfo = SqlHelper.ExecuteDataTable("select top 2 imgSrc from imgTable where colsBelong='艺术考试' and pagesBelong='首页优秀教师';");
            //对imgsrc数组赋值
            teaimgSrc = new string[teaimgInfo.Rows.Count];
            for (int i = 0; i < teaimgInfo.Rows.Count; i++)
            {
                string mylink = teaimgInfo.Rows[i]["imgSrc"].ToString().Trim();
                teaimgSrc[i] = mylink;
            }

            //教学成果图片
            DataTable resimgInfo = SqlHelper.ExecuteDataTable("select  imgSrc from imgTable where colsBelong='艺术考试' and pagesBelong='首页教学成果';");
            //对imgsrc数组赋值
            resultimgSrc = new string[resimgInfo.Rows.Count];
            for (int i = 0; i < resimgInfo.Rows.Count; i++)
            {
                string mylink = resimgInfo.Rows[i]["imgSrc"].ToString().Trim();
                resultimgSrc[i] = mylink;
            }

            //新革动态
            DataTable xgnewsInfo = SqlHelper.ExecuteDataTable(@"select * from(
                    select newsID, title,author,newsDate, pagesBelong ,newsImage , row_number() over (order by pagesBelong desc ,newsDate desc ) as num
	                from XGNews where newsBelong='新革艺术学校') as s
                    where s.num between 1 and 4 ;");
            xgnews = new XGNews[xgnewsInfo.Rows.Count];
           
            for (int i = 0; i < xgnewsInfo.Rows.Count; i++)
            {
                string mytitle = xgnewsInfo.Rows[i]["title"].ToString().Trim();
                string myimage = xgnewsInfo.Rows[i]["newsImage"].ToString().Trim();
                string id = xgnewsInfo.Rows[i]["newsID"].ToString().Trim();

                XGNews mynews = new XGNews();
                mynews.newsTitle = mytitle;
                mynews.newsImage = myimage;
                mynews.newsId = id;
                xgnews[i] = mynews;
            }
            aboutImgsrc = CommonHelper.ReadSetting("艺术首页新革简介图片").Trim();
           var  aboutXG1 = CommonHelper.ReadSetting("艺术首页新革简介").Trim();
           // //强制显示140个字符
            aboutXG = aboutXG1.Substring(0, aboutXG1.Length > 145 ? 145 : aboutXG1.Length);
           //var biandao1 = CommonHelper.ReadSetting("艺术首页编导类").Trim();
           // biandao = biandao1.Substring(0, biandao1.Length > 43 ? 43 : biandao1.Length);
           //var boyin1 = CommonHelper.ReadSetting("艺术首页播音类").Trim();
           // boyin = boyin1.Substring(0, boyin1.Length > 43 ? 43 : boyin1.Length);
           //var show1 = CommonHelper.ReadSetting("艺术首页表演类").Trim();
           // show = show1.Substring(0, show1.Length > 43 ? 43 : show1.Length);
           //var other1 = CommonHelper.ReadSetting("艺术首页其它类").Trim();
           // other = other1.Substring(0, other1.Length > 43 ? 43 : other1.Length);
            videoURL = CommonHelper.ReadSetting("视频地址").Trim();

            //string aboutXG1="新革简介";
            //string sql1 = "select SchoolColDetail from XGSchoolCols where SchoolColId=13;";
            //DataTable passage1 = SqlHelper.ExecuteDataTable(sql1);
            //if (passage1 != null && passage1.Rows.Count > 0)
            //{
            //    aboutXG1 =CommonHelper.ParseTags( passage1.Rows[0][0].ToString() );
            //}
            //aboutXG = aboutXG1.Substring(0, aboutXG1.Length > 145 ? 145 : aboutXG1.Length);

             string lesson1 = "编导类";
             string lesson2 = "播音类";
             string lesson3 = "表演类";
             string lesson4 = "美术类";      

            string sql = "select TrainDetail from GWYTrain where TrainId=17 or TrainId=18 or TrainId=19 or TrainId=20 ";
            DataTable passage = SqlHelper.ExecuteDataTable(sql);
            if (passage != null && passage.Rows.Count > 0)
            {
                lesson1 = CommonHelper.ParseTags( passage.Rows[0][0].ToString().Trim() );
                lesson2 = CommonHelper.ParseTags( passage.Rows[1][0].ToString().Trim() );
                lesson3 = CommonHelper.ParseTags( passage.Rows[2][0].ToString().Trim() );
                lesson4 = CommonHelper.ParseTags( passage.Rows[3][0].ToString().Trim() );                
            }

            biandao = lesson1.Substring(0, lesson1.Length > 42 ? 42 : lesson1.Length);
            boyin = lesson2.Substring(0, lesson2.Length > 43 ? 43 : lesson2.Length);
            show = lesson3.Substring(0, lesson3.Length > 43 ? 43 : lesson3.Length);
            other = lesson4.Substring(0, lesson4.Length > 43 ? 43 : lesson4.Length);
        }
    }
}