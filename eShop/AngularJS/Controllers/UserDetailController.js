'use strict';

var UserDetailController = function ($scope, $routeParams, $http, $location, UsersService) {

    var id = $routeParams.id;
    UsersService.getUser(id).then(function (data) { $scope.user = data; });

    $scope.updateUser = function () {
        UsersService.updateUser($scope.user.id, $scope.user.name).then(function () {
            $location.path('/users');
        });
    };

    $scope.cancel = function () {
        $location.path('/users');
    };
};

UserDetailController.$inject = ['$scope', '$routeParams', '$http', '$location', 'UsersService'];


