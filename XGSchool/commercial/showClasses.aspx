<%@ Page Title="" Language="C#" MasterPageFile="~/commercial/show.Master" AutoEventWireup="true" CodeBehind="showClasses.aspx.cs" Inherits="XGSchool.commercial.showClasses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<!--start slider-->
	<link href="../Skins/CSS/camera.css" rel="stylesheet" type="text/css" media="all" />
    <script type='text/javascript' src="../Skins/scripts/jquery.easing.1.3.js"></script> 
    <script type='text/javascript' src="../Skins/scripts/camera.min.js"></script>
    <script type="text/javascript">
        jQuery(function () {
            jQuery('#camera_wrap_2').camera({
                time: 1500,
                loader: 'bar',
                pagination: false,
                thumbnails: true
            });
        });
	</script>
    <style type="text/css">
    .camera_thumbs_cont ul li {
	padding-right: 23px;
	}
    </style>
<!--end slider-->

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="commercialimg boxborder">
<img src="<%=showImgsrc %>" width="1080" height="184" alt="背景图片" />
</div>

<div class="columns1">
您现在位置：<span class="myspan"><a href="#">首页</a></span>/<span class="myspan"><a href="#">商演培训</a></span>/<span class="myspan">课堂瞬间</span>
</div>

<div class="course-contain boxborder">
	<div class="course-contain-top">
    	<div class="course-contain-title-art" style=" color:#1E577C;background-color:#F7F7F7;">
        	<span>课堂瞬间</span>
        </div>
        <div class="course-contain-content">
        	        <!-- start slider -->
        <div class="main-con">
            <div class="slider">
                <div class="color"> <span> </span></div>
                <div class="wrap">
                <div class="fluid_container">
                    <div class="camera_wrap camera_magenta_skin" id="camera_wrap_2">
                     <%for (int i = 0; i < imgSrc.Length; i++)
                       {%>
                         <div data-thumb="<%=imgSrc[i] %>" data-src="<%=imgSrc[i] %>">
                        </div>
                     <% } %>
                        
                    </div><!-- #camera_wrap_2 -->
            	</div><!-- .fluid_container -->
           		<div class="clear"></div>
            </div><!-- wrap -->
            </div>
        </div>
        <!--end slider-->
        </div>
    </div>
</div>

</asp:Content>
