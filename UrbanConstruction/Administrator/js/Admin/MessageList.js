$(document).ready(function() {
    $('.tiaoshi tr:not(:has("th"))').css('background-color', '#FFFFFF');
    $('.tiaoshi tr:not(:has("th"))').hover(function() {
        $(this).css('background-color', '#FFEEAC');
    },
       function() {
           $(this).css('background-color', '#FFFFFF');
       });
   });

   $(document).ready(function() {
       $("#txtdate").click(function() {
           WdatePicker({ readOnly: true });
       });

       $("#txtdao").click(function() {
           WdatePicker({ readOnly: true });
       });
       $("#txthl").click(function() {
           WdatePicker({ readOnly: true });
       });
       $("#txthd").click(function() {
           WdatePicker({ readOnly: true });
       });

       $("a[id*='lbtnEdit']").click(function() {

           if ($(this).attr("disabled") == false) {
               parent.window.f_addTab('E05', '回复留言', $(this).attr("href") + "?ID=" + $(this).attr("identity"));
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

       $("#reset1").click(function() {
           $("#txttitle").val("");
           $("#ddlist").val("");
           $("#txtdate").val("");
           $("#txtdao").val("");
           $("#txthl").val("");
           $("#txthd").val("");
           $("#Hlist").val("");
           $("#drpType").val("");
       });

   });
