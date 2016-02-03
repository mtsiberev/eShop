var CatalogsService = function ($http, $q) {

    var getAddCatalogFunction = function (name) {
        return $http({
            url: "Catalog/AddCatalog",
            method: "GET",
            params: { name: name },
            cache: false
        }).then(function (result) {

            return result.data;
        });
    };

    var getCatalogFunction = function (id) {
        return $http({
            url: "Catalog/GetCatalog",
            method: "GET",
            params: { id: id },
            cache: false
        }).then(function (result) {

            return result.data;
        });
    };

    var getCatalogsFunction = function () {
        return $http({
            url: "Catalog/GetAllCatalogs",
            method: "GET",
            cache: false
        }).then(function (result) {

            return result.data;
        });
    };

    var getUpdateCatalogFunction = function (id, name) {
        return $http({
            url: "Catalog/UpdateCatalog",
            method: "GET",
            params: { id: id, name: name },
            cache: false
        }).then(function (result) {

            return result.data;
        });
    };

    var getDeleteCatalogFunction = function (id) {
        return $http({
            url: "Catalog/DeleteCatalog",
            method: "GET",
            params: { id: id },
            cache: false
        }).then(function (result) {

            return result.data;
        });
    };
    
    var getCatalogsForOnePageFunction = function (pageNum, pageSize, parentId) {
        return $http({
            url: "Catalog/GetCatalogsForOnePage",
            method: "GET",
            params: { pageNum: pageNum, pageSize: pageSize, parentId: parentId },
            cache: false
        }).then(function (result) {

            return result.data;
        });
    };
    
    return {
        getCatalog: getCatalogFunction,
        getCatalogs: getCatalogsFunction,
        updateCatalog: getUpdateCatalogFunction,
        deleteCatalog: getDeleteCatalogFunction,
        addCatalog: getAddCatalogFunction,
        getCatalogsForOnePage: getCatalogsForOnePageFunction
    };
};

CatalogsService.$inject = ['$http', '$q'];
