$(document).ready(function() {
    $("#txtdate").click(function() {
        WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss', readOnly: true });
    });
    
    $("#btnSave").click(function() {
        if ($("#txttitle").val() == "") {
            alert("视频名称不能为空");
            $("#txttitle").focus();
            return false;
        }
        if ($("#txtdate").val() == "") {
            alert("上传时间不能为空");
            $("#txtdate").focus();
            return false;
        }
        if ($("#DrState").val() == "" || $("#DrState").val() == "0") {
            alert("请选择类别");
            return false;
        }
    });
});


 