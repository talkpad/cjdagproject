<%@ Page Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true" CodeBehind="AddMessage.aspx.cs"
    Inherits="UrbanConstruction.AddMessage" Title="我要咨询" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(function() {
            $("input[id*='submit']").click(function() {
                var name = $("input[id*='txtxing']").val().trim();
                var title = $("input[id*='txttitle']").val().trim();
                var email = $("input[id*='txtmail']").val().trim();
                var dian = $("input[id*='txtdian']").val().trim();
                var content = $("#ctl00_ContentPlaceHolder1_txtcontent").val().trim();
                var sex = $("input[name*='rbl_sex']:checked").val();
                var result = true;
                if ($("input[id*='txtxing']").val().trim() == "") { alert("姓名不能为空"); result = false; }
                if ($("input[id*='txtxing']").val().trim() != "" && $("input[id*='txttitle']").val().trim() == "") { alert("咨询问题不能为空"); result = false; }

                if (email != "") {
                    $.ajax({
                        type: 'post',
                        dataType: "text",
                        url: "AddMessage.aspx",
                        data: "action=comparisonEmail&Email=" + email,
                        cache: false,
                        async: false,
                        success: function(msg) {
                            if (msg == "false") {
                                result = "false";
                                alert("请输入正确的邮箱格式！");
                            }
                        }
                    });
                }
                var VerifyCodeValue = $("input[id*='txtYan']").val().trim();
                $.ajax({
                    type: 'post',
                    dataType: "text",
                    url: "AddMessage.aspx",
                    data: "action=comparisonCode&VerifyCode=" + VerifyCodeValue,
                    cache: false,
                    async: false,
                    success: function(msg) {
                        if (msg == "false") {
                            alert("验证码输入有误!");
                            result = false;
                            $("#btncheck").trigger("click");
                            $("#txtYan").val("");
                        }
                        else if (result == true) {
                            $.ajax({
                                type: 'post',
                                dataType: "text",
                                url: "AddMessage.aspx",
                                data: "action=btnsubmit&token=<%=GetTokenFromRequest() %>&name=" + name + "&title=" + title + "&email=" + email + "&dian=" + dian + "&content=" + content + "&sex=" + sex + "",
                                cache: false,
                                async: false,
                                success: function(msg) {
                                    if (msg == "true") {
                                        alert("留言成功");
                                        $("#btncheck").trigger("click");
                                        $("input[id*='txtxing']").val("");
                                        $("input[id*='txttitle']").val("");
                                        $("input[id*='txtmail']").val("");
                                        $("input[id*='txtdian']").val("");
                                        $("input[id*='txtYan']").val("");
                                    }
                                    else {
                                        alert("出于安全考虑，请重新进入留言页面！");
                                        window.location.href = "index.aspx";
                                    }
                                }
                            });
                        }
                    }
                });
            });
            $("input[id*='clearbtn']").click(function() {
                $("input[id*='txtxing']").val("");
                $("input[id*='txttitle']").val("");
                $("input[id*='txtmail']").val("");
                $("input[id*='txtdian']").val("");
                $("input[id*='txtYan']").val("");
            });
        });
        String.prototype.trim = function() {
            return this.replace(/(^\s*)|(\s*$)/g, "");
        }  
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="middle">
        <!--S中间内容区域-->
        <input type="hidden" id="ssid" name="ssid" runat="server" />
        <p class="dw">
            您现在的位置： <a href="index.aspx">首页</a>&nbsp;&nbsp;<span>&gt;&gt;</span>&nbsp;&nbsp;我要咨询</p>
        <div class="List">
            <!--S列表内容-->
            <div class="ListL">
                <div class="LZCFG">
                    <!--S在线咨询-->
                    <h2>
                        <span>我要咨询</span></h2>
                    <ul>
                        <li><a href="MessageList.aspx">咨询列表</a></li>
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
                    <table width="100%" border="1" bordercolor="#bccddf" cellspacing="0" cellpadding="0"
                        id="table1" style="border-collapse: collapse;">
                        <tr>
                            <td width="18%" height="26" align="right" style="background-color: #e7eff7;">
                                <span style="color: Red;">*</span> 姓名：
                            </td>
                            <td width="24%" height="26">
                                <input type="text" name="textfield" id="txtxing" runat="server" style="margin-left: 5px;
                                    width: 80%;" class="required" />
                            </td>
                        </tr>
                        <tr>
                            <td width="18%" height="26" align="right" style="background-color: #e7eff7;">
                                性别：
                            </td>
                            <td height="20" width="40%">
                                <asp:RadioButtonList ID="rbl_sex" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="0" Selected="True">保密</asp:ListItem>
                                    <asp:ListItem Value="1">男</asp:ListItem>
                                    <asp:ListItem Value="2">女</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td width="18%" height="26" align="right" style="background-color: #e7eff7;">
                                Email：
                            </td>
                            <td width="24%" height="26">
                                <input type="text" name="txtmail" id="txtmail" runat="server" style="margin-left: 5px;
                                    width: 80%;" class="email" maxlength="50" />
                            </td>
                        </tr>
                        <tr>
                            <td width="18%" height="26" align="right" style="background-color: #e7eff7;">
                                地址：
                            </td>
                            <td class="NormalText" height="20" width="40%">
                                <asp:DropDownList ID="where_field" runat="server" Width="130px">
                                    <asp:ListItem Value="广东省">广东省</asp:ListItem>
                                    <asp:ListItem Value="中山市">┣中山市</asp:ListItem>
                                    <asp:ListItem Value="东区">┣━东区</asp:ListItem>
                                    <asp:ListItem Value="南区">┣━南区</asp:ListItem>
                                    <asp:ListItem Value="西区">┣━西区</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="石岐区">┣━石岐区</asp:ListItem>
                                    <asp:ListItem Value="港口镇">┣━港口镇</asp:ListItem>
                                    <asp:ListItem Value="沙溪镇">┣━沙溪镇</asp:ListItem>
                                    <asp:ListItem Value="板芙镇">┣━板芙镇</asp:ListItem>
                                    <asp:ListItem Value="黄圃镇">┣━黄圃镇</asp:ListItem>
                                    <asp:ListItem Value="东升镇">┣━东升镇</asp:ListItem>
                                    <asp:ListItem Value="南朗镇">┣━南朗镇</asp:ListItem>
                                    <asp:ListItem Value="小榄镇">┣━小榄镇</asp:ListItem>
                                    <asp:ListItem Value="三乡镇">┣━三乡镇</asp:ListItem>
                                    <asp:ListItem Value="三角镇">┣━三角镇</asp:ListItem>
                                    <asp:ListItem Value="火炬开发区">┣━火炬开发区</asp:ListItem>
                                    <asp:ListItem Value="大涌镇">┣━大涌镇</asp:ListItem>
                                    <asp:ListItem Value="横栏镇">┣━横栏镇</asp:ListItem>
                                    <asp:ListItem Value="坦洲镇">┣━坦洲镇</asp:ListItem>
                                    <asp:ListItem Value="南头镇">┣━南头镇</asp:ListItem>
                                    <asp:ListItem Value="神湾镇">┣━神湾镇</asp:ListItem>
                                    <asp:ListItem Value="古镇镇">┣━古镇镇</asp:ListItem>
                                    <asp:ListItem Value="东风镇">┣━东凤镇</asp:ListItem>
                                    <asp:ListItem Value="民众镇">┣━民众镇</asp:ListItem>
                                    <asp:ListItem Value="五桂山镇">┣━五桂山镇</asp:ListItem>
                                    <asp:ListItem Value="阜沙镇">┣━阜沙镇</asp:ListItem>
                                    <asp:ListItem Value="广州市">┣广州市</asp:ListItem>
                                    <asp:ListItem Value="深圳市">┣深圳市</asp:ListItem>
                                    <asp:ListItem Value="东莞市">┣东莞市</asp:ListItem>
                                    <asp:ListItem Value="珠海市">┣珠海市</asp:ListItem>
                                    <asp:ListItem Value="汕头市">┣汕头市</asp:ListItem>
                                    <asp:ListItem Value="惠州市">┣惠州市</asp:ListItem>
                                    <asp:ListItem Value="顺德市">┣顺德市</asp:ListItem>
                                    <asp:ListItem Value="江门市">┣江门市</asp:ListItem>
                                    <asp:ListItem Value="佛山市">┣佛山市</asp:ListItem>
                                    <asp:ListItem Value="南海市">┣南海市</asp:ListItem>
                                    <asp:ListItem Value="韶关市">┣韶关市</asp:ListItem>
                                    <asp:ListItem Value="河源市">┣河源市</asp:ListItem>
                                    <asp:ListItem Value="梅州市">┣梅州市</asp:ListItem>
                                    <asp:ListItem Value="汕尾市">┣汕尾市</asp:ListItem>
                                    <asp:ListItem Value="阳江市">┣阳江市</asp:ListItem>
                                    <asp:ListItem Value="湛江市">┣湛江市</asp:ListItem>
                                    <asp:ListItem Value="茂名市">┣茂名市</asp:ListItem>
                                    <asp:ListItem Value="肇庆市">┣肇庆市</asp:ListItem>
                                    <asp:ListItem Value="清远市">┣清远市</asp:ListItem>
                                    <asp:ListItem Value="潮州市">┣潮州市</asp:ListItem>
                                    <asp:ListItem Value="揭阳市">┣揭阳市</asp:ListItem>
                                    <asp:ListItem Value="云浮市">┣云浮市</asp:ListItem>
                                    <asp:ListItem Value="上海市">┣上海市</asp:ListItem>
                                    <asp:ListItem Value="北京市">┣北京市</asp:ListItem>
                                    <asp:ListItem Value="天津市">┣天津市</asp:ListItem>
                                    <asp:ListItem Value="重庆市">┣重庆市</asp:ListItem>
                                    <asp:ListItem Value="河北省">河北省</asp:ListItem>
                                    <asp:ListItem Value="山西省">山西省</asp:ListItem>
                                    <asp:ListItem Value="内蒙古">内蒙古</asp:ListItem>
                                    <asp:ListItem Value="辽宁省">辽宁省</asp:ListItem>
                                    <asp:ListItem Value="吉林省">吉林省</asp:ListItem>
                                    <asp:ListItem Value="黑龙江">黑龙江</asp:ListItem>
                                    <asp:ListItem Value="江苏省">江苏省</asp:ListItem>
                                    <asp:ListItem Value="浙江省">浙江省</asp:ListItem>
                                    <asp:ListItem Value="安徽省">安徽省</asp:ListItem>
                                    <asp:ListItem Value="福建省">福建省</asp:ListItem>
                                    <asp:ListItem Value="江西省">江西省</asp:ListItem>
                                    <asp:ListItem Value="山东省">山东省</asp:ListItem>
                                    <asp:ListItem Value="河南省">河南省</asp:ListItem>
                                    <asp:ListItem Value="湖北省">湖北省</asp:ListItem>
                                    <asp:ListItem Value="湖南省">湖南省</asp:ListItem>
                                    <asp:ListItem Value="广　西">广 西</asp:ListItem>
                                    <asp:ListItem Value="四川省">四川省</asp:ListItem>
                                    <asp:ListItem Value="贵州省">贵州省</asp:ListItem>
                                    <asp:ListItem Value="云南省">云南省</asp:ListItem>
                                    <asp:ListItem Value="西　藏">西 藏</asp:ListItem>
                                    <asp:ListItem Value="陕西省">陕西省</asp:ListItem>
                                    <asp:ListItem Value="甘肃省">甘肃省</asp:ListItem>
                                    <asp:ListItem Value="青海省">青海省</asp:ListItem>
                                    <asp:ListItem Value="宁　夏">宁 夏</asp:ListItem>
                                    <asp:ListItem Value="新　疆">新 疆</asp:ListItem>
                                    <asp:ListItem Value="海南省">海南省</asp:ListItem>
                                    <asp:ListItem Value="香　港">香 港</asp:ListItem>
                                    <asp:ListItem Value="台湾省">台湾省</asp:ListItem>
                                    <asp:ListItem Value="澳　门">澳 门</asp:ListItem>
                                    <asp:ListItem Value="国　外">国 外</asp:ListItem>
                                    <asp:ListItem Value="其　他">其 他</asp:ListItem>
                                </asp:DropDownList>
                                (选择所在地区,市内要选到镇区,市外要选到市)
                            </td>
                        </tr>
                        <tr>
                            <td width="18%" height="26" align="right" style="background-color: #e7eff7;">
                                头像
                            </td>
                            <td height="127" width="82%">
                                <label>
                                    <span class="NormalText">
                                        <asp:RadioButtonList ID="rbl_face" runat="server" RepeatColumns="6" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="face01.gif"><img src="images/guestbook/face01.gif" /></asp:ListItem>
                                            <asp:ListItem Value="face02.gif"><img src="images/guestbook/face02.gif" /></asp:ListItem>
                                            <asp:ListItem Value="face03.gif"><img src="images/guestbook/face03.gif" /></asp:ListItem>
                                            <asp:ListItem Value="face04.gif"><img src="images/guestbook/face04.gif" /></asp:ListItem>
                                            <asp:ListItem Value="face05.gif"><img src="images/guestbook/face05.gif" /></asp:ListItem>
                                            <asp:ListItem Value="face06.gif"><img src="images/guestbook/face06.gif" /></asp:ListItem>
                                            <asp:ListItem Value="face07.gif"><img src="images/guestbook/face07.gif" /></asp:ListItem>
                                            <asp:ListItem Value="face08.gif"><img src="images/guestbook/face08.gif" /></asp:ListItem>
                                            <asp:ListItem Value="face09.gif"><img src="images/guestbook/face09.gif" /></asp:ListItem>
                                            <asp:ListItem Value="face10.gif"><img src="images/guestbook/face10.gif" /></asp:ListItem>
                                            <asp:ListItem Value="face11.gif"><img src="images/guestbook/face11.gif" /></asp:ListItem>
                                            <asp:ListItem Value="face12.gif"><img src="images/guestbook/face12.gif" /></asp:ListItem>
                                            <asp:ListItem Value="face13.gif"><img src="images/guestbook/face13.gif" /></asp:ListItem>
                                            <asp:ListItem Value="face14.gif"><img src="images/guestbook/face14.gif" /></asp:ListItem>
                                            <asp:ListItem Value="face15.gif"><img src="images/guestbook/face15.gif" /></asp:ListItem>
                                            <asp:ListItem Value="face16.gif"><img src="images/guestbook/face16.gif" /></asp:ListItem>
                                            <asp:ListItem Value="face00.gif" Selected="True">不使用</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </span>
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <td width="18%" height="26" align="right" style="background-color: #e7eff7;">
                                电话/手机：
                            </td>
                            <td width="82%" height="26">
                                <input type="text" name="txtdian" id="txtdian" maxlength="20" runat="server" style="margin-left: 5px;
                                    width: 80%;" class="mobile" />
                            </td>
                        </tr>
                        <tr>
                            <td width="18%" height="26" align="right" style="background-color: #e7eff7;">
                                <span style="color: Red;">*</span>咨询问题：
                            </td>
                            <td width="24%" height="26" colspan="3">
                                <input type="text" name="textfield2" id="txttitle" runat="server" style="margin-left: 5px;
                                    width: 80%;" class="required" maxlength="50" />
                            </td>
                        </tr>
                    </table>
                    <p style="margin-top: 10px; height: 20px; color: #043173; font-weight: bold;">
                        请输入你需要咨询内容：</p>
                    <div>
                        <textarea id="txtcontent" runat="server" rows="12" style="width: 100%;" class="required"></textarea>
                    </div>
                    <div style="text-align: center;">
                        验证码：
                        <input type="text" name="txtYan" id="txtYan" maxlength="4" runat="server" style="margin-left: 5px;
                            width: 80px" />&nbsp;<div style="display: inline">
                                <a href="#" title="点击换一张" id="yanzheng">
                                    <img src="Handler/VerifyCode.aspx" onclick="this.src+='?'+Math.floor(Math.random()*10);return false;"
                                        width="60" height="26" id="btncheck" align="absmiddle" alt="" /></a></div>
                    </div>
                    <div style="height: 35px; line-height: 35px; text-align: center;">
                        <input type="button" name="button" id="submit" runat="server" value=" " style="width: 60px;
                            height: 22px; border: none; background: url(images/btn_tj.jpg) left top no-repeat;
                            cursor: pointer;" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <input type="button" name="button" id="clearbtn" value=" " style="width: 60px; height: 22px;
                            border: none; background: url(images/btn_Sreset.jpg) left top no-repeat; cursor: pointer;" />
                    </div>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
