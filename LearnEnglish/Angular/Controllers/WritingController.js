//var myApp = angular.module('learnEnglishApp', ['ngMaterial', 'ngMessages', 'youtube-embed']);
var app = angular.module('learnEnglishApp.controllers');
app.controller('WritingController', ['$scope', '$http', function ($scope, $http) {
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

    $scope.getVideoPhases = function () {
        $http({
            url: "/Video/GetVideoPhases",
            method: "GET",
            params: { id: $scope.video.Id }
        })
            .success(function (data, status, headers, config) {
                $scope.video.phrases = data.filter(a => a.Phrase != "");
                $scope.currentPhrase = { Phrase: "", OrderNumber: 0 };
                $scope.phrasesNumber = $scope.video.phrases.length;
                getNextPhrase();
            })
            .error(function (error, status, headers, config) {
                console.log(status);
                console.log("Error occured");
            });

    };

    $scope.init = function (data) {
        $scope.video = data;
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
    var index = 0;
    var getNextPhrase = function () {
        var phrases = $scope.video.phrases.filter(a => a.Phrase != "");
        var lastOrderNumber = phrases[phrases.length - 1].OrderNumber;
        if ($scope.currentPhrase.OrderNumber < lastOrderNumber) {
            $scope.currentPhrase = $scope.video.phrases[index++];
            
            $scope.expectedWord = { word: $scope.currentPhrase.Phrase.split(' ')[0], index: 0 };
            $scope.typedWords = [];
            $scope.typingWord = "";
            $scope.passed = $scope.video.phrases.filter(a => a.Phrase != "" && a.OrderNumber < $scope.currentPhrase.OrderNumber).length;
            $scope.progress = (($scope.passed / phrases.length) * 100).toFixed(0);
        } else {
            endTyping = true;        
            $scope.passed = $scope.video.phrases.filter(a => a.Phrase != "" && a.OrderNumber <= $scope.currentPhrase.OrderNumber).length;
            $scope.currentPhrase = $scope.currentPhrase = { Phrase: "" };
            $scope.expectedWord = { word: "", index: -1 };;
            $scope.typedWords = [];
            $scope.typingWord = "";
            $scope.progress = (($scope.passed / phrases.length) * 100).toFixed(0);
            $scope.passed = $scope.passed - 1;
        };
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
                var item = { Phrase: $scope.currentPhrase.Phrase, PhraseTranslated: $scope.currentPhrase.PhraseTranslated, OrderNumber: $scope.history.length + 1, TranslatedByGoogle: $scope.currentPhrase.TranslatedByGoogle  };
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