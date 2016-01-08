'use strict';

var UserDetailController = function ($scope, $routeParams, $http, $location, UsersService) {
    console.log("UserDetailController");

    var id = $routeParams.id;
    UsersService.getUser(id).then(function (data) { $scope.user = data; });
    
    $scope.updateUser = function () {
        console.log("UserDetailController: updateUser function before UsersService.updateUser call");
        UsersService.updateUser($scope.user.id, $scope.user.name, $scope.user.address);
        console.log("UserDetailController: updateUser function after UsersService.updateUser call");
        $location.path('/users');
    };

    $scope.cancel = function () {
        $location.path('/users');
    };
};

UserDetailController.$inject = ['$scope', '$routeParams', '$http', '$location', 'UsersService'];


