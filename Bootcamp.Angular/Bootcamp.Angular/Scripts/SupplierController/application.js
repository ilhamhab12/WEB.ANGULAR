var app = angular.module("BootcampAngularApp", ["BootcampAngularApp.controllers", "ngRoute"]);

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
        controller: "EditSuppllierController"
    }).
    otherwise({ redirectTo: "/" });
}])