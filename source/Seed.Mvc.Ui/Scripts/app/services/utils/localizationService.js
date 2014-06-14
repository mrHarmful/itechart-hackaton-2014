///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.services.utils')
    .provider('localizationService', [function() {
        var localization = {},
            resources = {
                errorMessages: 'ErrorMessages',
                enums: 'Enums'
            };

        this.setLocalizationResources = function(resourceSet) {
            localization = resourceSet;
        };

        this.$get = function() {
            return new LocalizationService();
        };

        function LocalizationService() {
            this.errorMessage = function(key) {
                return getString(resources.errorMessages, key);
            };

            this.enum = function(key) {
                return getString(resources.enums, key);
            };

            function getString(resource, key) {
                var result = null;

                if (localization.hasOwnProperty(resource)
                        && localization[resource].hasOwnProperty(key)) {
                    result = localization[resource][key];
                }

                return result;
            }
        }
    }]);