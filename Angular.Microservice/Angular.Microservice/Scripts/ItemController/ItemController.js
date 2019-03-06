angular.module("ItemController", []).
controller("MainController", function ($scope, ItemService) {
    $scope.message = "Main Controller";

    ItemService.GetItemFromDB().then(function (d) {

        $scope.listItems = d.data.list;
    })

    $scope.DeleteItem = function (id, index) {
        $scope.listItems.splice(index, 1);
        ItemService.DeleteItem(id);
    }
}).
controller("AddItemController", function ($scope, ItemService) {
    $scope.message = "Add Item Details";

    $scope.AddItem = function () {
        ItemService.AddItem($scope.item);
    }

    ItemService.GetSupplierFromDB().then(function (d) {
        $scope.listSuppliers = d.data.list;
    })
}).
controller("EditSuppllierController", function ($scope, ItemService, $routeParams) {
    $scope.message = "Update Item Details";

    var id = $routeParams.id;

    ItemService.GetItemByID(id).then(function (d) {
        $scope.item = d.data.item;
    })

    ItemService.GetSupplierFromDB().then(function (d) {
        $scope.listSuppliers = d.data.list;
    })

    //ItemService.GetSupplierByID(id).then(function (d) {
    //    $scope.listSuppliers = d.data.list;
    //})

    $scope.UpdateItem = function () {
        ItemService.UpdateItem($scope.item);
    }
}).
factory("ItemService", ["$http", function ($http) {

    var fac = {};

    fac.GetItemFromDB = function () {
        return $http.get("/Item/GetItems");
    }

    fac.GetSupplierFromDB = function () {
        return $http.get("/Supplier/GetSuppliers");
    }

    fac.GetItemByID = function (id) {
        return $http.get("/Item/GetItemById", { params: { id: id } });
    }

    //fac.GetSupplierByID = function (id) {
    //    return $http.get("/Supplier/GetSupplierById", { params: { id: id } });
    //}

    fac.AddItem = function (item) {
        $http.post("/Item/AddItem", item).success(function (response) {
            alert(response.status);
        })
    }

    fac.UpdateItem = function (item) {
        $http.post("/Item/UpdateItem", item).success(function (response) {
            alert(response.status);
        })
    }

    fac.DeleteItem = function (id) {
        $http.post("/Item/DeleteItem", { id: id }).success(function (response) {
            alert(response.status);
        })
    }

    return fac;
}])