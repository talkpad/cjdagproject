$(document).ready(function() {
    $("#txtdate").click(function() {
        WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss', readOnly: true });
    });
    $("#btnSave").click(function() {
        var txttitle = $("#txttitle").val();
        var txtzuoz = $("#txtzuoz").val();
        var txtsoure = $("#txtSoure").val();
        var txtdate = $("#txtdate").val();
        var Xdlist = $("#Xdlist").val();
        var Ldlist = $("#Ldlist").val();
        var m_filTitleImg = $("#m_filTitleImg").val();

        if (Xdlist == "" || Xdlist == "-1") {
            alert("新闻栏目不能为空");
            $("#Xdlist").focus();
            return false;
        }
        if (Ldlist == "" || Ldlist == "-1") {
            alert('栏目新闻类型不能为空');
            $("#Ldlist").focus();
            return false;
        }
        if (txttitle == "") {
            alert('标题不能为空');
            return false;
        }
        if (txtdate == "") {
            alert('发表日期不能为空');
            $("#txtdate").focus();
            return false;
        }
        if (txtzuoz == "") {
            alert('作者不能为空');
            $("#txtzuoz").focus();
            return false;
        }
        if (txtsoure == "") {
            alert('来源不能为空');
            $("#txtSoure").focus();
            return false;
        }


    });
});