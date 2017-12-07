<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyList.aspx.cs" Inherits="UrbanConstruction.Administrator.CompanyList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>

    <script type="text/javascript" src="js/Admin/AdminComm.js"></script>

    <script type="text/javascript" src="js/Admin/CompanyList.js"></script>
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
</head>
<body style="font-size: small; min-width: 855px">
    <form id="form1" runat="server">
    <table width="100%" border="0" cellpadding="5" cellspacing="1" bgcolor="#B5D0D9"
        align="center" class="tiaoshi">
        <tr align="center" bgcolor="#FAFAF1" height="18" style="font-size: 12px; font-weight: bold;">
            <td width="20%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                镇区
            </td>
            <td width="8%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                状态
            </td>
            <td width="10%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                排序
            </td>
            <td width="20%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                操作
            </td>
        </tr>
        <asp:Repeater ID="Rplist" runat="server">
            <ItemTemplate>
                <tr align='center' height="18">
                    <td align="center" valign="middle" title="<%# Eval("CompanyName")%>">
                        <%# SZM.Utility.Library.FunHelper.GetString(Eval("CompanyName"), 20, true)%>
                    </td>
                    <td align="center" valign="middle">
                        <%# StateName(int.Parse(Eval("State").ToString()))%>
                    </td>
                    <td align="center" valign="middle">
                        <%# Eval("ordering")%>
                    </td>
                    <td valign="middle">
                        <img src="../img/Loginimages/icon_edit.png" height="16px" /><a href="EditCompany.aspx">添加</a>&nbsp;&nbsp;&nbsp;&nbsp;<img
                            src="../img/Loginimages/icon_edit.png" height="16px" /><a href="EditCompany.aspx?id=<%# Eval("CompanyID")%>">修改</a><%# Url(Eval("State").ToString(), int.Parse(Eval("CompanyID").ToString()))%>&nbsp;&nbsp;&nbsp;&nbsp;<img
                                src="../img/Loginimages/icon_del.gif" height="16px" /><a href="CompanyList.aspx?id=<%# Eval("CompanyID")%>&type=del"
                                    onclick="return confirm('删除数据后不能恢复，请确认删除')">删除</a>
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
                     <a href="CompanyList.aspx?pageIndex=1">第一页</a>&nbsp;&nbsp;
                     <a href="CompanyList.aspx?pageIndex=<%=pageIndex-1 %>">上一页</a>&nbsp;&nbsp;
                <%} %>
                 <%if (pageIndex == pageCount)
                  {%>
                    <a href="javascript:void(0);" class="SX">下一页</a>&nbsp;&nbsp;
                    <a href="javascript:void(0);"class="SX">尾页</a>&nbsp;&nbsp;
                <%} %>
                <%else
                    { %>
                      <a href="CompanyList.aspx?pageIndex=<%=pageIndex+1 %>">下一页</a>&nbsp;&nbsp;
                      <a href="CompanyList.aspx?pageIndex=<%=pageCount %>">尾页</a>&nbsp;&nbsp;
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
