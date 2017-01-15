//var myApp = angular.module('learnEnglishApp', ['ngMaterial', 'ngMessages', 'youtube-embed']);
var app = angular.module('learnEnglishApp.controllers');
app.controller('ListeningController', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {
    $scope.video = {};
    $scope.currentIndex = 0;
    $scope.expectedWord = { word: "", index: -1 };
    $scope.typingWord = "";
    $scope.currentPhrase = { Phrase: "" };
    $scope.progress = 0;
    $scope.countHint = 0;
    $scope.history = [];
    $scope.placeholder = "...";

    $scope.playerVars = {
        'controls': 0,
        'autoplay': 0
    };

    $scope.$on('youtube.player.playing', function ($event, player) {
        if (!endTyping) {
            var time = ($scope.currentPhrase.EndTime - $scope.currentPhrase.StartTime) * 1000;
            setTimeout(stopVideo, time);
            function stopVideo() {
                $scope.youtubePlayer2.pauseVideo();
                if ($scope.currentPhrase.Phrase == "") {
                    getNextPhrase();
                }
            }
        }
    });

    $scope.$on('youtube.player.paused', function ($event, player) {
        $scope.youtubePlayer2.seekTo($scope.currentPhrase.StartTime, true);
    });

    $scope.$on('youtube.player.ready', function ($event, player) {
        $scope.youtubePlayer2.playVideo();
    });



    $scope.getVideoPhases = function () {
        $http({
            url: "/Api/VideoPhrase",
            method: "GET",
            params: { id: $routeParams.id }
        })
            .success(function (data, status, headers, config) {
                $scope.video.phrases = data;
                $scope.currentPhrase = { Phrase: "", OrderNumber: 0 };
                $scope.phrasesNumber = $scope.video.phrases.filter(a => a.Phrase != "").length;
                
                //getNextPhrase();
            })
            .error(function (error, status, headers, config) {
                console.log(status);
                console.log("Error occured");
            });

    };

    $scope.getVideoDetails = function () {
        $http({
            url: "/Api/Video",
            method: "GET",
            params: { id: $routeParams.id }
        })
            .success(function (data) {
                $scope.video = data;
            })
            .error(function (error, status) {
                console.log(status);
                console.log("Error occured");
            });
    };

    $scope.init = function () {
        $scope.getVideoDetails();
        $scope.getVideoPhases();
    };



    $scope.hint = function () {
        $scope.countHint++;
        $scope.typingWord = "";
        $scope.placeholder = $scope.expectedWord.word;

        setTimeout(clearPlaceholder, 1000);
        function clearPlaceholder() {
            $scope.placeholder = "...";
        }
    };

    $scope.typedWords = [];
    $scope.phrasesNumber = 1;
    $scope.passed = 0;
    var endTyping = false;

    var getNextPhrase = function () {
        var phrases = $scope.video.phrases.filter(a => a.Phrase != "");
        var lastOrderNumber = phrases[phrases.length - 1].OrderNumber;
        if ($scope.currentPhrase.OrderNumber < lastOrderNumber) {
            $scope.currentPhrase = $scope.video.phrases[$scope.currentPhrase.OrderNumber];
            $scope.youtubePlayer2.seekTo($scope.currentPhrase.StartTime, true);
            $scope.youtubePlayer2.playVideo();
            $scope.expectedWord = { word: $scope.currentPhrase.Phrase.split(' ')[0], index: 0 };
            $scope.typedWords = [];
            $scope.typingWord = "";
            $scope.passed = $scope.video.phrases.filter(a => a.Phrase != "" && a.OrderNumber < $scope.currentPhrase.OrderNumber).length;
            $scope.progress = (($scope.passed / phrases.length) * 100).toFixed(0);
        } else {
            endTyping = true;
            $scope.youtubePlayer2.playVideo();
            $scope.youtubePlayer2.seekTo($scope.currentPhrase.EndTime, true);
            $scope.passed = $scope.video.phrases.filter(a => a.Phrase != "" && a.OrderNumber <= $scope.currentPhrase.OrderNumber).length;
            $scope.currentPhrase = $scope.currentPhrase = { Phrase: "" };;
            $scope.youtubePlayer2.playVideo();
            $scope.expectedWord = { word: "", index: -1 };;
            $scope.typedWords = [];
            $scope.typingWord = "";            
            $scope.progress = (($scope.passed / phrases.length) * 100).toFixed(0);
            $scope.passed = $scope.passed - 1;
        };
    };

    var saveAction = function () {
        $http({
            method: 'POST',
            url: '/Video/SaveAction',
            data: $.param({ id: $scope.video.Id, action: "listening" }),
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        }).then(
            function (res) {
                console.log('succes !', res.data);
            },
            function (err) {
                console.log('error...', err);
            });
    };


    var getNextExpectedWord = function () {
        var phraseWords = $scope.currentPhrase.Phrase.split(' ');
        $scope.typedWords.push($scope.expectedWord.word);
        if ($scope.expectedWord.index + 1 < phraseWords.length) {
            $scope.expectedWord.index += 1;
            $scope.expectedWord.word = phraseWords[$scope.expectedWord.index];
            $scope.typingWord = "";
        } else {
            if ($scope.currentPhrase.Phrase != "") {
                var item = { Phrase: $scope.currentPhrase.Phrase, PhraseTranslated: $scope.currentPhrase.PhraseTranslated, OrderNumber: $scope.history.length + 1, TranslatedByGoogle: $scope.currentPhrase.TranslatedByGoogle };
                $scope.history.push(item);
            }
            if (!endTyping) {
                getNextPhrase();
                $scope.typingWord = "";
                $scope.typedWords = [];
            };
        }
    };
    $scope.typing = function (key) {
        var codes = [13, 32, 190, 33, 63];
        if (codes.includes(key) && !endTyping) {
            var typingWord = $scope.typingWord.toLowerCase().replace(/[^\w\s]/g, "").trim();
            var expectedWord = $scope.expectedWord.word.toLowerCase().replace(/[^\w\s]/g, "").trim();
            if (typingWord == expectedWord) {
                getNextExpectedWord();
            } else if (key == 13) {
                $scope.youtubePlayer2.seekTo($scope.currentPhrase.StartTime, true);
                $scope.youtubePlayer2.playVideo();
            }
        } else if (key == 27) { //Escape
            $scope.hint();
        }
    };

    $scope.generateColor = function () {
        if ($scope.typingWord.toLowerCase().trim() == $scope.expectedWord.word.toLowerCase().trim()) {
            return "green";
        }
        return $scope.expectedWord.word.toLowerCase().indexOf($scope.typingWord.toLowerCase()) ? "red" : "green";
    };



}]);