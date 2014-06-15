///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.factories.resources')
    .factory('Surveys', ['$resource', function($resource) {
        return $resource('/api/surveys/:id', null,
            {
                'all': { method: 'GET' },
                'available': { method: 'GET', url: '/api/surveys/available', isArray: true},
                'getQuiz': { method: 'GET', url: '/api/surveys/:id/quiz' },
                'getSingleQuestion': { method: 'GET', url: '/api/surveys/:id/single-question' },
                'getAttend': { method: 'GET', url: '/api/surveys/:id/attend'},
                'saveQuiz': { method: 'PUT', url: '/api/surveys/quiz' },
                'saveSingleQuestion': { method: 'PUT', url: '/api/surveys/single-question' }
            });
    }]);