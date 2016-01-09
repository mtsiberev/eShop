'use strict';

var ProductsController = function ($scope, $routeParams, $http, $location, ProductsService) {

    ProductsService.getProducts().then(function (data) { $scope.products = data; });

    $scope.addProduct = function () {
        console.log("ProductsController: createProduct");
        $location.path('/product-create/');
    };

    $scope.editProduct = function (productId) {
        console.log("ProductsController: editProduct");
        $location.path('/product-detail/' + productId);
    };

    $scope.deleteProduct = function (productId) {
        console.log("ProductsController: deleteProduct before ProductsService.deleteProduct call");
        ProductsService.deleteProduct(productId).then(function () {
            ProductsService.getProducts().then(function (data) { $scope.products = data; });
        });
        console.log("ProductsController: deleteProduct after ProductsService.deleteProduct call");
    };
};

ProductsController.$inject = ['$scope', '$routeParams', '$http', '$location', 'ProductsService'];



