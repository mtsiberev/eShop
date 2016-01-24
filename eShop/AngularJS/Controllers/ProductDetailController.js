'use strict';

var ProductDetailController = function ($scope, $routeParams, $http, $location, CatalogsService, ProductsService) {

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
    };

    $scope.cancel = function () {
        $location.path('/products');
    };

  

    $scope.setFileName = function (files) {
        $scope.filesToUpload = files;
    };

    $scope.uploadFile = function (files, productId) {
        var fileData = new FormData();
        fileData.append("file", files[0]);

        return $http({
            method: "POST",
            url: "Product/UploadFile",
            data: fileData,
            params: { id: productId },
            headers: { 'Content-Type': undefined },
            transformRequest: angular.identity
        }).then(function (result) {

            $scope.product.fileLink = result.data;
            return result.data;
        });
    };
 
    $scope.deleteFile = function (productId) {

        return $http({
            method: "GET",
            url: "Product/DeleteFile",
            params: { id: productId }
        }).then(function (result) {
            
            $scope.product.fileLink = result.data;
            return result.data;
        });
    };
    
};

ProductDetailController.$inject = ['$scope', '$routeParams', '$http', '$location', 'CatalogsService', 'ProductsService'];


