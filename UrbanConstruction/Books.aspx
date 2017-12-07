<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="UrbanConstruction.Books" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>中山市城市建设档案馆 </title>
    <link href="css/liquid-green.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/liquid.js"></script>

    <script type="text/javascript" src="js/swfobject.js"></script>

    <script type="text/javascript" src="js/flippingbook.js"></script>

    <script type="text/javascript" src="js/bookSettings.js"></script>

    <script type="text/javascript">
        flippingBook.pages = [
     
	<%=bookpages %>
	
];

        // 跳转页设置处
        flippingBook.contents = [
	["封面", 1],
	["封底", <%=pageCount %>]
];

        // 默认杂志图片大小
        flippingBook.settings.bookWidth = 900;
        flippingBook.settings.bookHeight = 580;
        flippingBook.settings.pageBackgroundColor = 0x5b7414;
        flippingBook.settings.backgroundColor = 0x83a51c;                    // 背景颜色修改
        flippingBook.settings.zoomUIColor = 0x919d6c;
        flippingBook.settings.useCustomCursors = false;
        flippingBook.settings.dropShadowEnabled = false,
        flippingBook.settings.zoomImageWidth = 668;                // 放大后的 杂志图片大小修改处
        flippingBook.settings.zoomImageHeight = 924;
        flippingBook.settings.downloadURL = "js/html-edition-documentation.pdf";
        flippingBook.settings.flipSound = "sounds/02.mp3";
        flippingBook.settings.flipCornerStyle = "first page only";
        flippingBook.settings.zoomHintEnabled = true;

        // default settings can be found in the flippingbook.js file
        flippingBook.create();

    </script>

</head>
<body>
    <div id="fbContainer">
        <a class="altlink" href="http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash">
        </a>
    </div>
    <div id="fbFooter">
        <div id="fbContents">
            <select id="fbContentsMenu" name="fbContentsMenu">
                <option>封面</option>
                <option>封底</option>
            </select>
            <span class="fbPaginationMinor">p.&nbsp;</span> <span id="fbCurrentPages">1</span>
            <span id="fbTotalPages" class="fbPaginationMinor"></span><span class="fbPaginationMinor">
                编研成果:&nbsp;&nbsp;</span>
            <select name="ddlphoto" id="ddlphoto" onchange="changeUrl(this)">
                <option selected="selected" value="0">请选择编研成果</option>
                <%for (int i = 0; i < booklist.Count; i++)
                  {%>
                <option value="<%=booklist[i].ID.ToString() %>">
                    <%=booklist[i].Title %></option>
                <%} %>
            </select>

            <script type="text/javascript">

                function changeUrl(obj) {
                    window.open("Books.aspx?FID=" + obj.value);
                    obj.selectedIndex = 0;
                }
            
            </script>

        </div>
        <div id="fbMenu">
            <img src="images/btnZoom.gif" width="36" height="40" border="0" id="fbZoomButton" />
            <img src="images/btnPrint.gif" width="36" style="display: none;" height="40" border="0" id="fbPrintButton" />
            <img src="images/btnDownload.gif" width="36" style="display: none;" height="40" border="0"
                id="fbDownloadButton" />
            <img src="images/btnDiv.gif" width="13" height="40" border="0" />
            <img src="images/btnPrevious.gif" width="36" height="40" border="0" id="fbBackButton" />
            <img src="images/btnNext.gif" width="36" height="40" border="0" id="fbForwardButton" />
        </div>
    </div>
</body>
</html>
