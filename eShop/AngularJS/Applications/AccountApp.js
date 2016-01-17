'use strict';

//var ShopApp = angular.module('ShopApp', ["ngRoute"]);
var AccountApp = angular.module('AccountApp', ["ngRoute"]).run(function ($rootScope, $location, $timeout) {
    $rootScope.$on('$viewContentLoaded', function () {
        $timeout(function () {
            componentHandler.upgradeAllRegistered();
        });
    });
});

AccountApp.controller('AccountController', ShopController);
AccountApp.controller('AdminMenuController', AdminMenuController);

AccountApp.factory('UsersService', UsersService);

var configFunction = function ($routeProvider) {
    $routeProvider.
        when('/login', {
            templateUrl: '/AngularJS/PartialViews/login.html',
            controller: AccountController
        }).
        when('/register', {
            templateUrl: '/AngularJS/PartialViews/register.html',
            controller: AccountController
        }).
        otherwise({
            redirectTo: '/login'
        });
};

configFunction.$inject = ['$routeProvider', '$httpProvider'];
AccountApp.config(configFunction);