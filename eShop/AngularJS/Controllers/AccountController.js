'use strict';

var AccountController = function ($scope, $routeParams, $http, $location, UsersService) {

  //  UsersService.getUsers().then(function (data) { $scope.users = data; });

   $scope.account = { username: "", password: "" };
    
   $scope.login = function (account) {
        console.log("UsersController: editUser");
        UsersService.login(account).then(function (data) {
            if (data == false) {
                alert("Login Error");

                $location.path('/login/');
            } else {
                window.location.href = "RedirectToHome";
            }
        });
    };
    

    $scope.deleteUser = function (userId) {
        console.log("UsersController: deleteUser before UsersService.deleteUser call");
        UsersService.deleteUser(userId).then(function () {
            UsersService.getUsers().then(function (data) { $scope.users = data; });
        });
        console.log("UsersController: deleteUser after UsersService.deleteUser call");
    };
};

AccountController.$inject = ['$scope', '$routeParams', '$http', '$location', 'UsersService'];



