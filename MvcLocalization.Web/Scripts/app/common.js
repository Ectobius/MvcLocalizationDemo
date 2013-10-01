var mvcLocalizationDemo = mvcLocalizationDemo || {};

(function () {
    var cultureName = $('meta[name="accept-language"]').attr('content'),
        localizationSettings = mvcLocalizationDemo.localizationSettings;

    mvcLocalizationDemo.cultureName = cultureName;
    Globalize.culture(cultureName);

    var dateTimePattern = localizationSettings.dateTimeFormat;
    $.extend($.validator.methods, {
        number: function (value, element) {
            return this.optional(element) || !isNaN(Globalize.parseFloat(value));
        },
        date: function (value, element) {
            return this.optional(element) || !!Globalize.parseDate(value, dateTimePattern);
        }
    });

    Globalize.addCultureInfo('en-US', {
        messages: {
            'deleteItemConfirmation': 'Are you sure?'
        }
    });
    
    Globalize.addCultureInfo('ru-RU', {
        messages: {
            'deleteItemConfirmation': 'Вы уверены?'
        }
    });
})();