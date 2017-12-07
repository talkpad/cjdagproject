<%@ Page Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true" CodeBehind="PictureList.aspx.cs"
    Inherits="UrbanConstruction.PictureList" Title="网上展览" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/lightbox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="js/jquery.masonry.js"></script>
    <script type="text/javascript" src="js/jquery.infinitescroll.js"></script>
    <script type="text/javascript" src="js/lightbox.js"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            $("#mySelect").change(function() {
            window.location.href = "PictureList.aspx?pageIndex=" + $("#mySelect").val() + "&picturetype=<%=Request.QueryString["picturetype"] %>";
            });
        });
        function item_masonry() {
            $('.item img').load(function() {
                $('.infinite_scroll').masonry({
                    itemSelector: '.masonry_brick',
                    columnWidth: 235,
                    gutterWidth: 10
                });
            });

            $('.infinite_scroll').masonry({
                itemSelector: '.masonry_brick',
                columnWidth: 235,
                gutterWidth: 10
            });
        }

        $(function() {

            function item_callback() {

                $('.item').mouseover(function() {
                    $(this).css('box-shadow', '0 1px 5px rgba(35,25,25,0.5)');
                    $('.btns', this).show();
                }).mouseout(function() {
                    $(this).css('box-shadow', '0 1px 3px rgba(34,25,25,0.2)');
                    $('.btns', this).hide();
                });

                item_masonry();

            }

            item_callback();

            $('.item').fadeIn();

            var sp = 1

            $(".infinite_scroll").infinitescroll({
                navSelector: "#more",
                nextSelector: "#more a",
                itemSelector: ".item",

                loading: {
                    img: "templates/images/masonry_loading_1.gif",
                    msgText: ' ',
                    finishedMsg: '图片加载完毕',
                    finished: function() {
                        sp++;
                        if (sp >= 1) { //到第10页结束事件
                            $("#more").remove();
                            $("#infscr-loading").hide();
                            $("#page").show();
                            $(window).unbind('.infscr');
                        }
                    }
                }, errorCallback: function() {
                    $("#page").show();
                }

            }, function(newElements) {
                var $newElems = $(newElements);
                $('.infinite_scroll').masonry('appended', $newElems, false);
                $newElems.fadeIn();
                item_callback();
                return;
            });

        });
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="middle">
        <!--S中间内容区域-->
        <p class="dw">
            您现在的位置： <a href="index.aspx">首页</a>&nbsp;&nbsp;<span>&gt;&gt;</span><a href="CityPictures.aspx"
                >网上展览</a>&nbsp;&nbsp;<%if (menu != null)
                                                      { %><span>&gt;&gt;</span>&nbsp;&nbsp;<%=menu.M_ItemName.ToString()%><%} %>
                                                       <%else if(isVideo) {%><span>&gt;&gt;</span>&nbsp;&nbsp;视频展览<%} %>
        </p>
        <div class="Content3">
            <div class="ContnetNR3" align="center">
                <div style="height: 10px;">
                </div>
                <div>
                    <!--S列表内容-->
                    <div class="img_list">
                        <div class="item_list infinite_scroll yoxview masonry" style="position: relative;">
                             <%if (!isVideo){ %>                           
                              <%for (int i = 0; i < newsList.Count; i++)
                                { %>
                                 <div class="item masonry_brick masonry-brick" style="position: absolute; top: 0px; left: 0px;">
                                   <div class="item_t">
                                    <div class="img">
                                        <a href="<%=newsList[i].PictureURL.ToString() %>" rel="lightbox[plants]" title="<%=newsList[i].PictureName.ToString() %>"
                                            target="_blank">
                                            <img src="<%=newsList[i].PictureURL.ToString() %>" width="219" height="158" alt="<%=newsList[i].PictureName.ToString() %>" /></a>
                                    </div>
                                    <div class="title">
                                        <span>
                                            <%=newsList[i].PictureName.ToString()%></span></div>
                                    </div>
                                </div>
                            <%} %>
                        <%} %>
                        <%if (isVideo)
                          {%>
                              <%for (int i = 0; i < newlist.Count; i++)
                                { %>
                                 <div class="item masonry_brick masonry-brick" style="position: absolute; top: 0px; left: 0px;">
                                   <div class="item_t">
                                    <div class="img">
                                        <a href="VideoDetail.aspx?FID=<%=newlist[i].ID.ToString()%>&type=<%=typePic %>&token=<%=Session["CRSFToken"] %>"  title="<%=newlist[i].Title.ToString() %>"
                                            target="_blank">
                                            <img src="<%=newlist[i].Pictures.ToString() %>" width="219" height="158" alt="<%=newlist[i].Title.ToString() %>" /></a>
                                    </div>
                                    <div class="title">
                                        <span>
                                            <%=newlist[i].Title.ToString()%></span></div>
                                    </div>
                                </div>
                            <%} %>
                          <%} %>
                        </div>
                    </div>
                    <p class="Page">
                        第<span><%=pageIndex%></span>页&nbsp;&nbsp;/&nbsp;&nbsp;共<%=pageCount %>页&nbsp;&nbsp;
                        <%if (pageIndex == 1)
                          {%>
                        <a href="javascript:void(0);" class="SX">第一页</a>&nbsp;&nbsp; <a href="javascript:void(0);"
                            class="SX">上一页</a>&nbsp;&nbsp;
                        <%} %>
                        <%else
                            { %>
                        <a href="PictureList.aspx?pageIndex=1&picturetype=<%=Request.QueryString["picturetype"] %>">
                            第一页</a>&nbsp;&nbsp; <a href="PictureList.aspx?pageIndex=<%=pageIndex-1 %>&picturetype=<%=Request.QueryString["picturetype"] %>">
                                上一页</a>&nbsp;&nbsp;
                        <%} %>
                        <%if (pageIndex == pageCount)
                          {%>
                        <a href="javascript:void(0);" class="SX">下一页</a>&nbsp;&nbsp; <a href="javascript:void(0);"
                            class="SX">尾页</a>&nbsp;&nbsp;
                        <%} %>
                        <%else
                            { %>
                        <a href="PictureList.aspx?pageIndex=<%=pageIndex+1 %>&picturetype=<%=Request.QueryString["picturetype"] %>">
                            下一页</a>&nbsp;&nbsp; <a href="PictureList.aspx?pageIndex=<%=pageCount %>&picturetype=<%=Request.QueryString["picturetype"] %>">
                                尾页</a>&nbsp;&nbsp;
                        <%} %>
                        第<select id="mySelect">
                            <%for (int i = 0; i < pageCount; i++)
                              {%>
                            <%if ((i + 1) == pageIndex)
                              {%>
                            <option selected="selected">
                                <%=i + 1%></option>
                            <%} %>
                            <%else
                                { %>
                            <option>
                                <%=i + 1%></option>
                            <%} %>
                            <%} %>
                        </select>页
                    </p>
                </div>
              <%if(!isVideo) {%>
               <div id="lightbox" style="top: 184.7px; left: 0px;">
                    <div class="lb-outerContainer" style="width: 620px; height: 420px;">
                        <div class="lb-container" >
                         <%-- <%if (isVideo)
                            {%> 
                                <div class="ContnetNR" align="center">
                                    <div id="container" class = "myVideo">
                                    </div>
                                </div>
                             <%} %>
                            <%else
                              {%>--%>
                                <img class="lb-image" src="" style="display: inline;">
                                <div class="lb-nav" style="display: block;">
                                    <a class="lb-prev" style="display: none;"></a><a class="lb-next" style="display: block;">
                                    </a>
                                </div>
                                <div class="lb-loader" style="display: none;">
                                    <a class="lb-cancel">
                                        <img src="images/loading.gif"></a>
                                </div>
                          <%--  <%} %>--%>
                        </div>
                    </div>
                    <div class="lb-dataContainer" style="display: block; width: 620px;">
                        <div class="lb-data">
                            <div class="lb-details">
                                <span class="lb-caption" style="display: inline;"></span>
                            </div>
                            <div class="lb-closeContainer">
                                <a class="lb-close">
                                    <img src="images/close.png"></a>
                            </div>
                        </div>
                    </div>                   
                </div>
                 <%} %>
            </div>
        </div>
    </div>
</asp:Content>
