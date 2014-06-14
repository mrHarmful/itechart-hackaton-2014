
angular.module('seedApp.factories').factory('errorsInterceptor', ['$injector','$q', function($injector, $q) {
    return {
        responseError: function(rejection) {
            var $state = $injector.get('$state');

            $state.go('error', { errorCode: rejection.status });
            
            return rejection;
        }
    };
}]);