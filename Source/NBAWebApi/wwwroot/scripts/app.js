let app = angular.module("NBAStats", ["ngRoute"]);

app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "views/teams.html",
            controller: "teamsController"
        });
});