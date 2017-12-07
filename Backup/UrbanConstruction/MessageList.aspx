<%@ Page Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true" CodeBehind="MessageList.aspx.cs"
    Inherits="UrbanConstruction.MessageList" Title="咨询列表 "%>

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
        <!--S中间内容区域-->
        <p class="dw">
            您现在的位置： <a href="index.aspx">首页</a>&nbsp;&nbsp;<span>&gt;&gt;</span>&nbsp;&nbsp;咨询列表</p>
        <div class="List">
            <!--S列表内容-->
            <div class="ListL">
                <div class="LZCFG">
                    <!--S在线咨询-->
                    <h2>
                        <span>咨询列表</span></h2>
                    <ul>
                        <li><a href="AddMessage.aspx?token=<%=Session["CRSFToken"] %>">我要咨询</a></li>
                    </ul>
                </div>
                <!--E在线咨询-->
                <div class="LPIC">
                    <!--S图片链接-->
                    <div>
                        <a href="Consult.aspx?type=1&token=<%=Session["CRSFToken"] %>" target="_blank">
                            <img src="images/picMailboxB.jpg" width="268" height="48" alt="馆长信箱" /></a></div>
                    <div>
                        <a href="Consult.aspx?type=2&token=<%=Session["CRSFToken"] %>" target="_blank">
                            <img src="images/picComehereB.jpg" width="268" height="48" alt="来馆路线" /></a></div>
                    <div class="picTell">
                        <a href="messageList.aspx" target="_blank">
                            <img src="images/picTellB.jpg" width="268" height="83" alt="公共互动" /></a></div>
                </div>
                <!--E图片链接-->
                <div class="LFriendlink">
        <h2>
            <span>友情链接</span></h2>
        <ul>
            <li>
                <select name="link" onchange="javascript:window.open(this.options[this.selectedIndex].value);">
                    <option value="" selected="selected">政府网站</option>
                    <option value="http://www.gov.cn">中华人民共和国中央人民政府门户网站</option>
                    <option value="http://www.gd.gov.cn">广东省人民政府网</option>
                    <option value="http://www.zs.gov.cn">中山市人民政府</option>
                </select>
            </li>
            <li>
                <select name="link" onchange="javascript:window.open(this.options[this.selectedIndex].value);">
                    <option value="" selected="selected">规划局网站</option>
                    <option value="http://bjcjdag.bjghw.gov.cn">北京市规划委员会</option>
                    <option value="http://www.upo.gov.cn/">广州市规划局</option>
                    <option value="http://www.zsghj.gov.cn">中山市城乡规划局</option>
                </select>
            </li>
            <li>
                <select name="link" onchange="javascript:window.open(this.options[this.selectedIndex].value);">
                    <option value="" selected="selected">档案局网站</option>
                    <option value="http://www.chinaarchives.cn/">中国档案网</option>
                    <option value="http://www.da.gd.gov.cn">广东档案信息网</option>
                    <option value="http://www.zsda.gov.cn">中山市档案信息网</option>
                </select>
            </li>
            <li>
                <select name="link" onchange="javascript:window.open(this.options[this.selectedIndex].value);">
                    <option value="" selected="selected">城建档案馆网站</option>
                    <option value="http://www.gzuda.gov.cn">广州市城建档案馆</option>
                    <option value="http://www.cqcjda.com">重庆市城市建设档案馆</option>
                    <option value="http://www.csccic.com">长沙城建档案馆</option>
                     <option value="http://www.suca.com.cn/">上海城建档案馆</option>
                    <option value="http://www.whcjda.gov.cn/16/">武汉城建档案馆</option>
                    <option value="http://www.zhcjda.com/default.htm">珠海城建档案馆</option>
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
                                                                        编号：
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
                                                                            &nbsp;<img height="15" src="images/guestbook/pc.gif" width="16" alt='<%#Eval("Name")+"的ip是："+  Eval("IP") %>' />&nbsp;&nbsp;                                                                            
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
                                                                                            来自：
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
                                                        <img height="18" src="images/guestbook/14.gif" width="17" />&nbsp;[<%# Eval("PostDate")%>发布]<br />
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
                                                        <img height="18" src="images/guestbook/15.gif" width="17" />&nbsp;[<%# Eval("WritebackDate")%>回复]<br />
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
                            第<span><%=pageIndex %></span>页&nbsp;&nbsp;/&nbsp;&nbsp;共<%=pageCount %>页&nbsp;&nbsp;
                            <%if (pageIndex == 1 || pageIndex == 0)
                              {%>
                            <a href="javascript:void(0);" class="SX">第一页</a>&nbsp;&nbsp; <a href="javascript:void(0);"
                                class="SX">上一页</a>&nbsp;&nbsp;
                            <%} %>
                            <%else
                                { %>
                            <a href="MessageList.aspx?pageIndex=1">第一页</a>&nbsp;&nbsp; <a href="MessageList.aspx?pageIndex=<%=pageIndex-1 %>">
                                上一页</a>&nbsp;&nbsp;
                            <%} %>
                            <%if (pageIndex == pageCount)
                              {%>
                            <a href="javascript:void(0);" class="SX">下一页</a>&nbsp;&nbsp; <a href="javascript:void(0);"
                                class="SX">尾页</a>&nbsp;&nbsp;
                            <%} %>
                            <%else
                                { %>
                            <a href="MessageList.aspx?pageIndex=<%=pageIndex+1 %>">下一页</a>&nbsp;&nbsp; <a href="MessageList.aspx?pageIndex=<%=pageCount %>">
                                尾页</a>&nbsp;&nbsp;
                            <%} %>
                            第<select id="mySelect">
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
                            </select>页</p>
                        
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
