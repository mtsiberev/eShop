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
    
    $scope.updateCatalog = function () {
        console.log("CatalogDetailController: updateCatalog function before CatalogsService.updateCatalog call");
        CatalogsService.updateCatalog($scope.catalog.id, $scope.catalog.name).then(function () {
            $location.path('/catalogs');
        });
        console.log("CatalogDetailController: updateCatalog function after CatalogsService.updateCatalog call");
    };
    
    $scope.createCatalog = function () {
        CatalogsService.addCatalog($scope.catalog.name).
            then(function () {
                $location.path('/catalogs');
            });
    };
    
    $scope.cancel = function () {
        $location.path('/catalogs');
    };
};

CatalogDetailController.$inject = ['$scope', '$routeParams', '$http', '$location', 'CatalogsService'];


