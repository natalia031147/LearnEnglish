//var myApp = angular.module('learnEnglishApp', ['ngMaterial', 'ngMessages', 'youtube-embed']);
var app = angular.module('learnEnglishApp.controllers');
app.controller('VideoDetailsController', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {
    $scope.video = {};
    
    $scope.playerVars = {
        'controls' : 0,
        'autoplay': 0
    };   
    
    $scope.getVideoDetails = function () {
        $http({
            url: "/Api/Video",
            method: "GET",
            params: { id: $routeParams.id }
        })
            .success(function (data) {
                $scope.video = data;
            })
            .error(function (error, status) {
                console.log(status);
                console.log("Error occured");
            });
    };
   
   
}]);