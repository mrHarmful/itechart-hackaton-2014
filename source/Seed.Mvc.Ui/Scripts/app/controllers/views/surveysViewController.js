///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.controllers.views')
    .controller('surveysViewController', [
        '$scope',
        '$state',
        'surveysService',
        function($scope, $state, surveysService) {
            $scope.surveys = surveysService.getAvailableSurveys();

            $scope.respond = function(survey) {
                $state.go('dashboard.answerSurvey', { surveyId: survey.id });
            };
        }]);