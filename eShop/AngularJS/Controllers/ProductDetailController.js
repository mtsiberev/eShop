'use strict';

var ProductDetailController = function ($scope, $routeParams, $http, $location, ProductsService) {
    console.log("ProductDetailController");



    if ($routeParams.id != null) {
        var id = $routeParams.id;
        ProductsService.getProduct(id).then(function (data) { $scope.product = data; });
    }
    else {
        $scope.product = { catalogId: 0, name: "500", description: "white" };
    }

    $scope.createProduct = function () {
        ProductsService.addProduct($scope.product.catalogId, $scope.product.name, $scope.product.description);
        $location.path('/products');
    };
    
    $scope.updateProduct = function () {
        console.log("ProductDetailController: updateProduct function before ProductsService.updateProduct call");
        ProductsService.updateProduct($scope.product.id, $scope.product.catalogId, $scope.product.name, $scope.product.description);
        console.log("ProductDetailController: updateProduct function after ProductsService.updateProduct call");
        $location.path('products');
    };

    $scope.cancel = function () {
        $location.path('/products');
    };
};

ProductDetailController.$inject = ['$scope', '$routeParams', '$http', '$location', 'ProductsService'];


