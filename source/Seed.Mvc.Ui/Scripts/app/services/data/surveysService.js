///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.services.clients')
    .service('surveysService', ['Surveys', function(Surveys) {
        var self = this;

        this.getUserSurveys = function () {
            var result = Surveys.all();

            return result;
        };
        
        this.getAvailableSurveys = function () {
            var result = Surveys.available();

            return result;
        };
        
        this.getQuiz = function (id) {
            var result = Surveys.getQuiz({id: id});

            return result;
        };
        
        this.getSingleQuestion = function (id) {
            var result = Surveys.getSingleQuestion({ id: id });

            return result;
        };
        
        this.getAttendSurvey = function (id) {
            var result = Surveys.getAttend({ id: id });

            return result;
        };
        
        this.saveQuiz = function (survey) {
            Surveys.saveQuiz(survey);
        };
        
        this.saveSingleQuestion = function (survey) {
            Surveys.saveSingleQuestion(survey);
        };
        
        this.getPointsStatus = function () {
            Surveys.getStatus();
        };
    }]);