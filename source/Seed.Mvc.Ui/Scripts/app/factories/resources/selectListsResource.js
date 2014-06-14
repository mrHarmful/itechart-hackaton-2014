///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.factories.resources')
    .factory('SelectLists', ['$resource', function($resource) {
        return $resource(null, null,
            {
                'categories': { method: 'GET', url: '/api/categories' },
                'targets': { method: 'GET', url: '/api/targets' },
                'priorities': { method: 'GET', url: '/api/priorities' },
            });
    }]);