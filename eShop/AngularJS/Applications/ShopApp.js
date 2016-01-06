'use strict';

var ShopApp = angular.module('ShopApp', ["ngRoute"]);

ShopApp.controller('ShopController', ShopController);
ShopApp.factory('DataService', DataService);

var configFunction = function ($routeProvider) {
    $routeProvider.
        when('/store', {
            templateUrl: '/AngularJS/PartialViews/shop.html',
            controller: ShopController
        }).
        when('/products/:productSku', {
            templateUrl: '/AngularJS/PartialViews/shop.html',
            controller: ShopController
        }).
        when('/cart', {
            templateUrl: '/AngularJS/PartialViews/shop.html',
            controller: ShopController
        }).
        otherwise({
            redirectTo: '/store'
        });
};

configFunction.$inject = ['$routeProvider', '$httpProvider'];
ShopApp.config(configFunction);