///<reference path="~/Scripts/lib/angular.js"/>
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
                        title: 'Profile'
                    }
                })
            .state('dashboard.surveysManager',
                {
                    url: '/surveys/manage',
                    templateUrl: '/Templates/views/surveysManager.html',
                    controller: 'surveysManagerController',
                    data: {
                        title: 'Your surveys',
                        description: 'feel free to manage your surveys: create, edit, remove etc.'
                    }
                })
            .state('dashboard.surveyEdit',
                {
                    url: $urlMatcherFactory.compile('/surveys/edit/{surveyId}', {
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
                        description: 'reveal your deepest hidden phantasies and create a survey, but remember conciseness and clearness are keys to goal.'
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