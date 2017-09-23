app.controller('MenuController', ['$scope','$rootScope', "$http", function ($scope,$rootScope, $http) {

	$scope.DataTable = {};
	$rootScope.menu = {};

	$scope.showDialog = function (id) {
		$("#myModal").modal();
		if (id == undefined) {
			$rootScope.menu = {
				status: true,
				createAt: null,
				updateAt: null
			}
			$rootScope.Tilte = "Add menu info";

		} else {
			// EDIT DATA
			$rootScope.Tilte = "update menu info";
			$http.get("/api/MenusAPI/"+id).then(function (response) {
				$rootScope.menu = response.data;
			}, function (error) {
				console.log(error);
			});

		}
	}

	// post -> Add , get->get , put->update . delete-> del

	$scope.delete = function (id) {
		if (confirm("ban co chac chan muon xoa khong")) {
			$http.delete("/api/MenusAPI/"+id).then(function (response) {
				$scope.LoadData();
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
			$http.put("/api/MenusAPI/"+id, $rootScope.menu).then(function (response) {
				$scope.LoadData();
			}, function (error) {
				console.log(error);
			});
		}

	}

	//load Data
	$scope.LoadData = function () {
		$.ajax({
			url: "/api/MenusAPI/",
			type: "get",
			dateType: "json",
			async: false,
			cache: true,
			success: function (response) {
				$scope.DataTable = response;
				console.log($scope.DataTable);
			}
		});
	}

	$scope.LoadData();

}]);
