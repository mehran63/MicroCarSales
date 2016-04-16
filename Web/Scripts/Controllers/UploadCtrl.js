angular.module("microCarSales")
     .constant("uploadUrl", "http://localhost:6666/api/Cars/0/images")
     .controller('UploadCtrl', function ($scope, $http, $timeout, Upload, $location, uploadUrl) {
         var url = uploadUrl.replace("0", $scope.data.lastAddedCarId);
         $scope.uploadFiles = function (files) {
             $scope.files = files;
             if (files && files.length) {
                 Upload.upload({
                     url: url,
                     data: {
                         files: files
                     }
                 }).then(function (response) {
                     $location.path("/thankYou");
                 }, function (response) {
                     if (response.status > 0) {
                         $scope.errorMsg = response.status + ': ' + response.data;
                     }
                 }, function (evt) {
                     $scope.progress =
                         Math.min(100, parseInt(100.0 * evt.loaded / evt.total));
                 });
             }
         }
     });