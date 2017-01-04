//var myApp = angular.module('learnEnglishApp', ['ngMaterial', 'ngMessages', 'youtube-embed']);
var app = angular.module('learnEnglishApp.controllers');
app.controller('VideoController', ['$scope', '$http', function ($scope, $http) {
    $scope.video = {};
    $scope.show_general = 1;
    $scope.show_listening = 0;
    $scope.currentIndex = 0;
    $scope.inputWord = { word: "", index: -1 };
    $scope.typingWord = "";
    $scope.currentPhrase = { Phrase: "" };
    $scope.progress = 0;
    $scope.countHint = 0;
    $scope.history = [];
    $scope.placeholder = "...";
    
    $scope.playerVars = {
        'controls' : 0,
        'autoplay': 0
    };

    $scope.playVideo = function () {
        //$scope.youtubePlayer.loadVideoById('4Y8WR5VrN9E', 0, 7);
        alert('');
       
        
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


    $scope.listening = function () {
        $scope.show_general = 0;
        $scope.show_listening = 1;
        $http({
            url: "/Video/GetVideoPhases",
            method: "GET",
            params: { id: $scope.video.Id }
        })
            .success(function (data, status, headers, config) {
                $scope.video.phrases = data.sort((a, b) => a.OrderNumber > b.OrderNumber);
                $scope.currentPhrase = { Phrase: "", OrderNumber: 0 };
                $scope.phrasesNumber = $scope.video.phrases.filter(a => a.Phrase != "").length;
                getNextPhrase();
            })
            .error(function (error, status, headers, config) {
                console.log(status);
                console.log("Error occured");
            });
        
    };
    
    $scope.init = function (data) {
        $scope.video = data;
    };

    

    $scope.hint = function () {
        $scope.countHint++;
        $scope.typingWord = "";
        $scope.placeholder = $scope.inputWord.word;

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
        var copy = Object.assign([], $scope.video.phrases).sort();
        var last = copy.sort((a, b) => a.OrderNumber < b.OrderNumber).find(a => a.Phrase != "").OrderNumber;
        if ($scope.currentPhrase.OrderNumber < last) {
            $scope.currentPhrase = $scope.video.phrases[$scope.currentPhrase.OrderNumber];
            $scope.youtubePlayer2.seekTo($scope.currentPhrase.StartTime, true);
            $scope.youtubePlayer2.playVideo();
            $scope.inputWord = { word: $scope.currentPhrase.Phrase.split(' ')[0], index: 0 };
            $scope.typedWords = [];
            $scope.typingWord = "";
            $scope.passed = $scope.video.phrases.filter(a => a.Phrase != "" && a.OrderNumber < $scope.currentPhrase.OrderNumber - 1).length;
            $scope.progress = (($scope.passed / $scope.phrasesNumber) * 100).toFixed(0);
        } else {                        
            endTyping = true;
            $scope.youtubePlayer2.playVideo();
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
            }
        );
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
            if ($scope.currentPhrase.Phrase != "") {
                var item = { Phrase: $scope.currentPhrase.Phrase, PhraseTranslated: $scope.currentPhrase.PhraseTranslated, OrderNumber: $scope.history.length + 1};
                $scope.history.push(item);
            }
            getNextPhrase();
            
        }
    };
    $scope.typing = function (key) {
        var codes = [13, 32, 190, 33, 63];
        if (codes.includes(key) && !endTyping) {
            var typingWord =  $scope.typingWord.toLowerCase().replace(/[^\w\s]/g, "").trim();
            var expectedWord = $scope.inputWord.word.toLowerCase().replace(/[^\w\s]/g, "").trim();
            if (typingWord == expectedWord) {
                getNextInputWord();
            } else if (key == 13) {
                $scope.youtubePlayer2.seekTo($scope.currentPhrase.StartTime, true);
                $scope.youtubePlayer2.playVideo();
            } 
        } else if (key == 16) {
            $scope.hint();
        }
    };

    $scope.generateColor = function () {
        if( $scope.typingWord.toLowerCase().trim() == $scope.inputWord.word.toLowerCase().trim() )
        {
            return "green";
        } 
        return $scope.inputWord.word.toLowerCase().indexOf($scope.typingWord.toLowerCase()) ? "red" : "green";
    };

  

}]);