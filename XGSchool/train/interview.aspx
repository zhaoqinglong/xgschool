﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="interview.aspx.cs" Inherits="XGSchool.train.interview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=passageName %></title>
    <link href="../Skins/CSS/bootstrap.min.css" rel="stylesheet" type="text/css"/>
    <link href="../Skins/CSS/Style.css" rel="stylesheet" type="text/css"/>
    <script type="text/javascript" src="../Skins/scripts/jquery-1.11.0.min.js"></script>
    <script type="text/javascript">
        function changeClass(obj) {
            $(".newactive").removeClass("newactive");
            $("#mya"+obj+"").addClass("newactive");
        }
        function getQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }
        $(document).ready(function () {
            var o1 = getQueryString("Id");
            if (o1 != null ) {
                changeClass(o1)
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
           <li><a href="interview.aspx" class="myactive">公务员培训</a></li>
           <li><a id="mynav1" href="advantages.aspx?colsId=1">中心介绍</a></li>
           <li><a id="mynav2" href="advantages.aspx?colsId=2">开设课程</a></li>
           <li><a id="mynav3" href="advantages.aspx?colsId=3">办学优势</a></li>
           <li><a href="teachers.aspx">权威师资</a></li> 
        </ul>
    </div>
</div>
<div class="columns1">
您现在位置：<span class="myspan"><a href="#">首页</a></span>/<span class="myspan"><a href="#">公务员培训</a></span>/<span class="myspan"><%=passageName %></span>
</div>
<div class="columns2">
	<div class="columns2-left boxborder myfloat">
    	<div><a href="interview.aspx?Id=2" id="mya2" >行测专区</a></div>
        <div class="border-no"><a href="interview.aspx?Id=3" id="mya3" >申论专区</a></div>
        <div><a href="interview.aspx?Id=1" class="newactive" id="mya1" >面试专区</a></div>
        <div class="border-no"><a href="interview.aspx?Id=4" id="mya4" >银行考试</a></div>
        <div><a href="interview.aspx?Id=5" id="mya5" >公共基础</a></div>
        <div class="border-no"><a href="interview.aspx?Id=24" id="mya24" >考试大纲</a></div>
    </div>
    <div class="columns2-right myfloat boxborder">
    	<div class="content1-title">
        	<span><%=passageName %></span>
        </div>
        <div class="columns2-right-content">
         <p class="passage-title"><%=passageCaption %></p>
         <p class="passage-content"><%=passageDetail %></p>

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
