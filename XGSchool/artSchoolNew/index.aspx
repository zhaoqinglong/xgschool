<%@ Page Title="" Language="C#" MasterPageFile="~/artSchoolNew/artSchool.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="XGSchool.artSchoolNew.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../Skins/CSS/flexslider1.css" rel="Stylesheet" />
<style type="text/css">
.flex-control-nav{ width:200px;}
.flexslider{ border:none;}
.flex-active { background: #00B4EE !important; background: rgba(0,0,0,0.9); cursor: default; }
.slider{ width:900px; height:270px; margin:0 auto; padding-top:40px; padding-left:19px;}

/* Control Nav */
.flex-control-nav {  bottom: -47px; }
.flex-control-paging li a {width: 15px; height: 15px; display: block; background: #666; background: rgba(255,255,255,1); cursor: pointer; text-indent: -9999px; -webkit-border-radius: 30px; -moz-border-radius: 30px; -o-border-radius:30px; border-radius: 30px; -webkit-box-shadow: inset 0 0 3px rgba(0,0,0,0.5); -moz-box-shadow: inset 0 0 3px rgba(0,0,0,0.5); -o-box-shadow: inset 0 0 3px rgba(0,0,0,0.5); box-shadow: inset 0 0 3px rgba(0,0,0,0.5); }
.wrapper {
    max-width: 930px;
    padding: 0;
    margin: auto;
	border:none;
}
#nav1{ background:url(../Skins/artimages/nav_01_current.png) no-repeat;}
    .rightfloat {
        float:right;
    }
</style>
  <!-- FlexSlider -->
  <script defer  src="../Skins/scripts/jquery.flexslider.js"></script>

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
  </script>

<!--图片轮播样式和JS-->
<link href="../Skins/CSS/jcarousel.connected-carousels.css" rel="stylesheet" />
<script type="text/javascript" src="../Skins/scripts/jquery.jcarousel.min.js"></script>
<script type="text/javascript" src="../Skins/scripts/jcarousel.connected-carousels.js"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div class="content1"><!--start of content1-->
            <div class="content1-con">
              <section class="slider">
                <div class="flexslider">
                  <ul class="slides">
                        <%for (int i = 0; i < imgSrc.Length; i++)
                          { %>
                        <li>
                            <img src="<%=imgSrc[i] %>" width="880" height="267" alt=""/>
                        </li>
                         <% } %>
                  </ul>
                </div>
              </section>   
            </div>
        </div><!--end of content1-->
        
        <div class="content2"><!--start of content2-->
            <div class="content2-con1 ">    
                <div class="">
                    <div class="content2-con1-left-top  myfloat " > </div>
                    <a href="about.aspx" class="content2-con1-left-middle  myfloat " ></a> 
                    <div class="content2-con1-left-right  myfloat "> </div>
                    <a href="advantages.aspx?colsId=1" class="content2-con1-left-middle  myfloat " ></a> 
                </div>
            
                <div class="content2-con1-left  myfloat">
                    <img src="<%=aboutImgsrc %>" width="571" height="284" alt="新革艺术培训学校"/>
                    <p><%=aboutXG %></p>
                </div>
                <div class="content2-con1-right  myfloat">
                    <img src="<%=teaimgSrc[0] %>" width="215" height="182" alt="钢琴老师" />
                    <img src="<%=teaimgSrc[1] %>" width="215" height="182" alt="钢琴老师" style=" margin-top:28px;" />
                </div>
            </div>
            
            <div class="content2-con2-title ">
                <div class="content2-con2-title-left  myfloat "></div>
                <a href="news.aspx" class="content2-con2-title-right myfloat "></a>
            </div>
               
            <div class="content2-con2 ">
            <%for (int i = 0; i < xgnews.Length; i++)
              {%>
                <div class="content2-con2-content" >
                    <div class="content2-con2-img" ><a href="newsDetail.aspx?newsID=<%=xgnews[i].newsId %>"><img src="<%=xgnews[i].newsImage %>" alt="#" width="75" height="75" /></a></div>
                    <div class="content2-con2-tit" ><a href="newsDetail.aspx?newsID=<%=xgnews[i].newsId %>"><%=xgnews[i].newsTitle%></a></div>
                </div>
              <%} %>  

            </div>
            
            <div class="content2-con3">
                <div class="content2-con3-title ">
                    <div class="content2-con3-title-left  myfloat "></div>
                    <a href="lesson.aspx" class="content2-con3-title-right myfloat "></a>
                </div>
                
                <div class="content2-con3-content">
                
                    <div class="content2-con3-content1  myfloat" style="">
                        <div class="content2-con3-content1-title" style=""></div>
                        <div class="content2-con3-content1-img"><img src="<%=biandaoimg %>" alt="#"  width="163" height="163" style=""/></div>
                        <div  class="content2-con3-content1-c" style=""><%=biandao %>...<a class="more rightfloat" href="lesson.aspx?colsId=0" >more</a>
                        </div>
                    </div>
                    
                    <div class="content2-con3-content1  myfloat" style="">
                        <div class="content2-con3-content1-title" style=" background:url(../Skins/artimages/class_02.png) no-repeat 35px 45px;"></div>
                        <div class="content2-con3-content1-img"><img src="<%=boyinimg %>" alt="#"  width="163" height="163" style=""/></div>
                        <div  class="content2-con3-content1-c" style=""><%=boyin %>...<a class="more rightfloat" href="lesson.aspx?colsId=1">more</a>
                        </div>
                    </div>
                    
                    
                     <div class="content2-con3-content1  myfloat" style="">
                        <div class="content2-con3-content1-title" style=" background:url(../Skins/artimages/class_03.png) no-repeat 35px 45px; "></div>
                        <div class="content2-con3-content1-img"><img src="<%=showimg %>" alt="#"  width="163" height="163" style=""/></div>
                        <div  class="content2-con3-content1-c" style=""><%=show %>...<a class="more rightfloat" href="lesson.aspx?colsId=2">more</a>
                        </div>
                    </div>
                    
                    
                     <div class="content2-con3-content1  myfloat" style="">
                        <div class="content2-con3-content1-title" style=" background:url(../Skins/artimages/class_04.png) no-repeat 35px 45px;"></div>
                        <div class="content2-con3-content1-img"><img src="<%=otherimg %>" alt="#"  width="163" height="163" style=""/></div>
                        <div  class="content2-con3-content1-c" style=""><%=other %>...<a class="more rightfloat" href="lesson.aspx?colsId=3">more</a>
                        </div>
                    </div>
                </div>
                
            </div><!--end of content2-con3-->
            
            
            <div class="content2-con4">
                <div class="content2-con4-title ">
                    <div class="content2-con4-title-left  myfloat "></div>
                    <a href="lesson.aspx" class="content2-con4-title-right myfloat "></a>
                </div>
                
                <!--start wrapper-->
                <div class="wrapper">
                    <div class="connected-carousels" style="">
                        <div class="stage">
                            <div class="carousel carousel-stage">
                                <ul>                               
                                    <%for (int i = 0; i < resultimgSrc.Length; i++)
                                      { %>
                                        <li><img src="<%=resultimgSrc[i] %>" width="420" height="160" alt=""/></li>
                                    <% } %>
                                </ul>
                            </div>
                            <a href="#" class="prev prev-stage"><span>&lsaquo;</span></a>
                            <a href="#" class="next next-stage"><span>&rsaquo;</span></a>
                        </div>
        
                        <div class="navigation" style=" background-color:#fff; width:924px;">
                            <a href="#" class="prev prev-navigation"></a>
                            <a href="#" class="next next-navigation"></a>
                            <div class="carousel carousel-navigation">
                                <ul>
                                    <%for (int i = 0; i < resultimgSrc.Length; i++)
                                      { %>
                                        <li><img src="<%=resultimgSrc[i] %>" width="80" height="80" alt=""/></li>
                                    <% } %>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <!--end of wrapper-->
                
            </div><!--end of content2-con4-->
            
           
            <div class="content2-con5"> <!--strat of content2-con5-->
                <div class="content2-con5-title ">
                    <div class="content2-con5-title-left  myfloat "></div>
                    <a href="culture.aspx" class="content2-con5-title-right myfloat "></a>
                </div>
                <div style="width:700px; height:332px; margin:0 auto; ">
                <embed src="<%=videoURL %>" allowFullScreen="true" quality="high" width="700" height="332" align="middle" allowScriptAccess="always" type="application/x-shockwave-flash"></embed>
                </div>
           	</div><!--end of content2-con5-->
            <div class="content2-con6"> </div>
        </div> <!--end of content2-->

</asp:Content>
