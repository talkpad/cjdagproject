<%@ Page Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="UrbanConstruction.Search" Title="Untitled Page" %>
<%@ Register src="/UserControl/DefaultLeft.ascx" tagname="DefaultLeft" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/content/css/search.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="subPage">
        <uc1:DefaultLeft ID="DefaultLeft1" runat="server" />
        <div class="Right">
            <p class="dw"><span>当前位置:</span><a href="index.aspx">首页</a>-><a href="#">搜索列表</a></p>
            <div class="SubCon">
               <%-- <form id="searchfrm" action="Seach.aspx" method="get">--%>
                    <dl>
                        <dd><input name="keyword" id="txtkeyword" value='<%=keyword %>' class="keyword" />
                            <asp:Button ID="btnSearch" runat="server" Text="搜索" CssClass="tps_btn" OnClick="btnSearch_Click" />
                            <asp:HyperLink ID="SearchResult" runat="server"></asp:HyperLink>
                            <input type="radio" name="sort" style="display:none;" value="time" <%=(sort=="time"?"checked=checked":"") %> />
                            <input type="radio" name="sort" style="display:none;" value="about" <%=(sort)=="about"?"checked=checked":"" %> />
                        </dd>
                    </dl>
                <%--</form>--%>
                <div id="divWhere" runat="server">
                    <table class="tfm" cellpadding="0" cellspacing="0" summary="搜索选项">
                        <tr>
                            <th>搜索选项</th>
                            <td></td>
                        </tr>
                        <tr>
                            <th>类型</th>
                            <td>
                              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                              <ContentTemplate>
                                <asp:DropDownList ID="Xdlist" runat="server" Width="150px" Height="20" AutoPostBack="true"
                                 OnSelectedIndexChanged="Xdlist_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:DropDownList ID="Ldlist" runat="server" Width="150px" Height="20">
                                </asp:DropDownList>
                              </ContentTemplate>
                              </asp:UpdatePanel>
                            </td>
                        </tr>
<%--                        <tr>
                            <th>时间</th>
                            <td>
                                <input type="text" name="textfield5" id="txtdate" runat="server" class="Wdate"  onclick="WdatePicker();"   style="margin-left: 5px; width:120px" />&nbsp;至&nbsp;
                                <input type="text" name="textfield5" id="txtdao" class="Wdate"  onclick="WdatePicker();"  runat="server" style="margin-left: 5px;width:120px" /> 
                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSearchForWhere" Text="执行搜索" CssClass="pn" runat="server" OnClick="btnSearchForWhere_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divResult" runat="server" visible="true">
                     <div id="info">
                        <div style="float:right">
                            找到相关网页约<%=count %>
                            篇，用时<%=time %>秒
                        </div>
                     </div>
                     <div id="result">
                        <%=builder.ToString() %>
                     </div>
                     <div id="pager">
                        <%=pager.Show() %>
                     </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

