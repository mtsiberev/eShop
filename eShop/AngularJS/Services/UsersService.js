﻿var UsersService = function ($http, $q) {


    var getUserFunction = function (id) {
        return $http({
            url: "User/GetUser",
            method: "GET",
            params: { id: id },
            cache: false
        }).then(function (result) {

            return result.data;
        });
    };

    var getUsersFunction = function () {
        return $http({
            url: "User/GetAllUsers",
            method: "GET",
            cache: false
        }).then(function (result) {

            return result.data;
        });
    };

    var getUpdateUserFunction = function (id, name) {
        return $http({
            url: "User/UpdateUser",
            method: "GET",
            params: { id: id, name: name },
            cache: false
        }).then(function (result) {

            return result.data;
        });
    };

    var getDeleteUserFunction = function (id) {
        return $http({
            url: "User/DeleteUser",
            method: "GET",
            params: { id: id },
            cache: false
        }).then(function (result) {

            return result.data;
        });
    };

    var getCurrentUserFunction = function () {
        return $http({
            url: "User/GetCurrentUser",
            method: "GET",
            cache: false
        }).then(function (result) {

            return result.data;
        });
    };

    return {
        getUser: getUserFunction,
        getUsers: getUsersFunction,
        updateUser: getUpdateUserFunction,
        deleteUser: getDeleteUserFunction,
        getCurrentUser: getCurrentUserFunction
    };
};

UsersService.$inject = ['$http', '$q'];
