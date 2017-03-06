<%@ Page Title="" Language="C#" MasterPageFile="~/artSchoolNew/artSchool.Master" AutoEventWireup="true" CodeBehind="teachers.aspx.cs" Inherits="XGSchool.artSchoolNew.teachers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="lesson-content "><!--start of lesson-content-->
        	<div class="lesson-content-title">权威师资</div>
            <div class="lesson-content-con">

            <div class="course-contain-main" >
      <% for (int i = 0; i < Teachers.Length; i++){%>
          <div class="course-contain-left-train " >
              <img src="<%=Teachers[i].TeacherImgSrc %>" width="370" height="288"alt="<%=Teachers[i].TeacherName %>" style="display:block;float:left; margin-right:30px;"/>
              <div>
                   <div class="teacher-name-train "><%=Teachers[i].TeacherName %></div>
                  <div class="teacher-title-train"><%=Teachers[i].TeacherTitle %></div>
                  <div class="teacher-details-train"><%=Teachers[i].TeacherDetail %></div>
               </div>
          </div>          

       <% } %><div class="clearfix"></div>
      </div>

            </div>
        </div>

</asp:Content>
