///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.directives.controls').directive('seedEditQuestion', function() {
    return {
        restrict: 'A',
        templateUrl: '/Templates/partials/editQuestion.html',
        scope: {
            question: '=seedEditQuestion'
        },
        link: function ($scope) {
            
        }
    };
});