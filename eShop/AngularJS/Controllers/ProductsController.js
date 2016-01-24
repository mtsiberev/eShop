'use strict';

var ProductsController = function ($scope, $routeParams, $http, $location, ProductsService) {

    ProductsService.getProducts().then(function (data) { $scope.products = data; });

    $scope.addProduct = function () {
        $location.path('/product-create/');
    };

    $scope.editProduct = function (productId) {
        $location.path('/product-detail/' + productId);
    };

    $scope.deleteProduct = function (productId) {

        ProductsService.deleteProduct(productId).then(function () {
            ProductsService.getProducts().then(function (data) { $scope.products = data; });
        });
    };
    
};

ProductsController.$inject = ['$scope', '$routeParams', '$http', '$location', 'ProductsService'];



