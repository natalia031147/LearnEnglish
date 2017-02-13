//var myApp = angular.module('learnEnglishApp', ['ngMaterial', 'ngMessages', 'youtube-embed']);
var app = angular.module('learnEnglishApp.controllers');
app.controller('WritingController', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {
    $scope.video = {};
    $scope.currentIndex = 0;
    $scope.expectedWord = { word: "", index: -1 };
    $scope.typingWord = "";
    $scope.currentPhrase = { phrase: "" };
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
            url: "/Api/VideoPhrase",
            method: "GET",
            params: { id: $routeParams.id }
        })
            .success(function (data, status, headers, config) {
                $scope.video.phrases = data.filter(a => a.phrase !== "" && a.phrase !== null && a.phraseTranslated !== "" && a.phraseTranslated !== null);
                $scope.currentPhrase = { phrase: "", orderNumber: 0 };
                $scope.phrasesNumber = $scope.video.phrases.length;
                getNextPhrase();
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

    $scope.init = function (data) {
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
    $scope.endTyping = false;
    var index = 0;
    var getNextPhrase = function () {
        var phrases = $scope.video.phrases.filter(a => a.phrase != "");
        var lastOrderNumber = phrases[phrases.length - 1].orderNumber;
        if ($scope.currentPhrase.orderNumber < lastOrderNumber) {
            $scope.currentPhrase = $scope.video.phrases[index++];
            
            $scope.expectedWord = { word: $scope.currentPhrase.phrase.split(' ')[0], index: 0 };
            $scope.typedWords = [];
            $scope.typingWord = "";
            $scope.passed = $scope.video.phrases.filter(a => a.phrase !== "" && a.orderNumber < $scope.currentPhrase.orderNumber).length;
            $scope.progress = (($scope.passed / phrases.length) * 100).toFixed(0);
        } else {
            $scope.endTyping = true;
            $scope.passed = $scope.video.phrases.filter(a => a.phrase !== "" && a.orderNumber <= $scope.currentPhrase.orderNumber).length;
            $scope.currentPhrase = $scope.currentPhrase = { phrase: "" };
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


    var getNextExpectedWord = function () {
        var phraseWords = $scope.currentPhrase.phrase.split(' ');
        $scope.typedWords.push($scope.expectedWord.word);
        if ($scope.expectedWord.index + 1 < phraseWords.length) {
            $scope.expectedWord.index += 1;
            $scope.expectedWord.word = phraseWords[$scope.expectedWord.index];
            $scope.typingWord = "";
        } else {
            if ($scope.currentPhrase.phrase != "") {
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
    $scope.typing = function (key) {
        var codes = [13, 32, 190, 33, 63];
        if (codes.includes(key) && !$scope.endTyping) {
            var typingWord = $scope.typingWord.toLowerCase().replace(/[^\w\s]/g, "").trim();
            var expectedWord = $scope.expectedWord.word.toLowerCase().replace(/[^\w\s]/g, "").trim();
            if (typingWord == expectedWord) {
                getNextExpectedWord();
            } else if (key == 13) {
                
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

    $scope.save = function () {

        $scope.video.writingModulePassed = true;
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

}]);