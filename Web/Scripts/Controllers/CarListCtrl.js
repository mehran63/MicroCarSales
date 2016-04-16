angular.module("microCarSales")
     .constant("carUrl", "http://localhost:6666/api/Cars")
     .controller('carListCtrl', function ($scope, $http, carUrl) {

         $http.get(carUrl)
         .success(function (data) {
             $scope.data.cars = data;
         })
         .error(function (error) {
             $scope.data.error = error;
         });
     });