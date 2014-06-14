///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.directives.controls').directive('lmsPagination',['$state', 'paginationService', function($state, paginationService) {
    return {
        restrict: 'E',
        require: 'ngModel',
        scope: {
            ngModel: '='
        },
        templateUrl: '/templates/partials/pagination.html',
        link: function($scope, elem, attrs) {
            var options = $scope.ngModel;
            options.pageNumber = $state.params.pageNumber;
            
            $scope.pagination = paginationService.build(options);
            $scope.stateName = $state.current.name;
            $scope.bookNumber = $state.params.bookNumber;
            $scope.orgId = $state.params.orgId;
            $scope.currentPageNumber = $state.params.pageNumber;
        }
    };
}]);