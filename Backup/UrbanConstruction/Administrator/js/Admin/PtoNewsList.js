function SelectAll(CheckAll) {
    var items = document.getElementsByTagName("input");
    for (var i = 0; i < items.length; i++) {
        if (items[i].type == "checkbox") {
            items[i].checked = CheckAll.checked;
        }
    }
};

$(document).ready(function() {
    $("#txtdate").click(function() {
        WdatePicker({ readOnly: true });
    });
    $("#txtdao").click(function() {
        WdatePicker({ readOnly: true });
    });

    $("a[id*='lbtnEdit']").click(function() {

        if ($(this).attr("disabled") == false) {
            parent.window.f_addTab('E02', '修改图片新闻', $(this).attr("href") + "?ID=" + $(this).attr("identity"));
        }
        return false;
    });
    $("a[id*='lbtnCheck']").click(function() {
        if ($(this).attr("disabled") == false) {
            return confirm("确定要审核该笔资料吗？");
        }
    });
    $("a[id*='lbtnCancel']").click(function() {
        if ($(this).attr("disabled") == false) {
            return confirm("确定要取消审核该笔资料吗？");
        }
    });
    $("a[id*='lbtnDel']").click(function() {
        if ($(this).attr("disabled") == false) {
            return confirm("确定要删除该笔资料吗？");
        }
    });
    $("#linkCheck").click(function() {
        var flag = false;
        var items = document.getElementsByTagName("input");
        for (var i = 0; i < items.length; i++) {
            if (items[i].type == "checkbox") {
                if (items[i].checked) {
                    flag = true;
                    break;
                }
            }
        }
        if (!flag) {
            window.alert("请选择操作纪录！");
            return false;
        }
        else
        { return confirm("确定要审核这些资料吗？"); }
    });
    $("#linkCancel").click(function() {
        var flag = false;
        var items = document.getElementsByTagName("input");
        for (var i = 0; i < items.length; i++) {
            if (items[i].type == "checkbox") {
                if (items[i].checked) {
                    flag = true;
                    break;
                }
            }
        }
        if (!flag) {
            window.alert("请选择操作纪录！");
            return false;
        }
        else {
            return confirm("确定要取消审核这些资料吗？");
        }
    });
    $("#linkDelete").click(function() {
        var flag = false;
        var items = document.getElementsByTagName("input");
        for (var i = 0; i < items.length; i++) {
            if (items[i].type == "checkbox") {
                if (items[i].checked) {
                    flag = true;
                    break;
                }
            }
        }
        if (!flag) {
            window.alert("请选择操作纪录！");
            return false;
        } else {
            return confirm("确定要删除这些资料吗？");
        }
    });

    $("#reset1").click(function() {
        $("#txttitle").val("");
        $("#ddlist").val("");
        $("#txtdate").val("");
        $("#txtdao").val("");
        $("#Xdlist").val("");
        $("#Ldlist").val("");
    });

});

