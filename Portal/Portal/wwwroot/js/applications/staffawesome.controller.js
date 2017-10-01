app.controller("StaffAwesomeController", ["$scope", "$rootScope", "$http", function ($scope, $rootScope, $http) {

    $scope.DataTable = {};
    $rootScope.staffawesome = {};

    $scope.showDialog = function (id) {
        $("#myModal").modal();
        if (id == undefined) {
            $rootScope.Tilte = "Add New Staff Awesome";
        } else {
            // EDIT DATA
            $rootScope.Tilte = "Update Staff Awesome";
            $http.get("/api/StaffAwesomeAPI/" + id).then(function (response) {
                $rootScope.staffawesome = response.data;
            }, function (error) {
                console.log(error);
            });

        }
    }

    $scope.delete = function (id) {
        if (confirm("do you want delete ?")) {
            $http.delete("/api/StaffAwesomeAPI/" + id).then(function (response) {
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
            $rootScope.staffawesome.createAt = new Date();
            $http.post("/api/StaffAwesomeAPI/", $rootScope.staffawesome).then(function (response) {
                $scope.LoadData();
            }, function (error) {
                console.log(error);
            });
        } else {
            // SAVE UPDATE
            $rootScope.staffawesome.updateAt = new Date();
            $http.put("/api/StaffAwesomeAPI/" + id, $rootScope.staffawesome).then(function (response) {
                $scope.LoadData();
            }, function (error) {
                console.log(error);
            });
        }

    }
    //LOAD DATATABLE
    $scope.LoadData = function () {
        $.ajax({
            url: "/api/StaffAwesomeAPI/",
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
}])