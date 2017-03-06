<%@ Page Title="" Language="C#" MasterPageFile="~/commercial/show.Master" AutoEventWireup="true" CodeBehind="newsDetail.aspx.cs" Inherits="XGSchool.commercial.newsDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="commercialimg boxborder">
<img src="<%=showImgsrc %>" width="1080" height="184" alt="背景图片" />
</div>

<div class="columns1">
您现在位置：<span class="myspan"><a href="#">首页</a></span>/<span class="myspan"><a href="commercialNews.aspx?colsId=7">新革动态</a></span>/<span class="myspan">新革动态详情</span>
</div>

<div class="course-contain boxborder">
	<div class="course-contain-top">
    	<div class="course-contain-title-art" style=" color:#1E577C;background-color:#F7F7F7;">
        	<span>新革动态</span>
        </div>
        <div class="course-contain-content">
            <div class="lesson-content-con">
                <div style="width:100%; height:40px; line-height:40px; text-align:center; font-size:18px;"><%=xgnewsDetail.newsTitle %></div>
                <div style="width:100%; height:40px; line-height:40px; text-align:center;  font-size:14px;">作者：<%=xgnewsDetail.author %> &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                    日期：<%=xgnewsDetail.newDate %></div>
                <div><%=xgnewsDetail.newsContent %></div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
