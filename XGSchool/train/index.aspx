<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="XGSchool.train.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="../Skins/CSS/bootstrap.min.css" type="text/css" rel="Stylesheet"/>
<link href="../Skins/CSS/Style.css" rel="Stylesheet" type="text/css" />
<script type="text/javascript" src="../Skins/scripts/jquery-1.11.0.min.js"></script>
<script type="text/javascript" src="../Skins/scripts/jquery.KinSlideshow-1.2.1.js"></script>
    <title>主页</title>
    <script type="text/javascript">
        $(function () {
            $("#KinSlideshow").KinSlideshow({
                moveStyle: "down"
            });
        })

        function setTab(m, n) {
            var menu = document.getElementById("tab" + m).getElementsByTagName("li");
            var showdiv = document.getElementById("tablist" + m).getElementsByTagName("div");
            for (i = 0; i < menu.length; i++) {
                menu[i].className = i == n ? "now" : "";
                showdiv[i].style.display = i == n ? "block" : "none";
            }
        }
</script>
</head>
<body>
<div id="container">
<div class="top">
<a href="../index.aspx" style=" cursor:pointer;">
    <div class="top-title">   
        <div class="top-title-top">新革教育</div>
        <div class="top-title-bottom">新革公考命题研究中心</div>
    </div>
 </a>
    <div class="top-nav">
        <ul class="mynav">
           <li><a href="index.aspx" class="myactive">首页</a></li>
           <li><a href="interview.aspx">公务员培训</a></li>
           <li><a id="mynav1" href="advantages.aspx?colsId=1">中心介绍</a></li>
           <li><a id="mynav2" href="advantages.aspx?colsId=2">开设课程</a></li>
           <li><a id="mynav3" href="advantages.aspx?colsId=3">办学优势</a></li>
           <li><a href="teachers.aspx">权威师资</a></li> 
        </ul>
    </div>
</div>
<div class="clear"></div>
<div class="content1 ">
    <div class="content1-left myfloat boxborder">
    	<div class="content1-title">
        	<span>办学优势</span>
        	<span style=" font-size:14px; padding-left:45%;">
            	<a href="advantages.aspx?colsId=3" style="text-decoration:underline; color:#FFF;" >更多</a>
            </span>
        </div>
        <div style=" padding: 10px 13px;">
        <p class="p-title">行测</p>
        <p style=" ">行测考题研究专家，系统讲授相关知识点，强化做题技巧；提升应试能力。</p>
        <p class="p-title">封闭式训练</p>
        <p>全真模拟考试场景提升，提升应考信心。</p>
        <p class="p-title">严格采用小班制</p>
        <p>确保考题专家单独指导。</p>
        <p class="p-title">面试培训采用全方位培训</p>
        <p>练口才，练反应，塑形象，提气质，针对每个考试单独指导。</p>
        </div>
    </div>
    <div class="content1-middle myfloat">
        <div id="KinSlideshow" style="visibility:hidden;">
        <%for (int i = 0; i < pics.Length; i++)
          {%>
            <a href="#" target="_blank">
                <img src="<%=pics[i].imgPath %>" alt="<%=pics[i].detail %>" width="580" height="316" />
            </a>
        <%} %>
    	</div>
    </div>
    <div class="content1-right myfloat boxborder">
        <div class="content1-title">
        	<span>最新开设课程</span>
        	<span style=" font-size:14px; padding-left:30px;"><a href="advantages.aspx?colsId=2" style="text-decoration:underline; color:#FFF;" >查看全部</a></span>
        </div>
        <div style="height:43px; line-height:43px; font-size:15px; padding-left:10px; border-left:none; border-right:none;" class="boxborder"> 
        <img src="../Skins/images/pencil.gif" alt="笔试课程"/>笔试课程
        </div>
        <div>
        	<p class="p-pag">精品班（推荐）</p>
            <p class="p-pag">封闭精品班</p>
            <p class="p-pag">联报班（推荐）</p>
            <p class="p-pag">行测专项班</p>
            <p class="p-pag">申论专项班</p>
        </div>
        <div style="height:43px; line-height:43px; font-size:15px; padding-left:10px; border-left:none; border-right:none;" class="boxborder"> 
        <img src="../Skins/images/contact.gif" alt="面试课程"/>面试课程
        </div>
        <div>
        	<p class="p-pag">面试实战特训班</p>
            <p class="p-pag">VIP一对一课程</p>
        </div>
    </div>
