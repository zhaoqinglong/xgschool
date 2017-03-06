<%@ Page Title="" Language="C#" MasterPageFile="~/artSchoolNew/artSchool.Master" AutoEventWireup="true" CodeBehind="culture.aspx.cs" Inherits="XGSchool.artSchoolNew.culture" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
#nav5{ background:url(../Skins/artimages/nav_05_current.png) no-repeat !important; }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="lesson-content "><!--start of lesson-content-->
        	<div class="lesson-content-title">校园文化</div>
            <div class="lesson-content-con"><%=SchoolColDetail %></div>
        </div>

</asp:Content>
