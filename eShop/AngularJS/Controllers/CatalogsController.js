'use strict';

var CatalogsController = function ($scope, $routeParams, $http, $location, CatalogsService) {

    CatalogsService.getCatalogs().then(function (data) { $scope.catalogs = data; });

    $scope.addCatalog = function () {
        console.log("CatalogsController: createCatalog");
        $location.path('catalog-create/');
    };

    $scope.editCatalog = function (catalogId) {
        console.log("CatalogsController: editCatalog");
        $location.path('/catalog-detail/' + catalogId);
    };

    $scope.deleteCatalog = function (catalogId) {
        console.log("CatalogsController: deleteCatalog before CatalogsService.deleteCatalog call");
        CatalogsService.deleteCatalog(catalogId).then(function () {
            CatalogsService.getCatalogs().then(function (data) { $scope.catalogs = data; });
        });
        console.log("CatalogsController: deleteCatalog after CatalogsService.deleteCatalog call");
    };
};

CatalogsController.$inject = ['$scope', '$routeParams', '$http', '$location', 'CatalogsService'];



