'use strict';

var ShopController = function ($scope, $routeParams, $http, $location, ProductsService) {

    ProductsService.getProducts().then(function (data) { $scope.products = data; });

};

ShopController.$inject = ['$scope', '$routeParams', '$http', '$location', 'ProductsService'];



