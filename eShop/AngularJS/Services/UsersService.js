var UsersService = function ($http, $q) {


    var getUserFunction = function (id) {
        var deferred = $q.defer();
        getJson(id)
            .success(function (json) {
                deferred.resolve(json);
            })
            .error(function (error) {
                console.log(error);
                deferred.reject(error);
            });
        return deferred.promise;
    };
    function getJson(id) {
        return $http({
            url: "User/GetUser",
            method: "GET",
            params: { id: id }
                  , cache: false
        });
    };
  

    var getUsersFunction = function () {
        var deferred = $q.defer();
        getAllUsersJson()
            .success(function (json) {
                deferred.resolve(json);
            })
            .error(function (error) {
                console.log(error);
                deferred.reject(error);
            });
        return deferred.promise;
    };
    function getAllUsersJson() {
        return $http({
            url: "User/GetAllUsers",
            method: "GET"
                  , cache: false
        });
    };
    
    
    var getUpdateUserFunction = function (id, name, address) {
        var deferred = $q.defer();
        updateUserJson(id, name, address)
            .success(function (json) {
                deferred.resolve(json);
            })
            .error(function (error) {
                console.log(error);
                deferred.reject(error);
            });
        return deferred.promise;
    };
    function updateUserJson(id, name, address) {
        return $http({
            url: "User/UpdateUser",
            method: "GET",
            params: { id: id, name: name, address: address }
            ,cache: false
        });
    };
    
    
    var getDeleteUserFunction = function (id) {
        var deferred = $q.defer();
        deleteUserJson(id)
            .success(function (json) {
                deferred.resolve(json);
            })
            .error(function (error) {
                console.log(error);
                deferred.reject(error);
            });
        return deferred.promise;
    };
    function deleteUserJson(id) {
        return $http({
            url: "User/DeleteUser",
            method: "GET",
            params: { id: id }
                  , cache: false
        });
    };
    


    return {
        getUser: getUserFunction,
        getUsers: getUsersFunction,
        updateUser: getUpdateUserFunction,
        deleteUser: getDeleteUserFunction
    };
};

UsersService.$inject = ['$http', '$q'];
