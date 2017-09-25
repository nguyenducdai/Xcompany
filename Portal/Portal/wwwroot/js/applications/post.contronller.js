app.controller("PostController", ["$scope", "$rootScope", "$http", function ($scope, $rootScope, $http) {

    $scope.DataTable = {};
    $rootScope.post = {};

    $scope.showDialog = function (id) {
        $("#myModal").modal();
        if (id == undefined) {
            //$rootScope.post = {
            //    status: true,
            //    createAt: null,
            //    updateAt: null
            //}
            $rootScope.Tilte = "Add New Post";

        } else {
            // EDIT DATA
            $rootScope.Tilte = "Update Post";
            $http.get("/api/PostsAPI/" + id).then(function (response) {
                $rootScope.post = response.data;
            }, function (error) {
                console.log(error);
            });

        }
    }

    // post -> Add , get->get , put->update . delete-> del

    $scope.delete = function (id) {
        if (confirm("do you want delete ?")) {
            $http.delete("/api/PostsAPI/" + id).then(function (response) {
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
            $rootScope.post.createAt = new Date();
            $http.post("/api/PostsAPI/", $rootScope.post).then(function (response) {
                $scope.LoadData();
            }, function (error) {
                console.log(error);
            });
        } else {
            // SAVE UPDATE
            $rootScope.post.updateAt = new Date();
            $http.put("/api/PostsAPI/" + id, $rootScope.post).then(function (response) {
                $scope.LoadData();
            }, function (error) {
                console.log(error);
            });
        }

    }
    //LOAD DATATABLE
    $scope.LoadData = function () {
        $.ajax({
            url: "/api/PostsAPI/",
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