var OrdersService = function ($http, $q) {


    var getOrderContentFunction = function (userId) {
        return $http({
            url: "ShoppingCart/GetContentOfShoppingCart",
            method: "GET",
            params: { userId: userId },
            cache: false
        }).then(function (result) {

            return result.data;
        });
    };

    var addToCartFunction = function (productId, qty) {
        return $http({
            url: "ShoppingCart/AddToCart",
            method: "GET",
            params: { productId: productId, qty: qty },
            cache: false
        }).then(function (result) {

            return result.data;
        });
    };

    var deleteFromCartFunction = function (productId) {
        return $http({
            url: "ShoppingCart/DeleteFromCart",
            method: "GET",
            params: { productId: productId },
            cache: false
        }).then(function (result) {

            return result.data;
        });
    };
    
    var approveOrderFunction = function (userId) {
        return $http({
            url: "ShoppingCart/ApproveOrder",
            method: "GET",
            params: { userId: userId },
            cache: false
        }).then(function (result) {

            return result.data;
        });
    };
    
    return {
        getOrderContent: getOrderContentFunction,
        addToCart: addToCartFunction,
        deleteFromCart: deleteFromCartFunction,
        approveOrder: approveOrderFunction
    };
};

OrdersService.$inject = ['$http', '$q'];
