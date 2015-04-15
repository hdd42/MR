;
(function(app) {
    "use strict";

    app.factory("mrApi", mrApi);

    mrApi.$inject = ["$q", "$http"]

    function mrApi($q, $http) {

        var addList = [];
        var topFives = [];
        var cover50 = [];


        var getAllAds = function() {
            var d = $q.defer();

            if (addList.length > 0) {
                d.resolve(addList);
            }

            else {
                $http.get("/api/Adds")
                .success(function (adds) {
                        addList = adds;
                        d.resolve(adds);
                })
                .error(function (err) {
                    d.reject(err);
                });
            }

            

            return d.promise;
        }

        var getTopFives = function () {
            var d = $q.defer();

            if (topFives.length > 0) {
                d.resolve(topFives);
            }

            else {
                $http.get("/api/TopFiveAdds")
                .success(function (adds) {
                    topFives = adds;
                    d.resolve(adds);
                })
                .error(function (err) {
                    d.reject(err);
                });
            }



            return d.promise;
        }

        var getOnTheCover50 = function () {
            var d = $q.defer();

            if (cover50.length > 0) {
                d.resolve(topFives);
            }

            else {
                $http.get("/api/CoverPageAdds")
                .success(function (adds) {
                    cover50 = adds;
                    d.resolve(adds);
                })
                .error(function (err) {
                    d.reject(err);
                });
            }



            return d.promise;
        }

        return {
            getAllAds: getAllAds,
            getTopFives: getTopFives,
            getOnTheCover50: getOnTheCover50
        }
    }
})(angular.module('MR'))