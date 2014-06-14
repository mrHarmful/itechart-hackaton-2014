///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.controllers.app')
    .controller('errorController', ['$scope', '$stateParams', 'errorCodesService', function($scope, $stateParams, errorCodesService) {
        $scope.error = errorCodesService.getErrorDetails($stateParams.errorCode);
    }]);