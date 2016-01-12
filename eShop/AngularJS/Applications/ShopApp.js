﻿'use strict';

var ShopApp = angular.module('ShopApp', ["ngRoute"]);

ShopApp.controller('ShopController', ShopController);

ShopApp.factory('ProductsService', ProductsService);
ShopApp.factory('CatalogsService', CatalogsService);

var configFunction = function ($routeProvider) {
    $routeProvider.
        when('/shop', {
            templateUrl: '/AngularJS/PartialViews/shop.html',
            controller: ShopController
        }).
        when('/cart', {
            templateUrl: '/AngularJS/PartialViews/cart.html',
            controller: ShopController
        }).
        otherwise({
            redirectTo: '/shop'
        });
};

configFunction.$inject = ['$routeProvider', '$httpProvider'];
ShopApp.config(configFunction);