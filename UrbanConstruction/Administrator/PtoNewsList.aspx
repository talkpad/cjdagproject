<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PtoNewsList.aspx.cs" Inherits="UrbanConstruction.Administrator.PtoNewsList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>图片新闻</title>

    <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>

    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>

    <script type="text/javascript" src="js/Admin/AdminComm.js"></script>

    <script type="text/javascript" src="js/Admin/PtoNewsList.js"></script>
    <script type="text/javascript">
        $(function() {
            $('.tiaoshi tr:not(:has("th"))').css('background-color', '#FFFFFF');
            $('.tiaoshi tr:not(:has("th"))').hover(function() {
                $(this).css('background-color', '#FFEEAC');
            },
       function() {
           $(this).css('background-color', '#FFFFFF');
       });
        });
    </script>
        <script type="text/javascript">
        $(document).ready(function() {
            $("#mySelect").change(function() {
            window.location.href = "PtoNewsList.aspx?pageIndex=" + $("#mySelect").val() + "";
            });
        });
    </script>
</head>
<body  style="font-size: small; min-width: 855px">
   <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table width="100%" border="1" bordercolor="#bccddf" cellspacing="0" cellpadding="0"
        style="border-collapse: collapse;">
        <tr>
            <td width="18%" height="26" align="right" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                标题：
            </td>
            <td width="32%" height="26">
                <input type="text" name="textfield" id="txttitle" runat="server" style="margin-left: 5px;
                    width: 80%;" enableviewstate="false" />
            </td>
            <td width="18%" height="26" align="right" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                状态：
            </td>
            <td width="32%" height="26">
                <asp:DropDownList runat="server" ID="ddlist">
                    <asp:ListItem Value="">请选择</asp:ListItem>
                    <asp:ListItem Value="0">未审核</asp:ListItem>
                    <asp:ListItem Value="1">审核</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td width="18%" height="26" align="right" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                发布日期：
            </td>
            <td height="26" width="32%">
                <input type="text" name="textfield5" id="txtdate" runat="server" class="Wdate" maxlength="10"
                    style="margin-left: 5px; width: 120px" />&nbsp;至&nbsp;<input type="text" name="textfield5"
                        id="txtdao" class="Wdate" maxlength="10" runat="server" style="margin-left: 5px;
                        width: 120px" />
            </td>
            <td width="18%" height="26" align="right" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                新闻类型：
            </td>
            <td height="26" width="32%">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="Xdlist" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Xdlistonclick"
                            Width="42%" Height="20">
                        </asp:DropDownList>
                        <asp:DropDownList ID="Ldlist" runat="server" Width="42%" Height="20">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td height="26" colspan="4" align="center" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                <asp:Button ID="btnQuery" runat="server" Text="查询" class="btn" OnClick="btnQuery_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" name="reset1" id="reset1" value="重置" class="btn" />
            </td>
        </tr>
    </table>
        <asp:Repeater ID="Rplist" runat="server" OnItemCommand="Rplist_ItemCommand" OnItemDataBound="Rplist_ItemDataBound">
            <HeaderTemplate>
                <table width="100%" border="0" cellpadding="5" cellspacing="1" bgcolor="#B5D0D9"
                align="center" class="tiaoshi">
                <tr align="center" bgcolor="#FAFAF1" height="18" style="font-size: 12px; font-weight: bold;">
                    <td width="4%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;"
                        id="td1" runat="server">
                        <asp:CheckBox ID="allbox" runat="server" onclick="SelectAll(this)" />
                    </td>
                    <td width="20%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                        标题
                    </td>
                    <td width="10%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                        来源
                    </td>
                    <td width="10%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                        新闻类型
                    </td>
                    <td width="8%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                        状态
                    </td>
                    <td width="10%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                        添加时间
                    </td>
                    <td width="20%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                        操作
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr align='center' height="18">
                <td align="center" id="td2" runat="server">
                    <asp:CheckBox ID="select" runat="server" />
                    <asp:HiddenField ID="hfID" runat="server" Value='<%# Eval("ID") %>' />
                </td>
                <td valign="middle" align="left" style="padding-left: 5px;" title="<%# Eval("Title")%>">
                    <%# SZM.Utility.Library.FunHelper.GetString(Eval("Title"), 30, true)%>
                </td>
                <td align="center" valign="middle" title="<%# Eval("Source")%>">
                    <%# SZM.Utility.Library.FunHelper.GetString(Eval("Source"), 20, true)%>
                </td>
                 <td align="center" valign="middle">
                        <%# GetMenuName(int.Parse(Eval("M_ItemID").ToString()))%>
                    </td>
                    <td align="center" valign="middle">
                        <%# GetState(int.Parse(Eval("State").ToString() ))%>
                    </td>
                <td align="center" valign="middle">
                    <%# DateTime.Parse(Eval("ReleaseTime").ToString()).ToString("yyyy-MM-dd")%>
                </td>
                <td valign="middle">
                  <%--  <asp:HyperLink ID="lbtnEdit"  NavigateUrl='<%#Eval("ID", "EditPtoNews.aspx?id={0}")%>'
                        runat="server">修改</asp:HyperLink>--%>
                      <a  href="javascript:void(0)" title="change" onclick="self.parent.addTab('修改<%# Eval("ID")%>','EditPtoNews.aspx?id=<%# Eval("ID")%>','icon-edit')">修改</a>
                  <%--  <asp:LinkButton ID="lbtnCheck" CommandArgument='<%# Eval("ID")%>' CommandName="check"
                        runat="server">审核</asp:LinkButton>
                    <asp:LinkButton ID="lbtnCancel" CommandArgument='<%# Eval("ID")%>' CommandName="cancel"
                        runat="server">取消审核</asp:LinkButton>--%>
                    <asp:LinkButton ID="lbtnDel" CommandArgument='<%# Eval("ID")%>' CommandName="del"
                        runat="server">删除</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
      <p class="Page">第<span><%=pageIndex %></span>页&nbsp;&nbsp;/&nbsp;&nbsp;共<%=pageCount %>页&nbsp;&nbsp;
                <%if (pageIndex == 1)
                  {%>
                  <a href="javascript:void(0);" class="SX">第一页</a>&nbsp;&nbsp;
                  <a href="javascript:void(0);" class="SX">上一页</a>&nbsp;&nbsp;
                <%} %>
                <%else
                    { %>
                     <a href="PtoNewsList.aspx?pageIndex=1">第一页</a>&nbsp;&nbsp;
                     <a href="PtoNewsList.aspx?pageIndex=<%=pageIndex-1 %>">上一页</a>&nbsp;&nbsp;
                <%} %>
                 <%if (pageIndex == pageCount)
                  {%>
                    <a href="javascript:void(0);" class="SX">下一页</a>&nbsp;&nbsp;
                    <a href="javascript:void(0);"class="SX">尾页</a>&nbsp;&nbsp;
                <%} %>
                <%else
                    { %>
                      <a href="PtoNewsList.aspx?pageIndex=<%=pageIndex+1 %>">下一页</a>&nbsp;&nbsp;
                      <a href="PtoNewsList.aspx?pageIndex=<%=pageCount %>">尾页</a>&nbsp;&nbsp;
                <%} %>
              
                第<select id="mySelect">
                <%for (int i = 0; i < pageCount; i++)
                  {%>
                  <%if ((i + 1) == pageIndex)
                    {%>
                     <option selected="selected"><%=i + 1%></option>
                  <%} %>
                  <%else
                      { %>
                      <option><%=i + 1%></option>
                  <%} %>
                 
                <%} %>
                </select>页</p>
    </form>
</body>
</html>