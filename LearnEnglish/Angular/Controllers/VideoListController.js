//var myApp = angular.module('learnEnglishApp', ['ngMaterial', 'ngMessages']);

var app = angular.module("learnEnglishApp.controllers");

app.controller("VideoListController", [
    "$scope", "$http", function($scope, $http) {

        $scope.getVideos = function() {
            $http({
                    url: "/Api/Video",
                    method: "GET"
                })
                .success(function(data) {
                    $scope.videos = data;
                })
                .error(function(error, status) {
                    console.log(status);
                    console.log("Error occured");
                });
        };

        $scope.loadVideo = function() {

        };


    }
]);
