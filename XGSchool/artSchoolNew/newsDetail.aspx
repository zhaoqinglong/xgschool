<%@ Page Title="" Language="C#" MasterPageFile="~/artSchoolNew/artSchool.Master" AutoEventWireup="true" CodeBehind="newsDetail.aspx.cs" Inherits="XGSchool.artSchoolNew.newsDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
#nav7{ background:url(../Skins/artimages/nav_07_current.png) no-repeat;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="lesson-content "><!--start of lesson-content-->
        	<div class="lesson-content-title">新革动态</div>
                            <div class="columns1">
                您现在位置：<span class="myspan"><a href="index.aspx">首页</a></span>/
                    <span class="myspan"><a href="news.aspx">新革动态列表</a></span>/<span class="myspan">详细信息</span>
                </div>  
            <div class="lesson-content-con">
              
                <div style="width:100%; height:40px; line-height:40px; text-align:center; font-size:18px; overflow:hidden;"><%=xgnewsDetail.newsTitle %></div>
                <div style="width:100%; height:40px; line-height:40px; text-align:center;  font-size:14px;">作者：<%=xgnewsDetail.author %> &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                    日期：<%=xgnewsDetail.newDate %></div>
                <div style="width:100%; height:auto; min-height:450px;"><%=xgnewsDetail.newsContent %></div>
            </div>
        </div>
</asp:Content>
