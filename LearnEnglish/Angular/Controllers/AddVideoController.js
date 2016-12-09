var myApp = angular.module('learnEnglishApp', []);

myApp.controller('AddVideoControler', ['$scope', '$http', function ($scope, $http) {
  
    $scope.step_one = 1;
    $scope.step_two = 0;
    $scope.getVideo = function () {        
        $scope.step_loading = 1;
        var str = $scope.youtubelink;
        var responseYoutube = $http({
            url: '/Video/GetYoutubeInfo/',
            method: "GET",
            params: { url: $scope.youtubelink }
        });

        responseYoutube.success(function (data, status, headers, config) {

            if (data.code) {
                $scope.step_one = 0;
                $scope.step_two = 1;
                $scope.errorLoading = 0;
                $scope.thumbnailurl = data.thumbnail_url;
                $scope.title = data.title;
                $scope.code = data.code;
                $scope.start = data.start;
                $scope.durationPhp = data.duration;
                console.log(data);

                $scope.playerY = new YoutubeVideo('video-div', $scope.code, 620, 348);
                $scope.playerY.init('mainPlayer');

                $(document).on('player:loadded:mainPlayer', function (e, id) {
                    $scope.playerY.play(); // для полной инициализации видео
                    $scope.playerY.pause();

                    $scope.durationAll = $scope.playerY.getDurationNative().toFixed(1); // пытаемся получить общюю продолжительность
                    //$scope.durationAll  = $scope.playerY.getDurationNative(); 
                });
            } else {
                $scope.error_youtube = data.errorYoutube;
                $scope.errorLoading = 1;
                $scope.count_loaging = 0;
            }
        });

        responseYoutube.error(function (data, status, headers, config) {
            $scope.errorLoading = 1;
            $scope.count_loaging = 0;
        });
    }
    function pseudoLoading() {
        if ($scope.count_loaging < 100) {
            angular.safeApply($scope, function ($scope) {
                if ($scope.errorLoading == 0) {
                    $scope.count_loaging++;
                }
            });
        } else {
            //angular.safeApply($scope, function ($scope) {
            //    //$scope.step_two = 1; // сделать отдельную переменную и обрабаатывать в getVideo при успешном получении кода 

            //    $scope.step_loading = 0;
            //    //$scope.step_one      = 0;

            //    if ($scope.code) {

            //        $scope.step_two = 1;
            //        $scope.count_loaging = 0;
            //    }
            //});
            //clearInterval(interLoading);
        }
    }
}]);