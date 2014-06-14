///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.directives.controls').directive('seedCheckboxList', function() {
    return {
        restrict: 'A',
        replace: true,
        templateUrl: '/Templates/partials/checkboxList.html',
        scope: {
            list: '=seedCheckboxList'
        },
        link: function($scope) {
            
        }
    };
});