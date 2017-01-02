//var myApp = angular.module('learnEnglishApp', ['ngMaterial', 'ngMessages', 'youtube-embed']);

myApp.controller('VideoController', ['$scope', '$http', function ($scope, $http) {
    $scope.video = {};
    $scope.show_general = 1;
    $scope.show_listening = 0;
    $scope.currentIndex = 0;
    $scope.inputWord = { word: "", index: -1 };
    $scope.typingWord = "";
    $scope.currentPhrase = { Phrase: "" };
    $scope.progress = 0;
    $scope.countHint = [];
    $scope.history = [];
    $scope.playerVars = {
        'controls' : 0,
        'autoplay': 0
    };

    $scope.playVideo = function () {
        //$scope.youtubePlayer.loadVideoById('4Y8WR5VrN9E', 0, 7);
        alert('');
       
        
    };
    $scope.$on('youtube.player.playing', function ($event, player) {
        var time = ($scope.currentPhrase.EndTime - $scope.currentPhrase.StartTime) * 1000;
        setTimeout(stopVideo, time);
        function stopVideo() {
            $scope.youtubePlayer2.pauseVideo();
            if ($scope.currentPhrase.Phrase == "") {
                getNextPhrase();
            } 
        }
    });

    $scope.$on('youtube.player.paused', function ($event, player) {
        $scope.youtubePlayer2.seekTo($scope.currentPhrase.StartTime, true);
    });


    $scope.listening = function () {
        $scope.show_general = 0;
        $scope.show_listening = 1;
        $http({
            url: "/Video/GetVideoPhases",
            method: "GET",
            params: { id: 6 }
        })
            .success(function (data, status, headers, config) {
                $scope.video.phrases = data;
                $scope.currentPhrase = { Phrase: "", OrderNumber : 0};
                getNextPhrase();
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
            params: { id: 6 }
        })
            .success(function (data, status, headers, config) {
                $scope.video = data;                
            })
            .error(function (error, status, headers, config) {
                console.log(status);
                console.log("Error occured");
            });
    };

    $scope.hint = function () {
        if (!$scope.countHint.includes($scope.currentPhrase.OrderNumber))
            $scope.countHint.push($scope.currentPhrase.OrderNumber)
        getNextInputWord();
    };

    $scope.typedWords = [];

    var getNextPhrase = function () {
        if ($scope.currentPhrase.OrderNumber - 1 < $scope.video.phrases.length) {
            $scope.currentPhrase = $scope.video.phrases[$scope.currentPhrase.OrderNumber];
            $scope.youtubePlayer2.seekTo($scope.currentPhrase.StartTime, true);
            $scope.youtubePlayer2.playVideo();
            $scope.inputWord = { word: $scope.currentPhrase.Phrase.split(' ')[0], index: 0 };
            $scope.typedWords = [];
            $scope.typingWord = "";
            $scope.progress = ((($scope.currentPhrase.OrderNumber - 1) / $scope.video.phrases.length) * 100).toFixed(0);
        } else {
            alert('The lessons is done');
        };
    };

    var getNextInputWord = function () {
        var phraseWords = $scope.currentPhrase.Phrase.split(' ');
        $scope.typedWords.push($scope.inputWord.word);
        if ($scope.inputWord.index + 1 < phraseWords.length) {
            $scope.inputWord.index += 1;
            $scope.inputWord.word = phraseWords[$scope.inputWord.index];
            $scope.typingWord = "";
        } else {
            $scope.history.push($scope.currentPhrase);
            getNextPhrase();
            
        }
    };
    $scope.typing = function (key) {
        var codes = [13, 32, 190, 33, 63];
        if (codes.includes(key)) {
            var typingWord =  $scope.typingWord.toLowerCase().replace(/[^\w\s]/g, "").trim();
            var expectedWord = $scope.inputWord.word.toLowerCase().replace(/[^\w\s]/g, "").trim();
            if (typingWord == expectedWord) {
                getNextInputWord();
            }
               
        };
    };

    $scope.generateColor = function () {
        if( $scope.typingWord.toLowerCase().trim() == $scope.inputWord.word.toLowerCase().trim() )
        {
            return "green";
        } 
        return $scope.inputWord.word.toLowerCase().indexOf($scope.typingWord.toLowerCase()) ? "red" : "green";
    };

  

}]);