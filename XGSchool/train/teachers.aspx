<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teachers.aspx.cs" Inherits="XGSchool.train.teachers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="Stylesheet" href="../Skins/CSS/bootstrap.min.css" />
<link rel="Stylesheet" href="../Skins/CSS/Style.css" />
    <title>权威师资</title>
</head>
<body>
<div id="container">
<div class="top">
    <a href="../index.aspx" style=" cursor:pointer;">
    <div class="top-title">   
        <div class="top-title-top1">新革公务员</div>
        <div class="top-title-bottom">新革教育考试命题研究中心</div>
    </div>
        </a>
    <div class="top-nav">
        <ul class="mynav">
           <li><a href="index.aspx">首页</a></li>
           <li><a href="interview.aspx">公务员培训</a></li>
           <li><a id="mynav1" href="advantages.aspx?colsId=1">中心介绍</a></li>
           <li><a id="mynav2" href="advantages.aspx?colsId=2">开设课程</a></li>
           <li><a id="mynav3" href="advantages.aspx?colsId=3">办学优势</a></li>
           <li><a href="teachers.aspx" class="myactive">权威师资</a></li> 
        </ul>
    </div>
</div>
<div class="columns1">
您现在位置：<span class="myspan"><a href="#">首页</a></span>/<span class="myspan"><a href="#">公务员培训</a></span>/<span class="myspan">权威师资</span>
</div>
<div class="course-contain boxborder" >
      <div class="course-contain-title">
          <span>权威师资</span>
      </div>
      <div class="course-contain-main" >
      <% for (int i = 0; i < Teachers.Length; i++){%>
          <div class="course-contain-left-train " >
              <img src="<%=Teachers[i].TeacherImgSrc %>" width="370" height="288"alt="<%=Teachers[i].TeacherName %>" style="display:block;float:left; margin-right:30px;"/>
              <div>
                   <div class="teacher-name-train "><%=Teachers[i].TeacherName %></div>
                  <div class="teacher-title-train"><%=Teachers[i].TeacherTitle %></div>
                  <div class="teacher-details-train"><%=Teachers[i].TeacherDetail %></div>
               </div>
          </div>          

       <% } %><div class="clearfix"></div>
      </div>
</div>
<div class="friendlink">
	<span>友情链接:</span>
    <%for (int i = 0; i < Links.Length; i++){%>
      <span><a href="<%=Links[i].LinkString%>" target="_blank"><%=Links[i].LinkName%></a></span>
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
