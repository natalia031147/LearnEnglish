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

}])
.config(function ($mdThemingProvider) {
    $mdThemingProvider.theme('dark-grey').backgroundPalette('grey').dark();
    $mdThemingProvider.theme('dark-orange').backgroundPalette('orange').dark();
    $mdThemingProvider.theme('dark-purple').backgroundPalette('deep-purple').dark();
    $mdThemingProvider.theme('dark-blue').backgroundPalette('blue').dark();
});
;