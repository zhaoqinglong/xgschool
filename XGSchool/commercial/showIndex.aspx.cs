using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XGSchool.XGModels;
using System.Data;

namespace XGSchool.commercial
{
    public partial class showIndex : System.Web.UI.Page
    {
        
        public Pic[] stupics = { };//学员图片1
        public Pic[] teapics = { };//教师图片
        public Pic[] pics = { };//轮播图片
        public XGNews[] xgnews = { };
        public string about = "1";
     //   public string news = "2";
        public string biandao = "3";
        public string boyin = "4";
        protected void Page_Load(object sender, EventArgs e)
        {
            var about1 = CommonHelper.ReadSetting("商演培训首页学院简介").Trim();
            about = about1.Substring(0, about1.Length > 195 ? 195 : about1.Length);

           // news = CommonHelper.ReadSetting("商演培训首页新闻资讯").Trim();//学校地址

           var  biandao1 = CommonHelper.ReadSetting("商演培训首页课程设置编导类").Trim();
           biandao = biandao1.Substring(0, biandao1.Length > 99 ? 99 : biandao1.Length);
           var boyin1 = CommonHelper.ReadSetting("商演培训首页课程设置播音主持类").Trim();//学校地址
           boyin = boyin1.Substring(0, boyin1.Length > 100 ? 100 : boyin1.Length);
            //轮播图片1
            DataTable PicInfo = SqlHelper.ExecuteDataTable("select imgSrc, imgDescription from imgTable where colsBelong='商演培训首页' and pagesBelong='学员风采图片';");
            stupics = new Pic[PicInfo.Rows.Count];
            for (int i = 0; i < PicInfo.Rows.Count; i++)
            {
                Pic mypic = new Pic();
                mypic.imgPath = PicInfo.Rows[i]["imgSrc"].ToString().Trim();
                mypic.detail = PicInfo.Rows[i]["imgDescription"].ToString().Trim();
                stupics[i] = mypic;
            }

            //轮播图片2
            DataTable PicInfo2 = SqlHelper.ExecuteDataTable("select imgSrc, imgDescription from imgTable where colsBelong='商演培训首页' and pagesBelong='师资力量图片';");
            teapics = new Pic[PicInfo2.Rows.Count];
            for (int i = 0; i < PicInfo2.Rows.Count; i++)
            {
                Pic mypic = new Pic();
                mypic.imgPath = PicInfo2.Rows[i]["imgSrc"].ToString().Trim();
                mypic.detail = PicInfo2.Rows[i]["imgDescription"].ToString().Trim();
                teapics[i] = mypic;
            }

            //轮播图片3
            DataTable PicInfo3 = SqlHelper.ExecuteDataTable("select imgSrc, imgDescription from imgTable where colsBelong='商演培训首页' and pagesBelong='商演培训顶部';");
            pics = new Pic[PicInfo3.Rows.Count];
            for (int i = 0; i < PicInfo3.Rows.Count; i++)
            {
                Pic mypic = new Pic();
                mypic.imgPath = PicInfo3.Rows[i]["imgSrc"].ToString().Trim();
                mypic.detail = PicInfo3.Rows[i]["imgDescription"].ToString().Trim();
                pics[i] = mypic;
            }

            //新闻列表
            string sql = @" select * from(
                    select newsID, title,author,newsDate, pagesBelong ,row_number() over (order by pagesBelong desc ,newsDate desc ) as num
	                from XGNews where newsBelong='新革商演培训') as s
                    where s.num between 1 and 7;";
            DataTable xgnewsInfo = SqlHelper.ExecuteDataTable(sql);
            xgnews = new XGNews[xgnewsInfo.Rows.Count];

            for (int i = 0; i < xgnewsInfo.Rows.Count; i++)
            {
                string id = xgnewsInfo.Rows[i]["newsID"].ToString().Trim();
                string mytitle = xgnewsInfo.Rows[i]["title"].ToString().Trim();
                string author = xgnewsInfo.Rows[i]["author"].ToString().Trim();
                string newsDate = xgnewsInfo.Rows[i]["newsDate"].ToString().Trim();
                XGNews mynews = new XGNews();
                mynews.newsId = id;
                mynews.newsTitle = mytitle;
                mynews.author = author;
                //  mynews.newDate = newsDate;
                try
                {
                    mynews.newDate = DateTime.Parse(xgnewsInfo.Rows[i]["newsDate"].ToString().Trim()).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {
                    mynews.newDate = "";
                }
                xgnews[i] = mynews;
            }
        }
    }
}