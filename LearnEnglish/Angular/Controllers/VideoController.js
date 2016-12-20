var myApp = angular.module('learnEnglishApp', ['youtube-embed']);

myApp.controller('VideoController', ['$scope', '$http', function ($scope, $http) {
    $scope.video = {};
    $scope.show_general = 1;
    $scope.show_listening = 0;
    $scope.playerVars = {
        'controls' : 0,
        'autoplay' : 0
    };

    $scope.playVideo = function () {
        //$scope.youtubePlayer.loadVideoById('4Y8WR5VrN9E', 0, 7);
        var done = false;
       
        if ($scope.youtubePlayer2.currentState == "playing") {
                setTimeout(stopVideo, 6000);
                done = true;
            }
          function stopVideo() {
              $scope.youtubePlayer2.pauseVideo();
        }
    };

    $scope.listening = function () {
        $scope.show_general = 0;
        $scope.show_listening = 1;
        $http({
            url: "/Video/GetVideoPhases",
            method: "GET",
            params: { id: 1 }
        })
            .success(function (data, status, headers, config) {
                $scope.video.phrases = data;
                $scope.video.currentPhrase = $scope.video.phrases[0];
            })
            .error(function (error, status, headers, config) {
                console.log(status);
                console.log("Error occured");
            });
        
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