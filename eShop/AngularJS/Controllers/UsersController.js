'use strict';

var UsersController = function ($scope, $routeParams, $http, $location, UsersService) {
    //$scope.users = UsersService.users;
    // use routing to pick the selected product
    if ($routeParams.productSku != null) {
        $scope.product = $scope.store.getProduct($routeParams.productSku);
    };
    ////////////////////
    
    UsersService.getUsers().then(function (data) { $scope.users = data; });
    
 
    $scope.editUser = function (userId) {
        $location.path('/user-detail/' + userId);
    };
    
    $scope.deleteUser = function (userId) {
        UsersService.deleteUser(userId).then(function(data) {
    
        });
        $location.path('/user-list');
   
    };

    ////////////////////////
};

UsersController.$inject = ['$scope', '$routeParams', '$http', '$location', 'UsersService'];



