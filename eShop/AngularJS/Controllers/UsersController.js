'use strict';

var UsersController = function ($scope, $routeParams, $http, $location, UsersService) {
    
    setTimeout(function () {
        UsersService.getUsers().then(function (data) { $scope.users = data; });
    }, 100);

    $scope.editUser = function (userId) {
        console.log("UsersController: editUser");
        $location.path('/user-detail/' + userId);
    };

    $scope.deleteUser = function (userId) {
        console.log("UsersController: deleteUser before UsersService.deleteUser call");
        UsersService.deleteUser(userId).then(function (data) {
        });
        console.log("UsersController: deleteUser after UsersService.deleteUser call");
        $location.path('/users');
    };
};

UsersController.$inject = ['$scope', '$routeParams', '$http', '$location', 'UsersService'];



