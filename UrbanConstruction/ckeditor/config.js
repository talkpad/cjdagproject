/*
Copyright (c) 2003-2011, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/


CKEDITOR.editorConfig = function(config) {
    config.language = 'zh-cn';
    config.height = 200;
    // 編輯器樣式，有三種：'kama'（默認）、'office2003'、'v2'
    config.skin = 'v2';
    // 背景顏色
    config.uiColor = '#FFF';
    // 工具欄（基礎'Basic'、全能'Full'、自定義）plugins/toolbar/plugin.js
    //config.toolbar = 'Basic';
    config.toolbar = 'Full';
    config.toolbar_Full = [
['Source', '-', 'Preview', '-'],
['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord'],
,
['Styles', 'Format', 'Font', 'FontSize'],
'/',
['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote'],
['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
['Link', 'Unlink', 'Anchor'],
['Image', 'Table', 'HorizontalRule', 'SpecialChar', 'PageBreak']
];
    config.font_names = '宋体;楷体_GB2312;新宋体;黑体;隶书;幼圆;微软雅黑;Arial;Comic Sans MS;Courier New;Tahoma;Times New Roman;Verdana';
    config.format_tags = 'p;div;h1;h2;h3;h4;h5;h6;pre;address';
    config.fontSize_defaultLabel = '12px';
    config.format_defaultLabel = 'div';
//config.filebrowserBrowseUrl = '/ckfinder/ckfinder.html'; //上传文件时浏览服务文件夹

//    config.filebrowserImageBrowseUrl = '/ckfinder/ckfinder.html?Type=Images'; //上传图片时浏览服务文件夹

//config.filebrowserFlashBrowseUrl = '/ckfinder/ckfinder.html?Type=Flash';  //上传Flash时浏览服务文件夹

////config.filebrowserUploadUrl = '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files'; //上传文件按钮(标签)

//config.filebrowserImageUploadUrl = '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images'; //上传图片按钮(标签)

    //config.filebrowserFlashUploadUrl = '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'; //上传Flash按钮(标签)
//debugger
    config.filebrowserBrowseUrl = location.hash + '/ckfinder/ckfinder.aspx?Type=Files'; //上传文件
    config.filebrowserImageBrowseUrl = location.hash + '/ckfinder/ckfinder.aspx?Type=Images';
 
 
    config.filebrowserUploadUrl = location.hash + '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = location.hash + '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
 

};