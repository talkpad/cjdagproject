<%@ Page Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true" CodeBehind="VideoDetail.aspx.cs"
    Inherits="UrbanConstruction.VideoDetail" Title="编研成果" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="js/jwplayer.js" type="text/javascript"></script>
<%--    <script src="js/jwplayer.html5.js" type="text/javascript"></script>--%>
<!--[if gt IE 9]> <script src="js/jwplayer.html5.js" type="text/javascript"></script> <![endif]-->   
    <%--<script type="text/javascript">
        var thePlayer;  //保存当前播放器以便操作
        $(function() {
            thePlayer = jwplayer('container').setup({
                flashplayer: 'js/jwplayer.flash.swf',
                file: 'VideoFiles/<%=url %>',
                width: 700,
                height: 550,
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="middle">
        <!--S中间内容区域-->
         <input type="hidden" id="ssid" name="ssid" runat="server"/>
        <p class="dw">
            您现在的位置： <a href="index.aspx">首页</a>&nbsp;&nbsp;<span>&gt;&gt;</span>&nbsp;&nbsp;
            <%if (menu != null)
              { %><a href="PictureList.aspx?picturetype=<%=picType %>">视频展览</a><%} %>
              <%else
                { %><a href="researchResult.aspx">编研成果</a><%} %>&nbsp;&nbsp;<span>&gt;&gt;</span>&nbsp;&nbsp;<%=Vtitle%>
        </p>
        <div class="Content">
            <div class="ContnetNR" align="center">
              <%--  <div id="container">
                </div>--%><%--20141202--%>
                 <embed src="js/player.swf" allowfullscreen="true" flashvars="controlbar=over&file=../VideoFiles/<%=url %>" width="700" height="550"/>
            </div>
        </div>
        <%--    <input type="button" class="player-play" value="播放" />
                <input type="button" class="player-stop" value="停止" />
                <input type="button" class="player-status" value="取得状态" />
                <input type="button" class="player-current" value="当前播放秒数" />
                <input type="button" class="player-goto" value="转到第30秒播放" />
                <input type="button" class="player-length" value="视频时长(秒)" />--%>
        <%-- <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://active.macromedia.com/flash2/cabs/swflash.cab#version=4,0,0,0"
            width="100%" height="500">
            <param name="enabled" value="-1">
            <param name="PlayCount" VALUE="1">
            <param name="uiMode" value="mini">
            <param name="movie" value="VideoFiles/<%=url %>" />
            <param name="quality" value="high" />
            <embed src="VideoFiles/<%=url %>" loop="false" menu="false" quality="high" width="100%"
              height="500" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash">
            </embed>
        </object>--%>
        <%--   <object id="MediaPlayer" name="MediaPlayer" align="absmiddle" border="0" width="450"
            height="500" classid="CLSID:22D6F312-B0F6-11D0-94AB-0080C74C7E95" codebase="http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=5,1,52,701"
            standby="正在下载播放控件..." type="application/x-oleobject">
            <param name="FileName" value="VideoFiles/<%=url %>">
            <param name="ShowStatusBar" value="True">
            <param name="EnableTracker" value="-1">
            <!--是否允许拉动播放进度条到任意地方播放-->
            <param name="ShowPositionControls" value="True">
            <embed type="application/x-mplayer2" pluginspage="http://www.microsoft.com/Windows/MediaPlayer/"
                name="MediaPlayer" showstatusbar="-1" showpositioncontrols="0" showcaptioning="-1">
                </embed>
        </object>--%>
    </div>
</asp:Content>
