'use strict';

var CatalogDetailController = function ($scope, $routeParams, $http, $location, CatalogsService) {

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
        if ($scope.catalog.id == 0) {
            CatalogsService.addCatalog($scope.catalog.name).
                then(function () {
                    $location.path('/catalogs');
                });
        }

        else {
            CatalogsService.updateCatalog($scope.catalog.id, $scope.catalog.name).then(function () {
                $location.path('/catalogs');
            });
        }
    };

    $scope.cancel = function () {
        $location.path('/catalogs');
    };
};

CatalogDetailController.$inject = ['$scope', '$routeParams', '$http', '$location', 'CatalogsService'];


