var myApp = angular.module('learnEnglishApp', ['youtube-embed']);

myApp.controller('AddVideoControler', ['$scope', '$http', function ($scope, $http) {

    $scope.step_one = 1;
    $scope.step_two = 0;
    $scope.errorLoading = 0;
    
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