config.$inject = ["$routeProvider", "$locationProvider", "$httpProvider"];

angular.module("learnEnglishApp.services", []);
angular.module("learnEnglishApp.controllers", []);
angular.module("learnEnglishApp.directives", []);

angular.module("learnEnglishApp", [
    "ngRoute",
    "ngMaterial",
    "ngMessages",
    "youtube-embed",
    
    "app.directives",
    "learnEnglishApp.services",
    "learnEnglishApp.controllers",
    "learnEnglishApp.directives"
]).config(config);


function config($routeProvider, $locationProvider) {

    $routeProvider
        .when("/", { redirectTo: "/recommendations" })
        .when("/recommendations", {
            templateUrl: "VideoView/Recommendations/",
            controller: "RecommendationsController"
        })
        .when("/videos", {
            templateUrl: "VideoView/List/",
            controller: "VideoListController"
        })
        .when("/videos/:id", {
            templateUrl: "VideoView/Details/",
            controller: "VideoDetailsController"

        })
        .when("/listening/:id", {
            templateUrl: "VideoView/Listening/",
            controller: "ListeningController"

        })
        .when("/writing/:id", {
            templateUrl: "VideoView/Writing/",
            controller: "WritingController"

        })
        .when("/speaking/:id", {
            templateUrl: "VideoView/Speaking/",
            controller: "SpeakingController"

        })
        .when("/add/", {
            templateUrl: "VideoView/Add/",
            controller: "AddVideoController"

        })
        .when("/login", {
            templateUrl: "Account/Login/"
        })
        .when("/register", {
            templateUrl: "Account/Register/"
        });
    $locationProvider.html5Mode(false);
}