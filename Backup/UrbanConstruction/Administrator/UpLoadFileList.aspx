<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpLoadFileList.aspx.cs" Inherits="UrbanConstruction.Administrator.UpLoadFileList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>上传文件列表</title>
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
<script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
<script type="text/javascript" src="js/Admin/AdminComm.js"></script>
<script type="text/javascript" src="js/Admin/UpLoadFileList.js"></script>
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
            window.location.href = "UpLoadFileList.aspx?pageIndex=" + $("#mySelect").val() + "";
            });
        });
    </script>
</head>
<body style="font-size: small;min-width:850px">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table width="100%" border="1" bordercolor="#bccddf" cellspacing="0" cellpadding="0"
        style="border-collapse: collapse;">
        <tr>
            <td width="18%" height="26" align="right" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                文件名：
            </td>
            <td width="32%" height="26">
                <input type="text" name="textfield" id="txttitle" runat="server" style="margin-left: 5px;
                    width: 80%;" />
            </td>
            <td width="18%" height="26" align="right" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                文件类别：
            </td>
            <td width="32%" height="26">
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
            <td width="18%" height="26" align="right" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                上传日期：
            </td>
            <td height="26" width="32%">
                <input type="text" name="textfield5" id="txtdate" runat="server" class="Wdate"
                    style="margin-left: 5px; width:40%;" maxlength="10" />&nbsp;至&nbsp;<input type="text" name="textfield5"
                        id="txtdao" class="Wdate" runat="server" style="margin-left: 5px;
                        width:40%;" maxlength="10"/>
            </td>
            <td width="18%" height="26" align="right" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
            </td>
            <td width="32%" height="26">
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                <asp:Button ID="btnQuery" runat="server" class="btn" Text="查询" OnClick="btnQuery_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" name="reset1" id="reset1" class="btn" value="重置" />
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="5" cellspacing="1" bgcolor="#B5D0D9"
        align="center" class="tiaoshi">
        <tr align="center" bgcolor="#FAFAF1" height="22" style="font-size: 12px; font-weight: bold;">
            <td width="30%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                文件名
            </td>
            <td width="10%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                状态
            </td>
            <td width="13%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                文件类别
            </td>
            <td width="13%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                上传时间
            </td>
            <td width="10%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                操作
            </td>
        </tr>
        <asp:Repeater ID="Rplist" runat="server" OnItemCommand="Rplist_ItemCommand" OnItemDataBound="Rplist_ItemDataBound">
            <ItemTemplate>
                <tr align='center' height="22">
                    <td valign="middle" align="left" style="padding-left: 5px;" title="<%# Eval("FileName") %>">
                        <%# SZM.Utility.Library.FunHelper.GetString(Eval("FileName"), 70, true)%>
                    </td>
                    <td valign="middle" align="left" style="padding-left: 5px;">
                        <%# StopStateName(int.Parse(Eval("State").ToString()))%>
                    </td>
                    <td valign="middle" align="left" style="padding-left: 5px;">
                        <%# GetMenuItemName(Eval("m_ItemID").ToString())%>
                    </td>
                    <td align="center" valign="middle">
                        <%# ((DateTime)(Eval("AddTime"))).ToString("yyyy-MM-dd")%>
                    </td>
                    <td valign="middle">
                        <%--<asp:HyperLink ID="lbtnEdit" identity='<%# Eval("ID")%>' NavigateUrl='<%#Eval("ID", "UpLoadFile.aspx?id={0}")%>'
                            runat="server">修改</asp:HyperLink>--%>
                              <a  href="javascript:void(0)" title="change" onclick="self.parent.addTab('修改<%# Eval("ID")%>','<%#Eval("ID", "UpLoadFile.aspx?id={0}")%>','icon-edit')">修改</a>
                        <asp:LinkButton ID="lbtnDel" CommandArgument='<%# Eval("ID")%>' CommandName="del"
                            runat="server">删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div class="technorati">
          <p class="Page">第<span><%=pageIndex %></span>页&nbsp;&nbsp;/&nbsp;&nbsp;共<%=pageCount %>页&nbsp;&nbsp;
                <%if (pageIndex == 1)
                  {%>
                  <a href="javascript:void(0);" class="SX">第一页</a>&nbsp;&nbsp;
                  <a href="javascript:void(0);" class="SX">上一页</a>&nbsp;&nbsp;
                <%} %>
                <%else
                    { %>
                     <a href="UpLoadFileList.aspx?pageIndex=1">第一页</a>&nbsp;&nbsp;
                     <a href="UpLoadFileList.aspx?pageIndex=<%=pageIndex-1 %>">上一页</a>&nbsp;&nbsp;
                <%} %>
                 <%if (pageIndex == pageCount)
                  {%>
                    <a href="javascript:void(0);" class="SX">下一页</a>&nbsp;&nbsp;
                    <a href="javascript:void(0);"class="SX">尾页</a>&nbsp;&nbsp;
                <%} %>
                <%else
                    { %>
                      <a href="UpLoadFileList.aspx?pageIndex=<%=pageIndex+1 %>">下一页</a>&nbsp;&nbsp;
                      <a href="UpLoadFileList.aspx?pageIndex=<%=pageCount %>">尾页</a>&nbsp;&nbsp;
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
    </div>
    </form>
</body>
</html>
