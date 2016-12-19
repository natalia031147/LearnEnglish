var myApp = angular.module('learnEnglishApp', ['youtube-embed']);

myApp.controller('VideoControler', ['$scope', '$http', function ($scope, $http) {
    $scope.video = {};
    $scope.all = 1;
    $scope.listening = 0;

    $scope.listening = function () {
        $scope.all = 0;
        $scope.listening = 1;
    };
    
    
    $scope.getVideo = function () {
        
        $http({
            url: "/Video/GetVideo",
            method: "GET",
            params: { id: 1 }
        })
            .success(function (data, status, headers, config) {
                $scope.video = data;
            })
            .error(function (error, status, headers, config) {
                console.log(status);
                console.log("Error occured");
            });
    };

    //$scope.getVideo();

}]);