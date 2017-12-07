<%@ Page Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true" CodeBehind="TwoConstruction.aspx.cs" Inherits="UrbanConstruction.TwoConstruction" Title="专题栏目" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="middle">
        <!--S中间内容区域-->
        <p class="dw">
            您现在的位置： <a href="/index.aspx">首页</a>&nbsp;&nbsp;<span>&gt;&gt;</span>&nbsp;&nbsp;
          两建专题栏目
        </p>
        <div class="Content">
            <!--S详细内容页-->
            <div class="ContnetNR">
             专题内容
            </div>
        </div>
        <!--E详细内容页-->
    </div>
</asp:Content>
