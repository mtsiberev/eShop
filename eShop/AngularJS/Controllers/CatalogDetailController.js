'use strict';

var CatalogDetailController = function ($scope, $routeParams, $http, $location, CatalogsService) {
    console.log("CatalogDetailController");

    if ($routeParams.id != null) {
        var id = $routeParams.id;
        CatalogsService.getCatalog(id).then(function (data) {
            $scope.catalog = data;
        });
    }
    else {
        $scope.catalog = { id: 0, name: "" };
    }
    
    $scope.saveCatalog = function () {
        console.log("ProductDetailController: updateProduct function before ProductsService.updateProduct call");
        if ($scope.catalog.id == 0) {
            CatalogsService.addCatalog($scope.catalog.name).
                then(function () {
                    $location.path('/catalogs');
          });
        }

        else {
            console.log("CatalogDetailController: updateCatalog function before CatalogsService.updateCatalog call");
            CatalogsService.updateCatalog($scope.catalog.id, $scope.catalog.name).then(function () {
                $location.path('/catalogs');
            });
            console.log("CatalogDetailController: updateCatalog function after CatalogsService.updateCatalog call");
        }
        console.log("ProductDetailController: updateProduct function after ProductsService.updateProduct call");
    };
    
    $scope.cancel = function () {
        $location.path('/catalogs');
    };
};

CatalogDetailController.$inject = ['$scope', '$routeParams', '$http', '$location', 'CatalogsService'];


