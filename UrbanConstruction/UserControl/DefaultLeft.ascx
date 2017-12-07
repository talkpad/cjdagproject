<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DefaultLeft.ascx.cs" Inherits="UrbanConstruction.UserControl.DefaultLeft" %>
<div class="Left">
    <div class="LNav" id="left1" runat="server">
        <h2>
            <%=M_NAME %></h2>
          
 
      <%--  <ul class="LeListCon">
            <asp:Repeater ID="Rplist" runat="server">
                <ItemTemplate>
                    <li><a href="<%# Eval("Url") %>" title='<%# Eval("M_ItemName")%>' class="<%# cl(Eval("M_ItemID")) %>">
                        <%# SZM.Utility.Library.FunHelper.GetString(Eval("M_ItemName"), 24, false)%></a></li></ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="Rplist2" runat="server">
                <ItemTemplate>
                    <li><a href="<%# Eval("LinkUrl") %>" target="showframe" title='<%# Eval("M_ItemName")%>' class="<%# cl(Eval("M_ItemID")) %>">
                        <%# SZM.Utility.Library.FunHelper.GetString(Eval("M_ItemName"), 24, false)%></a></li></ItemTemplate>
            </asp:Repeater>
        </ul>--%>
    </div>
                
    <div class="LPic_01">
        <a href="VideoList.aspx" target="_self" target="_blank">
            <img src="../img/subPage_26.jpg" width="216" height="50" /></a></div>
    <div class="LPic_01" style="margin-bottom: 0px;">
        <a href="MessageList.aspx" target="_self" target="_blank">
            <img src="../img/subPage_28.jpg" width="216" height="50" /></a></div>
</div>
