///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.factories.resources')
    .factory('Localization', ['$resource', function($resource) {
        return $resource('/api/localization/:culture', null,
            {
                'get': {method: 'GET'}
            });
    }]);