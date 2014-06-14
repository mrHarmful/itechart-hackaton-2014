///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.factories.resources')
    .factory('Surveys', ['$resource', function($resource) {
        return $resource('/api/surveys/:id', null,
            {
                'all': { method: 'GET' },
                'available': { method: 'GET', url: '/api/surveys/available', isArray: true},
                'get': { method: 'GET' },
                'save': {method: 'PUT'}
            });
    }]);