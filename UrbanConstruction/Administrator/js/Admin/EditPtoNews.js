$(document).ready(function() {
    $("#txtdate").click(function() {
    WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss', readOnly: true });
    });
    $("#btnSave").focus(function() {
        var txttitle = $("#txttitle").val();
        var txtzuoz = $("#txtzuoz").val();
        var txtsoure = $("#txtSoure").val();
        var txtdate = $("#txtdate").val();
        var Xdlist = $("#Xdlist").val();
        var Ldlist = $("#Ldlist").val();
        var txtNewsUrl = $("#txtNewsUrl").val();

        //        alert(imgbt);
        if (txttitle == "") {
            alert('标题不能为空', '请确认');
            $("#txttitle").focus();
            return;
        }
        if (txtzuoz == "") {
            alert('作者不能为空', '请确认');
            $("#txtzuoz").focus();
            return;
        }
        if (txtsoure == "") {
            alert('来源不能为空', '请确认');
            $("#txtSoure").focus();
            return;
        }
        if (txtdate == "") {
            alert('发表时间不能为空', '请确认');
            $("#txtdate").focus();
            return;
        }
        if (txtNewsUrl == "") {
            alert('标题图片不能为空', '请确认');
            $("#m_filTitleImg").focus();
            return;
        }
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
    });
});