</div>
<div class="content2">
	 <div class="content1-left myfloat boxborder">
    	<div class="content1-title">
        	<span>新革师资</span>
        	<span style=" font-size:14px; padding-left:45%;"><a href="teachers.aspx" style="text-decoration:underline; color:#FFF;" >更多</a></span>
        </div>
        <div style=" padding: 10px 13px; border-bottom:#CCC dashed 1px;" >
        	<img src="<%=Teachers[0].TeacherImgSrc %>" width="176px" height="90px;" alt="主讲教师"/>
            <p style=" text-align:center; margin-bottom:3px;"> <%=Teachers[0].TeacherName%></p>
            <p style=" text-align:center;"><%=Teachers[0].TeacherTitle %></p>
        </div>
        <div style=" padding: 10px 13px;">
        	<img src="<%=Teachers[1].TeacherImgSrc %>" width="176px" height="90px;" alt="主讲教师"/>
            <p style=" text-align:center; margin-bottom:3px;"><%=Teachers[1].TeacherName%></p>
            <p style=" text-align:center;"> <%=Teachers[1].TeacherTitle %></p>
        </div>
    </div>
     <div class="content1-middle myfloat">
         <div  style="height:145px;" class="boxborder">
          	<div id="tab1">
                <ul>
                   <li onclick="setTab(1,0)" class="now">新革公务员公告</li>
                   <li onclick="setTab(1,1)">公考招录公告</li>
                </ul>
			</div>
            <div id="tablist1">
                <div class="tablist block">
                    <table>
                       <%for (int i = 0; i < gwynews.Length; i++)
                       { %>
                          <tr>
          	                <td  class="td-left" style="width:440px; padding-left:0px;">
                                  <a href="examinationDetails.aspx?newsID=<%=gwynews[i].newsId %>">
                                  <%=gwynews[i].newsTitle %></a>

          	                </td>
                              <td><%=gwynews[i].newDate %></td>
                          </tr>
                      <%} %>
                    </table>
                    <span><a href="examinationList.aspx?newsBelong=新革公务员公告" class="more"  style="padding-left:85%;">[更多]</a></span>

                </div>
                <div class="tablist">
                     <table>
                       <%for (int i = 0; i < gkzlnews.Length; i++)
                       { %>
                          <tr>
          	                <td  class="td-left" style="width:440px; padding-left:0px;">
                                  <a href="examinationDetails.aspx?newsID=<%=gkzlnews[i].newsId %>">
                                  <%=gkzlnews[i].newsTitle %></a>

          	                </td>
                              <td><%=gkzlnews[i].newDate %></td>
                          </tr>
                      <%} %>
                    </table>
                    <span><a href="examinationList.aspx?newsBelong=公考招录公告" class="more" style="padding-left:85%;">[更多]</a></span></div>
            </div>
         </div>
         <div  style=" height:180px; margin-top:13px;" class="boxborder">
            <div class="content1-title">
        		<span>面试专区</span>
        	</div>
            <div>
　　<p  class="p-content" style="margin-top:0px;"><%=mszq%>...<a href="interview.aspx" class="more" >[更多]</a></p>
            </div>
     	</div>
	</div>
    <div class="content1-right myfloat">
         <div  style="height:145px;" class="boxborder">
            <div class="content1-title">
                <span>考试大纲</span>
            </div>
            <div>
            <p class="p-content"><%=ksdg%>...<a href="interview.aspx?Id=24" class="more" >[更多]</a></p>
            </div>
         </div>
        <div  style=" height:180px; margin-top:13px;" class="boxborder">
        	 <div class="content1-title">
                <span>试题专区</span>
                 <a href="examinationList.aspx?newsBelong=试题专区" style="text-decoration:underline; color:#FFF; padding-left:110px;" >更多</a>
            </div>
            <div class="content2-right-content">
<%--            	<ul>
                    <%for (int i = 0; i < testnews.Length;i++ ){ %>
               		<li><a href="examinationDetails.aspx?newsID=<%=testnews[i].newsId %>"><%=testnews[i].newsTitle %></a></li>
                    <%} %>                
                </ul>--%>
                <table>
                    <%for (int i = 0; i < testnews.Length;i++ ){ %>
                    <tr>
                        <td  class="td-left" style="width:220px; padding-left:20px; height:25px; line-height:25px;">
                            <a href="examinationDetails.aspx?newsID=<%=testnews[i].newsId %>"><%=testnews[i].newsTitle %></a>

                        </td>

                    </tr>
                     <%} %>       
                </table>
            </div>
        </div>
    </div>
</div>
<div class=" clear"></div>
<div class="content3"></div>
<div class="content4">
	<div style="width:523px; margin-right:15px;" class="boxborder myfloat">
    	<div class="content1-title">
        	<span>行测专区</span>
        </div>
        <div style="min-height:90px;">
            <p class="p-content1"><%=xczq%>...<a href="interview.aspx?Id=2" class="more" >[更多]</a></p>
         </div>
    </div>
    <div style="width:523px;" class="boxborder myfloat">
    	<div class="content1-title">
        	<span>申论专区</span>
        </div>
        <div style="min-height:90px;">
            <p class="p-content1"><%=slzq %>...<a href="interview.aspx?Id=3" class="more" >[更多]</a></p>
         </div>
    </div>
</div>
<div class="content4">
	<div style="width:523px; margin-right:15px;" class="boxborder myfloat">
    	<div class="content1-title">
        	<span>公共基础知识</span>
        </div>
        <div style="min-height:90px;">
            <p class="p-content1"><%=ggjc %>...<a href="interview.aspx?Id=5" class="more" >[更多]</a></p>
         </div>
    </div>
    <div style="width:523px;" class="boxborder myfloat">
    	<div class="content1-title">
        	<span>银行考试</span>
        </div>
        <div style="min-height:90px;">
            <p class="p-content1"><%=bank %>...<a href="interview.aspx?Id=4" class="more" >[更多]</a></p>
         </div>
    </div>
</div>
<div class="friendlink">
<span>友情链接:</span>
    <%for (int i = 0; i < Links.Length; i++)
      {%>
      <span><a href="<%=Links[i].LinkString%>"><%=Links[i].LinkName%></a></span>
     <% } %>
</div>
<div class="copyright">
    <span class="copyright1"><%=gkcopyright %></span>
    <span class="copyright2">地址：<%=gksiteAds %></span>
    <span class="copyright3">咨询热线：<%=Phone1 %> &nbsp;</span>
</div>

</div>
</body>
</html>
