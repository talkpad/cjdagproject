<%@ Page Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true" CodeBehind="MessageList.aspx.cs"
    Inherits="UrbanConstruction.MessageList" Title="��ѯ�б� "%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>

    <script src="js/jquery-1.9.1.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            $("#mySelect").change(function() {
            window.location.href = "MessageList.aspx?pageIndex=" + $("#mySelect").val() + "";
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="middle">
        <!--S�м���������-->
        <p class="dw">
            �����ڵ�λ�ã� <a href="index.aspx">��ҳ</a>&nbsp;&nbsp;<span>&gt;&gt;</span>&nbsp;&nbsp;��ѯ�б�</p>
        <div class="List">
            <!--S�б�����-->
            <div class="ListL">
                <div class="LZCFG">
                    <!--S������ѯ-->
                    <h2>
                        <span>��ѯ�б�</span></h2>
                    <ul>
                        <li><a href="AddMessage.aspx?token=<%=Session["CRSFToken"] %>">��Ҫ��ѯ</a></li>
                    </ul>
                </div>
                <!--E������ѯ-->
                <div class="LPIC">
                    <!--SͼƬ����-->
                    <div>
                        <a href="Consult.aspx?type=1&token=<%=Session["CRSFToken"] %>" target="_blank">
                            <img src="images/picMailboxB.jpg" width="268" height="48" alt="�ݳ�����" /></a></div>
                    <div>
                        <a href="Consult.aspx?type=2&token=<%=Session["CRSFToken"] %>" target="_blank">
                            <img src="images/picComehereB.jpg" width="268" height="48" alt="����·��" /></a></div>
                    <div class="picTell">
                        <a href="messageList.aspx" target="_blank">
                            <img src="images/picTellB.jpg" width="268" height="83" alt="��������" /></a></div>
                </div>
                <!--EͼƬ����-->
                <div class="LFriendlink">
        <h2>
            <span>��������</span></h2>
        <ul>
            <li>
                <select name="link" onchange="javascript:window.open(this.options[this.selectedIndex].value);">
                    <option value="" selected="selected">������վ</option>
                    <option value="http://www.gov.cn">�л����񹲺͹��������������Ż���վ</option>
                    <option value="http://www.gd.gov.cn">�㶫ʡ����������</option>
                    <option value="http://www.zs.gov.cn">��ɽ����������</option>
                </select>
            </li>
            <li>
                <select name="link" onchange="javascript:window.open(this.options[this.selectedIndex].value);">
                    <option value="" selected="selected">�滮����վ</option>
                    <option value="http://bjcjdag.bjghw.gov.cn">�����й滮ίԱ��</option>
                    <option value="http://www.upo.gov.cn/">�����й滮��</option>
                    <option value="http://www.zsghj.gov.cn">��ɽ�г���滮��</option>
                </select>
            </li>
            <li>
                <select name="link" onchange="javascript:window.open(this.options[this.selectedIndex].value);">
                    <option value="" selected="selected">��������վ</option>
                    <option value="http://www.chinaarchives.cn/">�й�������</option>
                    <option value="http://www.da.gd.gov.cn">�㶫������Ϣ��</option>
                    <option value="http://www.zsda.gov.cn">��ɽ�е�����Ϣ��</option>
                </select>
            </li>
            <li>
                <select name="link" onchange="javascript:window.open(this.options[this.selectedIndex].value);">
                    <option value="" selected="selected">�ǽ���������վ</option>
                    <option value="http://www.gzuda.gov.cn">�����гǽ�������</option>
                    <option value="http://www.cqcjda.com">�����г��н��赵����</option>
                    <option value="http://www.csccic.com">��ɳ�ǽ�������</option>
                     <option value="http://www.suca.com.cn/">�Ϻ��ǽ�������</option>
                    <option value="http://www.whcjda.gov.cn/16/">�人�ǽ�������</option>
                    <option value="http://www.zhcjda.com/default.htm">�麣�ǽ�������</option>
                </select>
            </li>
        </ul>
    </div>
            </div>
            <div class="ListR">
                <div class="SubCon">
                    <p style="text-align: right;">
                    </p>
                    <div>
                        <div>
                            
                        </div>                                                
                        <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False"
                            ShowHeader="False" Width="100%" AllowPaging="True" DataKeyNames="ID"> 
                        <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                            <tbody>
                                                <tr>
                                                    <td bgcolor="#dff0fb" colspan="2" height="22">
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 50px" align="left" class="style26">
                                                                        ��ţ�
                                                                    </td>
                                                                    <td style="width: 50px" align="left" class="style26">
                                                                        <%# Eval("ID")%>
                                                                    </td>
                                                                    <td>
                                                                        <div align="center">
                                                                            <img height="14" src="images/guestbook/gif-0408.gif" width="18" /></div>
                                                                    </td>
                                                                    <td style="width: 500px" align="left" class="style26">
                                                                        <%# Eval("Title")%>
                                                                    </td>
                                                                    <td>
                                                                        <div align="right">                                                                        
                                                                            &nbsp;<img height="15" src="images/guestbook/pc.gif" width="16" alt='<%#Eval("Name")+"��ip�ǣ�"+  Eval("IP") %>' />&nbsp;&nbsp;                                                                            
                                                                         </div>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px" rowspan="6">
                                                        <span class="style26">
                                                            <br />
                                                        </span>
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <div align="center">
                                                                            <img height="32" src='<%# Eval("Icon", "images/guestbook/{0}") %>' width="32" /></div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div align="center">
                                                                            <span class="style26">
                                                                                <%# Eval("Name") %>
                                                                            </span>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center">
                                                                        <span class="style26">
                                                                            <%# Eval("Sex") %>
                                                                        </span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div align="center">
                                                                            <table cellspacing="0" cellpadding="0" width="80" border="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td>
                                                                                            ���ԣ�
                                                                                        </td>
                                                                                        <td>
                                                                                            <span class="style26">
                                                                                                <%# Eval("Address")%>
                                                                                            </span>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <span class="style26">
                                                            <br />
                                                        </span>
                                                    </td>
                                                    <td style="width: 650px" class="style26" align="left" height="25">
                                                        <img height="18" src="images/guestbook/14.gif" width="17" />&nbsp;[<%# Eval("PostDate")%>����]<br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style26" align="left">
                                                        <%# Eval("content")%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style26" valign="middle" align="left" height="5">
                                                        <img height="1" src="images/guestbook/16.gif" width="100%" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style4" align="left" height="25">
                                                        <img height="18" src="images/guestbook/15.gif" width="17" />&nbsp;[<%# Eval("WritebackDate")%>�ظ�]<br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style4" align="left">
                                                        <%#Eval("WriteContent")%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="middle" align="left" height="5">
                                                        <img height="2" src="images/guestbook/17.gif" width="100%" />
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                        </Columns>
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                        <p class="Page">
                            ��<span><%=pageIndex %></span>ҳ&nbsp;&nbsp;/&nbsp;&nbsp;��<%=pageCount %>ҳ&nbsp;&nbsp;
                            <%if (pageIndex == 1 || pageIndex == 0)
                              {%>
                            <a href="javascript:void(0);" class="SX">��һҳ</a>&nbsp;&nbsp; <a href="javascript:void(0);"
                                class="SX">��һҳ</a>&nbsp;&nbsp;
                            <%} %>
                            <%else
                                { %>
                            <a href="MessageList.aspx?pageIndex=1">��һҳ</a>&nbsp;&nbsp; <a href="MessageList.aspx?pageIndex=<%=pageIndex-1 %>">
                                ��һҳ</a>&nbsp;&nbsp;
                            <%} %>
                            <%if (pageIndex == pageCount)
                              {%>
                            <a href="javascript:void(0);" class="SX">��һҳ</a>&nbsp;&nbsp; <a href="javascript:void(0);"
                                class="SX">βҳ</a>&nbsp;&nbsp;
                            <%} %>
                            <%else
                                { %>
                            <a href="MessageList.aspx?pageIndex=<%=pageIndex+1 %>">��һҳ</a>&nbsp;&nbsp; <a href="MessageList.aspx?pageIndex=<%=pageCount %>">
                                βҳ</a>&nbsp;&nbsp;
                            <%} %>
                            ��<select id="mySelect">
                                <%for (int i = 0; i < pageCount; i++)
                                  {%>
                                <%if ((i + 1) == pageIndex)
                                  {%>
                                <option selected="selected">
                                    <%=i + 1%></option>
                                <%} %>
                                <%else
                                    { %>
                                <option>
                                    <%=i + 1%></option>
                                <%} %>
                                <%} %>
                            </select>ҳ</p>
                        
                    </div>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>

    <script type="text/javascript" src="js/date.js"></script>

    <script type="text/javascript" src="js/jquery.bgiframe.min.js"></script>

    <script type="text/javascript" src="js/jquery.datePicker.min-2.1.2.js"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            Date.format = 'yyyy-mm-dd';
            $('.d1').datePicker({ startDate: '2000-01-01' }); $('.d1').bind('dpClosed', function(e, selectedDates) {
                var d = selectedDates[0]; if (d) {
                    d = new Date(d); $('.d2').dpSetStartDate(d.addDays(1).asString());
                }
            });
            $('.d2').datePicker({ startDate: '2000-01-01' }); $('.d2').bind('dpClosed', function(e, selectedDates) {
                var d = selectedDates[0]; if (d) {
                    d = new Date(d);
                    $('.d1').dpSetEndDate(d.addDays(-1).asString());
                }
            });
        }); 
    </script>

</asp:Content>
