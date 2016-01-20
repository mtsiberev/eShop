'use strict';

var CatalogsController = function ($scope, $routeParams, $http, $location, CatalogsService) {

    CatalogsService.getCatalogs().then(function (data) { $scope.catalogs = data; });

    $scope.addCatalog = function () {

        $location.path('catalog-create/');
    };

    $scope.editCatalog = function (catalogId) {

        $location.path('/catalog-detail/' + catalogId);
    };

    $scope.deleteCatalog = function (catalogId) {

        CatalogsService.deleteCatalog(catalogId).then(function () {
            CatalogsService.getCatalogs().then(function (data) { $scope.catalogs = data; });
        });
    };
};

CatalogsController.$inject = ['$scope', '$routeParams', '$http', '$location', 'CatalogsService'];



