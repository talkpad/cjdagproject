<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageList.aspx.cs" Inherits="UrbanConstruction.Administrator.MessageList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
 <title>在线留言</title>
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
<script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
<script type="text/javascript" src="js/Admin/AdminComm.js"></script>
<script type="text/javascript" src="js/Admin/MessageList.js"></script>
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
                  window.location.href = "MessageList.aspx?pageIndex=" + $("#mySelect").val() + "";
              });
          });
    </script>
</head>
<body style="font-size: small;min-width:800px">
    <form id="form1" runat="server">
    <table width="100%" border="1" bordercolor="#bccddf" cellspacing="0" cellpadding="0"
        style="border-collapse: collapse;">
        <tr>
            <td width="18%" height="26" align="right" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                标题：
            </td>
            <td width="32%" height="26">
                <input type="text" name="textfield" id="txttitle" runat="server" style="margin-left: 5px;
                    width: 80%;" />
            </td>
            <td width="18%" height="26" align="right" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                信息状态：
            </td>
            <td width="32%" height="26">
                <asp:DropDownList runat="server" ID="ddlist">
                        <asp:ListItem Value="" Selected="True">未选择</asp:ListItem>
                    <asp:ListItem Value="1">未审核</asp:ListItem>
                    <asp:ListItem Value="3">审核通过</asp:ListItem>
             
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td width="18%" height="26" align="right" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                留言日期：
            </td>
            <td height="26" width="32%">
                <input type="text" name="textfield5" id="txtdate" runat="server" class="Wdate" maxlength="10" 
                    style="margin-left: 5px; width:40%;" />&nbsp;至&nbsp;<input type="text" name="textfield5" id="txtdao"
                        class="Wdate" maxlength="10" runat="server" style="margin-left: 5px;width:40%;" />
            </td>
            <td width="18%" height="26" align="right" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                回复日期：
            </td>
            <td height="26" width="32%">
                <input type="text" name="textfield5" id="txthl" runat="server" class="Wdate" maxlength="10" 
                    style="margin-left: 5px;width:40%;" />&nbsp;至&nbsp;<input type="text" name="textfield5" id="txthd"
                        class="Wdate" maxlength="10" runat="server" style="margin-left: 5px;width:40%;" />
            </td>
        </tr>
        <tr>
            <td width="18%" height="26" align="right" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                回复状态：
            </td>
            <td height="26" width="32%">
                <asp:DropDownList runat="server" ID="Hlist">
                    <asp:ListItem Value="" Selected="True">未选择</asp:ListItem>
                    <asp:ListItem Value="1">已回复</asp:ListItem>
                    <asp:ListItem Value="2">未回复</asp:ListItem>
                </asp:DropDownList>
            </td>
                 <%-- <td  align="right" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                  是否公开：
            </td>
            <td height="26" width="32%">
                <asp:DropDownList runat="server" ID="drpType">
                    <asp:ListItem Value="" Selected="True">未选择</asp:ListItem>
                    <asp:ListItem Value="1">是</asp:ListItem>
                    <asp:ListItem Value="2">否</asp:ListItem>
                </asp:DropDownList>
            </td>--%>
        </tr>
        <tr>
            <td height="26" colspan="4" align="center" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                                <asp:Button ID="btnQuery" runat="server" CssClass="btn" Text="查询" OnClick="btnQuery_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" name="reset1" id="reset1" value="重置" class="btn" />
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="5" cellspacing="1" bgcolor="#B5D0D9"
        align="center" class="tiaoshi">
        <tr align="center" bgcolor="#FAFAF1" height="22" style="font-size: 12px; font-weight: bold;">
            <td width="5%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                编号
            </td>
            <td width="20%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                标题
            </td>
            <td width="10%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                留言时间
            </td>
           <%-- <td width="5%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                公开
            </td>--%>
            <td width="13%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                状态
            </td>
            <td width="13%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                是否回复
            </td>
            <td width="10%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
               回复时间
            </td>
            <td width="24%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                操作
            </td>
        </tr>
        <asp:Repeater ID="Rplist" runat="server" OnItemCommand="Rplist_ItemCommand" OnItemDataBound="Rplist_ItemDataBound">
            <ItemTemplate>
                <tr align='center' height="22">
                    <td valign="middle" style="padding-left: 5px;">
                        <%# Eval("ID")%>
                    </td>
                    <td align="left" valign="middle" title="<%# Eval("Title")%>">
                        <%# SZM.Utility.Library.FunHelper.GetString(Eval("Title"),40,true)%>
                    </td>
                    <td align="center" valign="middle">
                        <%# DateTime.Parse(Eval("PostDate").ToString()).ToString("yyyy-MM-dd")%>
                    </td>
                 <%--   <td align="center" valign="middle">
                        <%#Eval("Type").ToString()=="1"?"是":"否" %>
                    </td>--%>
                    <td align="center" valign="middle">
                        <%# StateName(int.Parse(Eval("State").ToString()))%>
                    </td>
                    <td align="center" valign="middle">
                        <%# AnswerName(Eval("WriteContent"))%>
                    </td>
                    <td align="center" valign="middle">
                        <%#DateTime.Parse(Eval("WriteBackDate").ToString()).ToString("yyyy-MM-dd") == "0001-01-01" ? "" : DateTime.Parse(Eval("WriteBackDate").ToString()).ToString("yyyy-MM-dd")%>
                    </td>
                    <td valign="middle">
                       <a href="javascript:void(0)" title="修改" onclick="self.parent.addTab('修改<%# Eval("ID")%>','EditMessage.aspx?id=<%# Eval("ID")%>','icon-edit')">修改</a>
                   <%--   <asp:HyperLink ID="lbtnEdit" identity='<%# Eval("ID")%>' NavigateUrl='<%#Eval("ID", "EditMessage.aspx?id={0}")%>'  runat="server">回复</asp:HyperLink>
                            
                        <asp:LinkButton ID="lbtnCheck" CommandArgument='<%# Eval("ID")%>' CommandName="check"
                            runat="server">审核</asp:LinkButton>
                        <asp:LinkButton ID="lbtnCancel" CommandArgument='<%# Eval("ID")%>' CommandName="cancel"
                            runat="server">取消审核</asp:LinkButton>--%>
                        <asp:LinkButton ID="lbtnDel" CommandArgument='<%# Eval("ID")%>' CommandName="del"
                            runat="server">删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
      <p class="Page">第<span><%=pageIndex %></span>页&nbsp;&nbsp;/&nbsp;&nbsp;共<%=pageCount %>页&nbsp;&nbsp;
                <%if (pageIndex == 1)
                  {%>
                  <a href="javascript:void(0);" class="SX">第一页</a>&nbsp;&nbsp;
                  <a href="javascript:void(0);" class="SX">上一页</a>&nbsp;&nbsp;
                <%} %>
                <%else
                    { %>
                     <a href="MessageList.aspx?pageIndex=1">第一页</a>&nbsp;&nbsp;
                     <a href="MessageList.aspx?pageIndex=<%=pageIndex-1 %>">上一页</a>&nbsp;&nbsp;
                <%} %>
                 <%if (pageIndex == pageCount)
                  {%>
                    <a href="javascript:void(0);" class="SX">下一页</a>&nbsp;&nbsp;
                    <a href="javascript:void(0);"class="SX">尾页</a>&nbsp;&nbsp;
                <%} %>
                <%else
                    { %>
                      <a href="MessageList.aspx?pageIndex=<%=pageIndex+1 %>">下一页</a>&nbsp;&nbsp;
                      <a href="MessageList.aspx?pageIndex=<%=pageCount %>">尾页</a>&nbsp;&nbsp;
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
