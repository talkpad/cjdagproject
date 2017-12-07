<%@ Page Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true" CodeBehind="Consult.aspx.cs" Inherits="UrbanConstruction.Consult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="middle">
        <!--S中间内容区域-->
         <input type="hidden" id="ssid" name="ssid" runat="server"/>
        <p class="dw">
            您现在的位置： <a href="index.aspx">首页</a>&nbsp;&nbsp;<span>&gt;&gt;</span>&nbsp;&nbsp;
            <%if(type=="1"){ %>馆长信箱<%} %>
            <%else if (type == "2")
                { %>来馆路线<%} %>
            <%else
                { %>预约电话<%} %></p>
     
            <!--S详细内容页-->
         
             <%if(type=="1")
               { %>
             <div class="Content">
              <div class="ContnetNR">
                <h2> zscjdag@126.com</h2>
              </div>
             </div>           
             <%} %>
                <%else if (type == "2")
                { %>
                   <div class="Content" style="padding-left:5px; padding-right:0px; padding-top:5px; width:983px; min-height:870px; height:auto!important; height:870px;">
                        <div class="map"><!--2014-07-15-->
            	            <p style="color:#064c26;">地址：中山市石岐兴中道15号（中山市城市建设档案馆）&nbsp;&nbsp;&nbsp;&nbsp;邮编：528403</p><!--2014-07-15-->
                            <p style="color:#c0530a; padding-left:37px;">联系电话：0760-8309788（总机）&nbsp;&nbsp;&nbsp;&nbsp;传真：0760-8162151</p><!--2014-07-15-->
                            <p style="color:#157d48; padding-left:90px;">乘车路线：可乘坐&nbsp;&nbsp;10路&nbsp;&nbsp;13路&nbsp;&nbsp;205路&nbsp;&nbsp;23路&nbsp;&nbsp;33路&nbsp;&nbsp;3路&nbsp;&nbsp;50路&nbsp;&nbsp;市政府站下。</p><!--2014-07-15-->
                        </div><!--2014-07-15-->
                  </div>
                <%} %>
                <%else
                { %>                
                   <div class="Content">
                      <div class="ContnetNR">
                        <h2>电话号码</h2>
                      </div>
                     </div>
           
                <%} %>
           
      
        <!--E详细内容页-->
    </div>
</asp:Content>
