﻿'use strict';

var ShopController = function ($scope, $routeParams, $http, $location, ProductsService, OrdersService, UsersService, CatalogsService, ngDialog) {

    initShop();

    function initShop() {
        console.log("ShopController init function");
        CatalogsService.getCatalogs().then(function (data) {
            $scope.catalogs = data;
            $scope.selectedCatalogId = null;
        });
        UsersService.getCurrentUser().then(function (id) {
            $scope.userId = id;
            refreshShopPage();
        });
    };

    function refreshShopPage() {
        if ($scope.selectedCatalogId == null) {
            ProductsService.getProducts().then(function (products) {
                $scope.products = products;
                OrdersService.getOrderContent($scope.userId).then(function (order) { $scope.content = order; });
            });
        }
        else {
            ProductsService.getProductsFromCatalog($scope.selectedCatalogId).then(function (products) {
                $scope.products = products;
                OrdersService.getOrderContent($scope.userId).then(function (order) { $scope.content = order; });
            });
        }
    };

    $scope.isCatalogSelected = function (id) {
        if ($scope.selectedCatalogId == id) return true;
        else {
            return false;
        }
    };

    $scope.isCartEmpty = function () {
        if ($scope.content == undefined) return true;
        if ($scope.content.OrderItemsList.length == 0) return true;
        return false;
    };

    $scope.addToCart = function (productId, qty) {
        if ((qty > 50) || (qty <= 0) || (qty == undefined)) {
            return;
        };
        OrdersService.addToCart(productId, qty).then(function () {
            refreshShopPage();
        });
    };

    $scope.deleteFromCart = function (productId) {
        OrdersService.deleteFromCart(productId).then(function () {
            refreshShopPage();
        });
    };

    $scope.selectCatalog = function (catalogId) {
        $scope.selectedCatalogId = catalogId;
        refreshShopPage();
    };

    $scope.selectAllCatalogs = function () {
        $scope.selectedCatalogId = null;
        refreshShopPage();
    };

    $scope.checkout = function () {
        UsersService.getCurrentUser().then(function (id) {
            $scope.userId = id;
            OrdersService.getOrderContent($scope.userId).then(function (data) {
                $scope.content = data;
                $location.path('/shopping-cart');
            });
        });
    };

    $scope.approveOrder = function () {
        UsersService.getCurrentUser().then(function (id) {
            $scope.userId = id;
            OrdersService.approveOrder($scope.userId).then(function (data) {
                $scope.content = data;
                $location.path('/shop');
            });
        });
    };

    $scope.openConfirm = function () {
        ngDialog.openConfirm({
            template: 'AngularJS/PartialViews/modalConfirm.html',
            className: 'ngdialog-theme-default'
        }).then(function () {
            $scope.approveOrder();
        }, function () {
        });
    };

    $scope.openProductInfo = function (product) {
        $scope.product = product;

        ngDialog.openConfirm({
            template: 'AngularJS/PartialViews/modalProductInfo.html',
            className: 'ngdialog-theme-default',
            scope: $scope
        }).then(function () {
        }, function () {
        });
    };

};

ShopController.$inject = ['$scope', '$routeParams', '$http', '$location', 'ProductsService', 'OrdersService', 'UsersService', 'CatalogsService', 'ngDialog'];