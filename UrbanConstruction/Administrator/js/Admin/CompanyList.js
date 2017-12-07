$(document).ready(function() {
    $('.tiaoshi tr:not(:has("th"))').css('background-color', '#FFFFFF');
    $('.tiaoshi tr:not(:has("th"))').hover(function() {
        $(this).css('background-color', '#FFEEAC');
    },
       function() {
           $(this).css('background-color', '#FFFFFF');
       });
});