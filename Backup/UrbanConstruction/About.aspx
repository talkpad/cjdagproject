<%@ Page Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs"
    Inherits="UrbanConstruction.About" Title="本馆简介" %>
<%@ Register Src="~/UserControl/DefaultFootLeft.ascx" TagName="DefaultFootLeft" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script src="js/jquery-1.9.1.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="middle">
        <!--S中间内容区域-->
        <p class="dw">
            您现在的位置： <a href="index.aspx">首页</a>&nbsp;&nbsp;<span>&gt;&gt;</span>&nbsp;&nbsp;<%=news.Title.ToString() %></p>
        <div class="List">
            <!--S列表内容-->
            <div class="ListL">
                <uc1:DefaultFootLeft ID="DefaultFootLeft1" runat="server" />
            </div>
            <%if (news!=null && news.Kind != 15)
              { %>
            <div class="ListR">
                <!--S中间内容区域-->   
                    <!--S详细内容页-->
                   <div class="ContnetNR1">
                    <h3>
                        <%=news.Title.ToString() %></h3>
                    <hr />
                    <p class="Date">
                        发布日期：<%=news.ReleaseTime.ToString("yyyy-MM-dd") %>&nbsp;&nbsp;&nbsp;&nbsp;发布人：<%=news.Author.ToString() %>
                    </p>
                 
                        <%=news.Content.ToString() %>
                    </div>
                <!--E详细内容页-->
            </div>
            <%} %>
            <%else
                { %>
            <div class="ListR mapb">
                <!--2014-07-15-->
                <div class="map">
                    <!--2014-07-15-->
                    <p style="color: #064c26;">
                        地址：中山市石岐兴中道15号（中山市城市建设档案馆）&nbsp;&nbsp;&nbsp;&nbsp;邮编：528403</p>
                    <!--2014-07-15-->
                    <p style="color: #c0530a; padding-left: 25px;">
                        联系电话：0760-88309788（总机）&nbsp;&nbsp;&nbsp;&nbsp;传真：0760-8162151</p>
                    <!--2014-07-15-->
                    <p style="color: #157d48; padding-left: 70px;">
                        乘车路线：可乘坐&nbsp;&nbsp;10路&nbsp;&nbsp;13路&nbsp;&nbsp;205路&nbsp;&nbsp;23路&nbsp;&nbsp;33路&nbsp;&nbsp;3路&nbsp;&nbsp;50路&nbsp;&nbsp;市政府站下。</p>
                    <!--2014-07-15-->
                </div>
            </div>
            <!--2014-07-15-->
            <%} %>
             <p class="clear">
            </p>
        </div>
        <!--E列表内容-->       
    </div>
    <!--E中间内容区域-->
</asp:Content>
