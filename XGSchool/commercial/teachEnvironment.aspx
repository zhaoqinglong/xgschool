<%@ Page Title="" Language="C#" MasterPageFile="~/commercial/show.Master" AutoEventWireup="true" CodeBehind="teachEnvironment.aspx.cs" Inherits="XGSchool.commercial.teachEnvironment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="commercialimg boxborder">
<img src="<%=showImgsrc %>" width="1080" height="184" alt="背景图片" />
</div>

<div class="columns1">
您现在位置：<span class="myspan"><a href="#">首页</a></span>/<span class="myspan"><a href="#">商演培训</a></span>/<span class="myspan">教学环境</span>
</div>
<div class="columns2">
	<div class="columns2-left-art boxborder myfloat">
    	<div class=""><a href="commercialShow.aspx?colsId=2" >学院简介</a></div>
        <div class="border-no"><a href="teachEnvironment.aspx?colsId=6" class="newactive-show">教学环境</a></div>
        <div><a href="teacherPower.aspx?colsId=6">师资力量</a></div>
        <div class="border-no"><a href="classes.aspx?colsId=6">课程设置</a></div>
    </div>
    <div class="columns2-right myfloat boxborder">
    	<div class="content1-title-show">
        	<span>教学环境</span>
        </div>
        <div class="columns2-right-content">
        <%=passageDetail %>
        </div>
    </div>
</div>

</asp:Content>
