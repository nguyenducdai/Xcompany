app.controller("PostController", ["$scope", "$rootScope", "$http", function ($scope, $rootScope, $http) {

    $scope.DataTable = {};
    $rootScope.DataDropList = {};
    $rootScope.Post = {};

    function loadCategory() {
        $.ajax({
            url: "/api/CategoriesAPI/GetListRecursiveCategories",
            type: "GET",
            cache: false,
            async: false,
            contentType: "application/json",
            success: function (response) {
                $rootScope.DataDropList = response;
            },
            error: function (error) {
                console.log("err");
            }

        });
    }

    $scope.showDialog = function (id) {
        loadCategory(); 
        $("#myModal").modal();
        if (id == undefined) {
            $rootScope.menu = {
                status: true,
                createAt: null,
                updateAt: null
            }
            $rootScope.Tilte = "add post infonation";
        }
        else
        {
            $rootScope.Tilte = "update post infonation";
            $http.get("/api/PostsAPI/" + id).then(function (response) {
                $rootScope.Post = response.data;
            }, function (error) {
                console.log(error);
            });
        }
    }

    // post -> Add , get->get , put->update . delete-> del
    $scope.delete = function (id) {
        if (confirm("do you want delete ?")) {
            $http.delete("/api/PostsAPI/" + id).then(function (response) {
                $scope.LoadDataPost();
                MessageEvent("delete done !", "#messageinfo", "s")
            }, function (error) {
                console.log(error);
            });
        }
    }

    // SAVE POST / PUT
    $rootScope.save = function (id) {
        // SAVE ADD
        if(id == undefined) {
            $rootScope.Post.alias = Alias($rootScope.Post.name);
            $rootScope.Post.createAt = new Date();
            $http.post("/api/PostsAPI/", $rootScope.Post).then(function (response) {
                $scope.LoadDataPost();
            }, function (error) {
                console.log(error);
            });
        }
        else
        {
            $rootScope.Post.alias = Alias($rootScope.Post.name);
            $rootScope.Post.updateAt = new Date();
            $http.put("/api/PostsAPI/" + id, $rootScope.Post).then(function (response) {
                DevExpress.ui.dialog.alert("Update post done ! ", "Alert");
                $scope.LoadDataPost();
            }, function (error) {
                console.log(error);
            });
        }
    }

    //LOAD DATATABLE
    $scope.LoadDataPost = function () {
        $.ajax({
            url: "/api/PostsAPI/",
            type: "GET",
            contentType: "application/json",
            async: false,
            cache: false,
            data: {},
            success: function (response) {
                $scope.DataTable = response;
            },
            error: function (error) {
                console.log("err");
            }

        });
    }
    $scope.LoadDataPost();
}]);