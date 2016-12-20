var myApp = angular.module('learnEnglishApp', ['youtube-embed']);

myApp.controller('VideoControler', ['$scope', '$http', function ($scope, $http) {
    $scope.video = {};
    $scope.show_general = 1;
    $scope.show_listening = 0;

    $scope.listening = function () {
        $scope.show_general = 0;
        $scope.show_listening = 1;
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