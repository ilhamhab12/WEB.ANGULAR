angular.module("SupplierController", []).
controller("MainController", function ($scope, SupplierService) {
    $scope.message = "Main Controller";

    SupplierService.GetSupplierFromDB().then(function (d) {

        $scope.listSuppliers = d.data.list;
    })

    $scope.DeleteSupplier = function (id, index) {
        $scope.listSuppliers.splice(index, 1);
        SupplierService.DeleteSupplier(id);
    }
}).
controller("AddSupplierController", function ($scope, SupplierService) {
    $scope.message = "Add Supplier Details";

    $scope.AddSupplier = function () {
        SupplierService.AddSupplier($scope.supplierParam);
    }
}).
controller("EditSuppllierController", function ($scope, SupplierService, $routeParams) {
    $scope.message = "Update Supplier Details";

    var id = $routeParams.id;

    SupplierService.GetSupplierByID(id).then(function (d) {
        $scope.supplier = d.data.supplierParam;
    })

    $scope.UpdateSupplier = function () {
        SupplierService.UpdateSupplier($scope.supplierParam);
    }
}).
factory("SupplierService", ["$http", function ($http) {

    var fac = {};

    fac.GetSupplierFromDB = function () {
        return $http.get("/Supplier/GetSuppliers");
    }

    fac.GetSupplierByID = function (id) {
        return $http.get("/Supplier/GetSupplierById", { params: { id: id } });
    }

    fac.AddSupplier = function (supplier) {
        $http.post("/Supplier/AddSupplier", supplier).success(function (response) {
            alert(response.status);
        })
    }

    fac.UpdateSupplier = function (supplier) {
        $http.post("/Supplier/UpdateSupplier", supplier).success(function (response) {
            alert(response.status);
        })
    }

    fac.DeleteSupplier = function (id) {
        $http.post("/Supplier/DeleteSupplier", { id: id }).success(function (response) {
            alert(response.status);
        })
    }

    return fac;
}])