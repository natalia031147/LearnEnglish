var myApp = angular.module('learnEnglishApp', ['youtube-embed']);

myApp.controller('VideoControler', ['$scope', '$http', function ($scope, $http) {
    $scope.video = {};
    
    
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