var ProductsService = function ($http, $q) {


    var getAddProductFunction = function (catalogId, name, description) {
        return $http({
            url: "Product/AddProduct",
            method: "GET",
            params: { catalogId: catalogId, name: name, description: description },
            cache: false
        }).then(function (result) {

            return result.data;
        });
    };

    var getProductFunction = function (id) {
        return $http({
            url: "Product/GetProduct",
            method: "GET",
            params: { id: id },
            cache: false
        }).then(function (result) {

            return result.data;
        });
    };

    var getProductsFunction = function () {
        return $http({
            url: "Product/GetAllProducts",
            method: "GET",
            cache: false
        }).then(function (result) {

            return result.data;
        });
    };

    var getUpdateProductFunction = function (id, catalogId, name, description) {
        return $http({
            url: "Product/UpdateProduct",
            method: "GET",
            params: { id: id, catalogId: catalogId, name: name, description: description },
            cache: false
        }).then(function (result) {

            return result.data;
        });
    };

    var getDeleteProductFunction = function (id) {
        return $http({
            url: "Product/DeleteProduct",
            method: "GET",
            params: { id: id },
            cache: false
        }).then(function (result) {

            return result.data;
        });
    };

    var getProductsFromCatalogFunction = function (id) {
        return $http({
            url: "Product/GetProductsFromCatalog",
            method: "GET",
            params: { id: id },
            cache: false
        }).then(function (result) {

            return result.data;
        });
    };

    return {
        getProduct: getProductFunction,
        getProducts: getProductsFunction,
        updateProduct: getUpdateProductFunction,
        deleteProduct: getDeleteProductFunction,
        addProduct: getAddProductFunction,
        getProductsFromCatalog: getProductsFromCatalogFunction
    };
};

ProductsService.$inject = ['$http', '$q'];
