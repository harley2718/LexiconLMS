$(function () {
    // Get data-annotations that are Marked DataType.DateTime and make them jquery date time pickers
    $('input[type=datetime]').datetimepicker({ dateFormat: 'yy-mm-dd', timeFormat: 'hh:mm', changeMonth: true, changeYear: true, showAnim: 'slideDown' });
});