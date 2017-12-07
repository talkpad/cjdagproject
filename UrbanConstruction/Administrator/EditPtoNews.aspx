<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPtoNews.aspx.cs" Inherits="UrbanConstruction.Administrator.EditPtoNews" %>
<%@ register Assembly="CKEditor.NET" Namespace ="CKEditor.NET" TagPrefix ="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>图片新闻</title>
    <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
<script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
<script type="text/javascript" src="js/Admin/AdminComm.js"></script>
<script type="text/javascript" src="js/Admin/EditPtoNews.js"></script> 
</head>
<body style="font-size:small;">
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#B5D0D9">
      <tr>
        <td width="15%" height="25" align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8" class="STYLE1">标题：</td>
        <td width="35%" height="25" align="left" valign="middle" bgcolor="#FFFFFF" class="STYLE1"><input type="text" name="txttitle" id="txttitle" runat="server"   style="width:300px; height:18px; font-size:12px; border:solid 1px #ccc; " /></td>
           <td width="15%" height="25" align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8" class="STYLE1">发表日期：</td>
        <td width="35%" height="25" align="left" valign="middle" bgcolor="#FFFFFF" class="STYLE1"><input type="text" id="txtdate" runat="server" class="Wdate" maxlength="19" style="width:300px; height:18px; font-size:12px; border:solid 1px #ccc; "  /></td>
      </tr>
       
      <tr>
      <td width="15%" height="25"  align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8" class="STYLE1">作者：</td>
        <td width="35%" height="25" align="left" valign="middle" bgcolor="#FFFFFF" class="STYLE1"><input type="text" name="txtzuoz"  id="txtzuoz" runat="server"   style="width:300px; height:18px; font-size:12px; border:solid 1px #ccc; " /></td>
       <td width="15%" height="25" align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8" class="STYLE1">来源：</td>
        <td width="35%" height="25" align="left" valign="middle" bgcolor="#FFFFFF" class="STYLE1"><input type="text" name="txtSoure"   id="txtSoure" value="中山市城市建设档案馆" runat="server"   style="width:300px; height:18px; font-size:12px; border:solid 1px #ccc; " /></td>
      </tr>
             <tr>
        <td width="15%" height="25" align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8" class="STYLE1">新闻类别：</td>
        <td width="35%" height="25"   align="left" valign="middle" bgcolor="#FFFFFF" class="STYLE1"> 
                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="Xdlist" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Xdlistonclick"
                            Width="150" Height="20">
                        </asp:DropDownList>
                        <asp:DropDownList ID="Ldlist" runat="server" Width="150" Height="20">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
        </td>
        <td width="15%" height="25" align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8" class="STYLE1">标题图片：</td>
        <td width="35%" height="25"    align="left" valign="middle" bgcolor="#FFFFFF" class="STYLE1">
        <asp:FileUpload ID="m_filTitleImg" runat="server" /> <asp:Button ID="btnUp" runat="server" onclick="btnUp_Click" Text="上传" /><asp:TextBox ID="txtNewsUrl" ReadOnly="true" runat="server"></asp:TextBox></td>
      </tr>
      <tr> 
       <td width="15%" height="25" align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8" class="STYLE1">状态：</td>
        <td width="35%" height="25"   align="left" valign="middle" bgcolor="#FFFFFF" class="STYLE1" >
            <asp:DropDownList runat="server" ID="ddlist">
                <asp:ListItem Value="">请选择</asp:ListItem>
                <asp:ListItem Value="0">未审核</asp:ListItem>
                <asp:ListItem Value="1">审核</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td width="15%" height="25" align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8"
                class="STYLE1">
                标记为站内公告：
            </td>
            <td width="35%" height="25" align="left" valign="middle" bgcolor="#FFFFFF" class="STYLE1">
                <asp:CheckBox ID="txtzhan" runat="server" />
            </td>
            </tr>
            <tr>
            <td width="15%" height="25" align="right" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8" class="STYLE1">置顶：</td>
            <td width="35%" height="25" align="left" valign="middle" bgcolor="#FFFFFF" class="STYLE1">
                <asp:CheckBox ID="txtZhi" runat="server" />
            </td>
      </tr>
<%--      <tr>
           <td width="15%" height="30" align="right" valign="middle" bgcolor="#EBEFF8" class="STYLE1" nowrap="nowrap">
                站外链接：
           </td>
           <td height="30" align="left" valign="middle" bgcolor="#FFFFFF" class="STYLE1" colspan="3">
                <input type="text" name="txtWebUrl" id="txtWebUrl" runat="server" style="width: 700px;
                    height: 18px; font-size: 12px; border: solid 1px #ccc;" />
           </td>
      </tr>--%>
      <tr>
        <td width="15%" height="30" align="right" valign="middle" bgcolor="#EBEFF8" class="STYLE1">文章内容：</td>
        <td  colspan="3" align="left" valign="middle" bgcolor="#FFFFFF" class="STYLE1">
         <CKEditor:CKEditorControl ID="FCKConten" runat="server" Height="300">
        </CKEditor:CKEditorControl>
        </td>
      </tr>
      <tr>
        <td width="15%" height="35" align="right" valign="middle" bgcolor="#FFFFFF" class="STYLE1">&nbsp;</td>
        <td height="35" colspan="3" align="left" valign="middle" bgcolor="#FFFFFF" class="STYLE1">
          &nbsp;<asp:Button ID="btnSave" runat="server" CssClass="btn" onclick="btnSave_Click" 
                Text="保存" />
        </td>
      </tr>
    </table>
</form>
</body>
</html>
