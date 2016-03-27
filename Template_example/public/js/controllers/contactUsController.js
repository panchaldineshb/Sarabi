/*
 * public/js/controllers/signinController.js
 *
 * Defines application module {templateApp} and also contoller {signinController}
 */

var templateApp = angular.module('templateApp', []);

function signinController($scope, $http) {
	
	/* Forms data
	 */
	$scope.formData = {};

	/* Person data
	 */
	$scope.bundlesSupported = [
		{  name: 'OrderProcessing', 			displayName: 'Order Processing', 				lastUpdated: '2013/1/5'},
		{  name: 'ContentManagement', 			displayName: 'Content Management', 				lastUpdated: '2013/4/15'},
		{  name: 'InventoryManagement', 		displayName: 'Inventory Management', 			lastUpdated: '2013/4/15'},
		{  name: 'CustomerRelationsManagement', displayName: 'Customer Relations Management', 	lastUpdated: '2013/4/15'},
		{  name: 'ServicesAndRepairs', 			displayName: 'Services and Repairs', 			lastUpdated: '2014/5/1'},
		{  name: 'BankruptcyCourt', 			displayName: 'Bankruptcy Court', 				lastUpdated: '2014/2/3'},
		{  name: 'CustomerService', 			displayName: 'Customer Service', 				lastUpdated: '2013/4/15'}
	];

	// when landing on the page, get all todos and show them
	$http.get('/api/users')
		.success(function(data) {
			$scope.users = data;
		})
		.error(function(data) {
			console.log('Error: ' + data);
		});

	// when submitting the add form, send the text to the node API
	$scope.createUser = function() {
		$http.post('/api/users', $scope.formData)
			.success(function(data) {
				$('input').val('');
				$scope.users = data;
			})
			.error(function(data) {
				console.log('Error: ' + data);
			});
	};

	// delete a User after checking it
	$scope.deleteUser = function(id) {
		$http.delete('/api/users/' + id)
			.success(function(data) {
				$scope.users = data;
			})
			.error(function(data) {
				console.log('Error: ' + data);
			});
	};

}
