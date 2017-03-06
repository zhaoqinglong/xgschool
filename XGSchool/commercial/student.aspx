<%@ Page Title="" Language="C#" MasterPageFile="~/commercial/show.Master" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="XGSchool.commercial.student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="commercialimg boxborder">
<img src="<%=showImgsrc %>" width="1080" height="184" alt="背景图片" />
</div>

<div class="columns1">
您现在位置：<span class="myspan"><a href="#">首页</a></span>/<span class="myspan"><a href="#">商演培训</a></span>/<span class="myspan">学员风采</span>
</div>

<div class="course-contain boxborder">
	<div class="course-contain-top">
    	<div class="course-contain-title-art" style=" color:#1E577C;background-color:#F7F7F7;">
        	<span>学员风采</span>
        </div>
        <div class="course-contain-content">
            <%=SchoolColDetail%>
        </div>
    </div>
</div>
</asp:Content>
