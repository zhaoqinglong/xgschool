<%@ Page Title="" Language="C#" MasterPageFile="~/artSchoolNew/artSchool.Master" AutoEventWireup="true" CodeBehind="advantages.aspx.cs" Inherits="XGSchool.artSchoolNew.advantages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<style type="text/css">
#tab1{width:920px;height:35px;}
#tab1 ul{width:400px; margin:10px auto; display:block; }
#tab1 li{float:left; margin:0px 7px; height:35px; line-height:30px; text-align:center; cursor:pointer; font-size:14px; color:#fff; background:url(../Skins/artimages/tab_normal.png) no-repeat 0 0; width:84px; font-weight:bold; font-size:14px; }
#tab1 li:hover{ background:url(../Skins/artimages/tab_focus.png) no-repeat 0 0;}
#tab1 li.now{color:#fff;background:url(../Skins/artimages/tab_current.png) no-repeat 0 0;}
.tablist{width:880px;height:auto; min-height:112px; padding:10px;font-size:14px;line-height:24px;display:none;}
.block{display:block;}
#nav3{ background:url(../Skins/artimages/nav_03_current.png) no-repeat !important; }
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
        if (o != null && o <= 2 && o >= 0) {
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
        	<div class="lesson-content-title">新革优势</div>
            <div class="lesson-content-con">
            	<div id="tab1">
                    <ul>
                       <li onclick="setTab(1,0)" class="now">教学环境</li>
                       <li onclick="setTab(1,1)">师资团队</li>
                       <li onclick="setTab(1,2)">课堂氛围</li>
                    </ul>
                </div>
                <div id="tablist1">
                        <div class="tablist block"><%=teachEnvironment%></div>
                        <div class="tablist"><%=teachTeam %></div>
                        <div class="tablist"><%=lessonEnvironment %></div>
                 </div>
            
            </div>
        </div><!--end of lesson-content-->

</asp:Content>
