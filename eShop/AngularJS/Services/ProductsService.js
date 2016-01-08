var ProductsService = function ($http, $q) {

    console.log("ProductsService");

    
    var getAddProductFunction = function (catalogId, name, description) {
        console.log("ProductsService: getAddProductFunction");

        return $http({
            url: "Product/AddProduct",
            method: "GET",
            params: { catalogId: catalogId, name: name, description: description },
            cache: false
        }).then(function (result) {
            console.log("ProductsService: getProductFunction in then");

            return result.data;
        });
    };

    
    var getProductFunction = function (id) {

        console.log("ProductsService: getProductFunction");

        return $http({
            url: "Product/GetProduct",
            method: "GET",
            params: { id: id },
            cache: false
        }).then(function (result) {
            console.log("ProductsService: getProductFunction in then");

            return result.data;
        });
    };

    var getProductsFunction = function () {

        console.log("ProductsService: getProductsFunction");

        return $http({
            url: "Product/GetAllProducts",
            method: "GET",
            cache: false
        }).then(function (result) {
            console.log("ProductsService: getProductsFunction in then");

            return result.data;
        });
    };

    var getUpdateProductFunction = function (id, catalogId, name, description) {
        console.log("ProductsService: getUpdateProductFunction");

        return $http({
            url: "Product/UpdateProduct",
            method: "GET",
            params: { id: id, catalogId: catalogId, name: name, description: description },
            cache: false
        }).then(function (result) {
            console.log("ProductsService: getUpdateProductFunction in then");

            return result.data;
        });
    };

    var getDeleteProductFunction = function (id) {

        console.log("ProductsService: getDeleteProductFunction");

        return $http({
            url: "Product/DeleteProduct",
            method: "GET",
            params: { id: id },
            cache: false
        }).then(function (result) {
            console.log("ProductsService: getDeleteProductFunction in then");

            return result.data;
        });
    };

    return {
        getProduct: getProductFunction,
        getProducts: getProductsFunction,
        updateProduct: getUpdateProductFunction,
        deleteProduct: getDeleteProductFunction,
        addProduct: getAddProductFunction
    };
};

ProductsService.$inject = ['$http', '$q'];
