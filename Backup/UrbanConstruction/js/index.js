
$(document).ready(function() {
    //    var w = $("#banner").width(); //容器宽度
    //    $("#banner img").each(function() {//如果有很多图片，我们可以使用each()遍历
    //        var img_w = $(this).width(); //图片宽度 
    //        var img_h = $(this).height(); //图片高度 
    //        if (img_w > w) {//如果图片宽度超出容器宽度--要撑破了 
    //            var height = (w * img_h) / img_w; //高度等比缩放 
    //            $(this).css({ "width": w, "height": height }); //设置缩放后的宽度和高度 
    //        }
    //    });
    //$('#banner a').autoIMG();
    $("#btnsearch").click(function() {
        if ($.trim($("#keyword").val()) == "" || $.trim($("#keyword").val()) == "请输入关键字查询") {
            alert("请输入关键字查询");
            $("#keyword").select();
            $("#keyword").focus();
            return false;
        }
        else {
            var url = "seach.aspx?advsearch=0&keyword=" + $("#keyword").val();
            window.open(url);
        }
    });

    $("#btnSearchByouter").click(function() {
        if ($.trim($("#keyword").val()) == "" || $.trim($("#keyword").val()) == "请输入关键字查询") {
            alert("请输入关键字查询");
            $("#keyword").select();
            $("#keyword").focus();
            return false;
        }
        else {
            var url = "searchByouter.aspx?keyword=" + $.trim($("#keyword").val());
            window.open(url);
        }
    });

    //$("#ck").hide(); //投票

    $('#marquee1').kxbdMarquee({ direction: 'left' }); //滚动框1 站内公告
    $('#marquee2').kxbdMarquee({ direction: 'left' }); //滚动框2 --友情 链接
    //友情链接
    $("#link_QTlist").change(function() {
        if ($("#link_QTlist").val() != "" && $("#link_QTlist").val() != "-1") {
            var url = $("#QTlist").val();
            window.open(url);
        }
    });
    $("#link_DRlist").change(function() {
        if ($("#link_DRlist").val() != "" && $("#link_DRlist").val() != "-1") {
            var url = $("#link_DRlist").val();
            window.open(url);
        }
    });
    $("#link_XWlist").change(function() {
        if ($("#link_XWlist").val() != "" && $("#link_XWlist").val() != "-1") {
            var url = $("#link_XWlist").val();
            window.open(url);
        }
    });
    $("#link_SSlist").change(function() {
        if ($("#link_SSlist").val() != "" && $("#link_SSlist").val() != "-1") {
            var url = $("#link_SSlist").val();
            window.open(url);
        }
    });
});

function setTab(name, cursel, n) {
    for (i = 1; i <= n; i++) {
        var menu = document.getElementById(name + i); /* xxk1 */
       // alert(menu);
        var con = document.getElementById("con_" + name + "_" + i); /* con_xxk_1 */
        menu.className = i == cursel ? "hover" : ""; /*三目运算 等号优先*/
        con.style.display = i == cursel ? "block" : "none";
    }
}


//判定是否有选中-在线投票
function checktrue() {
    var num = 0;
    $("input[id^='chkItem_']").each(function() {
        if ($(this).attr("checked")) {
            num = num + 1;
        }
    });
    if(num>0)
    {
       return true;
   }
     else {
    alert("投票不能为空");
        return false;
    }
}

//在线投票
function toupiao() {
    var str = "";
    $("input[id^='chkItem_']").each(function() {



    if ($(this).attr("checked")) {
        var id = $(this).attr("id");
        id = id.replace('chkItem_', '');
            str = str + id + "@";
        }
 
    });
    if(str.length>0)
    {
    str=str.substring(0,str.length-1);
    }
  
  
    $.ajax({
    url: "../Handler/Tpiao.ashx",
    type: "post",
    data: { postData: str },
    cache: false,
    success: function(data) {
    if (data == "成功") {
    alert("投票成功")
    $("#tijiao").toggle();
  //  $("#ck").show();
    }
    else {
    $("#tijiao").toggle();
  //  $("#ck").show();
    alert("投票失败，请刷新页面重新投票");
    }
    },
    error: function() {
    alert("失败")
    }
           
    });
}


//function AutoSize(ImgD,MaxWidth,MaxHeight)
//{
//   var image=new Image();
//   image.src=ImgD.src;
//   if(image.width>0 && image.height>0)
//   {
//    flag=true;
//    if(image.width/image.height>= MaxWidth/MaxHeight)
//    {
//     if(image.width>MaxWidth)
//     {
//     ImgD.width=MaxWidth;
//     ImgD.height=(image.height*MaxWidth)/image.width;
//     }
//     else
//     {
//     ImgD.width=image.width;
//     ImgD.height=image.height;
//     }
//     //ImgD.alt="原始尺寸:宽" + image.width+",高"+image.height;
//     }
//    else
//    {
//     if(image.height>MaxHeight)
//     {
//     ImgD.height=MaxHeight;
//     ImgD.width=(image.width*MaxHeight)/image.height;    
//     }
//     else
//     {
//     ImgD.width=image.width;
//     ImgD.height=image.height;
//     }
//     //ImgD.alt="原始尺寸:宽" + image.width+",高"+image.height;
//     }
//    }
//   }

//startList = function() {
//    var nar = document.getElementById("tdbmfw");
//    var ul = document.getElementById("divBm");
//    nar.onmouseover = function() {
//        ul.className += " over";
//    }
//    nar.onmouseout = function() {
//        ul.className = ul.className.replace(" over", "");
//    }
//}
//window.onload = startList; 