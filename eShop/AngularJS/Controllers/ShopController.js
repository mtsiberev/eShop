'use strict';

var ShopController = function ($scope, $routeParams, $http, $location, ProductsService, OrdersService, UsersService, CatalogsService, ngDialog) {
    
    CatalogsService.getCatalogs().then(function (data) { $scope.catalogs = data; });
    ProductsService.getProducts().then(function (data) { $scope.products = data; });

    UsersService.getCurrentUser().then(function (id) {
        $scope.userId = id;
        OrdersService.getOrderContent($scope.userId).then(function (data) { $scope.content = data; });
    });

    $scope.addToCart = function (productId, qty) {
        if ((qty > 50) || (qty <= 0) || (qty == undefined)) {
            return;
        };

        OrdersService.addToCart(productId, qty).then(function () {
            ProductsService.getProducts().then(function (products) {
                $scope.products = products;
                OrdersService.getOrderContent($scope.userId).then(function (data) { $scope.content = data; });
            });
        });
    };

    $scope.deleteFromCart = function (productId) {
        OrdersService.deleteFromCart(productId).then(function () {
            ProductsService.getProducts().then(function (products) {
                $scope.products = products;
                OrdersService.getOrderContent($scope.userId).then(function (data) { $scope.content = data; });
            });
        });
    };

    $scope.selectCatalog = function (catalogId) {
        $scope.currentCatalogId = catalogId;
        ProductsService.getProductsFromCatalog($scope.currentCatalogId).then(function (data) { $scope.products = data; });
    };

    $scope.selectAllCatalogs = function () {
        $scope.currentCatalogId = 0;
        ProductsService.getProducts().then(function (data) { $scope.products = data; });
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