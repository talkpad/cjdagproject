<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCompany.aspx.cs" Inherits="UrbanConstruction.Administrator.EditCompany" %>
<%@ register Assembly="CKEditor.NET" Namespace ="CKEditor.NET" TagPrefix ="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>编辑镇区</title>
    <script type="text/javascript" src="/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/js/Admin/AdminComm.js"></script>
    <script type="text/javascript" src="/js/Admin/EditCompany.js"></script>
</head>
<body style="font-size: small;">
    <form id="form1" runat="server">
    <table width="100%" border="0" align="center" cellpadding="5" cellspacing="1" bgcolor="#B5D0D9">
        <tr>
            <td width="15%" height="23" align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8"
                class="STYLE1">
                镇区名称：
            </td>
            <td width="35%" height="23" align="left" valign="middle" bgcolor="#FFFFFF" class="STYLE1">
                <input name="txtOPass" type="text" id="txtzhenqu" runat="server" style="width: 200px;
                    height: 17px; font-size: 12px; border: solid 1px #ccc;"  maxlength="50"/>
            </td>
            <td width="15%" height="23" align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8"
                class="STYLE1">
                状态：
            </td>
            <td width="35%" height="23" align="left" valign="middle" bgcolor="#FFFFFF" class="STYLE1">
                <asp:DropDownList name="txtOPass" runat="server" ID="DRlist" Style="width: 200px;
                    height: auto">
                    <asp:ListItem Value="2">禁用</asp:ListItem>
                    <asp:ListItem Value="1" Selected="True">启用</asp:ListItem>
                </asp:DropDownList>
                <input name="txtOPass" type="text" runat="server" id="txtpwd" style="width: 200px;
                    height: 17px; font-size: 12px; border: solid 1px #ccc;" visible="false"/>
            </td>
        </tr>
        <tr>
            <td width="15%" height="23" align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8"
                class="STYLE1">
                单位地址：
            </td>
            <td width="35%" height="23" align="left" valign="middle" bgcolor="#FFFFFF" class="STYLE1">
                <input name="txtOPass" type="text" runat="server" id="txtadd" style="width: 200px;
                    height: 17px; font-size: 12px; border: solid 1px #ccc;"  maxlength="50"/>
            </td>
            <td width="15%" height="23" align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8"
                class="STYLE1">
                业务电话：
            </td>
            <td width="35%" height="23" align="left" valign="middle" bgcolor="#FFFFFF" class="STYLE1">
                <input name="txtOPass" type="text" runat="server" id="txttel" style="width: 200px;
                    height: 17px; font-size: 12px; border: solid 1px #ccc;"  maxlength="50"/>
           </td> 
        </tr>
        <tr>
            <td width="15%" height="23" align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8"
                class="STYLE1">
                联系邮箱：
            </td>
            <td width="35%" height="23" align="left" valign="middle" bgcolor="#FFFFFF" class="STYLE1">
                <input name="txtOPass" type="text" id="txtfdren" runat="server" style="width: 200px;
                    height: 17px; font-size: 12px; border: solid 1px #ccc;" />
            </td>
            <td width="15%" height="23" align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8"
                class="STYLE1" maxlength="50">
                显示排序：
            </td>
            <td width="35%" height="23" align="left" valign="middle" bgcolor="#FFFFFF" class="STYLE1">
                <input name="txtOrdering" type="text" id="txtOrdering" runat="server" style="width: 200px;
                    height: 17px; font-size: 12px; border: solid 1px #ccc;" maxlength="5"/>
            </td>
        </tr>
               <tr>
            <td   height="23" align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8"
                class="STYLE1">
                网址：
            </td>
            <td colspan="3" height="23" align="left" valign="middle" bgcolor="#FFFFFF" class="STYLE1">
                <input name="txtWebUrl" type="text" id="txtWebUrl" runat="server" maxlength="100" style="width: 300px;
                    height: 17px; font-size: 12px; border: solid 1px #ccc;" />
            </td>
        </tr> 
        <tr>
            <td width="15%" height="23" align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8" class="STYLE1">
                镇区简介：
            </td>
            <td colspan="3" align="left" valign="middle" bgcolor="#FFFFFF" class="STYLE1">
                <CKEditor:CKEditorControl ID="FCKConten" runat="server" Height="270"></CKEditor:CKEditorControl>
            </td>
        </tr>
        <tr>
            <td width="15%" height="35" align="right" valign="middle" bgcolor="#FFFFFF" class="STYLE1">
                &nbsp;
            </td>
            <td colspan="3" align="left" valign="middle" bgcolor="#FFFFFF" class="STYLE1">
                <asp:Button ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click" Text="提交" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
