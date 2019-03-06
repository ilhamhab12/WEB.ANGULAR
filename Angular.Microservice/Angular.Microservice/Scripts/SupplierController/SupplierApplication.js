var app = angular.module("SupplierApplication", ["SupplierController", "ngRoute"]);

app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.
    when("/",
    {
        templateUrl: "/Partials/Supplier/SupplierList.html",
        controller: "MainController"
    }).
    when("/AddSupplier",
    {
        templateUrl: "/Partials/Supplier/AddSupplier.html",
        controller: "AddSupplierController"
    }).
    when("/EditSupplier/:id",
    {
        templateUrl: "/Partials/Supplier/EditSupplier.html",
        controller: "EditSupplierController"
    }).
    otherwise(
    {
        redirectTo: "/"
    });
}])