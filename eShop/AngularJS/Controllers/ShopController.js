'use strict';

var ShopController = function ($scope, $routeParams, $http, $location, ProductsService, OrdersService, UsersService) {

    ProductsService.getProducts().then(function (data) { $scope.products = data; });
    UsersService.getCurrentUser().then(function(id) {
        $scope.userId = id;
        OrdersService.getOrderContent($scope.userId).then(function (data) { $scope.content = data; });
    });
   
        $scope.addToCart = function (productId) {
            console.log("ShopController: addToCart before OrdersService.addToCart call");
            OrdersService.addToCart(productId).then(function () {
                ProductsService.getProducts().then(function(products) {
                    $scope.products = products;
                    OrdersService.getOrderContent($scope.userId).then(function (data) { $scope.content = data; });
                });
            });
            console.log("ShopController: addToCart after OrdersService.addToCart call");
        };
    
        $scope.deleteFromCart = function (productId) {
            console.log("ShopController: deleteProduct before OrdersService.deleteFromCart call");
            OrdersService.deleteFromCart(productId).then(function () {
                ProductsService.getProducts().then(function (products) {
                    $scope.products = products;
                    OrdersService.getOrderContent($scope.userId).then(function (data) { $scope.content = data; });
                });
            });
            console.log("ShopController: deleteProduct after OrdersService.deleteFromCart call");
        };
};

ShopController.$inject = ['$scope', '$routeParams', '$http', '$location', 'ProductsService', 'OrdersService', 'UsersService'];