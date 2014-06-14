///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.services.clients')
    .service('surveysService', ['Surveys', function(Surveys) {
        var self = this;

        this.getUserSurveys = function () {
            var result = Surveys.get();

            return result;
        };
        
        this.getSurvey = function (id) {
            var result = Surveys.get({id: id});

            return result;
        };

    }]);