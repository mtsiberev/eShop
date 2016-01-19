var AdminMenuController = function ($scope, $http, $location) {

    $scope.selectMenuOption = function (page) {
        $location.path(page);
    };
 
};

AdminMenuController.$inject = ['$scope', '$http', '$location'];
