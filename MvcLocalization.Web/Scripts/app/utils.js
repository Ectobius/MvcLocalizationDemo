var mvcLocalizationDemo = mvcLocalizationDemo || {};

mvcLocalizationDemo.utils = (function () {

    function localize(key) {
        return Globalize.localize(key);
    }
    
    return {
        localize: localize
    };
})();