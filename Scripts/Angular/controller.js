; (function (app) {

    app.controller("mrCtrl", mapController)

    mapController.$inject = ["$scope", "mrApi"];

    function mapController($scope, mrApi) {

        $scope.loading = true;
        angular.element("#ngApp").removeClass("hidden")    ;
        $scope.adds = [];
        $scope.allAdds = [];
        $scope.getTopFives = [];
        $scope.getOnTheCover50 = [];
        $scope.setItemsPerPage = 10;

        $scope.title = "Listed all adds";

        mrApi.getAllAds().then(function(adds) {
            $scope.adds = adds;
            $scope.loading = false;
        }).then(function() {
            $scope.allAdds = $scope.adds;

        });

        mrApi.getTopFives().then(function (top5) {
            $scope.getTopFives = top5;
        });

        mrApi.getOnTheCover50().then(function (cover50) {
            $scope.getOnTheCover50 = cover50;
        });

        $scope.$watch("extraFilters", function (newValue) {

            if (newValue === "Cover") {

                $scope.adds = $scope.getOnTheCover50;
                $scope.title = "Listed adds on the cover w/ %50 C";
            } else if (newValue === "TopFive") {
                $scope.adds = $scope.getTopFives;
                $scope.title = "Listed Top Five Adds";
            } else {
                $scope.adds = $scope.allAdds;
                $scope.title = "Listed all adds";
            }
            console.log(newValue);
        });
    }


})(angular.module("MR"))
