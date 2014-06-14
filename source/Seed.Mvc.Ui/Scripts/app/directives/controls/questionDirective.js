///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.directives.controls').directive('seedQuestion', function() {
    return {
        restrict: 'A',
        replace: true,
        templateUrl: '/Templates/partials/question.html',
        scope: {
            question: '=seedQuestion'
        },
        link: function ($scope) {
            
        }
    };
});