<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPicture.aspx.cs" Inherits="UrbanConstruction.Administrator.EditPicture" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加图片文件</title>

    <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>

    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>

    <script type="text/javascript" src="js/Admin/AdminComm.js"></script>

    <script type="text/javascript" src="js/Admin/EditPicture.js"></script>

</head>
<body style="font-size: small;">
    <form id="form1" runat="server">
    <table width="100%" border="0" align="center" cellpadding="5" cellspacing="1" bgcolor="#B5D0D9">
        <tr>
            <td width="10%" height="25" align="right" valign="middle" colspan="2" nowrap="nowrap"
                bgcolor="#EBEFF8">
                图片名称：
            </td>
            <td width="40%" height="25" align="left" valign="middle" colspan="2" bgcolor="#FFFFFF">
                <input type="text" name="txttitle" id="txttitle" runat="server" style="width: 200px;
                    height: 17px; font-size: 12px; border: solid 1px #ccc;" />
            </td>
        </tr>
        <tr>
            <td width="10%" height="25" align="right" colspan="2" valign="middle" nowrap="nowrap"
                bgcolor="#EBEFF8">
                时间：
            </td>
            <td width="40%" height="25" align="left" colspan="2" valign="middle" bgcolor="#FFFFFF">
                <input type="text" name="txtdate" id="txtdate" maxlength="19" runat="server" class="Wdate"
                    style="width: 200px; height: 17px; font-size: 12px; border: solid 1px #ccc;" />
            </td>
        </tr>
        <tr>
            <td width="10%" height="25" align="right" a valign="middle" colspan="2" nowrap="nowrap"
                bgcolor="#EBEFF8">
                状态：
            </td>
            <td width="70%" height="25" align="left" colspan="2" valign="middle" bgcolor="#FFFFFF">
                <asp:DropDownList ID="DrState" runat="server" Style="width: 205px; height: 27px;
                    font-size: 12px; border: solid 1px #ccc;">
                    <asp:ListItem Value="0">请选择状态</asp:ListItem>
                    <asp:ListItem Value="0">停用</asp:ListItem>
                    <asp:ListItem Value="1">启用</asp:ListItem>
                </asp:DropDownList>
            </td>
         
        </tr>
        <tr>  
        <td width="10%" height="25" align="right" a valign="middle" colspan="2" nowrap="nowrap"
                bgcolor="#EBEFF8">
                类型：
            </td>
           <td width="70%" height="25" align="left" colspan="2" valign="middle" bgcolor="#FFFFFF">
                <asp:DropDownList ID="ddl_type" runat="server" Style="width: 205px; height: 27px;
                    font-size: 12px; border: solid 1px #ccc;">
                    <asp:ListItem Value="0">请选择类型</asp:ListItem>
                    <asp:ListItem Value="1">旧城图</asp:ListItem>
                    <asp:ListItem Value="2">城市记忆</asp:ListItem>
                    <asp:ListItem Value="3">名胜古迹</asp:ListItem>
                     <asp:ListItem Value="4">城市巨变</asp:ListItem>
                    <asp:ListItem Value="5">城市新貌</asp:ListItem>
                    <asp:ListItem Value="6">伟人故里</asp:ListItem>
                    <asp:ListItem Value="7">人居环境</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td width="10%" height="25" align="right" valign="middle" colspan="2" nowrap="nowrap"
                bgcolor="#EBEFF8">
                上传文件：
            </td>
            <td width="40%" height="25" align="left" valign="middle" colspan="2" bgcolor="#FFFFFF">
                <asp:FileUpload ID="FileUp" runat="server" /><span style="color: Red;">上传文件大小为20M以内</span>
            </td>
        </tr>
        <tr>
            <td width="10%" height="35" align="right" colspan="2" valign="middle" bgcolor="#FFFFFF">
                &nbsp;
            </td>
            <td height="35" colspan="2" align="left" valign="middle" bgcolor="#FFFFFF">
                <asp:Button ID="btnSave" Text="提交" runat="server" CssClass="btn" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
