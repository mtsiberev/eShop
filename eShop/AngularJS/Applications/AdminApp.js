'use strict';

var AdminApp = angular.module('AdminApp', ["ngRoute"]);

AdminApp.controller('AdminMenuController', AdminMenuController);

AdminApp.controller('UsersController', UsersController);
AdminApp.controller('UserDetailController', UserDetailController);
AdminApp.controller('ProductsController', ProductsController);
AdminApp.controller('ProductDetailController', ProductDetailController);
AdminApp.controller('CatalogsController', CatalogsController);
AdminApp.controller('CatalogDetailController', CatalogDetailController);

AdminApp.factory('UsersService', UsersService);
AdminApp.factory('ProductsService', ProductsService);
AdminApp.factory('CatalogsService', CatalogsService);

/*--------------------users----------------------------*/
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
        /*--------------products-------------------------------*/
        when('/products', {
        templateUrl: '/AngularJS/PartialViews/products.html',
        controller: ProductsController
        }).

        when('/product-detail/:id', {
               templateUrl: '/AngularJS/PartialViews/product-detail.html',
               controller: ProductDetailController
        }).

        when('/product-create/', {
            templateUrl: '/AngularJS/PartialViews/product-create.html',
            controller: ProductDetailController
        }).
           /*--------------catalogs-------------------------------*/
           when('/catalogs', {
               templateUrl: '/AngularJS/PartialViews/catalogs.html',
               controller: CatalogsController
           }).

           when('/catalog-detail/:id', {
               templateUrl: '/AngularJS/PartialViews/catalog-detail.html',
               controller: CatalogDetailController
           }).

            when('/catalog-create', {
                templateUrl: '/AngularJS/PartialViews/catalog-create.html',
                controller: CatalogDetailController
            }).
               /*-------------default---------------------------------*/
    otherwise({
        redirectTo: '/users'
    });
};

configFunction.$inject = ['$routeProvider', '$httpProvider'];
AdminApp.config(configFunction);