<%@ Page Title="" Language="C#" MasterPageFile="~/commercial/show.Master" AutoEventWireup="true" CodeBehind="teacherPower.aspx.cs" Inherits="XGSchool.commercial.teacherPower" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="commercialimg boxborder">
<img src="<%=showImgsrc %>" width="1080" height="184" alt="背景图片" />
</div>

<div class="columns1">
您现在位置：<span class="myspan"><a href="#">首页</a></span>/<span class="myspan"><a href="#">商演培训</a></span>/<span class="myspan">师资力量</span>
</div>
<div class="columns2">
	<div class="columns2-left-art boxborder myfloat">
    	<div class=""><a href="commercialShow.aspx?colsId=2">学院简介</a></div>
        <div class="border-no"><a href="teachEnvironment.aspx?colsId=6">教学环境</a></div>
        <div><a href="teacherPower.aspx?colsId=6" class="newactive-show">师资力量</a></div>
        <div class="border-no"><a href="classes.aspx?colsId=6">课程设置</a></div>
    </div>
    <div class="columns2-right myfloat boxborder">
    	<div class="content1-title-show">
        	<span>师资力量</span>
        </div>
        <div class="columns2-right-content">
              <% for (int i = 0; i < Teachers.Length; i++){%>
          <div class="course-contain-left-art" >
              <img src="<%=Teachers[i].TeacherImgSrc %>" width="300" height="226" class="myfloat" style=" margin-right:10px;" alt="<%=Teachers[i].TeacherName %>"/>
              <p class="teacher-name-art"><%=Teachers[i].TeacherName %></p>
              <p class="teacher-title-art"><%=Teachers[i].TeacherTitle %></p>
              <p class="teacher-details-art"><%=Teachers[i].TeacherDetail %></p>
          </div>
       <% } %>
            <div class="clearfix"></div>
        </div>
    </div>
</div>

</asp:Content>
