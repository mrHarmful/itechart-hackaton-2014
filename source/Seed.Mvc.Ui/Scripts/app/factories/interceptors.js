
angular.module('seedApp.factories').factory('errorsInterceptor', ['$injector','$q', function($injector, $q) {
    return {
        responseError: function(rejection) {
            var $state = $injector.get('$state');

            $state.go('dashboard.error', { errorCode: rejection.status });
            
            return rejection;
        }
    };
}]);