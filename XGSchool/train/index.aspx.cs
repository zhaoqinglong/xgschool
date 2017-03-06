using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XGSchool.XGModels;
using System.Data;

namespace XGSchool.train
{
    public partial class index : System.Web.UI.Page
    {
        public Link[] Links = { };//友情链接

        public string gkcopyright = CommonHelper.ReadSetting("公考培训版权信息").Trim();
        public string gksiteAds = CommonHelper.ReadSetting("公考培训学校地址").Trim();//艺考培训学校地址

        public string Phone1 = "15723197680";
        public Pic[] pics = { };//轮播图片

        public string ksdg = "3"; //主页电话
        public string mszq = "4"; //艺术考试电话
        public string xczq = "5"; //公务员培训电话
        public string slzq = "6"; //商演培训电话
        public string ggjc = "7"; //商演培训电话
        public string bank = "8"; //商演培训电话

        //新闻列表
        public XGNews[] gwynews = { };//新革公务员公告
        public XGNews[] gkzlnews = { };//公考招录公告
        public XGNews[] testnews = { };//试题专区

        

        //教师图片展示
        public Teacher[] Teachers = { };
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
           
            Phone1 = CommonHelper.ReadSetting("公务员培训电话").Trim();

            //轮播图片
            DataTable PicInfo = SqlHelper.ExecuteDataTable("select imgSrc, imgDescription from imgTable where colsBelong='新革教育首页' and pagesBelong='图片轮播';");
            pics = new Pic[PicInfo.Rows.Count];
            for (int i = 0; i < PicInfo.Rows.Count; i++)
            {
                Pic mypic = new Pic();
                mypic.imgPath = PicInfo.Rows[i]["imgSrc"].ToString().Trim();
                mypic.detail = PicInfo.Rows[i]["imgDescription"].ToString().Trim();
                pics[i] = mypic;
            }

            //读取其余内容
             //ksdg = CommonHelper.ReadSetting("考试大纲").Trim(); //主页电话
             //mszq = CommonHelper.ReadSetting("面试专区").Trim(); //艺术考试电话
             //xczq = CommonHelper.ReadSetting("行测专区").Trim(); //公务员培训电话
             //slzq = CommonHelper.ReadSetting("申论专区").Trim(); //商演培训电话
             //ggjc = CommonHelper.ReadSetting("公共基础知识").Trim(); //商演培训电话
             //bank = CommonHelper.ReadSetting("银行考试").Trim(); //商演培训电话

