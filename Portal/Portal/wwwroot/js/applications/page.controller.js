app.controller("PageController", ["$scope", "$rootScope", "$http", function ($scope, $rootScope, $http) {

    $scope.DataTable = {};
    $rootScope.page = {};

    $scope.showDialog = function (id) {
        $("#myModal").modal();
        if (id == undefined) {
            $rootScope.page = {
                status: true,
                createAt: null,
                updateAt: null
            }
            $rootScope.Tilte = "Add New Page";

        } else {
            // EDIT DATA
            $rootScope.Tilte = "Update Page";
            $http.get("/api/PagesAPI/" + id).then(function (response) {
                $rootScope.page = response.data;
            }, function (error) {
                console.log(error);
            });

        }
    }

    // post -> Add , get->get , put->update . delete-> del

    $scope.delete = function (id) {
        if (confirm("do you want delete ?")) {
            $http.delete("/api/PagesAPI/" + id).then(function (response) {
                $scope.LoadData();
                MessageEvent("delete done !", "#messageinfo", "s")
            }, function (error) {
                console.log(error);
            });
        }
    }

    // SAVE POST / PUT
    $rootScope.save = function (id) {
        // SAVE ADD
        if (id == undefined) {
            $rootScope.page.createAt = new Date();
            $http.post("/api/PagesAPI/", $rootScope.page).then(function (response) {
                $scope.LoadData();
            }, function (error) {
                console.log(error);
            });
        } else {
            // SAVE UPDATE
            $rootScope.page.updateAt = new Date();
            $http.put("/api/PagesAPI/" + id, $rootScope.page).then(function (response) {
                $scope.LoadData();
            }, function (error) {
                console.log(error);
            });
        }

    }
    //LOAD DATATABLE
    $scope.LoadData = function () {
        $.ajax({
            url: "/api/PagesAPI/",
            type: "get",
            dateType: "json",
            async: false,
            cache: true,
            success: function (response) {
                $scope.DataTable = response;
                //console.log($scope.DataTable);
            }
        });
    }

    $scope.LoadData();
}]);