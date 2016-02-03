'use strict';

var CatalogsController = function ($scope, $routeParams, $http, $location, CatalogsService) {

    console.log("in controller");

    var pageNum = 1;
    var pageSize = 5;
    var parentId = 0;
    CatalogsService.getCatalogsForOnePage(pageNum, pageSize, parentId).then(function (data) { $scope.catalogs = data; });
    //CatalogsService.getCatalogs().then(function (data) { $scope.catalogs = data; });
    

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

    $scope.prevPage = function () {

        pageNum--;
        CatalogsService.getCatalogsForOnePage(pageNum, pageSize, parentId).then(function (data) { $scope.catalogs = data; });
    };

    $scope.nextPage = function () {

        pageNum++;
        CatalogsService.getCatalogsForOnePage(pageNum, pageSize, parentId).then(function (data) { $scope.catalogs = data; });
    };

};

CatalogsController.$inject = ['$scope', '$routeParams', '$http', '$location', 'CatalogsService'];



