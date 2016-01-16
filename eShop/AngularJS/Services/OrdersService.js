var OrdersService = function ($http, $q) {

    console.log("OrdersService");
    
    var getOrderContentFunction = function (userId) {
        console.log("OrdersService: getContentOfShoppingCart");

        return $http({
            url: "ShoppingCart/GetContentOfShoppingCart",
            method: "GET",
            params: { userId: userId },
            cache: false
        }).then(function (result) {
            console.log("OrdersService: getContentOfShoppingCart in then");

            return result.data;
        });
    };
    
    var addToCartFunction = function (productId) {
        console.log("OrdersService: addToCartFunction");

        return $http({
            url: "ShoppingCart/AddToCart",
            method: "GET",
            params: { productId: productId },
            cache: false
        }).then(function (result) {
            console.log("OrdersService: addToCartFunction in then");

            return result.data;
        });
    };

    var deleteFromCartFunction = function (productId) {
        console.log("OrdersService: addToCartFunction");

        return $http({
            url: "ShoppingCart/DeleteFromCart",
            method: "GET",
            params: { productId: productId },
            cache: false
        }).then(function (result) {
            console.log("OrdersService: addToCartFunction in then");

            return result.data;
        });
    };
    
    return {
        getOrderContent: getOrderContentFunction,
        addToCart: addToCartFunction,
        deleteFromCart: deleteFromCartFunction
    };
};

OrdersService.$inject = ['$http', '$q'];
