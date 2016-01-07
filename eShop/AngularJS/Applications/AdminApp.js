'use strict';

var AdminApp = angular.module('AdminApp', ["ngRoute"]);

AdminApp.controller('AdminMenuController', AdminMenuController);
AdminApp.controller('UsersController', UsersController);
AdminApp.controller('UserDetailController', UserDetailController);


AdminApp.factory('UsersService', UsersService);

var configFunction = function ($routeProvider) {
    $routeProvider.
        when('/users', {
            templateUrl: '/AngularJS/PartialViews/users.html',
            controller: UsersController
        }).
        when('/user-detail/:id', {
            templateUrl: '/AngularJS/PartialViews/user-detail.html',
            controller: UserDetailController
        }).
        //////////////////////////////////////////
        
    when('/catalogs', {
        templateUrl: '/AngularJS/PartialViews/users.html',
        controller: UsersController
    }).
    when('/products', {
        templateUrl: '/AngularJS/PartialViews/users.html',
        controller: UsersController
    }).

    otherwise({
        redirectTo: '/users'
    });
};

configFunction.$inject = ['$routeProvider', '$httpProvider'];
AdminApp.config(configFunction);