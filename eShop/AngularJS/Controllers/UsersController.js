'use strict';

var UsersController = function ($scope, $routeParams, $http, $location, UsersService) {

    UsersService.getUsers().then(function (data) { $scope.users = data; });

    $scope.editUser = function (userId) {
        $location.path('/user-detail/' + userId);
    };

    $scope.deleteUser = function (userId) {

        UsersService.deleteUser(userId).then(function () {
            UsersService.getUsers().then(function (data) { $scope.users = data; });
        });
    };
};

UsersController.$inject = ['$scope', '$routeParams', '$http', '$location', 'UsersService'];



