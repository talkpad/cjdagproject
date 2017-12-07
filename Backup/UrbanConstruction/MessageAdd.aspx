<%@ Page Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true" CodeBehind="MessageAdd.aspx.cs" Inherits="UrbanConstruction.MessageAdd" Title="增加留言" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="/js/jquery-1.9.1.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function() {
        $("#mySelect").change(function() {
        window.location.href = "MessageAdd.aspx?pageIndex=" + $("#mySelect").val() + "";
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="middle"><!--S中间内容区域-->
    	<p class="dw">您现在的位置： <a href="index.aspx">首页</a>&nbsp;&nbsp;<span>&gt;&gt;</span>&nbsp;&nbsp;我要咨询</p>
        <div class="List"><!--S列表内容-->	
        	<div class="ListL">
            	 	<div class="LZCFG"><!--S在线咨询-->
                	<h2><span>我要咨询</span></h2>
                	<ul>
                        <li><a href="MessageList.aspx" class="SZ">咨询列表</a></li>
                    </ul>
                </div><!--E在线咨询-->                
              <div class="LPIC"><!--S图片链接-->
                	<div><a href="Consult.aspx?type=1&token=<%=Session["CRSFToken"] %>" target="_blank"><img src="images/picMailboxB.jpg" width="268" height="48"  alt="馆长信箱"/></a></div>
                    <div><a href="Consult.aspx?type=2&token=<%=Session["CRSFToken"] %>" target="_blank"><img src="images/picComehereB.jpg" width="268" height="48"  alt="来馆路线"/></a></div>
                    <div class="picTell"><a href="messageList.aspx" target="_blank"><img src="images/picTellB.jpg" width="268" height="83"  alt="公共互动"/></a></div>
              </div><!--E图片链接-->
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
            <p class="dw">
                <span>当前位置：</span><a href="index.aspx">首页</a>->&nbsp;<a href="#">我要咨询</a></p>
            <div class="SubCon">
                <p style="margin-top: 10px; height: 20px; color: #043173; font-weight: bold;">
                    请输入您的个人资料及联系方式：<span id="spanMsg" style=" color:Red;">(如果选择“不公开”，则E-Mail必须输入)</span></p>
                <table width="100%" border="1" bordercolor="#bccddf" cellspacing="0" cellpadding="0" id="table1"
                    style="border-collapse: collapse;">
                    <tr>
                        <td width="18%" height="26" align="right" style="background-color: #e7eff7;">
                            是否公开问题及答复：
                        </td>
                        <td height="26" colspan="3">
                            <asp:RadioButtonList ID="rblist" runat="server" RepeatDirection="Horizontal" Style="margin-left: 5px;
                                cursor: pointer;">
                                <asp:ListItem Selected="True" Value="1">公开</asp:ListItem>
                                <asp:ListItem Value="0">不公开</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td width="18%" height="26" align="right" style="background-color: #e7eff7;">
                          <span style=" color:Red;">*</span> 姓名：
                        </td>
                        <td width="24%" height="26">
                            <input type="text" name="textfield" id="txtxing" runat="server" style="margin-left: 5px;
                                width: 80%;" class="required"/>
                        </td>
                        <td width="18%" height="26" align="right" style="background-color: #e7eff7;">
                            地址：
                        </td>
                        <td width="40%" height="26">
                            <input type="text" name="txtdi" id="txtdi" runat="server" style="margin-left: 5px;
                                width: 80%;" />
                        </td>
                    </tr>
                    <tr>
                        <td width="18%" height="26" align="right" style="background-color: #e7eff7;">
                            电话/手机：
                        </td>
                        <td width="24%" height="26">
                            <input type="text" name="txtdian" id="txtdian" maxlength="20" runat="server" style="margin-left: 5px;
                                width: 80%;" class="mobile" />
                        </td>
                        <td width="18%" height="26" align="right" style="background-color: #e7eff7;">
                           E-mail：
                        </td>
                        <td width="40%" height="26">
                            <input type="text" name="txtmail" id="txtmail" runat="server" style="margin-left: 5px;
                                width: 80%;" class="email"  maxlength="50"/>
                        </td>
                    </tr>
                    <tr>
                        <td width="18%" height="26" align="right" style="background-color: #e7eff7;">
                            <span style=" color:Red;">*</span>咨询问题：
                        </td>
                        <td width="24%" height="26" colspan="3">
                            <input type="text" name="textfield2" id="txttitle" runat="server" style="margin-left: 5px;
                                width: 80%;" class="required" maxlength="50"/>
                        </td>
                    </tr>
                </table>
                <p style="margin-top: 10px; height: 20px; color: #043173; font-weight: bold;">
                    请输入你需要咨询内容：</p>
                <div>
                    <textarea id="txtcontent" runat="server" rows="12" style="width: 100%;" class="required"></textarea></div>
                <div style="text-align:center;">
                             验证码： <input type="text" name="txtYan" id="txtYan" maxlength="4" runat="server" style="margin-left: 5px;
                                width: 80px" />&nbsp;<div style="display:inline"><a href="#" title="点击换一张" id="yanzheng">
                            <img src="/Handler/VerifyCode.aspx" onclick="this.src+='?'+Math.floor(Math.random()*10);return false;"
                                width="60" height="26" id="btncheck" align="absmiddle" alt=""/></a></div>
                </div>
                <div style="height: 35px; line-height: 35px; text-align: center;">
                   <input type="submit" name="button" id="btn" runat="server" onserverclick="btn_onserverclick"
                        value=" " style="width: 60px; height: 22px; border: none; background: url(/images/btn_tj.jpg) left top no-repeat;
                        cursor: pointer;" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="reset" name="button2" id="button2" value=" " style="width: 60px; height: 22px;
                        border: none; background: url(/images/btn_Sreset.jpg) left top no-repeat; cursor: pointer;" /></div>
            </div>
        </div>
        </div><!--E列表内容-->
    </div><!--E中间内容区域-->
</asp:Content>
