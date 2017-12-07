$(document).ready(function() {
    $("#btnSave").click(function() {
    if ($("#txtname").val() == "") {
        alert('用户名不能为空');
        $("#txtname").focus();
        return false;
    }
    if ($("#txtpwd").val() == "") {
        alert('密码不能为空');
        $("#txtpwd").focus();
        return false;
    }
    if ($("#txtzhenqu").val() == "") {
        alert('镇区单位名称不能为空');
        $("#txtzhenqu").focus();
        return false;
    }
    if ($("#txtadd").val() == "") {
        alert('单位地址不能为空');
        $("#txtadd").focus();
        return false;
    }
    if ($("#txttel").val() == "") {
        alert('电话不能为空');
        $("#txttel").focus();
        return false;
    }
    if ($("#txtfdren").val() == "") {
        alert('邮箱不能为空');
        $("#txtfdren").focus();
        return false;
    }
     if ($("#txtOrdering").val() == "") {
        alert('排序不能为空');
        $("#txtOrdering").focus();
        return false;
    }
    var reg = /^[0-9]*[1-9][0-9]*$/;
    if (reg.test($.trim($("#txtOrdering").val())) == false) {
        alert("请输入一个大于0的整数");
        $("#txtOrdering").focus();
        $("#txtOrdering").select();
        return false;
    }
 
    });
});