var myApp = angular.module('learnEnglishApp', ['youtube-embed']);

myApp.controller('AddVideoControler', ['$scope', '$http', function ($scope, $http) {

    $scope.step_one = 1;
    $scope.step_two = 0;
    $scope.errorLoading = 0;
    $scope.startTime = 0;
    $scope.endTime = 0;
    $scope.parts = [];
    $scope.newPartArr = [];

    $scope.playerVars = {
        controls: 0,
        autoplay: 0
    };
    
    $scope.getVideo = function () {        
        $scope.step_loading = 1;
        $scope.video = $scope.youtubelink;
        if ($scope.validateYoutubeUrl($scope.youtubelink)) {
            $scope.step_one = 0;
            $scope.step_two = 1;
        } else {
            $scope.errorLoading = 1;
        }
    };

    $scope.playVideo = function () {
        $scope.youtubePlayer.playVideo();
        $scope.editErrors = "";
    }

    $scope.pauseVideo = function () {
        $scope.youtubePlayer.pauseVideo();
        $scope.endTime = $scope.youtubePlayer.getCurrentTime().toFixed(1);
    }

    $scope.rePlayVideo = function () {
        $scope.youtubePlayer.seekTo($scope.startTime, true);
        $scope.endTime = $scope.startTime;
        $scope.youtubePlayer.playVideo();
        $scope.editErrors = "";
    }

    $scope.addPart = function () {
        $scope.pauseVideo();

        $scope.newPartArr = [];

        if ($scope.endTime - $scope.startTime <= 0) {
            $scope.editErrors = 'EndTime - StartTime must be greater than zero';
            return false;
        }
        
        $scope.newPartArr.startTime = $scope.startTime;
        $scope.newPartArr.endTime = $scope.endTime;
        $scope.parts.push($scope.newPartArr);
        $scope.newPartArr = [];
        $scope.startTime = $scope.endTime;
    }

   
    $scope.$on('youtube.player.paused', function ($event, player) {
        // play it again
        $scope.endTime = $scope.youtubePlayer.getCurrentTime().toFixed(1);
    });

    $scope.validateYoutubeUrl = function (url) {
        if (url != undefined || url != '') {
            var regExp = /^.*(youtu.be\/|v\/|u\/\w\/|embed\/|watch\?v=|\&v=|\?v=)([^#\&\?]*).*/;
            var match = url.match(regExp);
            if (match && match[2].length == 11) {
                return true;
            }
            else {
                return false;
            }
        }
    }

       
    
    
}]);