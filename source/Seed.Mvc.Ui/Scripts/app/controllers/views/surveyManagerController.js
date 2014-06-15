///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.controllers.views')
    .controller('surveysManagerController', [
        '$scope',
        '$state',
        'surveysService',
        function($scope, $state, surveysService) {
            $scope.surveys = surveysService.getUserSurveys();

            $scope.toggle = function (collection) {
                if (angular.isUndefined(collection)) {
                    return;
                }
                
                collection.visible = !collection.visible;
            };
        }]);