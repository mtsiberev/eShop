'use strict';

var ProductDetailController = function ($scope, $routeParams, $http, $location, CatalogsService, ProductsService) {
    console.log("ProductDetailController");

    if ($routeParams.id != null) {
        var id = $routeParams.id;
        ProductsService.getProduct(id).then(function (product) {
            $scope.product = product;
            CatalogsService.getCatalogs().then(function (catalogs) {
                $scope.catalogs = catalogs;
            });
        });
    }
    else {
        CatalogsService.getCatalogs().then(function (data) {
            $scope.catalogs = data;
            $scope.product = { id: 0, catalogId: 0, name: "", description: "" };
        });
    }

    $scope.saveProduct = function () {
        console.log("ProductDetailController: updateProduct function before ProductsService.updateProduct call");
        if ($scope.product.id == 0) {
            ProductsService.addProduct($scope.product.catalogId, $scope.product.name, $scope.product.description).
                then(function () {
                    $location.path('/products');
                });
        }
        else {
            ProductsService.updateProduct($scope.product.id, $scope.product.catalogId, $scope.product.name, $scope.product.description).
         then(function () {
             $location.path('/products');
         });
        }
        console.log("ProductDetailController: updateProduct function after ProductsService.updateProduct call");
    };

    $scope.cancel = function () {
        $location.path('/products');
    };
};

ProductDetailController.$inject = ['$scope', '$routeParams', '$http', '$location', 'CatalogsService', 'ProductsService'];


