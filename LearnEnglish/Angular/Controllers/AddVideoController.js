var myApp = angular.module('learnEnglishApp', ['youtube-embed']);

myApp.controller('AddVideoControler', ['$scope', '$http', function ($scope, $http) {
  
    $scope.step_one = 1;
    $scope.step_two = 0;
    
    $scope.getVideo = function () {        
        $scope.step_loading = 1;
        $scope.video = $scope.youtubelink;

        $scope.step_one = 0;
        $scope.step_two = 1;
        
            
    };

       
    
    
}]);