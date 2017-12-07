<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UrbanConstruction.Administrator.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>中山市城市建设档案馆后台管理系统-用户登录</title>
<link href="css/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrap">
     <input type="hidden" id="HidUrl" runat="server" />
	<div class="con">
    	<dl>
        	<dt>用户名：</dt>
            <dd style="padding-top:9px; _padding-top:11px;"><input name="name" type="text" class="text"  id="txtname" runat="server" /></dd>
            <dt>密码：</dt>
            <dd style="padding-top:9px; _padding-top:11px;"><input name="" type="password" class="text"  id="txtpwd" runat="server"/></dd>
            <dt>验证码：</dt>
           
            <dd style="width:172px;">
                    <div >
                        <input name="" type="text"   style="width:70px; height:26px;"  id="checkimg" runat="server" /></div>
                    <div style="padding-top:2px;">
                        <a href="#" id="yanzheng">
                            <img src="../Handler/ValidateImageHandler.ashx" onclick="this.src+='?'+Math.floor(Math.random()*10);"
                                width="54" height="26" align="absmiddle" id="btncheck" alt="点击换一张" /></a></div>
                    <div class="login_yzma">
                    </div>
                    <div class="clear">
                    </div>
                </dd>
        </dl>
        <dl class="btn0">
        	<dd class="btn0" style="padding-top:0px; _padding-top:11px;"><input name=" btnlog" type="button" class="btn" value=" " id="btn_Login" runat="server" onserverclick="button_onserverclick"/></dd>
        </dl>
    </div>
    <p class="clear BC">版权所有：中山市城市建设档案馆&nbsp;&nbsp;&nbsp;&nbsp;技术支持：中山市置信信息科技有限公司</p>
</div>
    </form>
</body>
</html>
