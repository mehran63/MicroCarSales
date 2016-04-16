angular.module("microCarSales")
    .constant("carUrl", "http://localhost:6666/api/Cars")
    .controller("microCarSalesCtrl", function ($scope, $http, $location, carUrl) {
        $scope.data = {};
        $scope.navbarProperties = {
            isCollapsed: true
        };
        
        $scope.addCar = function (carDetails) {
            var car = angular.copy(carDetails);
            $http.post(carUrl, car)
            .success(function (data) {
                $scope.data.lastAddedCarId = data;
                $location.path("/addImages");
            })
            .error(function (error) {
                $scope.data.orderError = error;
            });
        }
});