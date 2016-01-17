'use strict';

//var ShopApp = angular.module('ShopApp', ["ngRoute"]);
var ShopApp = angular.module('ShopApp', ["ngRoute"]).run(function ($rootScope, $location, $timeout) {
    $rootScope.$on('$viewContentLoaded', function () {
        $timeout(function () {
            componentHandler.upgradeAllRegistered();
        });
    });
});


ShopApp.controller('ShopController', ShopController);

ShopApp.factory('ProductsService', ProductsService);
ShopApp.factory('CatalogsService', CatalogsService);
ShopApp.factory('OrdersService', OrdersService);
ShopApp.factory('UsersService', UsersService);

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