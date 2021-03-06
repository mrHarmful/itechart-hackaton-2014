﻿///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.controllers.app').controller('dashboardController', ['$scope', '$timeout', function ($scope, $timeout) {
    $scope.alerts = [];
    $scope.statAlert = {
        questions: 20,
        quizzes: 10,
        points: 30,
        css: 'red',
        visible: false
    };
    
    $scope.showAlert = function (text, type, fade) {
        type = type || 'red';
        
        var alert = {
            text: text,
            css: type
        };

        $scope.alerts.push(alert);
        
        if (fade) {
            $timeout(function() {
                $scope.removeAlert(alert);
            }, 3000);
        }
    };

    $scope.showStatAlert = function () {
        $scope.statAlert.visible = true;
    };

    $scope.removeAlert = function (alert) {
        var index = $scope.alerts.indexOf(alert);
        
        if (index < 0) {
            return;
        }

        $scope.alerts.splice(index, 1);
    };
    
    $scope.showAlert('Welcome back, Dmitry!', 'green', true);
    $scope.showStatAlert();
}]);