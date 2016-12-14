var myApp = angular.module('learnEnglishApp', ['youtube-embed']);

myApp.controller('AddVideoControler', ['$scope', '$http', function ($scope, $http) {

    $scope.step_one = 1;
    $scope.step_two = 0;
    $scope.errorLoading = 0;
    $scope.startTime = 0;
    $scope.endTime = 0;
    $scope.parts = [];
    $scope.newPartArr = {};
    var API_CREDENTIAL = "AIzaSyCZlKOKZ0-U0FCmuMZoVLXPJzB4bcK8zq4";
    $scope.data = {

    };

    $scope.playerVars = {
        controls: 0,
        autoplay: 0
    };


    $scope.getVideo = function () {
        $scope.step_loading = 1;
        $scope.video = $scope.youtubelink;

        var urlApi = "https://www.googleapis.com/youtube/v3/videos?id=" + $scope.getIdFromURL($scope.youtubelink) + "&key=" + API_CREDENTIAL + "&part=snippet,statistics&fields=items(id,snippet,statistics)";

        $http.get(urlApi)
        .success(function (data, status, headers, config) {
            $scope.data.Title = data.items[0].snippet.title;
            $scope.data.Thumbnail = data.items[0].snippet.thumbnails.medium.url;
            $scope.data.Url = $scope.youtubelink;
            $scope.data.Language = 'en';
        })
        .error(function (error, status, headers, config) {
            console.log(status);
            console.log("Error occured");
        });

        if ($scope.getIdFromURL($scope.youtubelink)) {
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

        if ($scope.endTime - $scope.startTime <= 0) {
            $scope.editErrors = 'EndTime - StartTime must be greater than zero';
            return false;
        }

        $scope.newPartArr = {
            startTime: $scope.startTime,
            endTime: $scope.endTime,
            native: $scope.native,
            source: $scope.source
        };
        $scope.parts.push($scope.newPartArr);
        //$scope.saveVideo
        $scope.native = "";
        $scope.source = "";
        $scope.startTime = $scope.endTime;
    }

    $scope.save = function () {
        $scope.editErrors = "";
        $scope.addPart();
        $scope.data.Level = $scope.level;
        $scope.data.parts = $scope.parts;
        // save video
        $.ajax({
            type: "POST",
            url: "AddNewVideo",
            data: $scope.data,
            success: function (result) {
                alert('success');
                //debugger;
            }
        });
    }


    $scope.$on('youtube.player.paused', function ($event, player) {
        // play it again
        $scope.endTime = $scope.youtubePlayer.getCurrentTime().toFixed(1);
    });

    $scope.getIdFromURL = function (url) {
        if (url != undefined || url != '') {
            var regExp = /^.*(youtu.be\/|v\/|u\/\w\/|embed\/|watch\?v=|\&v=|\?v=)([^#\&\?]*).*/;
            var match = url.match(regExp);
            if (match && match[2].length == 11) {
                return match[2];
            }
            else {
                return false;
            }
        }
    }




}]);