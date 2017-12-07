<%@ Page Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true" CodeBehind="CityPictures.aspx.cs"
    Inherits="UrbanConstruction.CityPictures" Title="网上展览" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/innerPager.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="middle">
        <!--S中间内容区域-->
        <p class="dw">
            您现在的位置： <a href="index.aspx">首页</a>&nbsp;&nbsp;<span>&gt;&gt;</span>&nbsp;&nbsp;网上展览</p>
        <div class="Content2">
            <div class="ContnetNR2" align="center">
                <div style="height: 10px;">
                </div>
                <div class="img_list">
                    <div class="item_list infinite_scroll yoxview masonry" style="position: relative; height: 468px;">
                        <div class="item masonry_brick masonry-brick" style="position: absolute; top: 0px;
                            left: 0px; box-shadow: rgba(34, 25, 25, 0.2) 0px 1px 3px;">
                            <div class="item_t">
                                <div class="img">
                                    <a href="PictureList.aspx?picturetype=<%=NewScenery.Type.ToString() %>" title="城市新貌"
                                        target="_blank">
                                        <img alt="城市新貌" height="158" src="<%=NewScenery.PictureURL.ToString() %>" width="219"></a></div>
                                <div class="title">
                                    <span>城市新貌</span></div>
                            </div>
                        </div>
                        <div class="item masonry_brick masonry-brick" style="position: absolute; top: 0px;
                            left: 240px;">
                            <div class="item_t">
                                <div class="img">
                                    <a href="PictureList.aspx?picturetype=<%=OldView.Type.ToString() %>" title="旧城图"
                                        target="_blank">
                                        <img alt="旧城图" height="158" src="<%=OldView.PictureURL.ToString() %>" width="219"></a></div>
                                <div class="title">
                                    <span>旧城图</span></div>
                            </div>
                        </div>
                        <div class="item masonry_brick masonry-brick" style="position: absolute; top: 0px;
                            left: 480px;">
                            <div class="item_t">
                                <div class="img">
                                    <a href="PictureList.aspx?picturetype=<%=Memory.Type.ToString() %>" title="城市记忆"
                                        target="_blank">
                                        <img alt="城市记忆" height="158" src="<%=Memory.PictureURL.ToString() %>" width="219"></a></div>
                                <div class="title">
                                    <span>城市记忆</span></div>
                            </div>
                        </div>
                        <div class="item masonry_brick masonry-brick" style="position: absolute; top: 0px;
                            left: 720px; box-shadow: rgba(34, 25, 25, 0.2) 0px 1px 3px;">
                            <div class="item_t">
                                <div class="img">
                                    <a href="PictureList.aspx?picturetype=<%=Famous.Type.ToString() %>" title="名胜古迹"
                                        target="_blank">
                                        <img alt="名胜古迹" height="158" src="<%=Famous.PictureURL.ToString() %>" width="219"></a></div>
                                <div class="title">
                                    <span>名胜古迹</span></div>
                            </div>
                        </div>
                        <div class="item masonry_brick masonry-brick" style="position: absolute; top: 217px;
                            left: 0px;">
                            <div class="item_t">
                                <div class="img">
                                    <a href="PictureList.aspx?picturetype=<%=BigChange.Type.ToString() %>" title="城市巨变"
                                        target="_blank">
                                        <img alt="城市巨变" height="158" src="<%=BigChange.PictureURL.ToString() %>" width="219"></a></div>
                                <div class="title">
                                    <span>城市巨变</span></div>
                            </div>
                        </div>
                        <div class="item masonry_brick masonry-brick" style="position: absolute; top: 217px;
                            left: 240px;">
                            <div class="item_t">
                                <div class="img">
                                    <a href="PictureList.aspx?picturetype=<%=GreaterHouse.Type.ToString() %>" title="伟人故里"
                                        target="_blank">
                                        <img alt="伟人故里" height="158" src="<%=GreaterHouse.PictureURL.ToString() %>" width="219"></a>
                                </div>
                                <div class="title">
                                    <span>伟人故里</span></div>
                            </div>
                        </div>
                        <div class="item masonry_brick masonry-brick" style="position: absolute; top: 217px;
                            left: 480px;">
                            <div class="item_t">
                                <div class="img">
                                    <a href="PictureList.aspx?picturetype=<%=LivingEnvironment.Type.ToString() %>" title="人居环境"
                                        target="_blank">
                                        <img alt="人居环境" height="158" src="<%=LivingEnvironment.PictureURL.ToString() %>"
                                            width="219"></a></div>
                                <div class="title">
                                    <span>人居环境</span></div>
                            </div>
                        </div> 
                        <%if (VideoPicture != null){ %>
                        <div class="item masonry_brick masonry-brick" style="position: absolute; top: 217px;
                            left: 720px;">
                            <div class="item_t">
                           
                              
                                <div class="img">
                                    <a href="PictureList.aspx?picturetype=<%=VideoPicture.Kind.ToString() %>" title="视频展览"
                                        target="_blank">
                                        <img alt="视频展览" height="158" src="<%=VideoPicture.Pictures.ToString() %>"
                                            width="219"></a></div>
                                <div class="title">
                                    <span>视频展览</span></div>
                            </div>
                        </div><%} %>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
