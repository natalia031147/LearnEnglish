//var myApp = angular.module('learnEnglishApp', ['ngMaterial', 'ngMessages', 'youtube-embed']);
var app = angular.module("learnEnglishApp.controllers");
app.controller("ChangeLevelController", [
    "$scope", "$http", "$routeParams", function($scope, $http, $routeParams) {
        $scope.level = "elementary";

        $scope.setLevel = function (level) {
            $scope.level = getLevelValue(level);
        };

        $scope.init = function() {
            $scope.getUserLevel();
        };

        var getLevelValue = function (level) {
            var levelValue;
            switch (level) {
                case (1):
                    levelValue = "elementary";
                    break;
                case (2):
                    levelValue = "preIntermediate";
                    break;
                case (3):
                    levelValue = "intermediate";
                    break;
                case (4):
                    levelValue = "upperIntermediate";
                    break;
                case (5):
                    levelValue = "advanced";
                    break;
                default:
                    levelValue = "elementary";

            }
            return levelValue;
        };

        $scope.getUserLevel = function () {
            $http({
                url: "/Api/Level",
                method: "GET"
            })
                .success(function (data) {
                    $scope.level = getLevelValue(data);
                })
                .error(function (error, status) {
                    console.log(status);
                    console.log("Error occured");
                });
        };

        $scope.changeLevel = function () {
            var levelId = getLevelId($scope.level);
            $http({
                url: "/Api/Level",
                method: "POST",
                params: { level: levelId }
            })
                .success(function (data) {
                    console.log(data);
                })
                .error(function (error, status) {
                    console.log(status);
                    console.log("Error occured");
                });
        }

        
        var getLevelId = function (levelValue) {
            var levelId;
            switch (levelValue) {
                case ("elementary"):
                    levelId = 1;
                    break;
                case ("preIntermediate"):
                    levelId = 2;
                    break;
                case ("intermediate"):
                    levelId = 3;
                    break;
                case ("upperIntermediate"):
                    levelId = 4;
                    break;
                case ("advanced"):
                    levelId = 5;
                    break;

            }
            return levelId;
        };
        
    }
]);