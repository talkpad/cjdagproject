function setHomepage() { // 设置首页
    if (document.all) {
        document.body.style.behavior = 'url(#default#homepage)';
        document.body.setHomePage('http://www.zssf.gov.cn');
    } else if (window.sidebar) {
        if (window.netscape) {
            try {
                netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
            } catch (e) {
                alert("该操作被浏览器拒绝，如果想启用该功能，请在地址栏内输入 about:config,然后将项 signed.applets.codebase_principal_support 值改为true");
            }
        }
        var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch);
        prefs.setCharPref('browser.startup.homepage', 'http://www.zssf.gov.cn');
    }
}

function setTab(name, cursel, n) {
    for (i = 1; i <= n; i++) {
        var menu = document.getElementById(name + i); /* xxk1 */
        var con = document.getElementById("con_" + name + "_" + i); /* con_xxk_1 */
        menu.className = i == cursel ? "hover" : ""; /*三目运算 等号优先*/
        con.style.display = i == cursel ? "block" : "none";
    }
}

 
//关闭
function closeWin() {
    //IE
    window.open('', '_parent', '');
    window.close();
    //FF
    window.parent.top.close();
}

$(function() {
    //清空
    $("#rest").click(function() {
        $("#username").val("");
        $("#pwd").val("");
        $("#sp").text("");
    }); //rest End
    $("#samll967>a").attr("target", "_blank");
    $("#samll969 a").attr("target", "_blank");
    //$("#samll969>a").click(function() { return false; });
    $("#samll963>a").attr("target", "_blank");
    $("#samll957 li:first").next().find("a").attr("target", "_blank");

    //登录
    $("#denglu").click(function() {
        //        var user = $("#username").val();
        //        var pwd = $("#pwd").val();
        //        if ($.trim(user) == "" || $.trim(user) == "undefined") {
        //            $("#sp").text('用户名不能为空');
        //            $("#username").focus();
        //            return false;
        //        }
        //        if ($.trim(pwd) == "" || $.trim(pwd) == "undefined") {
        //            $("#sp").text('密码不能为空');
        //            $("#pwd").focus();
        //            return false;
        //        }

        //        $.ajax({
        //            type: "POST",
        //            url: "../Handler/InLogin.ashx",
        //            data: { user: user, pwd: pwd },
        //            success: function(id) {
        //                if (id == "1") {
        //                    $("#sp").text('用户名不存在');
        //                    $("#username").select();
        //                    $("#username").focus();
        //                    return false;
        //                }
        //                if (id == "2") {
        //                    $("#sp").text('密码错误');
        //                    $("#pwd").select();
        //                    $("#pwd").focus();
        //                    return false;
        //                }
        //                if (id == "3") {
        //                    $("#sp").text('帐号被禁用,请联系管理员');
        //                    return false;
        //                }
        //                if (id == "4") {
        //                    $("#sp").text('系统出现bug,请联系网管')
        //                }
        //                if (id == "6") {
        //                    window.location.href = "../administrator/AdminList.aspx"
        //                }
        //            },
        //            error: function() { alert("登录失败"); }
        //        }); //ajax End

    }); //denglu End
});