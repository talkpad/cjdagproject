$(document).ready(function() {
    $("#txtdate").click(function() {
        WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss', readOnly: true });
    });
    $("#btnSave").click(function() {
        if ($("#txttitle").val() == "") {
            alert("文件名不能为空");
            $("#txttitle").focus();
            return false;
        }
        if ($("#Xdlist").val() == "" || $("#Xdlist").val() == "-1") {
            alert("请选择文件类别");
            $("#Xdlist").focus();
            $("#Xdlist").select();
            return false;
        }
        if ($("#Ldlist").val() == "" || $("#Ldlist").val() == "0") {
            alert("请选择文件类别");
            $("#Ldlist").focus();
            $("#Ldlist").select();
            return false;
        }
        if ($("#txtFileFact").val() == "") {
            alert("请上传文件");
            return false;
        }
    });
});