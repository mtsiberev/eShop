var UsersService = function ($http, $q) {
    
    console.log("UsersService");

    var getUserFunction = function (id) {
        console.log("UsersService: getUserFunction" );
        return $http({
            url: "User/GetUser",
            method: "GET",
            params: { id: id },
            cache: false
        }).then(function (result) {
            console.log("UsersService: getUserFunction in then");
            return result.data;
        });
    };

    var getUsersFunction = function () {
 
        console.log("UsersService: getUsersFunction");
        
        return $http({
            url: "User/GetAllUsers",
            method: "GET",
            cache: false
        }).then(function (result) {
            console.log("UsersService: getUsersFunction in then");
      
            return result.data;
        });
    };

    var getUpdateUserFunction = function (id, name, address) {
        console.log("UsersService: getUpdateUserFunction" );

        return $http({
            url: "User/UpdateUser",
            method: "GET",
            params: { id: id, name: name, address: address },
            cache: false
        }).then(function (result) {
            console.log("UsersService: getUpdateUserFunction in then");

            return result.data;
        });
    };

    var getDeleteUserFunction = function (id) {
      
        console.log("UsersService: getDeleteUserFunction");

        return $http({
            url: "User/DeleteUser",
            method: "GET",
            params: { id: id },
            cache: false
        }).then(function (result) {
            console.log("UsersService: getDeleteUserFunction in then");
         
            return result.data;
        });
    };
    
    var getCurrentUserFunction = function () {
        console.log("UsersService: getCurrentUserFunction");
        return $http({
            url: "User/GetUserId",
            method: "GET",
            cache: false
        }).then(function (result) {
            console.log("UsersService: getCurrentUserFunction in then");
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
