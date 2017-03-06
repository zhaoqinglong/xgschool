<%@ Page Title="" Language="C#" MasterPageFile="~/artSchoolNew/artSchool.Master" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="XGSchool.artSchoolNew.about" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
#nav2{ background:url(../Skins/artimages/nav_02_current.png) no-repeat;}
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="lesson-content "><!--start of lesson-content-->
        	<div class="lesson-content-title">新革是谁</div>
            <div class="lesson-content-con"><%=SchoolColDetail %></div>
        </div>

</asp:Content>
