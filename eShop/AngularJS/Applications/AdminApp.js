'use strict';

var AdminApp = angular.module('AdminApp', ["ngRoute"]);

AdminApp.controller('AdminMenuController', AdminMenuController);

AdminApp.controller('UsersController', UsersController);
AdminApp.controller('UserDetailController', UserDetailController);

AdminApp.controller('ProductsController', ProductsController);
AdminApp.controller('ProductDetailController', ProductDetailController);

AdminApp.controller('ProductCreateController', ProductCreateController);

AdminApp.factory('UsersService', UsersService);
AdminApp.factory('ProductsService', ProductsService);


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
        /*-----------------------------------------------------*/
        when('/products', {
        templateUrl: '/AngularJS/PartialViews/products.html',
        controller: ProductsController
        }).

        when('/product-detail/:id', {
               templateUrl: '/AngularJS/PartialViews/product-detail.html',
               controller: ProductDetailController
        }).

        when('/product-create/', {
            templateUrl: '/AngularJS/PartialViews/product-detail.html',
            controller: ProductDetailController
        }).
        
           when('/catalogs', {
               templateUrl: '/AngularJS/PartialViews/users.html',
               controller: UsersController
           }).


    otherwise({
        redirectTo: '/users'
    });
};

configFunction.$inject = ['$routeProvider', '$httpProvider'];
AdminApp.config(configFunction);