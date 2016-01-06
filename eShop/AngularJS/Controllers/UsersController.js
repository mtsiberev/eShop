'use strict';

var UsersController = function ($scope, $routeParams, $http, UsersService) {
    //$scope.users = UsersService.users;
    // use routing to pick the selected product
    if ($routeParams.productSku != null) {
        $scope.product = $scope.store.getProduct($routeParams.productSku);
    };
    ////////////////////

 //  getUser(30);
 //  getUser(31);
  // getUser(32);

   getAllUsers();

  
 
    var container = [];
  
    function getUser(id) {
        getJson(id)
            .success(function (json) {
                //var anotherOne = new user(json["id"], json["name"]);
                //var anotherOne = json;
                container.push(json);
                $scope.users = container;
            })
            .error(function (error) {
                $scope.status = 'Unable to load data: ' + error.message;
                console.log($scope.status);
            });
    };

    function getJson(id) {
        return $http({
            url: "User/GetUser",
            method: "GET",
            params: { id: id }
        });
    };
    

    function getAllUsers() {
        getAllUsersJson()
            .success(function (json) {
                $scope.users = json;
            })
            .error(function (error) {
                $scope.status = 'Unable to load data: ' + error.message;
                console.log($scope.status);
            });
    };

    function getAllUsersJson() {
        return $http({
            url: "User/GetAllUsers",
            method: "GET"
        });
    };
    

};

UsersController.$inject = ['$scope', '$routeParams', '$http', 'UsersService'];



