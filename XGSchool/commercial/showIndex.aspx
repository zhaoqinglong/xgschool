<%@ Page Title="" Language="C#" MasterPageFile="~/commercial/show.Master" AutoEventWireup="true" CodeBehind="showIndex.aspx.cs" Inherits="XGSchool.commercial.showIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" href="../Skins/CSS/flexslider.css" type="text/css" />
<style type="text/css">
    body{ width:auto; max-width:100%;}
	#container2{ height:300px; width:1100px; margin:0 auto 15px auto;}
	#container3{ height:250px; width:1100px; margin: 15px auto 0; background-color:#F4F4F4;}
	#container4{ height:300px; width:1100px; margin: 15px auto;}
	/*图片滚动切换效果*/
.bx_wrap {margin-left:30px; margin-top:10px;} 
.bx_wrap ul img { border: 5px solid #CCC; -moz-border-radius: 5px; -webkit-border-radius: 5px;  border-radius:5px;} 
.bx_wrap ul li{text-align:center; float:left; width:150px; height:170px; overflow:hidden; } 
.bx_wrap ul li a{color:#FFF;}
.bx_wrap ul li a:hover{text-decoration:none; } 
/*如果要使用方向按钮导航，则需要设置.bx_wrap a.prev和.bx_wrap a.next的样式。*/
.bx_wrap a.prev {width:46px;height:40px;line-height:24px;outline-style:none;outline-width: 0; position:absolute; top:135px; left:0px; text-indent:-999em; background: url(../Skins/images/left.png) no-repeat; } 
.bx_wrap a.next {width:46px;height:40px;line-height:24px; position: absolute; top:135px; text-indent:-999em; background:url(../Skins/images/right.png) no-repeat; right:5px;} 
.demo {width:980px; height:200px; margin: 40px auto;position: relative; overflow:hidden; background:url(../Skins/images/bg3.gif) no-repeat -3px 80px;}
.bx_container{ width:900px !important;}


/*第二个*/
.demo2 {width:980px; height:200px; margin: 40px auto;position: relative; overflow:hidden; background:url(../Skins/images/03.gif) no-repeat 0px 0px;}
.demo2>.bx_wrap>a.prev {width:46px;height:40px;line-height:24px;outline-style:none;outline-width: 0; position:absolute; top:55px; left:0px; text-indent:-999em; background: url(../Skins/images/left.png) no-repeat; } 
.demo2>.bx_wrap>a.next {width:46px;height:40px;line-height:24px; position: absolute; top:55px; text-indent:-999em; background:url(../Skins/images/right.png) no-repeat; right:5px;} 


.flex-control-nav{ width:40%;}
.flex-active { background: #00B4EE !important; background: rgba(0,0,0,0.9); cursor: default; }

/*背景*/
.flexslider{ border:none;}
/*.slides li{ background:url(../Skins/images/bg_yellow.png) repeat-x; }*/
.flexslider .slides img{ width:100%; margin:0 auto;}
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="content1-new">

      <section class="slider">
        <div class="flexslider">
          <ul class="slides">
                <%for (int i = 0; i < pics.Length; i++)
                  {%>
                  <li>
  	    	        <img src="<%=pics[i].imgPath %>" width="800" height="354" alt="#"/>
  	    		  </li>
                  <% }%>
          </ul>
        </div>
      </section>    

</div>
<div id="container2" class="">
     <div class="container2-top">
         <span class="myline" style="margin-right:20px;">&nbsp;</span>
         <span style="color:#fd6563;">学员风采</span>
         <span class="myline" style="margin-left:20px;">
         	&nbsp;
         </span>
     </div>
     <div class="clear"></div>
  	<div class="demo">
		<ul id="demo1">
             <%for (int i = 0; i < stupics.Length; i++)
                  {%>
                    <li><a href="student.aspx?colsId=4"><img  alt="#" width="150" height="150" src="<%=stupics[i].imgPath %>"><br/><%=stupics[i].detail%></a></li>
             <% }%>
		</ul>
	</div>
    
</div>


<div id="container3" class="" style=" height:auto; font-size:14px;">
    <div class="container3-left myfloat" style=" padding-right:10px; font-size:14px;">
        <div class="container3-show-title">
        	学院简介
        </div>
        <div>
        	<img src="../Skins/artimages/school.png" width="135" height="100" style="margin:0 10px 10px 0; float:left; ">
            <p style="display:inline; height:22px; line-height:22px; text-indent:2em;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%=about %>...</p>
        </div>
    </div>
    <div class="container3-middle myfloat ">
    	<div class="container3-show-title" >
        	新革动态
        </div>
          <table>
               <%for (int i = 0; i < xgnews.Length; i++)
               { %>
          <tr>
          	<td  class="td-left">
                  <a href="newsDetail.aspx?colsId=7&newsID=<%=xgnews[i].newsId %>">
                  <%=xgnews[i].newsTitle %></a>

          	</td>
              <td><%=xgnews[i].newDate %></td>
          </tr>
              <%} %>
          </table>
    </div>
    <div class="container3-right myfloat ">
       <div class="container3-show-title">
        	课程设置
        </div>
        <div style="text-align:center;" class="container3-show-title1 boxborder" >
        	普通话课程
        </div>
        <div style=" height:100px; text-indent:2em; line-height:22px;" >
        <p><%=biandao %>...</p>
        </div>
        <div style="text-align:center;" class="container3-show-title1 boxborder" >
        	商演主持&婚礼主持
        </div>
        <div style="text-indent:2em; line-height:22px; " >
        <p><%=boyin %>...</p>
        </div>
    </div>
</div>
<div style="height:40px; width:1100px; margin: 0 auto; background-color:#F4F4F4;">
    <div class="container3-left myfloat ">
        <a href="commercialShow.aspx?colsId=2" class="newmore">MORE</a>
    </div>
    <div class="container3-middle myfloat ">
        <a href="commercialNews.aspx?colsId=7" class="newmore">MORE</a>
    </div>
    <div class="container3-right myfloat ">
        <a href="classes.aspx?colsId=2" class="newmore">MORE</a>
    </div>
</div>

<div class=" clear"></div>
<div id="container4" class="">
     <div class="container2-top">
         <span class="myline" style="margin-right:20px;">&nbsp;</span>
         <span style="color:#fd6563;">师资力量</span>
         <span class="myline" style="margin-left:20px;">
         	&nbsp;
         </span>
     </div>
     <div class="clear"></div>
  	<div class="demo2">
		<ul id="demo2">
            <%for (int i = 0; i < teapics.Length; i++)
                  {%>
                  <li><a href="teacherPower.aspx?colsId=2"><%=teapics[i].detail%><br/><img  alt="#" width="150" height="150" src="<%=teapics[i].imgPath %>"/></a></li>
             <% }%>
		</ul>
	</div>
    
</div>


  <!-- FlexSlider -->
  <script defer src="../Skins/scripts/jquery.flexslider.js"></script>
  <script type="text/javascript" src="../Skins/scripts/bxCarousel.js"></script>
<script type="text/javascript">
    $(window).load(function () {
        $('.flexslider').flexslider({
            animation: "slide",
            start: function (slider) {
                $('body').removeClass('loading');
            },
            directionNav: false,
            animationDuration: 100
        });
    });
    jQuery(function () {
        jQuery('#demo1').bxCarousel({//bxCarousel滚动效果
            display_num: 4,
            move: 1,
            auto: true,
            controls: true, //此处为false,表示不显示左右箭头控制按钮
            margin: 80,
            auto_hover: true //鼠标悬停到轮播区域时，是否停止图片轮播
        });
    });

    jQuery(function () {
        jQuery('#demo2').bxCarousel({//bxCarousel滚动效果
            display_num: 4,
            move: 1,
            auto: true,
            controls: true, //此处为false,表示不显示左右箭头控制按钮
            margin: 80,
            auto_hover: true //鼠标悬停到轮播区域时，是否停止图片轮播
        });
    });
</script>
</asp:Content>



