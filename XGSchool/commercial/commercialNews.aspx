<%@ Page Title="" Language="C#" MasterPageFile="~/commercial/show.Master" AutoEventWireup="true" CodeBehind="commercialNews.aspx.cs" Inherits="XGSchool.commercial.commercialNews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="commercialimg boxborder">
<img src="<%=showImgsrc %>" width="1080" height="184" alt="背景图片" />
</div>

<div class="columns1">
您现在位置：<span class="myspan"><a href="#">首页</a></span>/<span class="myspan"><a href="#">商演培训</a></span>/<span class="myspan">新革动态</span>
</div>

<div class="course-contain boxborder">
	<div class="course-contain-top">
    	<div class="course-contain-title-art" style=" color:#1E577C;background-color:#F7F7F7;">
        	<span>新革动态</span>
        </div>
        <div class="course-contain-content">
            <div style="height:auto; min-height:400px;">
         <table style="margin-left:200px;">
             <%for (int i = 0; i < xgnews.Length; i++)
               { %>
          <tr style=" height:40px; font-size:15px;">
          	  <td  class="td-left-news"><a href="newsDetail.aspx?colsId=7&newsID=<%=xgnews[i].newsId %>" style="font-size:15px;"><%=xgnews[i].newsTitle%></a> </td>
              <td class="td-left-date"><%=xgnews[i].newDate %></td>
             <%-- <td class="td-left-author"><%=xgnews[i].author %></td>--%>
          </tr>
             <%} %>
<%--             <tr ><td  class=""></td>
              <td class="td-left-date"></td>
              <td class="td-left-author" style="color:#0094ff;">共<%=total %>条/<%=pageCount %>页，每页显示5条</tr>--%>
          </table>
                </div>
            <div style=" height:10px; width:750px; text-align:right;" class=" myfloat" ></div>
                    <ul class="pagination">
                      <li><a href="commercialNews.aspx?colsId=7&pageNum=1">&laquo;</a></li>
                                 <%for (int i = 1; i <= pageCount; i++)
                                  {%>
                                    <li><a href="commercialNews.aspx?colsId=7&pageNum=<%=i %>"><%=i %></a></li>
                                 <%} %>
                      <li><a href="commercialNews.aspx?colsId=7&pageNum=<%=pageCount %>">&raquo;</a></li>
                    </ul>
        </div>
    </div>
</div>
</asp:Content>
