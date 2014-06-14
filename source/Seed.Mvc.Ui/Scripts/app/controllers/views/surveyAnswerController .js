///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.controllers.views')
    .controller('surveyAnswerController', [
        '$scope',
        '$state',
        'surveysService',
        function($scope, $state, surveysService) {
            $scope.survey = surveysService.getSurvey($state.params.surveyId);
        }]);