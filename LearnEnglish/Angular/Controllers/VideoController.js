var myApp = angular.module('learnEnglishApp', ['youtube-embed']);

myApp.controller('VideoController', ['$scope', '$http', function ($scope, $http) {
    $scope.video = {};
    $scope.show_general = 1;
    $scope.show_listening = 0;
    $scope.playerVars = {
        'controls' : 0,
        'autoplay': 0
    };

    $scope.playVideo = function () {
        //$scope.youtubePlayer.loadVideoById('4Y8WR5VrN9E', 0, 7);
        alert('');
       
        
    };
    $scope.$on('youtube.player.playing', function ($event, player) {
        // play it again
        var time;
        var startTime = $scope.video.currentPhrase.StartTime;
        var index = $scope.video.currentIndex;
        for (i = index; i < $scope.video.phrases.length ; i++) {
            if  ($scope.video.phrases[i].Phrase != ""){
                $scope.video.currentIndex = i;
                $scope.video.currentPhrase = $scope.video.phrases[i];
                break;
            }
        }
        time = ($scope.video.currentPhrase.EndTime - startTime) * 1000 + 100;
        setTimeout(stopVideo, time);
        function stopVideo() {
            $scope.youtubePlayer2.pauseVideo();
        }
    });


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
                $scope.video.currentIndex = 0;
                $scope.video.currentPhrase =  $scope.video.phrases[0];
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