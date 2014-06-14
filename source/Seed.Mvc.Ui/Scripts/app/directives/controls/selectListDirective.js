///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>
///<reference path="~/Scripts/app/factories/controls/selectListFactory.js"/>

'use strict';

angular.module('seedApp.directives.controls').directive('seedSelectList', ['selectListFactory', function(selectListFactory) {
    return {
        restrict: 'A',
        templateUrl: '/Templates/partials/selectList.html',
        scope: {
            model: '=seedSelectList',
            selectedValue: '='
        },
        link: function($scope) {
            $scope.onItemClick = function(itemValue) {
                $scope.selectList.hideList();
                $scope.selectList.setSelectedItem(itemValue);
                $scope.selectedValue = $scope.selectList.getSelectedValue();
            };

            $scope.$watch('model', function(newValue, oldValue) {
                if (newValue === oldValue) {
                    return;
                }

                $scope.selectList = selectListFactory.get($scope.model, $scope.lmsSelectedValue);
            });
        }
    };
}]);