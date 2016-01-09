'use strict';

var ProductDetailController = function ($scope, $routeParams, $http, $location, CatalogsService, ProductsService) {
    console.log("ProductDetailController");


    if ($routeParams.id != null) {
        var id = $routeParams.id;
        ProductsService.getProduct(id).then(function (product) {
            $scope.product = product;
            CatalogsService.getCatalogs().then(function (catalogs) {
                $scope.catalogs = catalogs;
                
                var catalog = new Object();
                for (var i = 0, len = catalogs.length; i < len; i++)
                {
                    if (catalogs[i].id == $scope.product.id)
                    {
                        catalog = catalogs[i];
                    }
                }
                $scope.currentCatalog = catalog;
            });
        });
    }

    else {
        CatalogsService.getCatalogs().then(function (data) {
            $scope.catalogs = data;
            $scope.product = { catalogId: 0, name: "", description: "" };
        });
    }

    $scope.createProduct = function () {
        ProductsService.addProduct($scope.product.catalogId, $scope.product.name, $scope.product.description).
            then(function () {
                $location.path('/products');
            });
    };

    $scope.updateProduct = function () {
        console.log("ProductDetailController: updateProduct function before ProductsService.updateProduct call");
        ProductsService.updateProduct($scope.product.id, $scope.product.catalogId, $scope.product.name, $scope.product.description).
            then(function () {
                $location.path('/products');
            });
        console.log("ProductDetailController: updateProduct function after ProductsService.updateProduct call");
    };

    $scope.cancel = function () {
        $location.path('/products');
    };
};

ProductDetailController.$inject = ['$scope', '$routeParams', '$http', '$location', 'CatalogsService', 'ProductsService'];


