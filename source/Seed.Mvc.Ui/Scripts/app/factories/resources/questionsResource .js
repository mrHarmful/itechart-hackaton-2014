///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.factories.resources')
    .factory('Questions', ['$resource', function($resource) {
        return $resource('/api/questions/:questionId', null,
            {
                'get': { method: 'GET' },
                'saveAnswer': { method: 'PUT', url: '/api/questions/:questionId/answer', params:{questionId: '@questionId'}}
    });
    }]);