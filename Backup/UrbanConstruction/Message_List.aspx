<%@ Page Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true" CodeBehind="Message_List.aspx.cs"
    Inherits="UrbanConstruction.Message_List" Title="留言列表" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="js/jquery-1.9.1.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            $("#mySelect").change(function() {
                window.location.href = "Message_List.aspx?pageIndex=" + $("#mySelect").val() + "";
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
                        <li><a href="MessageAdd.aspx">我要咨询</a></li>
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
                    <asp:Repeater ID="Rplist" runat="server">
                        <ItemTemplate>
                            <div style="margin-bottom: 8px; border: 1px solid #c6c6c6;">
                                <!--Star 在线咨询列表-->
                                <div style="height: 29px; line-height: 29px; background: url(images/ZXZXList_title.jpg) left top no-repeat;">
                                    <!--Title-->
                                    <h3 style="float: left; padding-left: 27px; width: 225px; height: 29px; color: #3d1300;
                                        font-size: 14px;">
                                        <%# Eval("Name")%></h3>
                                    <p style="float: right; width: 96px; height: 29px;">
                                        <%# Eval("AddTime")%></p>
                                </div>
                                <div style="padding-bottom: 5px; background: url(images/ZXZXList_wenBg.jpg) left top repeat-x #f1f1f1;">
                                    <div style="float: left; width: 35px; height: 35px; background: url(images/ZXZXList_wen.jpg) left top no-repeat;">
                                    </div>
                                    <p style="float: left; padding-top: 5px; width: 690px; line-height: 24px; color: #3d1300;">
                                        &nbsp;&nbsp;<%# Eval("Content").ToString().Replace("\\r\\n","<br/>") %></p>
                                    <div class="clear">
                                    </div>
                                </div>
                                <!--提问-->
                                <div style="border-top: 1px solid #c2c3c4; padding-bottom: 5px;">
                                    <div style="float: left; width: 35px; height: 35px; background: url(images/ZXZXList_ta.jpg) left top no-repeat;">
                                    </div>
                                    <div style="float: left; padding-top: 5px; width: 690px; line-height: 24px; color: #3d1300;">
                                        <%# Eval("Answer").ToString().Replace("\\r\\n","<br/>")%></div>
                                    <div class="clear">
                                    </div>
                                </div>
                                <!--回答-->
                            </div>
                            <!--End 在线咨询列表-->
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <p class="Page">
                    第<span><%=pageIndex %></span>页&nbsp;&nbsp;/&nbsp;&nbsp;共<%=pageCount %>页&nbsp;&nbsp;
                    <%if (pageIndex == 1)
                      {%>
                    <a href="javascript:void(0);" class="SX">第一页</a>&nbsp;&nbsp; <a href="javascript:void(0);"
                        class="SX">上一页</a>&nbsp;&nbsp;
                    <%} %>
                    <%else
                        { %>
                    <a href="Message_List.aspx?pageIndex=1">第一页</a>&nbsp;&nbsp; <a href="Message_List.aspx?pageIndex=<%=pageIndex-1 %>">
                        上一页</a>&nbsp;&nbsp;
                    <%} %>
                    <%if (pageIndex == pageCount)
                      {%>
                    <a href="javascript:void(0);" class="SX">下一页</a>&nbsp;&nbsp; <a href="javascript:void(0);"
                        class="SX">尾页</a>&nbsp;&nbsp;
                    <%} %>
                    <%else
                        { %>
                    <a href="Message_List.aspx?pageIndex=<%=pageIndex+1 %>">下一页</a>&nbsp;&nbsp; <a href="Message_List.aspx?pageIndex=<%=pageCount %>">
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
        <!--E列表内容-->
    </div>
    <!--E中间内容区域-->
</asp:Content>
