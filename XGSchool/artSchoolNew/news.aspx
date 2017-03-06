<%@ Page Title="" Language="C#" MasterPageFile="~/artSchoolNew/artSchool.Master" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="XGSchool.artSchoolNew.news" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../Skins/CSS/bootstrap.min.css" rel="Stylesheet" type="text/css" />
<style type="text/css">
a:hover{ color:#5F5CCB;}
#nav7{ background:url(../Skins/artimages/nav_07_current.png) no-repeat;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="lesson-content "><!--start of lesson-content-->
        	<div class="lesson-content-title">新革动态</div>
            <div class="lesson-content-con">
                <div style="height:auto; min-height:430px;">
            <%for (int i = 0; i < xgnews.Length; i++)
              {%>
                <div class="content2-con2-content" >
                    <div class="content2-con2-img" ><img src="<%=xgnews[i].newsImage %>" alt="教师图像" width="75" height="75" /></div>
                    <a href="newsDetail.aspx?newsID=<%=xgnews[i].newsId %>">
                    <div class="content2-con2-tit" ><%=xgnews[i].newsTitle%></div>
                    </a>
                </div>
              <%} %>  
                    </div>
<%--                    <div class=" myfloat newBorder" style=" height:50px; line-height:50px; font-size:15px; width:200px;">共<%=total %>条/<%=pageCount %>页</div>--%>
                    <div style=" height:30px; width:680px;" class=" myfloat" ></div>
                    <ul class="pagination">
                      <li><a href="news.aspx?pageNum=1">&laquo;</a></li>
                                 <%for (int i = 1; i <= pageCount; i++)
                                  {%>
                                    <li><a href="news.aspx?pageNum=<%=i %>"><%=i %></a></li>
                                 <%} %>
                      <li><a href="news.aspx?pageNum=<%=pageCount %>">&raquo;</a></li>
                    </ul>

            </div>
        </div>
</asp:Content>
