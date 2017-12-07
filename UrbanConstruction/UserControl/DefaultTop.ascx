<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DefaultTop.ascx.cs"
    Inherits="UrbanConstruction.UserControl.DefaultTop" %>
<div class="top">
    <!--S 头部-->
    <div class="top0">
        <!--S顶 文字-->
      <%--  <div class="top0L">
            中山&nbsp;&nbsp;<img src="images/IconYun.gif" width="21" height="15" alt="" />&nbsp;&nbsp;9&deg;C&ndash;17&deg;C&nbsp;&nbsp;微风&nbsp;&nbsp;2014年06月30日&nbsp;&nbsp;星期一</div>--%>
        <div class="top0L" id="divT">
            </div>
        <div class="top0R">   
            <a href="#" onclick="this.style.behavior='url(#default#homepage)';this.setHomePage('http://www.zsuca.com.cn/');">
                设为首页</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a style="cursor: pointer;" onclick="javascript:window.external.AddFavorite('http://www.zscjda.com','中山市城建档案馆')"
                    title="网址">收藏本站</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href="about.aspx?kind=15">联系我们</a></div>
    </div>
    
    <!--E顶 文字-->
   <div class="banner"><!--S动画-->
          <object id="FlashID" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="1000" height="185">
            <param name="movie" value="images/Banner-1.swf">
            <param name="quality" value="high">
            <param name="wmode" value="opaque">
            <param name="swfversion" value="8.0.35.0">
            <!-- 此 param 标签提示使用 Flash Player 6.0 r65 和更高版本的用户下载最新版本的 Flash Player。如果您不想让用户看到该提示，请将其删除。 -->
            <param name="expressinstall" value="Scripts/expressInstall.swf">
            <!-- 下一个对象标签用于非 IE 浏览器。所以使用 IECC 将其从 IE 隐藏。 -->
            <!--[if !IE]>-->
            <object type="application/x-shockwave-flash" data="images/Banner-1.swf" width="1000" height="185">
              <!--<![endif]-->
              <param name="quality" value="high">
              <param name="wmode" value="opaque">
              <param name="swfversion" value="8.0.35.0">
              <param name="expressinstall" value="Scripts/expressInstall.swf">
              <!-- 浏览器将以下替代内容显示给使用 Flash Player 6.0 和更低版本的用户。 -->
              <div>
                <h4>此页面上的内容需要较新版本的 Adobe Flash Player。</h4>
                <p><a href="http://www.adobe.com/go/getflashplayer"><img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif" alt="获取 Adobe Flash Player" /></a></p>
              </div>
              <!--[if !IE]>-->
            </object>
            <!--<![endif]-->
          </object>
        </div><!--E动画-->
         <script type="text/javascript">
		function fetch_object(idname)
		{
		 var my_obj = document.getElementById(idname);
		 return my_obj;
		}
		function toggle_nav(obj)
		{
		 for (i = 1; i<= 9; i++ )
		 {
		  var sub_nav = fetch_object("zzjs_nav" + i);
		  var sub_nav_index = fetch_object("zzjs_nav0");
		  sub_nav_index.style.display = "none";
		  if (obj == i)
		  {
		   sub_nav.style.display = "block";
		  }
		  else
		  {
		   sub_nav.style.display = "none";
		  }
		 }
		}
		</script>
    <script type="text/javascript">
        function getCurDate() {
            var d = new Date();
            var week;
            switch (d.getDay()) {
                case 1: week = "星期一"; break;
                case 2: week = "星期二"; break;
                case 3: week = "星期三"; break;
                case 4: week = "星期四"; break;
                case 5: week = "星期五"; break;
                case 6: week = "星期六"; break;
                default: week = "星期天";
            }

            var years = d.getFullYear()
            var month = add_zero(d.getMonth() + 1);
            var days = add_zero(d.getDate());
            var hour = d.getHours();
            var minu = d.getMinutes();
            var seco = d.getSeconds();
            if (seco < 10) {
                seco = '0' + seco;
            }
            if (minu < 10) {
                minu = '0' + minu;
            }
            if (hour < 10) {
                hour = '0' + hour;
            }
            var ndate = years + "年" + month + "月" + days + "日 " + week + " " + hour + ":" + minu + ":" + seco;
            divT.innerHTML = ndate;
            //time.innerHTML = ndate;
        }
        function add_zero(temp) {
            if (temp < 10) return "0" + temp;
            else return temp;
        }
        setInterval("getCurDate()", 1000);

        $(document).ready(function() {
            $(".mainNav1>li").hover(
	          function() {
	              $(".mainNav1 ul").hide();
	              $(this).children("ul").fadeIn("fast");
	          },
	          function() {
	              $(this).children("ul").fadeOut("fast");
	          }
	        );
            $(".mainNav1>li>ul").hover(

	          function() {
	              $(this).parent().addClass("hover");

	          },
	          function() {
	              $(this).parent().removeClass("hover");
	          }
	        );

            $(function() {
                var last = $('div.mainNav.mainNav1').find('li ._t');
                var len = last.length;
                $(last[len - 1]).addClass('lastli');
            });
        });
    </script>

    <div class="mainNav">
    <ul class="mainNav1">
            <%for (int i = 0; i < count; i++)
              {%>
            <li class="_t" onmouseover="javascript:toggle_nav(<%=i+1 %>)"><a href="<%=listMenuBig[i].Url.ToString() %>">
                <%=listMenuBig[i].M_NAME.ToString()%></a>
                
            </li>
            <%} %>
            
        </ul>
        
           <div class="clear"></div>
             <div id="zzjs_nav0" class="headt mheadt" style="display:block">欢迎来到中山市城市建设档案馆</div>
            <%for (int i = 1; i <= count; i++)
              {
                  %>
        
                <%if (GetMenuSon(listMenuBig[i-1]) > 0)
                  {%>
                       <div id="zzjs_nav<%=i %>" class="headt cd<%=++n %>" <%if(i==0){%>style="display:block;"<%}else{%>style="display:none;"<%} %>>
                    <%for (int j = 0; j < countSon; j++)
                      {%>      
                      <%if (j != countSon - 1)
                        {%>               
                      <%if (listMenuSon[j].Type == 1)
                        { %>
                           
                            <a href="<%=listMenuSon[j].Url.ToString() %>?kind=<%=listMenuSon[j].Kind.ToString() %>" target="_blank"><%=listMenuSon[j].M_ItemName.ToString()%>
                            </a> |  
                           
                        <%} %>
                        <%else
                          { %>
                        
                            <a href="<%=listMenuSon[j].Url.ToString() %>?picturetype=<%=listMenuSon[j].PictureType.ToString() %>" target="_blank"><%=listMenuSon[j].M_ItemName.ToString()%>
                            </a> |  
                          
                        <%} %>
                        <%} %>
                        <%else
                          { %>  <%if (listMenuSon[j].Type == 1)
                        { %>
                           
                            <a href="<%=listMenuSon[j].Url.ToString() %>?kind=<%=listMenuSon[j].Kind.ToString() %>" target="_blank"><%=listMenuSon[j].M_ItemName.ToString()%>
                            </a>
                           
                        <%} %>
                        <%else
                          { %>
                        
                            <a href="<%=listMenuSon[j].Url.ToString() %>?picturetype=<%=listMenuSon[j].PictureType.ToString() %>" target="_blank"><%=listMenuSon[j].M_ItemName.ToString()%>
                            </a>
                          
                        <%} %><%} %>
                    <%} %>
              <%--  </ul>--%>
            
                <% }
                  else
                  { %>     
                  <div id="zzjs_nav<%=i %>" class="headt mheadt" <%if(i==0){%>style="display:block;"<%}else{%>style="display:none;"<%} %>>
                  欢迎来到中山市城市建设档案馆<%} %>
               </div>
            <%
              } %>
           
       
    </div>
</div>
<!--E头部-->

