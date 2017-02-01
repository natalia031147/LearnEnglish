//var myApp = angular.module('learnEnglishApp', ['ngMaterial', 'ngMessages', 'youtube-embed']);
var app = angular.module('learnEnglishApp.controllers');
app.controller('RecommendationsController', ['$scope', '$http', function ($scope, $http) {
    $scope.recommendations;

    $scope.playerVars = {
        'controls': 0,
        'autoplay': 0
    };

    $scope.getRecommendations = function () {
        $http({
            url: "/Api/Recommendations",
            method: "GET"
        })
            .success(function (data, status, headers, config) {
                $scope.recommendations = data;
            })
            .error(function (error, status, headers, config) {
                console.log(status);
                console.log("Error occured");
            });
    };

    $scope.getUserPoints = function () {
        $http({
            url: "/Api/UserPoints",
            method: "GET"
        })
            .success(function (data, status, headers, config) {
                $scope.userPoints = data;
                $scope.currentLevel = levelToString($scope.userPoints.userLevel);
                if ($scope.currentLevel == "Advanced") {
                    $scope.nextLevel = "";
                } else {
                    $scope.nextLevel = levelToString($scope.userPoints.userLevel + 1);
                }               

            })
            .error(function (error, status, headers, config) {
                console.log(status);
                console.log("Error occured");
            });
    };

    $scope.init = function () {        
        $scope.getRecommendations();
        $scope.getUserPoints();
    }

    var levelToString = function (level) {
        var levelName;
        switch (level)
        {
            case (1):
                levelName = "Elementary";
                break;
            case (2):
                levelName = "Pre-Intermediate";
                break;
            case (3):
                levelName = "Intermediate";
                break;
            case (4):
                levelName = "Upper-Intermediate";
                break;
            case (5):
                levelName = "Advanced";
                break;
            default:
                levelName = "Unkown";

        }
        return levelName;
    }


}])
.config(function ($mdThemingProvider) {
    $mdThemingProvider.theme('dark-grey').backgroundPalette('grey').dark();
    $mdThemingProvider.theme('dark-orange').backgroundPalette('orange').dark();
    $mdThemingProvider.theme('dark-purple').backgroundPalette('deep-purple').dark();
    $mdThemingProvider.theme('dark-blue').backgroundPalette('blue').dark();
});
;