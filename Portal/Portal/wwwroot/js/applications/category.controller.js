app.controller('CategoryController', ['$scope', '$rootScope', "$http", function ($scope, $rootScope, $http) {

    $rootScope.DataTable = {};
    $rootScope.DataDropList = {};
    $rootScope.srcViewImage = null;

    $rootScope.multiple = false;
    $rootScope.accept = "*";
    $rootScope.value = [];
    $rootScope.uploadMode = "instantly";

    $rootScope.options = {
        uploadUrl: "/api/CategoriesAPI/Upload",
        bindingOptions: {
            multiple: "multiple",
            accept: "accept",
            value: "value",
            uploadMode: "uploadMode"
        }
    };

    // post -> Add , get->get , put->update . delete-> del
    $scope.delete = function (id) {
        if (confirm("do you want delete ?")) {
            $http.delete("/api/MenusAPI/" + id).then(function (response) {
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
            $rootScope.Category.createAt = new Date();
            $rootScope.Category.alias = Alias($rootScope.Category.name)
            $http.post("/api/CategoriesAPI/", $rootScope.Category).then(function (response) {
                DevExpress.ui.dialog.alert("Add category done ! ", "Alert");
                loadCategory();
            }, null);
        } else {
            $rootScope.Category.updateAt = new Date();
            $rootScope.Category.alias = Alias($rootScope.Category.name)
            $http.put("/api/CategoriesAPI/" + id, $rootScope.Category).then(function (response) {
                DevExpress.ui.dialog.alert("update category done ! ", "Alert"); 
                loadCategory();
            },null);
        }
    }

    function loadCategory() {
        $.ajax({
            url: "/api/CategoriesAPI/GetListRecursiveCategories",
            type: "GET",
            cache: false,
            async: false,
            contentType: "application/json",
            success: function (response) {
                $rootScope.DataTable = response;
            },
            error: function (error) {
                console.log("err");
            }
        });
    }
    loadCategory();

    $scope.showDialog = function (id) {
        $("#myModal").modal();
        if (id == undefined) {
            $rootScope.Category = {
                imageIcon: null,
                status: true,
                createAt: null,
                updateAt: null
            }
            $rootScope.Tilte = "Add category Info";
            loadCategory();

        } else {
            // EDIT DATA
            $rootScope.Tilte = "Update category info";
            $http.get("/api/CategoriesAPI/" + id).then(function (response) {
                $rootScope.Category = response.data;
            }, function (error) {
                console.log(error);
            });
        }

    }
}]);