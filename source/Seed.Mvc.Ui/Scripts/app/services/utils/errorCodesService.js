'use strict';

angular.module('seedApp.services.utils')
    .service('errorCodesService', ['localizationService', function(localizationService) {
        var errorCodes = {
            404: {
                code: 404,
                codeDescription: 'Not Found',
                message: localizationService.errorMessage('ResourceNotFound')
            },
            500: {
                code: 500,
                codeDescription: 'Server Error',
                message: localizationService.errorMessage('AjaxServerError')
            },
            401: {
                code: 401,
                codeDescription: 'Unauthorized',
                message: localizationService.errorMessage('UnauthorizedAction')
            }
        };

        this.getErrorDetails = function(code) {
            var result = null;
            
            if(errorCodes.hasOwnProperty(code)) {
                result = errorCodes[code];
            }

            return result;
        };
    }]);