//var myApp = angular.module('learnEnglishApp', ['youtube-embed']);

var app = angular.module('learnEnglishApp.controllers');
app.controller('AddVideoController', ['$scope', '$http', function ($scope, $http) {

    $scope.step_one = 1;
    $scope.step_two = 0;
    $scope.errorLoading = 0;
    $scope.startTime = 0;
    $scope.endTime = 0;
    $scope.parts = [];
    $scope.newPartArr = {};
    $scope.phraseTranslated = "";
    var API_CREDENTIAL = "AIzaSyCZlKOKZ0-U0FCmuMZoVLXPJzB4bcK8zq4";
    $scope.videoData = {

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
            $scope.videoData.Title = data.items[0].snippet.title;
            $scope.videoData.Thumbnail = data.items[0].snippet.thumbnails.medium.url;
            $scope.videoData.Url = $scope.youtubelink;
            $scope.videoData.Language = 'en';
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
    var orderNumber = 0;
    $scope.addPart = function (saveScope = false) {
        $scope.pauseVideo();

        if ($scope.endTime - $scope.startTime <= 0 && !saveScope) {
            $scope.editErrors = 'EndTime - StartTime must be greater than zero';
            return false;
        }
        orderNumber++
        $scope.newPartArr = {
            startTime: $scope.startTime,
            endTime: $scope.endTime,
            phrase: $scope.phrase,
            phraseTranslated: $scope.phraseTranslated,
            orderNumber:  orderNumber
        };
        $scope.parts.push($scope.newPartArr);
        //$scope.saveVideo
        $scope.phrase = "";
        $scope.phraseTranslated = "";
        $scope.startTime = $scope.endTime;
    }

    $scope.save = function () {
        $scope.editErrors = "";
        $scope.addPart(true);
        $scope.videoData.Level = $scope.level;
        //$scope.videoData.VideoPhrases = $scope.parts ;
        var postData = {video:  $scope.videoData, videoPhrases: $scope.parts}
        $http({
            url: "/Api/Video",
            method: "POST",
            data:  JSON.stringify(postData),
            //params: { video: $scope.videoData },
            headers: { 'Content-Type': 'application/json' }
            //params: { video: $scope.videoData, videoPhrases: $scope.parts }
        })
                 .success(function (data) {
                     console.log(data);
                 })
                 .error(function (error, status) {
                     console.log(status);
                     console.log("Error occured");
                 });
    }

    $scope.getGoogleTranslatePhrase = function (phrase) {
        if ($scope.phraseTranslated !== "" && $scope.phraseTranslated !== undefined) {
            return;
        }
        if (phrase === "")
        {
            $scope.phraseTranslated =  "";
        }
        $http({
            url: "/Api/GoogleTranslate",
            method: "GET",
            params: { phrase: phrase }
        })
                .success(function (data) {
                    $scope.phraseTranslated = data;
                })
                .error(function (error, status) {
                    console.log(status);
                    console.log("Error occured");
                });
    };

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