<%@ Page Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true" CodeBehind="VideoDetail.aspx.cs"
    Inherits="UrbanConstruction.VideoDetail" Title="���гɹ�" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="js/jwplayer.js" type="text/javascript"></script>
<%--    <script src="js/jwplayer.html5.js" type="text/javascript"></script>--%>
<!--[if gt IE 9]> <script src="js/jwplayer.html5.js" type="text/javascript"></script> <![endif]-->   
    <%--<script type="text/javascript">
        var thePlayer;  //���浱ǰ�������Ա����
        $(function() {
            thePlayer = jwplayer('container').setup({
                flashplayer: 'js/jwplayer.flash.swf',
                file: 'VideoFiles/<%=url %>',
                width: 700,
                height: 550,
                dock: false
            });

            //���� ��ͣ
            $('.player-play').click(function() {
                if (thePlayer.getState() != 'PLAYING') {
                    thePlayer.play(true);
                    this.value = '��ͣ';
                } else {
                    thePlayer.play(false);
                    this.value = '����';
                }
            });

            //ֹͣ
            $('.player-stop').click(function() { thePlayer.stop(); });

            //��ȡ״̬
            $('.player-status').click(function() {
                var state = thePlayer.getState();
                var msg;
                switch (state) {
                    case 'BUFFERING':
                        msg = '������';
                        break;
                    case 'PLAYING':
                        msg = '���ڲ���';
                        break;
                    case 'PAUSED':
                        msg = '��ͣ';
                        break;
                    case 'IDLE':
                        msg = 'ֹͣ';
                        break;
                }
                alert(msg);
            });

            //��ȡ���Ž���
            $('.player-current').click(function() { alert(thePlayer.getPosition()); });

            //��ת��ָ��λ�ò���
            $('.player-goto').click(function() {
                if (thePlayer.getState() != 'PLAYING') {    //����ǰδ���ţ�������������
                    thePlayer.play();
                }
                thePlayer.seek(30); //��ָ��λ�ÿ�ʼ����(��λ����)
            });

            //��ȡ��Ƶ����
            $('.player-length').click(function() { alert(thePlayer.getDuration()); });
        });
    </script>--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="middle">
        <!--S�м���������-->
         <input type="hidden" id="ssid" name="ssid" runat="server"/>
        <p class="dw">
            �����ڵ�λ�ã� <a href="index.aspx">��ҳ</a>&nbsp;&nbsp;<span>&gt;&gt;</span>&nbsp;&nbsp;
            <%if (menu != null)
              { %><a href="PictureList.aspx?picturetype=<%=picType %>">��Ƶչ��</a><%} %>
              <%else
                { %><a href="researchResult.aspx">���гɹ�</a><%} %>&nbsp;&nbsp;<span>&gt;&gt;</span>&nbsp;&nbsp;<%=Vtitle%>
        </p>
        <div class="Content">
            <div class="ContnetNR" align="center">
              <%--  <div id="container">
                </div>--%><%--20141202--%>
                 <embed src="js/player.swf" allowfullscreen="true" flashvars="controlbar=over&file=../VideoFiles/<%=url %>" width="700" height="550"/>
            </div>
        </div>
        <%--    <input type="button" class="player-play" value="����" />
                <input type="button" class="player-stop" value="ֹͣ" />
                <input type="button" class="player-status" value="ȡ��״̬" />
                <input type="button" class="player-current" value="��ǰ��������" />
                <input type="button" class="player-goto" value="ת����30�벥��" />
                <input type="button" class="player-length" value="��Ƶʱ��(��)" />--%>
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
            standby="�������ز��ſؼ�..." type="application/x-oleobject">
            <param name="FileName" value="VideoFiles/<%=url %>">
            <param name="ShowStatusBar" value="True">
            <param name="EnableTracker" value="-1">
            <!--�Ƿ������������Ž�����������ط�����-->
            <param name="ShowPositionControls" value="True">
            <embed type="application/x-mplayer2" pluginspage="http://www.microsoft.com/Windows/MediaPlayer/"
                name="MediaPlayer" showstatusbar="-1" showpositioncontrols="0" showcaptioning="-1">
                </embed>
        </object>--%>
    </div>
</asp:Content>
