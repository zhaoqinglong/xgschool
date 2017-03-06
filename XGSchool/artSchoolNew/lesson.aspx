<%@ Page Title="" Language="C#" MasterPageFile="~/artSchoolNew/artSchool.Master" AutoEventWireup="true" CodeBehind="lesson.aspx.cs" Inherits="XGSchool.artSchoolNew.lesson" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<style type="text/css">
#tab1{width:920px;height:35px;}
#tab1 ul{width:750px; margin:10px auto; display:block; }
#tab1 li{float:left; margin:0px 5px; height:35px; line-height:30px; text-align:center; cursor:pointer; font-size:14px; color:#fff; background:url(../Skins/artimages/tab_normal.png) no-repeat 0 0; width:84px; font-weight:bold; font-size:14px;}
#tab1 li:hover{ background:url(../Skins/artimages/tab_focus.png) no-repeat 0 0;}
#tab1 li.now{color:#fff;background:url(../Skins/artimages/tab_current.png) no-repeat 0 0;}
.tablist{width:880px;height:auto; min-height:112px; padding:10px;font-size:14px;line-height:24px;display:none; }
.block{display:block;}
#nav4{ background:url(../Skins/artimages/nav_04_current.png) no-repeat !important; }
</style>
<script type="text/javascript">
    function setTab(m, n) {
        var menu = document.getElementById("tab" + m).getElementsByTagName("li");
        var showdiv = document.getElementById("tablist" + m).getElementsByTagName("div");
        for (i = 0; i < menu.length; i++) {
            menu[i].className = i == n ? "now" : "";
            showdiv[i].style.display = i == n ? "block" : "none";
        }
    }

    function getQueryString(name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    }

    $(document).ready(function () {
        var o = getQueryString("colsId");
        if (o != null && o <= 6 && o >= 0) {
            setTab(1, o);
        }
        else {
            setTab(1, 0);
        }
    })
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class="lesson-content "><!--start of lesson-content-->
        	<div class="lesson-content-title">专业课程</div>
            <div class="lesson-content-con">
            	<div id="tab1">
                    <ul>
                       <li onclick="setTab(1,0)" class="now">编导类</li>
                       <li onclick="setTab(1,1)">播音类</li>
                       <li onclick="setTab(1,2)">表演类</li>
                       <li onclick="setTab(1,3)">美术类</li>
                       <li onclick="setTab(1,4)">声乐类</li>
                       <li onclick="setTab(1,5)">舞蹈类</li>
                       <li onclick="setTab(1,6)">空乘类</li>
                    </ul>
                </div>
                <div id="tablist1">
                        <div class="tablist block"><%=lesson1 %></div>
                        <div class="tablist"><%=lesson2 %></div>
                        <div class="tablist"><%=lesson3 %></div>
                        <div class="tablist"><%=lesson4 %></div>
                        <div class="tablist"><%=lesson5 %></div>
                        <div class="tablist"><%=lesson6 %></div>
                        <div class="tablist"><%=lesson7 %></div>
                 </div>
            
            </div>
        </div><!--end of lesson-content-->

</asp:Content>
