config.$inject = ["$routeProvider", "$locationProvider", "$httpProvider"];

angular.module("learnEnglishApp.services", []);
angular.module("learnEnglishApp.controllers", []);

angular.module("learnEnglishApp", [
    "ngRoute",
    "ngMaterial",
    "ngMessages",
    "youtube-embed",
    "learnEnglishApp.services",
    "learnEnglishApp.controllers"
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
        .when("/add/", {
            templateUrl: "VideoView/Add/",
            controller: "AddVideoController"

        });
    $locationProvider.html5Mode(false);
}