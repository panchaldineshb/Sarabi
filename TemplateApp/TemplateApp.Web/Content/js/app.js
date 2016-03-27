/*
 * public/js/app.js
 *
 * Defines application module {templateApp} and also contoller {mainController}
 */

'use strict';

/*
var templateApp = angular.module('templateApp', []);
function mainController($scope, $http) {
}

var templateApp = angular.module('templateApp', []);
templateApp.contoller('mainController', function ($scope, $http) {
}
*/


var templateApp = angular.module('templateApp', ['ngCookies']);

templateApp.controller('mainController', ['$scope', '$http', '$cookieStore', function ($scope, $http, $cookieStore) {
    console.log('Initialized templateApp');
	
	/* Forms data
	 */
	$scope.formData = {};

	/* Forms data
	 */
	$scope.quoteLine = 'The real software development';
	$scope.tagLine = 'The real software development';

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

	/* Quotes data
	 */
	$scope.quotes = [
	  { author : 'Audrey Hepburn', text : "Nothing is impossible, the word itself says 'I'm possible'!"},
	  { author : 'Walt Disney', text : "You may not realize it when it happens, but a kick in the teeth may be the best thing in the world for you"},
	  { author : 'Unknown', text : "Even the greatest was once a beginner. Don't be afraid to take that first step."},
	  { author : 'Neale Donald Walsch', text : "You are afraid to die, and you're afraid to live. What a way to exist."}
	];

	// when landing on the page, get all todos and show them
	$http.get('/api/todos')
		.success(function(data) {
			$scope.todos = data;
		})
		.error(function(data) {
			console.log('Error: ' + data);
		});

}]);
console.log('App registered.');
