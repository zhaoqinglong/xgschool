<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="examinationDetails.aspx.cs" Inherits="XGSchool.train.examinationDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="../Skins/CSS/bootstrap.min.css" rel="Stylesheet" />
<link href="../Skins/CSS/Style.css" rel="stylesheet"/>
<script type="text/javascript" src="../Skins/scripts/jquery-1.11.0.min.js"></script>
    <title>试题专区</title>

  <script type="text/javascript">
      function changeColsClass(obj) {
          $(".myactive").removeClass("myactive");
          $("#mynav" + obj + "").addClass("myactive");
      }
      function getQueryString(name) {
          var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
          var r = window.location.search.substr(1).match(reg);
          if (r != null) return unescape(r[2]); return null;
      }
      $(document).ready(function () {
          var o = getQueryString("colsId");
          if (o != null) {
              changeColsClass(o)
          }
      })
    </script>
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
           <li><a id="mynav3" href="advantages.aspx?colsId=3" class="myactive">办学优势</a></li>
           <li><a href="teachers.aspx">权威师资</a></li>   
        </ul>
    </div>
</div>
<div class="columns1">
您现在位置：<span class="myspan"><a href="index.aspx">首页</a></span>/<span class="myspan"><a href="examinationList.aspx?newsBelong=<%=xgnewsDetail.newsBelong %>"><%=xgnewsDetail.newsBelong %></a></span>/<span class="myspan">详细信息</span>
</div>
<div class="course-contain boxborder">
	<div class="course-contain-top">
         <div class="course-contain-title">
        	<span><%=xgnewsDetail.newsBelong %></span>
        </div>
        <div class="course-contain-content">
                <div style="width:100%; height:40px; line-height:40px; text-align:center; font-size:18px;"><%=xgnewsDetail.newsTitle %></div>
                <div style="width:100%; height:40px; line-height:40px; text-align:center;  font-size:14px;">作者：<%=xgnewsDetail.author %> &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                    日期：<%=xgnewsDetail.newDate %></div>
                <div><%=xgnewsDetail.newsContent %></div>
            
        </div>
        </div>
    </div>

</div>
<div class="friendlink">
    <span>友情链接:</span>
    <%for (int i = 0; i < Links.Length; i++){%>
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
