var app = angular.module("ItemApplication", ["ItemController", "ngRoute"]);

app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.
    when("/",
    {
        templateUrl: "/Partials/Item/ItemList.html",
        controller: "MainController"
    }).
    when("/AddItem",
    {
        templateUrl: "/Partials/Item/AddItem.html",
        controller: "AddItemController"
    }).
    when("/EditItem/:id",
    {
        templateUrl: "/Partials/Item/EditItem.html",
        controller: "EditSuppllierController"
    }).
    otherwise({ redirectTo: "/" });
}])