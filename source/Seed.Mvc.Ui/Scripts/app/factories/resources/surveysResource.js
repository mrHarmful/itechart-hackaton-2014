///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.factories.resources')
    .factory('Surveys', ['$resource', function($resource) {
        return $resource('/api/surveys', null,
            {
                'get': {method: 'GET'}
            });
    }]);