///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.services.utils')
    .service('arrayService', function() {
        var self = this;

        self.first = function(array, func) {
            if (!angular.isFunction(func)) {
                return null;
            }

            for (var i = 0; i < array.length; i++) {
                if (func(array[i])) {
                    return array[i];
                }
            }

            return null;
        };

        self.map = function(array, constructor) {
            if (!angular.isFunction(constructor)) {
                return null;
            }

            var result = array.map(function(item) {
                return new constructor(item);
            });

            return result;
        };

        self.setCheckedItems = function(oldArray, newArray) {
            newArray.forEach(function(newItem) {
                var oldItem = self.first(oldArray, function(item) {
                    return item.label == newItem.label;
                });

                if (oldItem != null) {
                    newItem.isChecked = oldItem.isChecked;
                }
            });
        };

        self.checkItemsIfNeed = function(array, checkedItemsNumber) {
            var currentCheckedItemsNubmer = 0;

            array.forEach(function(item) {
                if (item.isChecked) {
                    currentCheckedItemsNubmer++;
                }
            });

            for (var i = currentCheckedItemsNubmer; i < checkedItemsNumber; i++) {
                var unchekedFirst = self.first(array, function(item) {
                    return !item.isChecked;
                });
                
                if (unchekedFirst != null) {
                    unchekedFirst.isChecked = true;
                } else {
                    break;
                }
            }
        };
    });