///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/lib/angular-ui-router.js"/>

'use strict';

//TODO: remove after debug
window.onerror = function(errorMsg, url, lineNumber, columnNumber, errorObject) {
    var errMsg;
    //check the errorObject as IE and FF don't pass it through (yet)
    if (errorObject && errorObject !== undefined) {
        errMsg = errorObject.message;
    } else {
        errMsg = errorMsg;
    }
    console.log('Error: ' + errMsg);
};
//TODO: remove after debug

/***** Resources *****/
angular.module('seedApp.factories.resources', ['ngResource']);

/***** Filters *****/
angular.module('seedApp.filters', []);
angular.module('seedApp.filters.formats', []);

/***** Services *****/
angular.module('seedApp.services.utils', ['seedApp.factories.resources']);
angular.module('seedApp.services.clients', ['seedApp.factories.resources']);

/***** Factories *****/
angular.module('seedApp.factories', []);
angular.module('seedApp.factories.controls', ['seedApp.services.utils']);

/***** Directives *****/
angular.module('seedApp.directives.events', ['seedApp.services.utils']);
angular.module('seedApp.directives.controls', [
    'ui.bootstrap',
    'seedApp.factories.controls',
    'seedApp.factories.resources',
    'seedApp.directives.events']);

/***** Controllers *****/
angular.module('seedApp.controllers.app', [
    'seedApp.services.clients',
    'seedApp.directives.controls']);
angular.module('seedApp.controllers.views', [
    'seedApp.services.clients',
    'seedApp.directives.controls']);

/***** Application *****/
angular.module('seedApp', [
    'ui.router',
    'seedApp.factories',
    'seedApp.filters',
    'seedApp.controllers.app',
    'seedApp.controllers.views']);