///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.directives.controls').directive('seedCheckboxDropdown', function() {
    return {
        restrict: 'A',
        replace: true,
        templateUrl: '/Templates/partials/checkboxDropdown.html',
        scope: {
            model: '=seedCheckboxDropdown'
        },
        link: function ($scope) {
            $scope.getSelectedText = function() {
                var text;

                var texts = $scope.model.items.filter(function(item) {
                    return item.selected;
                }).map(function(item) {
                    return item.text;
                });

                if (texts != null && texts.length > 0) {
                    if (texts.length > 1) {
                        text = texts[0] + ' ...' + (texts.length - 1) + ' More';
                    } else {
                        text = texts[0];
                    }
                } else {
                    text = $scope.model.caption;
                }

                return text;
            };

            $scope.toggleList = function() {
                $scope.isVisibleList = !$scope.isVisibleList;
            };
            
            $scope.hideList = function () {
                $scope.isVisibleList = false;
            };

            $scope.isVisibleList = false;
        }
    };
});