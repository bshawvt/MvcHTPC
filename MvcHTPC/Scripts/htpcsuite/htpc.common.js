jQuery(document).ready(function () {
    jQuery(document).on('click', '.i-removable-close', function () {
        var idNum = jQuery(this).attr("id");
        d("idNum: " + idNum);
        jQuery(".i-removable[id='" + idNum + "']").remove();
    });

    jQuery(i_dialogPlacement).prepend('<div class="i-notifier-dialog"></div>');

});

// creates a dynamic dialog box that may be closed
var i_dialogCounter = 0;
var i_dialogPlacement = '.body-content'; // element that dialogs appear before. eg, the content body
var iAddDialog = function (title, body) {
    var html = "";

    html += '<div class="panel panel-default i-removable" id="' + i_dialogCounter + '">';
    html += '<div class="panel-heading">';
    html += '<button class="i-removable-close close" id="' + i_dialogCounter + '" type="button"><span>&times;</span></button>';
    html += '<h3 class="panel-title">' + title + '</h3>';
    html += '</div>';
    html += '<div class="panel-body">';
    html += body;
    html += '</div>';
    html += '</div>';

    if (jQuery(".i-notifier-dialog").length) {
        jQuery('.i-notifier-dialog').append(html);
    }

    i_dialogCounter++;

}