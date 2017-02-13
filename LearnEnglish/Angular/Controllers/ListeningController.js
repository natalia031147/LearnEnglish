//var myApp = angular.module('learnEnglishApp', ['ngMaterial', 'ngMessages', 'youtube-embed']);
var app = angular.module("learnEnglishApp.controllers");
app.controller("ListeningController", [
    "$scope", "$http", "$routeParams", function($scope, $http, $routeParams) {
        $scope.video = {};
        $scope.currentIndex = 0;
        $scope.expectedWord = { word: "", index: -1 };
        $scope.typingWord = "";
        $scope.currentPhrase = { phrase: "" };
        $scope.progress = 0;
        $scope.countHint = 0;
        $scope.history = [];
        $scope.placeholder = "...";
        $scope.endTyping = false;
        $scope.playerVars = {
            'controls': 0,
            'autoplay': 1
        };

        $scope.$on("youtube.player.playing", function() {
            if (!$scope.endTyping) {
                var time = ($scope.currentPhrase.endTime - $scope.currentPhrase.startTime) * 1000;
                setTimeout(stopVideo, time);

                function stopVideo() {
                    $scope.youtubePlayer2.pauseVideo();
                    if ($scope.currentPhrase.phrase === "") {
                        getNextPhrase();
                    }
                }
            }
        });

        $scope.$on("youtube.player.paused", function () {
            if (!$scope.endTyping) {
                $scope.youtubePlayer2.seekTo($scope.currentPhrase.startTime, true);
            }
        });

        $scope.$on("youtube.player.ready", function() {
            $scope.youtubePlayer2.playVideo();
        });


        $scope.getVideoPhases = function() {
            $http({
                    url: "/Api/VideoPhrase",
                    method: "GET",
                    params: { id: $routeParams.id }
                })
                .success(function(data) {
                    $scope.video.phrases = data.sort(function (a, b) { return (a.orderNumber > b.orderNumber) ? 1 : ((b.orderNumber > a.orderNumber) ? -1 : 0); });
                    $scope.currentPhrase = { phrase: "", orderNumber: 0 };
                    $scope.phrasesNumber = $scope.video.phrases.filter(a => a.phrase !== "").length;

                    //getNextPhrase();
                })
                .error(function(error, status) {
                    console.log(status);
                    console.log("Error occured");
                });

        };

        $scope.getVideoDetails = function() {
            $http({
                    url: "/Api/Video",
                    method: "GET",
                    params: { id: $routeParams.id }
                })
                .success(function(data) {
                    $scope.video = data;
                })
                .error(function(error, status) {
                    console.log(status);
                    console.log("Error occured");
                });
        };

        $scope.init = function() {
            $scope.getVideoDetails();
            $scope.getVideoPhases();
        };


        $scope.hint = function() {
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
        var getNextPhrase = function() {
            var phrases = $scope.video.phrases.filter(a => a.phrase !== "");
            var lastOrderNumber = phrases[phrases.length - 1].orderNumber;
            if ($scope.currentPhrase.orderNumber < lastOrderNumber) {
                $scope.currentPhrase = $scope.video.phrases[$scope.currentPhrase.orderNumber];
                $scope.youtubePlayer2.seekTo($scope.currentPhrase.startTime, true);
                $scope.youtubePlayer2.playVideo();
                $scope.expectedWord = { word: $scope.currentPhrase.phrase.split(" ")[0], index: 0 };
                $scope.typedWords = [];
                $scope.typingWord = "";
                $scope.passed = $scope.video.phrases.filter(a => a.phrase !== "" && a.orderNumber < $scope.currentPhrase.orderNumber).length;
                $scope.progress = (($scope.passed / phrases.length) * 100).toFixed(0);
            } else {
                $scope.endTyping = true;
                $scope.youtubePlayer2.playVideo();
                $scope.youtubePlayer2.seekTo($scope.currentPhrase.endTime, true);
                $scope.passed = $scope.video.phrases.filter(a => a.phrase !== "" && a.orderNumber <= $scope.currentPhrase.orderNumber).length;
                $scope.currentPhrase = $scope.currentPhrase = { phrase: "" };;
                $scope.youtubePlayer2.playVideo();
                $scope.expectedWord = { word: "", index: -1 };;
                $scope.typedWords = [];
                $scope.typingWord = "";
                $scope.progress = (($scope.passed / phrases.length) * 100).toFixed(0);
                $scope.passed = $scope.passed - 1;
                var numberOfWords = $scope.video.phrases.filter(a => a.phrase != "").map(m => m.phrase).join(' ').split(' ').length;
                var progress = ((numberOfWords - $scope.countHint) / numberOfWords).toFixed(2) * 100;
                if (progress < 90) {
                    $scope.scoredMessage = "Your lesson has not been scored.";
                    $scope.efficiency = "Your Efficiency: " + progress + "%. Efficiency should be greater than or equal to 90%.";

                } else {
                    $scope.scoredMessage = "Congratulations! Your lesson has been scored!";
                    $scope.efficiency = "Your Efficiency: " + progress + "%";
                    $scope.save();
                }                
            };
        };
        


        var getNextExpectedWord = function() {
            var phraseWords = $scope.currentPhrase.phrase.split(" ");
            $scope.typedWords.push($scope.expectedWord.word);
            if ($scope.expectedWord.index + 1 < phraseWords.length) {
                $scope.expectedWord.index += 1;
                $scope.expectedWord.word = phraseWords[$scope.expectedWord.index];
                $scope.typingWord = "";
            } else {
                if ($scope.currentPhrase.phrase !== "") {
                    var item = { phrase: $scope.currentPhrase.phrase, phraseTranslated: $scope.currentPhrase.phraseTranslated, orderNumber: $scope.history.length + 1, translatedByGoogle: $scope.currentPhrase.translatedByGoogle };
                    $scope.history.push(item);
                }
                if (!$scope.endTyping) {
                    getNextPhrase();
                    $scope.typingWord = "";
                    $scope.typedWords = [];
                };
            }
        };
        $scope.typing = function(key) {
            var codes = [13, 32, 190, 33, 63];
            if (codes.includes(key) && !$scope.endTyping) {
                var typingWord = $scope.typingWord.toLowerCase().replace(/[^\w\s]/g, "").trim();
                var expectedWord = $scope.expectedWord.word.toLowerCase().replace(/[^\w\s]/g, "").trim();
                if (typingWord === expectedWord) {
                    getNextExpectedWord();
                } else if (key === 13) {
                    $scope.youtubePlayer2.seekTo($scope.currentPhrase.startTime, true);
                    $scope.youtubePlayer2.playVideo();
                }
            } else if (key === 27) { //Escape
                $scope.hint();
            }
        };

        $scope.generateColor = function() {
            if ($scope.typingWord.toLowerCase().trim() === $scope.expectedWord.word.toLowerCase().trim()) {
                return "green";
            }
            return $scope.expectedWord.word.toLowerCase().indexOf($scope.typingWord.toLowerCase()) ? "red" : "green";
        };

        $scope.save = function () {

            $scope.video.listeningModulePassed = true;
            $http({
                url: "/Api/VideoPhrase",
                method: "POST",
                data: JSON.stringify($scope.video),
                headers: { 'Content-Type': 'application/json' }
            })
                     .success(function (data) {
                         console.log(data);
                     })
                     .error(function (error, status) {
                         console.log(status);
                         console.log("Error occured");
                     });
        }

    }
]);