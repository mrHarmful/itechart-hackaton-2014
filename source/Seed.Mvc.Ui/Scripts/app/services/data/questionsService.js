///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.services.clients')
    .service('questionsService', ['Questions', function(Questions) {
        var self = this;

        this.getQuestion = function(id) {
            var result = Questions.get({ questionId: id });

            return result;
        };
        
        this.saveQuestionAnswer = function (questionId, answers) {
            var result = Questions.saveAnswer({
                questionId: questionId,
                answersIds: answers
            });

            return result;
        };
    }]);