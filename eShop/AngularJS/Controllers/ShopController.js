'use strict';

var ShopController = function($scope, $routeParams, DataService) {

    $scope.store = DataService.store;
    $scope.cart = DataService.cart;

    // use routing to pick the selected product
    if ($routeParams.productSku != null) {
        $scope.product = $scope.store.getProduct($routeParams.productSku);
    };
};

ShopController.$inject = ['$scope', '$routeParams', 'DataService'];



