$(document).ready(function() {
    $("a[id*=lbtnCheck]").click(function() {
        if ($(this).attr("disabled") == undefined) {
            return confirm("确定要核准该笔资料吗？");
        }
    });

    $("a[id*=lbtnDel]").click(function() {
        if ($(this).attr("disabled") == undefined) {
            return confirm("确定要删除该笔资料吗？");
        }
    });

    $("a[id*=lbtnCancel]").click(function() {
        if ($(this).attr("disabled") == undefined) {
            return confirm("确定要取消核准该笔资料吗？");
        }
    });

});