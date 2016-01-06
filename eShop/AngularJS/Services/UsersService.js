var UsersService = function ($http) {
    
    var myUsers = [
    new user("1", "John"),
    new user("2", "Jack")
    ];
    
    return {
        users: myUsers
    };
};

UsersService.$inject = ['$http'];
