<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpLoadFile.aspx.cs" Inherits="UrbanConstruction.Administrator.UpLoadFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>文件上传</title>
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
<script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
<script type="text/javascript" src="js/Admin/AdminComm.js"></script>
<script type="text/javascript" src="js/Admin/UpLoadFile.js"></script>
</head>
<body style="font-size:small;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <table width="100%" border="0" align="center" cellpadding="5" cellspacing="1" bgcolor="#B5D0D9">
      <tr>
        <td width="10%" height="25" align="right" valign="middle" colspan="2" nowrap="nowrap" bgcolor="#EBEFF8">文件名称：</td>
        <td width="40%" height="25" align="left" valign="middle" colspan="2" bgcolor="#FFFFFF"><input type="text" name="txttitle" id="txttitle" runat="server"   style="width:200px; height:17px; font-size:12px; border:solid 1px #ccc; " class="validate[required] text-input"/></td>
       
      </tr>
      <tr>
       <td width="10%" height="25" align="right" colspan="2" valign="middle" nowrap="nowrap" bgcolor="#EBEFF8" >文件类别：</td>
        <td width="40%" height="25" align="left" colspan=2 valign="middle" bgcolor="#FFFFFF">
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
        
      </tr>
      <tr>
       <td  align="right" valign="middle" colspan="2"  nowrap="nowrap" bgcolor="#EBEFF8"
                class="STYLE1">
                上传日期：
            </td>
            <td   height="25" colspan="2"  align="left" valign="middle" bgcolor="#FFFFFF" class="STYLE1">
                <input type="text" id="txtdate" runat="server" class="Wdate" maxlength="19" style="width: 300px; height: 18px; font-size: 12px; border: solid 1px #ccc;" />
            </td>
        </tr>
   <tr>
      <td width="10%" height="25" align="right" a valign="middle" colspan="2" nowrap="nowrap" bgcolor="#EBEFF8" >状态：</td>
          <td width="70%" height="25" align="left" colspan="2"  valign="middle" bgcolor="#FFFFFF" >
          <asp:DropDownList ID="DrState" runat="server" style="width:205px; height:27px; font-size:12px; border:solid 1px #ccc; ">
 
        <asp:ListItem Value="1" Selected="True">启用</asp:ListItem>
        <asp:ListItem Value="0">停用</asp:ListItem>
        </asp:DropDownList>
          </td>
      </tr>
      <tr>
        <td width="10%" height="25" align="right" valign="middle" colspan="2" nowrap="nowrap" bgcolor="#EBEFF8" class="STYLE1">
                置顶：
            </td>
            <td width="10%" height="25" align="left" valign="middle" bgcolor="#FFFFFF" class="STYLE1">
                <asp:CheckBox ID="txtZhi" runat="server" />
            </td>
      </tr>
      
     <tr>
      <td width="10%" height="25" align="right" valign="middle" colspan="2" nowrap="nowrap" bgcolor="#EBEFF8" >上传文件：</td>
        <td width="40%" height="25" align="left" valign="middle" colspan="2" bgcolor="#FFFFFF" >
            <asp:FileUpload ID="FileUp" runat="server" Width="214px"/>
            <asp:Button ID="btnUp" runat="server" onclick="btnUp_Click" Text="上传" />
            <span style="color:Red;">上传文件大小为100M以内<br />
            </span>
            <asp:TextBox ID="txtFileFact" ReadOnly="true" runat="server" Width="217px"></asp:TextBox>
         </td>
        
      </tr>
      <tr>
        <td width="10%" height="35" align="right" colspan="2" valign="middle" bgcolor="#FFFFFF" >&nbsp;</td>
        <td height="35" colspan="2" align="left" valign="middle" bgcolor="#FFFFFF" >
             
             <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="提交" onclick="btnSave_Click" />
        </td>
      </tr>
    </table>
     
    </form>
</body>
</html>
