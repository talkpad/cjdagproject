<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookList.aspx.cs" Inherits="UrbanConstruction.Administrator.BookList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>图片列表</title>
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
<script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
<script type="text/javascript" src="js/Admin/AdminComm.js"></script>
<script type="text/javascript" src="js/Admin/BookList.js"></script>
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
            window.location.href = "BookList.aspx?pageIndex=" + $("#mySelect").val() + "";
            });
        });
    </script>
</head>
<body style="font-size: small;min-width:800px">
   <form id="form1" runat="server">
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
                上传时间
            </td>
            <td width="10%" valign="middle" style="background: url(../img/Loginimages/ms_LabelBg.jpg) left top repeat-x #f5f4f4;">
                操作
            </td>
        </tr>
        <asp:Repeater ID="Rplist" runat="server" OnItemCommand="Rplist_ItemCommand" OnItemDataBound="Rplist_ItemDataBound">
            <ItemTemplate>
                <tr align='center' height="22">
                    <td valign="middle" align="left" style="padding-left: 5px;" title="<%# Eval("Title") %>">
                        <%# SZM.Utility.Library.FunHelper.GetString(Eval("Title"), 70, true)%>
                    </td>
                    <td valign="middle" align="left" style="padding-left: 5px;">
                        <%# StopStateName(int.Parse(Eval("State").ToString()))%>
                    </td>
                    <td align="center" valign="middle">
                        <%# ((DateTime)(Eval("ReleaseTime"))).ToString("yyyy-MM-dd")%>
                    </td>
                    <td valign="middle">
                         <%--<asp:HyperLink ID="lbtnEdit" identity='<%# Eval("ID")%>' NavigateUrl='<%#Eval("ID", "EditBook.aspx?id={0}")%>'  runat="server">修改</asp:HyperLink>--%>
                        <a  href="javascript:void(0)" title="change" onclick="self.parent.addTab('修改<%# Eval("ID")%>','<%#Eval("ID", "EditBook.aspx?id={0}")%>','icon-edit')">修改</a>
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
                     <a href="PictureList.aspx?pageIndex=1">第一页</a>&nbsp;&nbsp;
                     <a href="PictureList.aspx?pageIndex=<%=pageIndex-1 %>">上一页</a>&nbsp;&nbsp;
                <%} %>
                 <%if (pageIndex == pageCount)
                  {%>
                    <a href="javascript:void(0);" class="SX">下一页</a>&nbsp;&nbsp;
                    <a href="javascript:void(0);"class="SX">尾页</a>&nbsp;&nbsp;
                <%} %>
                <%else
                    { %>
                      <a href="PictureList.aspx?pageIndex=<%=pageIndex+1 %>">下一页</a>&nbsp;&nbsp;
                      <a href="PictureList.aspx?pageIndex=<%=pageCount %>">尾页</a>&nbsp;&nbsp;
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
