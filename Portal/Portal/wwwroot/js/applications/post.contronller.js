app.controller("PostController", ["$scope", "$rootScope", "$http", function ($scope, $rootScope, $http) {


	$scope.DataTable = {};
	$rootScope.Post = {};

	$rootScope.multiple = false;
	$rootScope.accept = "image/*";
	$rootScope.value = [];
	$rootScope.uploadMode = "instantly";

	$rootScope.options = {
	    uploadUrl: "",
	    bindingOptions: {
	        multiple: "multiple",
	        accept: "accept",
	        value: "value",
	        uploadMode: "uploadMode"
	    }
	};

	$scope.showDialog = function (id) {
		$("#myModal").modal();
		if (id == undefined) {
			$rootScope.menu = {
				status: true,
				createAt: null,
				updateAt: null
			}
			$rootScope.Tilte = "add post infronation";

		} else {
			// EDIT DATA
			$rootScope.Tilte = "update post infronation";
			$http.get("/api/MenusAPI/" + id).then(function (response) {
				$rootScope.menu = response.data;
			}, function (error) {
				console.log(error);
			});

		}
	}

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
			$rootScope.menu.createAt = new Date();
			$http.post("/api/MenusAPI/", $rootScope.menu).then(function (response) {
				$scope.LoadData();
			}, function (error) {
				console.log(error);
			});
		} else {
			// SAVE UPDATE
			$rootScope.menu.updateAt = new Date();
			$http.put("/api/MenusAPI/" + id, $rootScope.menu).then(function (response) {
				$scope.LoadData();
			}, function (error) {
				console.log(error);
			});
		}
	}

	$rootScope.upload = function () {
		$('#openFile').click();
	}

	
	//LOAD DATATABLE
	$scope.LoadDataPost = function () {
		$.ajax({
			url: "/api/PostsAPI/",
			type: "GET",
			contentType: "application/json",
			async: false,
			cache: false,
			success: function (response) {
				$scope.DataTable = response;
			}
		});
	}

	$scope.LoadDataPost();


}]);