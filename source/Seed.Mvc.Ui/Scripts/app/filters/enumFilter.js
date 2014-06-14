///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

angular.module('seedApp.filters')
    .filter('enum', ['localizationService', function(localizationService) {
        return function(value, enumType) {
            var out = '',
                key;

            if (!angular.isNumber(value)) {
                return out;
            }

            key = enumType + '_' + value;
            out = localizationService.enum(key);

            return out;
        };
    }]);