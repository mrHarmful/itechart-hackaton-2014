///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>
///<reference path="~/Scripts/app/services/utils/arrayService.js"/>

'use strict';

angular.module('seedApp.factories.controls')
    .factory('selectListFactory', ['arrayService', function(arrayService) {

        function selectList(data, selectedValue) {
            var self = this;

            // Properties
            self.items = null;
            self.isVisibleList = null;

            // Methods
            self.init = function() {
                if (angular.isDefined(data.caption) && data.caption != null) {
                    data.items.unshift({text: data.caption, value: null, selected: false});
                }

                self.items = data.items;

                if (self.getSelectedValue() == null) {
                    if (selectedValue != null && angular.isDefined(selectedValue)) {
                        self.setSelectedItem(selectedValue);
                    }
                    if (self.getSelectedValue() == null) {
                        self.setSelectedItem(self.items[0].value);
                    }
                }

                self.hideList();
            };

            self.getSelectedItem = function() {
                return arrayService.first(self.items, function(item) {
                    return item.selected;
                });
            };

            self.getSelectedValue = function() {
                var item = self.getSelectedItem();

                if (item != null) {
                    return item.value;
                }

                return null;
            };

            self.getSelectedText = function() {
                var item = self.getSelectedItem();

                if (item != null) {
                    return item.text;
                }

                return null;
            };

            self.getCaption = function() {
                var item = self.getSelectedItem();

                if (item != null) {
                    return item.text;
                }

                return null;
            };

            self.setSelectedItem = function(value) {
                var oldSelectedItem = self.getSelectedItem();

                if (oldSelectedItem != null) {
                    oldSelectedItem.selected = false;
                }

                var newSelectedItem = arrayService.first(self.items, function(item) {
                    return item.value == value;
                });

                if (newSelectedItem != null) {
                    newSelectedItem.selected = true;
                }
            };

            self.toggleList = function() {
                self.isVisibleList = !self.isVisibleList;
            };

            self.hideList = function() {
                self.isVisibleList = false;
            };

            // Initialization
            self.init();

            return self;
        }

        return {
            get: function(data, element) {
                return new selectList(data, element);
            }
        };
    }]);