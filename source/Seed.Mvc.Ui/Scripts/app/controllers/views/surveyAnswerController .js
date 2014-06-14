///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.controllers.views')
    .controller('surveyAnswerController', [
        '$scope',
        '$state',
        'surveysService',
        'questionsService',
        function ($scope, $state, surveysService, questionsService) {
            $scope.survey = surveysService.getAttendSurvey($state.params.surveyId);

            $scope.survey.$promise.then(function () {
                if ($scope.survey.questionsIds.length > 0) {
                    $scope.currentQuestionId = $scope.survey.questionsIds[0];
                }
            });

            $scope.submitAnswer = function () {
                var answers = $scope.question.answers.items.filter(function(item) {
                    return item.selected;
                }).map(function(item) {
                    return item.value;
                });
                
                if (answers.length == 0) {
                    return;
                }

                questionsService.saveQuestionAnswer($scope.question.id, answers).$promise.then(function() {
                    var questions = $scope.survey.questionsIds,
                    current = questions.indexOf($scope.currentQuestionId);

                    if (current + 1 >= questions.length) {
                        $scope.completed = true;
                        return;
                    }

                    $scope.currentQuestionId = questions[current + 1];
                });
            };

            $scope.$watch('currentQuestionId', function (newValue, oldValue) {
                if (newValue === oldValue) {
                    return;
                }
                
                $scope.question = questionsService.getQuestion(newValue);
            });
        }]);