             //新革公务员公告
             string sql = @" select * from(
                    select newsID, title,author,newsDate, pagesBelong ,row_number() over (order by pagesBelong desc ,newsDate desc ) as num
	                from XGNews where newsBelong='新革公务员公告') as s
                    where s.num between 1 and 3 ;";
             DataTable xgnewsInfo = SqlHelper.ExecuteDataTable(sql);
             gwynews = new XGNews[xgnewsInfo.Rows.Count];

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
                 try
                 {
                     mynews.newDate = DateTime.Parse(xgnewsInfo.Rows[i]["newsDate"].ToString().Trim()).ToString("yyyy-MM-dd");
                 }
                 catch (Exception ex)
                 {
                     mynews.newDate = "";
                 }
                 gwynews[i] = mynews;
             }

            //公考招录
             string gksql = @" select * from(
                    select newsID, title,author,newsDate, pagesBelong ,row_number() over (order by pagesBelong desc ,newsDate desc ) as num
	                from XGNews where newsBelong='公考招录公告') as s
                    where s.num between 1 and 3 ;";
             DataTable xgnewsInfo1 = SqlHelper.ExecuteDataTable(gksql);
             gkzlnews = new XGNews[xgnewsInfo1.Rows.Count];

             for (int i = 0; i < xgnewsInfo1.Rows.Count; i++)
             {
                 string id = xgnewsInfo1.Rows[i]["newsID"].ToString().Trim();
                 string mytitle = xgnewsInfo1.Rows[i]["title"].ToString().Trim();
                 string author = xgnewsInfo1.Rows[i]["author"].ToString().Trim();
                 string newsDate = xgnewsInfo1.Rows[i]["newsDate"].ToString().Trim();
                 XGNews mynews = new XGNews();
                 mynews.newsId = id;
                 mynews.newsTitle = mytitle;
                 mynews.author = author;
                 try
                 {
                     mynews.newDate = DateTime.Parse(xgnewsInfo.Rows[i]["newsDate"].ToString().Trim()).ToString("yyyy-MM-dd");
                 }
                 catch (Exception ex)
                 {
                     mynews.newDate = DateTime.Now.ToString("yyyy-MM-dd");
                 }
                 gkzlnews[i] = mynews;
             }

            //试题专区
             string testsql = @" select * from(
                    select newsID, title,author,newsDate, pagesBelong ,row_number() over (order by pagesBelong desc ,newsDate desc ) as num
	                from XGNews where newsBelong='试题专区') as s
                    where s.num between 1 and 5 ;";
             DataTable xgnewsInfo2 = SqlHelper.ExecuteDataTable(testsql);
             testnews = new XGNews[xgnewsInfo2.Rows.Count];

             for (int i = 0; i < xgnewsInfo2.Rows.Count; i++)
             {
                 string id = xgnewsInfo2.Rows[i]["newsID"].ToString().Trim();
                 string mytitle = xgnewsInfo2.Rows[i]["title"].ToString().Trim();
                 string author = xgnewsInfo2.Rows[i]["author"].ToString().Trim();
                 string newsDate = xgnewsInfo2.Rows[i]["newsDate"].ToString().Trim();
                 XGNews mynews = new XGNews();
                 mynews.newsId = id;
                 mynews.newsTitle = mytitle;
                 mynews.author = author;
                 try
                 {
                     mynews.newDate = DateTime.Parse(xgnewsInfo.Rows[i]["newsDate"].ToString().Trim()).ToString("yyyy-MM-dd");
                 }
                 catch (Exception ex)
                 {
                     mynews.newDate = DateTime.Now.ToString("yyyy-MM-dd");
                 }
                 testnews[i] = mynews;
             }

            //2.行测 3.申论 1.面试 4.银行考试 5.公共基础 24.考试大纲
             string mysql = "select * from GWYTrain where TrainId >=1 and TrainId <=5 or TrainId=24;";
             DataTable passage = SqlHelper.ExecuteDataTable(mysql);
             string[] passageDetail = new String[6];
             //if (passage != null && passage.Rows.Count > 0)
             //{
                 //passageName = passage.Rows[0][0].ToString().Trim();
                 //passageCaption = passage.Rows[0][1].ToString().Trim();
                 for (int i = 0; i < passage.Rows.Count; i++)
                 {
                     passageDetail[i] = passage.Rows[i]["TrainDetail"].ToString().Trim();
                 }


                 //相关项
                 string[] passageDetails = new String[6];
                 for(int i=0;i<passageDetail.Length;i++)
                 {
                     passageDetails[i] = CommonHelper.ParseTags(passageDetail[i]);
                 }
                 ksdg = passageDetails[5].Substring(0, passageDetails[5].Length > 80 ? 80 : passageDetails[5].Length);
                 mszq = passageDetails[0].Substring(0, passageDetails[0].Length > 240 ? 240 : passageDetails[0].Length);
                 xczq = passageDetails[1].Substring(0, passageDetails[1].Length > 150 ? 150 : passageDetails[1].Length);
                 slzq = passageDetails[2].Substring(0, passageDetails[2].Length > 150 ? 150 : passageDetails[2].Length);
                 ggjc = passageDetails[4].Substring(0, passageDetails[4].Length > 150 ? 150 : passageDetails[4].Length);
                 bank = passageDetails[3].Substring(0, passageDetails[3].Length > 150 ? 150 : passageDetails[3].Length);


                 //获取教师信息
                 DataTable teac = SqlHelper.ExecuteDataTable("select top 2 TeacherName,TeacherTitle,TeacherDetail,TeacherImgSrc from XGTeachers where TeacherBelongTo='新革公务员';");
                 Teachers = new Teacher[teac.Rows.Count];
                 for (int i = 0; i < teac.Rows.Count; i++)
                 {
                     Teacher teacher = new Teacher();
                     teacher.TeacherName = teac.Rows[i]["TeacherName"].ToString().Trim();
                     teacher.TeacherTitle = teac.Rows[i]["TeacherTitle"].ToString().Trim();
                     teacher.TeacherDetail = teac.Rows[i]["TeacherDetail"].ToString().Trim();
                     teacher.TeacherImgSrc = teac.Rows[i]["TeacherImgSrc"].ToString().Trim();
                     Teachers[i] = teacher;
                 }
        }
    }
}