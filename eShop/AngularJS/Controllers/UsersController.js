'use strict';

var UsersController = function ($scope, $routeParams, $http, $location, UsersService) {
    
    UsersService.getUsers().then(function (data) { $scope.users = data; });
    

    $scope.editUser = function (userId) {
        console.log("UsersController: editUser");
        $location.path('/user-detail/' + userId);
    };

    $scope.deleteUser = function (userId) {
        console.log("UsersController: deleteUser before UsersService.deleteUser call");
        UsersService.deleteUser(userId).then(function () {
                  UsersService.getUsers().then(function (data) { $scope.users = data; });
        });
        console.log("UsersController: deleteUser after UsersService.deleteUser call");
    };
};

UsersController.$inject = ['$scope', '$routeParams', '$http', '$location', 'UsersService'];



