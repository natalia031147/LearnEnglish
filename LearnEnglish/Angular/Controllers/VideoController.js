//var myApp = angular.module('learnEnglishApp', ['ngMaterial', 'ngMessages', 'youtube-embed']);
var app = angular.module('learnEnglishApp.controllers');
app.controller('VideoController', ['$scope', '$http', function ($scope, $http) {
    $scope.video = {};
    
    $scope.playerVars = {
        'controls' : 0,
        'autoplay': 0
    };   
    
    $scope.init = function (data) {
        $scope.video = data;
    }; 
}]);