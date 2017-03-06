<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="examinationList.aspx.cs" Inherits="XGSchool.train.examinationList" %>


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
您现在位置：<span class="myspan"><a href="index.aspx">首页</a></span>/<span class="myspan"><%=newsBelong %>列表</span>
  <%--  /<span class="myspan">相关列表</span>--%>
</div>
<div class="course-contain boxborder">
	<div class="course-contain-top">
         <div class="course-contain-title">
        	<span><%=newsBelong %></span>
        </div>
        <div class="course-contain-content">
            <div style="height:auto; min-height:400px;">
           <table style="margin-left:200px;">
             <%for (int i = 0; i < xgnews.Length; i++)
               { %>
          <tr style=" height:40px; font-size:15px;">
          	  <td  class="td-left-news" style=""><a href="examinationDetails.aspx?newsID=<%=xgnews[i].newsId %>" style="font-size:15px;"><%=xgnews[i].newsTitle%></a> </td>
             <td class="td-left-date"><%=xgnews[i].newDate %></td>
     <%--          <td class="td-left-author">作者：<%=xgnews[i].author %></td>--%>
          </tr>
             <%} %>
<%--             <tr ><td  class=""></td>
              <td class="td-left-date"></td>
              <td class="td-left-author" style="color:#0094ff;">共<%=total %>条/<%=pageCount %>页，每页显示5条</tr>--%>
          </table>
            </div>
            <div style=" height:10px; width:800px; text-align:right;" class=" myfloat" ></div>
                    <ul class="pagination">
                      <li><a href="?pageNum=1&newsBelong=<%=newsBelong %>">&laquo;</a></li>
                                 <%for (int i = 1; i <= pageCount; i++)
                                  {%>
                                    <li><a href="?pageNum=<%=i %>&newsBelong=<%=newsBelong %>"><%=i %></a></li>
                                 <%} %>
                      <li><a href="?pageNum=<%=pageCount %>&newsBelong=<%=newsBelong %>">&raquo;</a></li>
                    </ul>
        
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
