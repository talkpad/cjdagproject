$(document).ready(function() {
    $("a[id*='edit']").click(function() {
        parent.window.f_addTab('listpage5', '修改编研成果文件', $(this).attr("href"));
        return false;
    });

    $("a[id*='lbtnDel']").click(function() {
        if ($(this).attr("disabled") == false) {
            return confirm("确定要删除该笔资料吗？");
        }
    });
});

$(function() {
    $('.tiaoshi tr:not(:has("th"))').css('background-color', '#FFFFFF');
    $('.tiaoshi tr:not(:has("th"))').hover(function() {
        $(this).css('background-color', '#FFEEAC');
    },
       function() {
           $(this).css('background-color', '#FFFFFF');
       });
});