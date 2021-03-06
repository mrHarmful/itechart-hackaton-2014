﻿///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/lib/angular-ui-router.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp').config(['$stateProvider', '$urlRouterProvider', '$locationProvider', '$urlMatcherFactoryProvider', '$httpProvider',
    function($stateProvider, $urlRouterProvider, $locationProvider, $urlMatcherFactory, $httpProvider) {

        $stateProvider
            .state('dashboard',
                {
                    abstract: true,
                    templateUrl: '/Templates/views/dashboard.html',
                    controller: 'dashboardController'
                })
            .state('dashboard.profile',
                {
                    url: '/profile',
                    templateUrl: '/Templates/views/profile.html',
                    controller: 'profileController',
                    data: {
                        title: 'Profile',
                        description: 'Something about you.'
                    }
                })
            .state('dashboard.achivements',
                {
                    url: '/achivements',
                    templateUrl: '/Templates/views/achivements.html',
                    data: {
                        title: 'Achievements',
                        description: 'Enjoy your succes story.'
                    }
                })
            .state('dashboard.surveysManager',
                {
                    url: '/surveys/manage',
                    templateUrl: '/Templates/views/surveysManager.html',
                    controller: 'surveysManagerController',
                    data: {
                        title: 'Your surveys',
                        description: 'Feel free to manage your surveys: create, edit, remove etc.'
                    }
                })
            .state('dashboard.surveyEdit',
                {
                    url: $urlMatcherFactory.compile('/surveys/edit/quiz/{surveyId}', {
                        params: {
                            surveyId: {
                                value: null,
                            }
                        }
                    }),
                    templateUrl: '/Templates/views/surveyEdit.html',
                    controller: 'surveyEditController',
                    data: {
                        title: 'Survey edit',
                        description: 'Reveal your deepest hidden phantasies and create a survey, but remember conciseness and clearness are keys to goal.'
                    }
                })
            .state('dashboard.singleQuestionEdit',
                {
                    url: $urlMatcherFactory.compile('/surveys/edit/single-question/{surveyId}', {
                        params: {
                            surveyId: {
                                value: null,
                            }
                        }
                    }),
                    templateUrl: '/Templates/views/singleQuestionEdit.html',
                    controller: 'singleQuestionEditController',
                    data: {
                        title: 'Single Question edit',
                        description: 'Reveal your deepest hidden phantasies and create a survey, but remember conciseness and clearness are keys to goal.'
                    }
                })
            .state('dashboard.surveyView',
                {
                    url: '/surveys/view',
                    templateUrl: '/Templates/views/availableSurveys.html',
                    controller: 'surveysViewController',
                    data: {
                        title: 'Available surveys',
                        description: 'Answer questions, earn points ... profit!.'
                    }
                })
            .state('dashboard.answerSurvey',
                {
                    url: $urlMatcherFactory.compile('/surveys/answer/{surveyId}', {
                        params: {
                            surveyId: {
                                value: null,
                            }
                        }
                    }),
                    templateUrl: '/Templates/views/answerSurvey.html',
                    controller: 'surveyAnswerController',
                    data: {
                        title: 'Answer survey',
                        description: 'Answer questions, earn points ... profit!.'
                    }
                });

        $stateProvider.state('dashboard.error', {
            url: '/error/{errorCode}',
            templateUrl: '/Templates/views/error.html',
            controller: 'errorController',
            data: {
                title: 'Error',
                description: 'sorry, an error occurred while processing your request.'
            }
        });

        $urlRouterProvider.rule(function($injector, $location) {
            var path = $location.path();
            var normalized = path.toLowerCase();

            if (path != normalized) {
                $location.replace().path(normalized);
            }
        });

        $urlRouterProvider.otherwise('/error/404');

        $locationProvider.html5Mode(true);

        $httpProvider.interceptors.push('errorsInterceptor');
    }]);

angular.module('seedApp').run(['$location', '$rootScope', function($location, $rootScope) {
    $rootScope.$on('$stateChangeStart', function(event, toState, toParams) {
        $rootScope.title = toState.data.title;
        $rootScope.description = toState.data.description;

    });
}]);