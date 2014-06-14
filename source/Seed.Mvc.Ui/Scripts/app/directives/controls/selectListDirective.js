///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>
///<reference path="~/Scripts/app/factories/controls/selectListFactory.js"/>

'use strict';

angular.module('seedApp.directives.controls').directive('lmsSelectList', ['selectListFactory', function(selectListFactory) {
    return {
        restrict: 'E',
        require: ['ngModel'],
        templateUrl: '/Templates/partials/selectList.html',
        scope: {
            ngModel: '=',
            lmsSelectedValue: '='
        },
        link: function($scope) {
            $scope.selectList = selectListFactory.get($scope.ngModel, $scope.lmsSelectedValue);

            $scope.onItemClick = function(itemValue) {
                $scope.selectList.hideList();
                $scope.selectList.setSelectedItem(itemValue);
                $scope.lmsSelectedValue = $scope.selectList.getSelectedValue();
            };
        }
    };
}]);