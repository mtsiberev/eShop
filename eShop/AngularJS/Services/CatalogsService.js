var CatalogsService = function ($http, $q) {

    console.log("CatalogsService");
    
    var getAddCatalogFunction = function (name) {
        console.log("CatalogsService: getAddCatalogFunction");

        return $http({
            url: "Catalog/AddCatalog",
            method: "GET",
            params: { name: name },
            cache: false
        }).then(function (result) {
            console.log("CatalogsService: getCatalogFunction in then");

            return result.data;
        });
    };

    var getCatalogFunction = function (id) {
        console.log("CatalogsService: getCatalogFunction");

        return $http({
            url: "Catalog/GetCatalog",
            method: "GET",
            params: { id: id },
            cache: false
        }).then(function (result) {
            console.log("CatalogsService: getCatalogFunction in then");

            return result.data;
        });
    };

    var getCatalogsFunction = function () {
        console.log("CatalogsService: getCatalogsFunction");

        return $http({
            url: "Catalog/GetAllCatalogs",
            method: "GET",
            cache: false
        }).then(function (result) {
            console.log("CatalogsService: getCatalogsFunction in then");

            return result.data;
        });
    };

    var getUpdateCatalogFunction = function (id, name ) {
        console.log("CatalogsService: getUpdateCatalogFunction");

        return $http({
            url: "Catalog/UpdateCatalog",
            method: "GET",
            params: { id: id, name: name },
            cache: false
        }).then(function (result) {
            console.log("CatalogsService: getUpdateCatalogFunction in then");

            return result.data;
        });
    };

    var getDeleteCatalogFunction = function (id) {
        console.log("CatalogsService: getDeleteCatalogFunction");

        return $http({
            url: "Catalog/DeleteCatalog",
            method: "GET",
            params: { id: id },
            cache: false
        }).then(function (result) {
            console.log("CatalogsService: getDeleteCatalogFunction in then");

            return result.data;
        });
    };

    return {
        getCatalog: getCatalogFunction,
        getCatalogs: getCatalogsFunction,
        updateCatalog: getUpdateCatalogFunction,
        deleteCatalog: getDeleteCatalogFunction,
        addCatalog: getAddCatalogFunction
    };
};

CatalogsService.$inject = ['$http', '$q'];
