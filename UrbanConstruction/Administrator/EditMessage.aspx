<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditMessage.aspx.cs" Inherits="UrbanConstruction.Administrator.EditMessage" %>
<%@ register Assembly="CKEditor.NET" Namespace ="CKEditor.NET" TagPrefix ="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>回复留言</title>
      <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="js/Admin/AdminComm.js"></script>
    <script type="text/javascript" src="js/Admin/EditMessage.js"></script>
</head>
<body style="font-size: small;">
    <form id="form1" runat="server">
    <table width="100%" border="0" align="center" cellpadding="5" cellspacing="1" bgcolor="#B5D0D9">
        <tr>
            <td width="15%" align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8">
                姓名：
            </td>
            <td width="35%" align="left" valign="middle" bgcolor="#FFFFFF">
                <input type="text" name="txtname" id="txtname" runat="server" readonly style="width: 200px;
                    height: 17px; font-size: 12px; border: solid 1px #ccc;" />
            </td>
          <%--  <td width="15%" align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8">
                是否公开：
            </td>
            <td width="35%" align="left" valign="middle" bgcolor="#FFFFFF">
                <asp:RadioButtonList ID="rbgk" runat="server" RepeatDirection="Horizontal" Enabled="false">
                    <asp:ListItem Value="1">公开</asp:ListItem>
                    <asp:ListItem Value="0">不公开</asp:ListItem>
                </asp:RadioButtonList>
            </td>--%>
        </tr>
        <tr>
            <td align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8">
                邮箱：
            </td>
            <td align="left" valign="middle" bgcolor="#FFFFFF">
                <input type="text" readonly name="txtemail" id="txtemail" runat="server" style="width: 200px;
                    height: 17px; font-size: 12px; border: solid 1px #ccc;" />
            </td>
            <td align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8">
                电话：
            </td>
            <td align="left" valign="middle" bgcolor="#FFFFFF">
                <input type="text" readonly name="txttel" id="txttel" runat="server" style="width: 200px;
                    height: 17px; font-size: 12px; border: solid 1px #ccc;" />
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8">
                标题：
            </td>
            <td align="left" valign="middle" bgcolor="#FFFFFF">
                <input type="text" readonly name="txtzhuti" id="txtzhuti" runat="server" style="width: 200px;
                    height: 17px; font-size: 12px; border: solid 1px #ccc;" />
            </td>
            <td align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8">
                地址：
            </td>
            <td align="left" valign="middle" bgcolor="#FFFFFF">
                <input type="text" name="txtname" id="txtaddress" runat="server" readonly style="width: 200px;
                    height: 17px; font-size: 12px; border: solid 1px #ccc;" />
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8">
                内容：
            </td>
            <td colspan="3" align="left" valign="middle" bgcolor="#FFFFFF">
                <textarea id="content_1" name="content2" style="width: 100%; height: 70px;" runat="server"
                    readonly></textarea>
            </td>
        </tr>
        <tr>
       <td align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8">
                状态：
            </td>
            <td colspan="3" align="left" valign="middle" bgcolor="#FFFFFF">
                <asp:RadioButtonList ID="rlistState" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">未审核</asp:ListItem>
                    <asp:ListItem Value="1">审核</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8">
                回复：
            </td>
            <td colspan="3" align="left" valign="middle" bgcolor="#FFFFFF">
                <CKEditor:CKEditorControl ID="FCKConten" runat="server" Height="200" 
                    ResizeMinHeight="200"></CKEditor:CKEditorControl>
            </td>
        </tr>
        <tr>
            <td height="40" colspan="4" align="center" valign="middle" bgcolor="#FFFFFF" class="STYLE1"
                style="padding-left: 60px;">
                <input id="Button1" value="提交" runat="server" onserverclick="BtSava_onserverclick" class="btn" type="button" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
