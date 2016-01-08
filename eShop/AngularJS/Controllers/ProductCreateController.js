'use strict';

var ProductCreateController = function ($scope, $routeParams, $http, $location, ProductsService) {
    console.log("ProductDetailController");
    
    $scope.createProduct = function () {
       ProductsService.addProduct($scope.product.catalogId, $scope.product.name, $scope.product.description);
       $location.path('/products');
    };

    $scope.cancel = function () {
        $location.path('/products');
    };
};

ProductCreateController.$inject = ['$scope', '$routeParams', '$http', '$location', 'ProductsService'];


