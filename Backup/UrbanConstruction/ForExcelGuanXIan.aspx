<%@ Page Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true" CodeBehind="ForExcelGuanXIan.aspx.cs" Inherits="UrbanConstruction.ForExcelGuanXIan" Title="管线工程档案预验收" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <input type="hidden" id="ssid" name="ssid" runat="server"/>
    <div>
      <select id="paramSel" runat="server">
        <option value="0" selected="selected">请选择</option>		
        <option value="1">报建编号</option>
        <option value="2" >工程名称</option> 
        <option value="3">建设单位</option>  
      </select>        
      <input id="valueText" type="text"  size="50" runat="server"/>   
      <input type="submit" id="btn_search"  runat="server" onserverclick="search_click" value="检索"/>
    </div>
    <div><%=excelContent %></div>
</asp:Content>
