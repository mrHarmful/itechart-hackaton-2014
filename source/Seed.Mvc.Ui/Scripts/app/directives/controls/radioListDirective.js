///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.directives.controls').directive('seedRadioList', function() {
    return {
        restrict: 'A',
        replace: true,
        templateUrl: '/Templates/partials/radioList.html',
        scope: {
            model: '=seedRadioList'
        },
        link: function($scope) {
            $scope.list = $scope.model.items;
            $scope.selected = $scope.list[0].value;

            $scope.$watch('selected', function (newValue) {
                angular.forEach($scope.list, function (item){                    
                    if (item.value != newValue) {
                        item.selected = false;
                    }
                });
            });
        }
    };
});