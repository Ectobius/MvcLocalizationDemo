$(function () {
    var localizationSettings = mvcLocalizationDemo.localizationSettings,
        $producedAt = $('#ProducedAt'),
        localizationForDatepicker = $.datepicker.regional[localizationSettings.datePickerLocaleName];

    $producedAt.datepicker(localizationForDatepicker);
    $producedAt.datepicker('option', 'dateFormat', localizationSettings.dateTimeFormatForDatePicker);
});