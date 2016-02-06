'use strict';

var CatalogsController = function ($scope, $routeParams, $http, $location, CatalogsService) {

    initPage();
    
    function initPage() {
        $scope.pageNum = 1;
        $scope.pageSize = 5;
        $scope.parentId = 0;
        $scope.maxPageNumber = 0;
        refreshPage();
    }
    
    function refreshPage() {
        CatalogsService.getCount($scope.parentId).then(function (count) {
            $scope.maxPageNumber = Math.floor(count / $scope.pageSize);
            if ((count % $scope.pageSize) != 0) $scope.maxPageNumber++;
            if ($scope.maxPageNumber == 0) $scope.maxPageNumber++;
            if ($scope.pageNum > $scope.maxPageNumber) $scope.pageNum = $scope.maxPageNumber;

            CatalogsService.getCatalogsForOnePage($scope.pageNum, $scope.pageSize, $scope.parentId).then(function (data) {
                $scope.catalogs = data;
            });
        });
    };

    $scope.addCatalog = function () {

        $location.path('catalog-create/');
    };

    $scope.editCatalog = function (catalogId) {

        $location.path('/catalog-detail/' + catalogId);
    };

    $scope.deleteCatalog = function (catalogId) {

        CatalogsService.deleteCatalog(catalogId).then(function () {
            refreshPage();
        });
    };

    $scope.prevPage = function () {
        $scope.pageNum--;
        if ($scope.pageNum <= 0) $scope.pageNum = 1;
        CatalogsService.getCatalogsForOnePage($scope.pageNum, $scope.pageSize, $scope.parentId).then(function (data) { $scope.catalogs = data; });
    };

    $scope.nextPage = function () {
        $scope.pageNum++;
        if ($scope.pageNum > $scope.maxPageNumber) $scope.pageNum = $scope.maxPageNumber;
        CatalogsService.getCatalogsForOnePage($scope.pageNum, $scope.pageSize, $scope.parentId).then(function (data) { $scope.catalogs = data; });
    };

};

CatalogsController.$inject = ['$scope', '$routeParams', '$http', '$location', 'CatalogsService'];



