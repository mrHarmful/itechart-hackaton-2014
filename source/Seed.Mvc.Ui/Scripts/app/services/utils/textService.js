///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.services.utils')
    .service('textService', function() {
        this.toClassString = function(str) {
            if (angular.isString(str)) {
                return str.replace(' ', '-').toLowerCase();
            }
            return null;
        };
    });