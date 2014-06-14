///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.controllers.views')
    .controller('surveyEditController', [
        '$scope',
        '$stateParams',
        'surveysService',
        'SelectLists',
        function($scope, $stateParams, surveysService, SelectLists) {
            if ($stateParams.surveyId === null) {
                $scope.survey = {                    
                    meta: {
                        selectedTargets: $scope.targets = SelectLists.targets(),
                    },
                    questions: []
                };
            } else {
                $scope.survey = surveysService.getSurvey($stateParams.surveyId);
            }

            $scope.tab = 'meta';

            $scope.categories = SelectLists.categories();
            $scope.priorities = SelectLists.priorities();

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

                question.enquiry = 'Some enquiry...';
                $scope.survey.questions.push(question);
            };
        }]);