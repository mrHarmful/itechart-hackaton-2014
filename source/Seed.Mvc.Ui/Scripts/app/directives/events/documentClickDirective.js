///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>
///<reference path="~/Scripts/app/services/utils/mathService.js"/>

'use strict';

angular.module('seedApp.directives.events')
    .directive('lmsDocumentClick', ['$document', '$parse', 'mathService', function($document, $parse, mathService) {
        return {
            restrict: 'A',
            link: function($scope, element, attr) {
                var scopeExpression = attr.lmsDocumentClick;
                var invoker = $parse(scopeExpression);
                var uniquePrivateFlag = '__' + mathService.newGuid() + '__lmsElementClicked';

                var elementClick = function() {
                    $scope[uniquePrivateFlag] = true;
                };

                var documentClick = function(event) {
                    if (!$scope[uniquePrivateFlag]) {
                        $scope.$apply(function() {
                            invoker($scope, {
                                $event: event
                            });
                        });
                    }
                    $scope[uniquePrivateFlag] = false;
                };

                element.on('click', elementClick);
                $document.on('click', documentClick);

                $scope.$on('$destroy', function() {
                    element.off('click', elementClick);
                    $document.off('click', documentClick);
                });
            }
        };
    }]);