<%@ Page Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs"
    Inherits="UrbanConstruction.Index" Title="中山市城市建设档案馆" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/index.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.9.1.js" type="text/javascript"></script>
<script src="js/jwplayer.js" type="text/javascript"></script>  
<%--<script src="js/jwplayer.html5.js" type="text/javascript"></script>--%> 
 <!--[if gt IE 9]> <script src="js/jwplayer.html5.js" type="text/javascript"></script> <![endif]-->   
    <%--<script type="text/javascript">
        var thePlayer;  //保存当前播放器以便操作
        $(function() {
            thePlayer = jwplayer('container').setup({
                flashplayer: 'js/jwplayer.flash.swf',
                file: 'VideoFiles/<%=url %>',
                width: 246,
                height: 176,
                image: 'VideoFiles/2.jpg',
                dock: false
            });

            //播放 暂停
            $('.player-play').click(function() {
                if (thePlayer.getState() != 'PLAYING') {
                    thePlayer.play(true);
                    this.value = '暂停';
                } else {
                    thePlayer.play(false);
                    this.value = '播放';
                }
            });

            //停止
            $('.player-stop').click(function() { thePlayer.stop(); });

            //获取状态
            $('.player-status').click(function() {
                var state = thePlayer.getState();
                var msg;
                switch (state) {
                    case 'BUFFERING':
                        msg = '加载中';
                        break;
                    case 'PLAYING':
                        msg = '正在播放';
                        break;
                    case 'PAUSED':
                        msg = '暂停';
                        break;
                    case 'IDLE':
                        msg = '停止';
                        break;
                }
                alert(msg);
            });

            //获取播放进度
            $('.player-current').click(function() { alert(thePlayer.getPosition()); });

            //跳转到指定位置播放
            $('.player-goto').click(function() {
                if (thePlayer.getState() != 'PLAYING') {    //若当前未播放，先启动播放器
                    thePlayer.play();
                }
                thePlayer.seek(30); //从指定位置开始播放(单位：秒)
            });

            //获取视频长度
            $('.player-length').click(function() { alert(thePlayer.getDuration()); });
        });
    </script>--%>
    <script type="text/javascript">
        //图片滚动框-begin
        var t = n = 0, count;
        $(document).ready(function() {       
            
            count = $("#banner_list a").length;
            $("#banner_list a:not(:first-child)").hide();
            $("#banner_info").html($("#banner_list a:first-child").find("img").attr('alt'));
            $("#banner_info").click(function() { window.open($("#banner_list a:first-child").attr('href'), "_blank") });
            $("#banner li").click(function() {
                var i = $(this).text() - 1; //获取Li元素内的值，即1，2，3，4
                n = i;
                if (i >= count) return;
                $("#banner_info").html($("#banner_list a").eq(i).find("img").attr('alt'));
                $("#banner_info").unbind().click(function() { window.open($("#banner_list a").eq(i).attr('href'), "_blank") })
                $("#banner_list a").filter(":visible").fadeOut(500).parent().children().eq(i).fadeIn(1000);
                document.getElementById("banner").style.background = "";
                $(this).toggleClass("on");
                $(this).siblings().removeAttr("class");
            });
            t = setInterval("showAuto()", 4000);
            $("#banner").hover(function() { clearInterval(t) }, function() { t = setInterval("showAuto()", 4000); });                                  
        })
        function showAuto() {
            n = n >= (count - 1) ? 0 : ++n;
            $("#banner li").eq(n).trigger('click');
        }

        function GoAhead() {
            var count = $(".PicCon ul li[class='on']:first").attr("value");
            var begin = $(".PicCon ul li[class='on']:first").attr("id");
            var num = Number(begin) + 3;
            if (num < count) {
                $(".PicCon ul li[id=" + begin + "]").attr("style", "display:none").removeAttr("class")
                $(".PicCon ul li[id=" + num + "]").attr("class", "on").removeAttr("style");
            }
            
        }
     
        function GoEnd() {
            var count = $(".PicCon ul li[class='on']:last").attr("value");
            var begin = $(".PicCon ul li[class='on']:last").attr("id");
            var num = Number(begin) - 3;
            if (num >= 0) {
                $(".PicCon ul li[id=" + begin + "]").attr("style", "display:none").removeAttr("class")
                $(".PicCon ul li[id=" + num + "]").attr("class", "on").removeAttr("style");
            }
        }


        time = window.setInterval(function() {
            var count = $(".PicCon ul li[class='on']:first").attr("value");
            var begin = $(".PicCon ul li[class='on']:first").attr("id");
            var num = Number(begin) + 3;
            if (num < count) {
                $(".PicCon ul li[id=" + begin + "]").attr("style", "display:none").removeAttr("class")
                $(".PicCon ul li[id=" + num + "]").attr("class", "on").removeAttr("style");
            }
            else {
                $(".PicCon ul li[id=" + 0 + "]").attr("class", "on").removeAttr("style");
                $(".PicCon ul li[id=" + 1 + "]").attr("class", "on").removeAttr("style");
                $(".PicCon ul li[id=" + 2 + "]").attr("class", "on").removeAttr("style");
                for (var i = 3; i < count; i++) {
                    $(".PicCon ul li[id=" + i + "]").attr("style", "display:none").removeAttr("class")
                }
            }

        }, 3000);
        //图片滚动框-end
    </script>  
    <script type="text/javascript">       
         function setTab(name, cursel, n) {
             for (i = 1; i <= n; i++) {
                 var menu = document.getElementById(name + i); /* zzjs1 */
                 var con = document.getElementById("con_" + name + "_" + i); /* con_zzjs_1 */
                 menu.className = i == cursel ? "hover" : ""; /*三目运算 等号优先*/
                 con.style.display = i == cursel ? "block" : "none";
             }
         }					  
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--S-->
    <div class="middle">
        <!--S中间内容区域-->
        <div class="middle0">
            <!--S包含框 左边内容跟右边内容-->
            <div class="mLeft">
                <!--S左边内容-->
                <div class="Notice NoticeAll">
                    <!--S公告-->
                    <h2>
                        <span>通知公告</span><a href="workDynamic.aspx?kind=<%=list[0].Kind.ToString() %>"  target="_blank">更多</a></h2>
                    <ul>
                        <%for (int i = 0; i < list.Count; i++)
                          {%>
                          <%if ((i+1) % 2 == 0)
                            {%>
                              <li class="HBg"><a href="NewsDetail.aspx?FID=<%=list[i].ID.ToString() %>"  target="_blank">
                                    <%if (list[i].Title.Length > 25)
                                      { %>
                                      <%=list[i].Title.Substring(0, 25)%>...
                                      <%} %>
                                      <%else
                                        { %>
                                        <%=list[i].Title%>
                                      <%} %> &nbsp;&nbsp;&nbsp;&nbsp;<%=list[i].ReleaseTime.ToString("yyyy-MM-dd")%></a>
                                </li>
                            <%} %>
                            <%else
                              { %>
                                 <li><a href="NewsDetail.aspx?FID=<%=list[i].ID.ToString() %>"  target="_blank">
                                    <%if (list[i].Title.Length > 25)
                                      { %>
                                      <%=list[i].Title.Substring(0, 25)%>...
                                      <%} %>
                                      <%else
                                        { %>
                                        <%=list[i].Title%>
                                      <%} %>&nbsp;&nbsp;&nbsp;&nbsp;<%=list[i].ReleaseTime.ToString("yyyy-MM-dd")%></a>
                                </li>
                            <%} %>
                      
                        <%} %>
                    </ul>
                </div>
                <!--E公告-->
           
                <div class="Notice DAYSXXGBBg">
                    <!--S档案验收信息公布-->
                    <h2>
                        <span>档案验收信息公布</span><a href="workDynamic.aspx?kind=<%=kind %>"  target="_blank">更多</a></h2>
                    <ul>
                     <li><a href="ForExcel.aspx?searchtype=null&value=null&pageIndex=1&token=<%=Session["CRSFToken"] %>" class="YJText"  target="_blank">
                            建筑工程档案预验收</a><span>&nbsp;</span>
                     </li>
                     <%if (listChecked1 != null)
                       {%>
                        <%for (int i = 0; i < listChecked1.Count; i++)
                          {%>
                          <%if ((i + 1) % 2 == 0)
                            {%> 
                              <li ><a href="NewsDetail.aspx?FID=<%=listChecked1[i].ID.ToString() %>"  target="_blank">
                                    <%if (listChecked1[i].Title.Length > 10)
                                      { %>
                                      <%=listChecked1[i].Title.Substring(0, 10)%>...
                                      <%} %>
                                      <%else
                                        { %>
                                        <%=listChecked1[i].Title.Substring(0, listChecked1[i].Title.Length-1)%>
                                        <%} %></a><span><%=listChecked1[i].ReleaseTime.ToString("MM-dd")%></span>
                              </li>
                            <%} %>
                            <%else
                              { %>
                               <li class="HBg"><a href="NewsDetail.aspx?FID=<%=listChecked1[i].ID.ToString() %>"  target="_blank">
                                    <%if (listChecked1[i].Title.Length > 10)
                                      { %>
                                      <%=listChecked1[i].Title.Substring(0, 10)%>...
                                      <%} %>
                                      <%else
                                        { %>
                                            <%=listChecked1[i].Title.Substring(0, listChecked1[i].Title.Length-1)%><%} %></a><span><%=listChecked1[i].ReleaseTime.ToString("MM-dd")%></span>
                              </li>
                            <%} %>
                     
                        <%} %>
                        <%} %>
                         <li class="HBg"><a href="ForExcelGuanXIan.aspx?searchtype=null&value=null&token=<%=Session["CRSFToken"] %>"  class="YJText"  target="_blank">
                            管线工程档案预验收</a><span>&nbsp;</span>
                            </li>
                              <%if (listChecked1 != null)
                       {%>
                          <%for (int i = 0; i < listChecked2.Count; i++)
                          {%>
                          <%if (i % 2 == 0)
                            {%> 
                              <li ><a href="NewsDetail.aspx?FID=<%=listChecked2[i].ID.ToString() %>"  target="_blank">
                                    <%if (listChecked2[i].Title.Length > 10)
                                      { %>
                                      <%=listChecked2[i].Title.Substring(0, 10)%>...
                                      <%} %>
                                      <%else
                                        { %>
                                        <%=listChecked2[i].Title.Substring(0, listChecked2[i].Title.Length - 1)%>
                                        <%} %></a><span><%=listChecked2[i].ReleaseTime.ToString("MM-dd")%></span>
                              </li>
                            <%} %>
                            <%else
                              { %>
                               <li class="HBg"><a href="NewsDetail.aspx?FID=<%=listChecked2[i].ID.ToString() %>"  target="_blank">
                                    <%if (listChecked2[i].Title.Length > 10)
                                      { %>
                                      <%=listChecked2[i].Title.Substring(0, 10)%>...
                                      <%} %>
                                      <%else
                                        { %>
                                            <%=listChecked2[i].Title.Substring(0, listChecked2[i].Title.Length - 1)%><%} %></a><span><%=listChecked2[i].ReleaseTime.ToString("MM-dd")%></span>
                              </li>
                            <%} %>
                        <%} %>
                        <%} %>
                     
                    </ul>
                </div>
                <!--E档案验收信息公布-->
                <div class="Video">
                    <!--S视频-->
                    <%--  <div id="container"></div>                  --%><%--//20141202     --%>   
                    <embed src="js/player.swf" allowfullscreen="true" flashvars="controlbar=over&image=VideoFiles/2.jpg&file=../VideoFiles/<%=url %>" width="246" height="176"/>
                </div>
                <!--E视频-->
                <div class="PIC">
                    <!--S专题栏目图-->
                    <div class="ZTnm02">
                         <a href="NewsDetail.aspx?FID=<%=zhuantiLeft.ID %>" target="_blank">
                            <img src="NewsFile/images/News/<%=zhuantiLeft.PictureURL %>" width="248" height="130" alt="专题" /></a></div>
                    <div>
                        <a href="Consult.aspx?type=1&token=<%=Session["CRSFToken"] %>"  target="_blank">
                            <img src="images/picMailbox.jpg" width="248" height="48" alt="馆长信箱" /></a></div>
                    <div>
                        <a href="Consult.aspx?type=2&token=<%=Session["CRSFToken"] %>"  target="_blank">
                            <img src="images/picComehere.jpg" width="248" height="48" alt="来馆路线" /></a></div>
                    <div class="picTell">
                        <a href="messageList.aspx"  target="_blank">
                            <img src="images/picTell.jpg" width="248" height="83" alt="公共互动" /></a></div>
                </div>
                <!--E专题栏目图-->
            </div>
            <!--E左边内容-->
            <div class="mRight">
                <!--S右边内容-->                
                   <div class="h1News"><!--S行1 工作动态 2014-09-01-->
                	<div class="h1NewsTitle">                    
                          <ul class="titleNews">
                            <li id="zzjs1" onmousemove="setTab('zzjs',1,2)" class="hover"><span>本馆工作动态</span></li>
                            <li id="zzjs2" onmousemove="setTab('zzjs',2,2)"><span>中山城建新闻</span></li>
                          </ul>
                          <div id="banner" class="h1NewsL" style="z-index: 0">
                            <div id="banner_bg">
                            </div>
                            <!--标题背景-->
                            <div id="banner_info" style="background:#E8CA97; color:#3d1300; line-height:25px" >
                            </div>
                        <!--标题-->
                            <ul>
                                <li class="on">1</li>
                                <li>2</li>
                                <li>3</li>
                                <li>4</li>
                                <li>5</li>
                            </ul>
                         
                            <div id="banner_list">
                                <asp:Repeater ID="Tplist" runat="server">
                                    <ItemTemplate>
                                        <a href="NewsDetail.aspx?FID=<%# Eval("ID") %>" target="_blank">
                                            <img src="NewsFile/images/News/<%# Eval("PictureURL") %>" title="<%# Eval("Title") %>"
                                                alt="<%#(Eval("Title"))%>"
                                                width="307" height="193" />
                                        </a>                                 
                                   </ItemTemplate>
                                </asp:Repeater>
                            </div>
                              
                        </div>
                      </div> 
                      <div id="con_zzjs_1" class="h1NewsCon table0 dis_none">
                      	<p class="h1NewsMore"><a href="WorkDynamic.aspx?kind=3"  target="_blank">更多</a></p>                     
                          <div class="h1NewsR">
                            <h3>
                                <%if (listWork.Count >= 1)
                                  { %>
                                <a href="NewsDetail.aspx?FID=<%=listWork[0].ID.ToString() %>"  target="_blank">
                                       <%if (listWork[0].Title.Length > 22)
                                          { %><%=listWork[0].Title.Substring(0, 22)%>......
                                          <%} %><%else
                                            { %><%=listWork[0].Title %><%} %></a>
                                <%} %>
                                <%--<a href="#">中山市“伟人故里，城乡新貌”城建摄影大赛暨城市历... ...</a>--%></h3>
                            <ul>             
                                <%for (int i = 1; i < listWork.Count; i++)
                              {%>
                                  <%if (i % 2 == 0)
                                    {%>
                                    <li class="HBg"><a href="NewsDetail.aspx?FID=<%=listWork[i].ID.ToString() %>"  target="_blank">
                                        <%if (listWork[i].Title.Length > 20)
                                          { %><%=listWork[i].Title.Substring(0, 20)%>...
                                          <%} %>
                                          <%else
                                            { %><%=listWork[i].Title %><%} %></a><span><%=listWork[i].ReleaseTime.ToString("yyyy-MM-dd")%></span>
                                        </li>
                                    <%} %>  
                                    <%else
                                      { %>
                                        <li><a href="NewsDetail.aspx?FID=<%=listWork[i].ID.ToString() %>"  target="_blank">
                                            <%if (listWork[i].Title.Length > 20)
                                          { %><%=listWork[i].Title.Substring(0, 20)%>...
                                          <%} %>
                                          <%else
                                            { %><%=listWork[i].Title %><%} %></a><span><%=listWork[i].ReleaseTime.ToString("yyyy-MM-dd")%></span></li>
                                    
                                    <%} %>                              
                            <%} %>        
                            </ul>
                        </div>
                      </div>
                      <div id="con_zzjs_2" class="h1NewsCon table0 dis_none">
                      	<p class="h1NewsMore"><a href="WorkDynamic.aspx?kind=4"  target="_blank">更多</a></p>                     
                          <div class="h1NewsR">
                            <h3>
                                <%if (listUCNew.Count >= 1)
                                  { %>
                                <a href="NewsDetail.aspx?FID=<%=listUCNew[0].ID.ToString() %>"  target="_blank">
                                       <%if (listUCNew[0].Title.Length > 22)
                                          { %><%=listUCNew[0].Title.Substring(0, 22)%>......
                                          <%} %><%else
                                            { %><%=listUCNew[0].Title%><%} %></a>
                                <%} %>
                                <%--<a href="#">中山市“伟人故里，城乡新貌”城建摄影大赛暨城市历... ...</a>--%></h3>
                            <ul>             
                                <%for (int i = 1; i < listUCNew.Count; i++)
                              {%>
                                  <%if (i % 2 == 0)
                                    {%>
                                    <li class="HBg"><a href="NewsDetail.aspx?FID=<%=listUCNew[i].ID.ToString() %>"  target="_blank">
                                        <%if (listUCNew[i].Title.Length > 20)
                                          { %><%=listUCNew[i].Title.Substring(0, 20)%>...
                                          <%} %>
                                          <%else
                                            { %><%=listUCNew[i].Title%><%} %></a><span><%=listUCNew[i].ReleaseTime.ToString("yyyy-MM-dd")%></span>
                                        </li>
                                    <%} %>  
                                    <%else
                                      { %>
                                        <li><a href="NewsDetail.aspx?FID=<%=listUCNew[i].ID.ToString() %>"  target="_blank">
                                            <%if (listUCNew[i].Title.Length > 20)
                                          { %><%=listUCNew[i].Title.Substring(0, 20)%>...
                                          <%} %>
                                          <%else
                                            { %><%=listUCNew[i].Title%><%} %></a><span><%=listUCNew[i].ReleaseTime.ToString("yyyy-MM-dd")%></span></li>
                                    
                                    <%} %>                              
                            <%} %>        
                            </ul>
                        </div>
                      </div>
              </div><!--E行1 工作动态 2014-09-01-->
                <!--E行1 工作动态-->
                <div class="hand2">
                    <!--S行2-->
                    <%--<div class="h2LGuide">
                        <!--S办事指南-->
                        <h2>
                            <span>办事指南</span><a href="Guide.aspx"  target="_blank">更多</a></h2>
                        <ul>
                            <%for (int i = 0; i < listGuide.Count; i++)
                              {%>
                              <%if ((i + 1) % 2 == 0)
                                { %>
                                  <li class="HBg"><a href="NewsDetail.aspx?FID=<%=listGuide[i].ID.ToString() %>"  target="_blank">
                                     <%if (listGuide[i].Title.Length > 17)
                                              { %><%=listGuide[i].Title.Substring(0, 17)%>...
                                              <%} %><%else
                                                { %><%=listGuide[i].Title%><%} %></a><span><%=listGuide[i].ReleaseTime.ToString("yyyy-MM-dd")%></span>
                                </li>
                                <%} %>
                                <%else{ %>
                                  <li><a href="NewsDetail.aspx?FID=<%=listGuide[i].ID.ToString() %>"  target="_blank">
                                     <%if (listGuide[i].Title.Length > 17)
                                              { %><%=listGuide[i].Title.Substring(0, 17)%>...
                                              <%} %><%else
                                                { %><%=listGuide[i].Title%><%} %></a><span><%=listGuide[i].ReleaseTime.ToString("yyyy-MM-dd")%></span>
                                </li>
                                <%} %>                          
                            <%} %>
                        </ul>
                    </div>--%>   <!--E办事指南-->
                   <div class="h2LGuide"><!--S办事指南 2014-07-24-->
                   <img src="images/BSZN.jpg"  alt="" width="358" height="250" usemap="#Map"/>
                    <map name="Map">
                      <area shape="rect" coords="37,82,211,118" href="guide.aspx?kind=5" target="_blank" title="建设工程档案验收">
                      <area shape="rect" coords="38,145,210,182" href="Guide.aspx?kind=6"  target="_blank" title="地下管线档案验收">
                      <area shape="rect" coords="224,54,314,88" href="Guide.aspx?kind=7" target="_blank" title="档案查阅">
                      <area shape="rect" coords="224,117,318,151" href="Guide.aspx?kind=8" target="_blank" title="档案征集">
                      <area shape="rect" coords="227,185,317,219" href="Guide.aspx?kind=21" target="_blank" title="办公电话">
                    </map>
                  </div><!--E办事指南 2014-07-24-->
                 
                    <div class="h2RDownload">
                        <!--S下载中心-->
                        <h2>
                            <span>下载中心</span><a href="DownLoadField.aspx"  target="_blank">更多</a></h2>
                        <ul>
                            <%for (int i = 0; i < listDown.Count; i++)
                              {%>
                               <%if ((i + 1) % 2 == 0)
                                { %> 
                                <li class="HBg"><a href="DownLoadField.aspx?DID=<%=listDown[i].ID.ToString() %>"  target="_blank">
                                   <%if (listDown[i].FileName.Length > 17)
                                          { %><%=listDown[i].FileName.Substring(0, 17)%>...
                                          <%} %><%else
                                            { %><%=listDown[i].FileName%><%} %></a><span><%=listDown[i].AddTime.ToString("yyyy-MM-dd")%></span>
                                </li>
                                <%} %>
                                <%else{ %>
                                 <li><a href="DownLoadField.aspx?DID=<%=listDown[i].ID.ToString() %>"  target="_blank">
                                   <%if (listDown[i].FileName.Length > 17)
                                          { %><%=listDown[i].FileName.Substring(0, 17)%>...
                                          <%} %><%else
                                            { %><%=listDown[i].FileName%><%} %></a><span><%=listDown[i].AddTime.ToString("yyyy-MM-dd")%></span>
                                </li>
                                <%} %>
                           
                            <%} %>
                        </ul>
                    </div>
                    <!--E下载中心-->
                </div>
                <!--E行2-->
                <div class="hand3">
                    <!--S行3 专题栏目位-->
                     <a href="NewsDetail.aspx?FID=<%=zhuantiRight.ID %>" target="_blank">
                        <img src="NewsFile/images/News/<%=zhuantiRight.PictureURL %>" width="726" height="66" alt="" /></a></div>
                <!--E行3 专题栏目位-->
                <div class="hand4Pic">
                    <!--S行4 网上展览-->
                    <h2>
                        <span>网上展览</span><a href="CityPictures.aspx"  target="_blank">更多</a></h2>
                    <div class="PicCon">
                        <div class="PicL">
                            <a onmousedown="GoAhead()" style="cursor:pointer;">
                                <img src="images/LeftWSZN.jpg" width="21" height="169" alt="" /></a></div>
                        <ul>
                            <%for (int i = 0; i < listPic.Count; i++)
                              {%>
                            <%if (i <= 2)
                              {%>
                            <li id="<%=i %>" value="<%=listPic.Count%>" class="on">
                            <span>
                            <a href="PictureList.aspx?picturetype=<%=listPic[i].Type.ToString()%>"  target="_blank">  
                                <img src="<%=listPic[i].PictureURL.ToString()%>" width="208" height="133" alt="" />
                            </a>                              
                            </span>
                            <a href="PictureList.aspx?picturetype=<%=listPic[i].Type.ToString()%>"  target="_blank">
                                <%=listPic[i].PictureName.ToString()%></a>
                            </li>
                            <%} %>
                            <%else
                                { %>
                            <li style="display: none" id="<%=i %>" value="<%=listPic.Count%>">
                            <span>
                             <a href="PictureList.aspx?picturetype=<%=listPic[i].Type.ToString()%>"  target="_blank">  
                              <img src="<%=listPic[i].PictureURL.ToString()%>" width="208" height="133" alt="" />
                             </a>
                              </span>
                              <a href="PictureList.aspx?picturetype=<%=listPic[i].Type.ToString()%>"  target="_blank">
                                <%=listPic[i].PictureName.ToString()%>
                                </a>
                                </li>
                            <%} %>
                            <%} %>
                        </ul>		                         
                        <div class="PicR">
                            <a onmousedown="GoEnd()"  style="cursor:pointer;">
                                <img src="images/RightWSZN.jpg" width="21" height="169" alt="" /></a></div>
                    </div>
                </div>
                <!--E行4 网上展览-->
                <div class="hand5">
                    <!--S行5-->
                    <div class="h5LPolicies">
                        <h2>
                            <span>法律法规</span><a href="RuleOfLaw.aspx"  target="_blank">更多</a></h2>
                       
                            <%if (listLaw.Count >= 1)
                              {%>
                             <div class="h5LPolNr">
                            <h3><%=listLaw[0].Title.ToString()%></h3>
                            <p class="11">
                                <a href="NewsDetail.aspx?FID= <%=listLaw[0].ID.ToString()%>" id="contentNew"  target="_blank"> 
                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%= content%>
                                </a>
                            </p>
                            </div>
                            <%} %>
                            <ul>
                                <%for (int i = 1; i < listLaw.Count; i++)
                                  { %>
                                   <%if (i % 2 == 0)
                                { %>  
                                 <li class="HBg"><a href="NewsDetail.aspx?FID= <%=listLaw[i].ID.ToString()%>"  target="_blank">
                                      <%if (listLaw[i].Title.Length > 17)
                                          { %><%=listLaw[i].Title.Substring(0, 17)%>...
                                          <%} %><%else
                                            { %><%=listLaw[i].Title%><%} %></a><span><%=listLaw[i].ReleaseTime.ToString("yyyy-MM-dd")%></span>
                                 </li>
                                <%} %>
                                <%else{ %>
                                 <li><a href="NewsDetail.aspx?FID= <%=listLaw[i].ID.ToString()%>"  target="_blank">
                                      <%if (listLaw[i].Title.Length > 17)
                                          { %><%=listLaw[i].Title.Substring(0, 17)%>...
                                          <%} %><%else
                                            { %><%=listLaw[i].Title%><%} %></a><span><%=listLaw[i].ReleaseTime.ToString("yyyy-MM-dd")%></span>
                                 </li>
                                <%} %>                             
                                <%} %>
                            </ul>
                    </div>
                    <!--E行5左 政策法规-->
                    <div class="h5R">
                        <!--S行5右-->
                        <div class="Profession">
                            <!--S学术研究-->
                            <h2>
                                <span>学术研究</span><a href="academicResearch.aspx"  target="_blank">更多</a></h2>
                            <ul>
                                <%for (int i = 0; i < listKnowledge.Count; i++)
                                  { %>
                                   <%if ((i + 1) % 2 == 0)
                                { %>
                                 <li class="HBg"><a href="NewsDetail.aspx?FID= <%=listKnowledge[i].ID.ToString()%>"  target="_blank">
                                       <%if (listKnowledge[i].Title.Length > 17)
                                          { %><%=listKnowledge[i].Title.Substring(0, 17)%>...
                                          <%} %><%else
                                            { %><%=listKnowledge[i].Title%><%} %></a><span><%=listKnowledge[i].ReleaseTime.ToString("yyyy-MM-dd")%></span></li>
                                <%} %>
                                <%else{ %>
                                 <li><a href="NewsDetail.aspx?FID= <%=listKnowledge[i].ID.ToString()%>"  target="_blank">
                                       <%if (listKnowledge[i].Title.Length > 17)
                                          { %><%=listKnowledge[i].Title.Substring(0, 17)%>...
                                          <%} %><%else
                                            { %><%=listKnowledge[i].Title%><%} %></a><span><%=listKnowledge[i].ReleaseTime.ToString("yyyy-MM-dd")%></span></li>
                                <%} %>                               
                                <%} %>
                            </ul>
                        </div>
                        <!--E业务知识-->
                        <div class="Result">
                            <!--S编研成果-->
                            <a href="ResearchResult.aspx" title="编研成果"  target="_blank">
                                <img src="images/PYCG.jpg" width="356" height="132" alt="" /></a></div>
                        <!--E编研成果-->
                    </div>
                    <!--E行5右-->
                </div>
                <!--E行5-->
            </div>
            <!--E右边内容-->
        </div>
        <!--E包含框 左边内容跟右边内容-->
        <div class="clear friendLink">
            <!--S友情链接-->
            <h2>
                友情链接</h2>
            <ul>
            <li>
                <select name="link" onchange="javascript:window.open(this.options[this.selectedIndex].value);">
                    <option value="" selected="selected">政府网站</option>
                    <option value="http://www.gov.cn">中华人民共和国中央人民政府门户网站</option>
                    <option value="http://www.gd.gov.cn">广东省人民政府网</option>
                    <option value="http://www.zs.gov.cn">中山市人民政府</option>
                </select>
            </li>
            <li>
                <select name="link" onchange="javascript:window.open(this.options[this.selectedIndex].value);">
                    <option value="" selected="selected">规划局网站</option>
                    <option value="http://bjcjdag.bjghw.gov.cn">北京市规划委员会</option>
                    <option value="http://www.upo.gov.cn/">广州市规划局</option>
                    <option value="http://www.zsghj.gov.cn">中山市城乡规划局</option>
                </select>
            </li>
            <li>
                <select name="link" onchange="javascript:window.open(this.options[this.selectedIndex].value);">
                    <option value="" selected="selected">档案局网站</option>
                    <option value="http://www.chinaarchives.cn/">中国档案网</option>
                    <option value="http://www.da.gd.gov.cn">广东档案信息网</option>
                    <option value="http://www.zsda.gov.cn">中山市档案信息网</option>
                </select>
            </li>
            <li>
                <select name="link" onchange="javascript:window.open(this.options[this.selectedIndex].value);">
                    <option value="" selected="selected">城建档案馆网站</option>
                    <option value="http://www.gzuda.gov.cn">广州市城建档案馆</option>
                    <option value="http://www.cqcjda.com">重庆市城市建设档案馆</option>
                    <option value="http://www.csccic.com">长沙城建档案馆</option>
                     <option value="http://www.suca.com.cn/">上海城建档案馆</option>
                    <option value="http://www.whcjda.gov.cn/16/">武汉城建档案馆</option>
                    <option value="http://www.zhcjda.com/default.htm">珠海城建档案馆</option>
                </select>
            </li>
        </ul>
        </div>
        <!--E友情链接-->
    </div>
    <!--E中间内容区域-->
</asp:Content>
