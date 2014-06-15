///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.controllers.views')
    .controller('singleQuestionEditController', [
        '$scope',
        '$state',
        'surveysService',
        'SelectLists',
        function($scope, $state, surveysService, SelectLists) {
            if ($state.params.surveyId === null || angular.isUndefined($state.params.surveyId)) {
                $scope.survey = {                    
                    meta: {
                        selectedTargets: $scope.targets = SelectLists.targets(),
                        selectedCategoryId: null,
                        selectedPriorityId: null
                    },
                    questions: []
                };
            } else {
                $scope.survey = surveysService.getSingleQuestion($state.params.surveyId);
            }

            $scope.tab = 'meta';

            $scope.categories = SelectLists.categories();
            $scope.priorities = SelectLists.priorities();

            $scope.saveSurvey = function () {
                surveysService.saveSingleQuestion($scope.survey);

                $state.go('dashboard.surveysManager');
            };

            $scope.addQuestion = function (type) {
                var question = {};
                
                switch (type) {
                    case 'yes|no':
                        question.answers = [
                            {
                                caption: 'Yes'
                            },
                            {
                                caption: 'No'
                            }
                        ];
                        question.isSingleSelect = true;
                        break;
                    case 'assurance':
                        question.answers = [
                            {
                                caption: 'Sure no'
                            },
                            {
                                caption: 'Almost sure no'
                            },
                            {
                                caption: 'Unsure'
                            },
                            {
                                caption: 'Almost sure yes'
                            },
                            {
                                caption: 'Sure yes'
                            }
                        ];
                        question.isSingleSelect = true;
                        break;
                    case 'single':
                        question.answers = [
                            {
                                caption: 'Caption1'
                            },
                            {
                                caption: 'Caption2'
                            },
                            {
                                caption: 'Caption3'
                            }
                        ];
                        question.isSingleSelect = true;
                        break;
                    case 'multi':
                        question.answers = [
                            {
                                caption: 'Caption1'
                            },
                            {
                                caption: 'Caption2'
                            },
                            {
                                caption: 'Caption3'
                            }
                        ];
                        question.isSingleSelect = false;
                        break;
                default:
                }

                $scope.survey.question = question;
            };
        }]);