<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="XGSchool.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新革艺术学校</title>
    <meta name="renderer" content="webkit"/>
<link href="Skins/CSS/bootstrap.min.css" rel="stylesheet" />


 <!--[if lte IE 7]>

  <link rel="stylesheet" type="text/css" href="Skins/CSS/bootstrap-ie6.min.css" />
  <link rel="stylesheet" type="text/css" href="Skins/CSS/ie.css"/>
  <![endif]-->
    <script type="text/javascript" src="Skins/scripts/jquery.min.js"></script>
    <script type="text/javascript" src="Skins/scripts/bootstrap.min.js"></script>

     <!--[if lte IE 7]>
    <script type="text/javascript" src="Skins/scripts/bootstrap-ie.js"></script>
    <![endif]-->

    <script type="text/javascript" src="Skins/scripts/respond.min.js"></script>
    <script type="text/javascript" src="Skins/scripts/html5shiv.min.js"></script>

<style type="text/css">
html{ height:100%; }
body{ margin:0; padding:0 auto; background-color:#F7F7F7; }
body,a,strong,input,select,button,h1,h2,h3,h4,h5,h6,h7 {font:12px "Microsoft YaHei","SimSun","Arial","Tahoma",sans-serif; }
a { text-decoration:none;}
.col-lg-4 a:hover{ color:#fff;}
.clear{clear:both;}
.myfloat{ float:left;}
img{ border:none;}
li{ list-style:none; float:left;}
#container {}
.newBorder{ border:#666 solid 1px;}
.top{ width:100%; height:6px; background:url(../Skins/images/top.png) repeat-x ;}
.banner{ width:100%; height:86px; }
.banner-left{ width:60%; height:80px; padding-left:15%; font-size:28px; color:#999; letter-spacing:4px; background:url(../Skins/images/logo_new.png) no-repeat 25% 50%;}
.banner-right{ width:40%; height:80px; line-height:60px;  color:#666;}
.main{width:100%; height:auto;  min-height:540px; margin:auto auto; box-shadow: 0 8px 6px -6px #999,0 -8px 6px -6px #B0B0B0;}
.myline{ width:300px; height:1px; background:#919292; display:inline-block;  vertical-align:bottom;}
.box-bottom{width:216px; height:52px; line-height:40px; font-size:24px; color:white;}
.foot{ height:50px; line-height:50px; text-align:center; font-size:14px; color:#666;}
.idea{  width:820px; height:auto; min-height:30px; margin:20px auto; }
.idea-p{ height:20px; line-height:20px; text-align:center; font-size:14px; color:#999; margin-bottom:3px;}
.btn{ border:none; border-radius:0;}
</style>
</head>
<body>
<div id="container">
<div class="top">
    &nbsp;
</div>
<div class="banner">
	<div class="myfloat banner-left" style="">
    </div>
    <div class="myfloat banner-right ">
        	<div style="height:30px; width:70%; text-align:right; font-size:14px;">品牌及合作媒体：<%=email %></div>
    		<div style="height:50px; width:70%; text-align:right; line-height:50px; font-size:14px; padding-top:-5px; overflow:hidden;"><%=phone %></div>
    </div>
</div>
<div class="main">
	<div style="width:100%; height:88px;"></div>
    <div class="container">
        <div class="row">
          <div class="col-lg-4 col-md-4" style="padding-left:8%; "> 
              
         <a href="artSchoolNew/index.aspx"> 
            <img class="" src="<%=pics[0].imgPath %>" alt="image" style="width: 216px; height: 177px;  box-shadow:0 0 5px 2px #888, 0 5px 0 0; "/></a>
          <p><a class="btn btn-default box-bottom" href="artSchoolNew/index.aspx" role="button" style="background-color:#FD7438; box-shadow:0 0 5px 2px #888; "><%=pics[0].detail %> </a></p>
          
              </div>
          <div class="col-lg-4 col-md-4" style="padding-left:8%;">
           <a href="train/index.aspx">
           <img class="" src="<%=pics[1].imgPath %>" alt="image" style="width: 216px; height: 177px; box-shadow: 0 0 5px 2px #888, 0 5px 0 0; "/>
           </a>
          <p><a class="btn btn-default box-bottom" href="train/index.aspx" role="button" style="background-color:#38B1FD; box-shadow: 0 0 5px 2px #888; "><%=pics[1].detail %> </a></p>
          </div>   
          <div class="col-lg-4 col-md-4" style="padding-left:8%;">
          <a href="commercial/showIndex.aspx">
          <img class="" src="<%=pics[2].imgPath %>" alt="image" style="width: 216px; height: 177px; box-shadow: 0 0 5px 2px #888, 0 5px 0 0; "/>
          </a>
          <p><a class="btn btn-default box-bottom" href="commercial/showIndex.aspx" role="button" style="background-color:#FD3874; box-shadow: 0 0 5px 2px #888; "><%=pics[2].detail %> </a></p>
          </div>   
      	</div>
     </div>
     <div style="width:100%; height:30px;"></div>
     <div class="" style="width:100%; height:70px; line-height:70px; text-align:center; font-size:30px; background:url(../Skins/images/ico.png) no-repeat 50% 15px;" >
          <span class="myline" style="">&nbsp;</span>
          <span class=" " style=" padding:0 30px;" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
          <span class="myline">&nbsp;</span>
     </div>
     <div style="width:100%; height:15px; line-height:15px; text-align:center; font-size:15px; color:#919292; font-weight:bolder; text-decoration:none; letter-spacing:1px;">
     起帆远航</div>
    <div style="width:100%; height:20px;"></div>
     <div class="idea">
     	<p class="idea-p"><%=msg %></p>
     </div>
    <div style="margin-top:50px; height:1px; width:100%;"></div>
</div>
<div style="height:50px; line-height:50px; font-size:18px; text-align:center; color:#e9e9e9; float:left; padding-left:5%;">ivy</div>
<div class="foot"><%=copyright %></div>

</div>
</body>
</html>
