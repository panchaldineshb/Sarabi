/*
  * public/js/controllers/registerController.js
  *
  * Defines application module {templateApp} and also contoller {registerController}
  */
'use strict';

/*
var templateApp = angular.module('templateApp', []);
function registerController($scope, $http) {
*/

var templateApp = angular.module('templateApp');

templateApp.controller("registerController", function($scope, $http, $location, $q, $rootScope, userFactory) {
    console.log('Initialized registerController');

    /* Forms data
      */
    $scope.tagLine = 'The real people and real software development';

    /* Person data
      */
    $scope.bundlesSupported = [{
        name: 'OrderProcessing',
        displayName: 'Order Processing',
        lastUpdated: '2013/1/5'
    }, {
        name: 'ContentManagement',
        displayName: 'Content Management',
        lastUpdated: '2013/4/15'
    }, {
        name: 'InventoryManagement',
        displayName: 'Inventory Management',
        lastUpdated: '2013/4/15'
    }, {
        name: 'CustomerRelationsManagement',
        displayName: 'Customer Relations Management',
        lastUpdated: '2013/4/15'
    }, {
        name: 'ServicesAndRepairs',
        displayName: 'Services and Repairs',
        lastUpdated: '2014/5/1'
    }, {
        name: 'BankruptcyCourt',
        displayName: 'Bankruptcy Court',
        lastUpdated: '2014/2/3'
    }, {
        name: 'CustomerService',
        displayName: 'Customer Service',
        lastUpdated: '2013/4/15'
    }];

    /* Forms data
      */
    $scope.formData = {};
    $scope.formData.failedValidations = [];
    $scope.formData.$invalid = true;
    $scope.formData.errorMessage = '';

    // when submitting the add form, send the text to the node API
    // example was copied from -- https://docs.angularjs.org/api/ng/service/$q
    $scope.loginUser = function(user) {
        userFactory.authenticateUser(user).then(function(result) {
            // success: do something and resolve promiseB
            //          with the old or a new result
            debugger;
            $scope.formData.$invalid = false;
        }, function(reason) {
            // error: handle the error if possible and
            //        resolve promiseB with newPromiseOrValue,
            //        otherwise forward the rejection to promiseB
            debugger;
            $scope.formData.$invalid = true;
            $scope.formData.errorMessage = reason;
        });

        /*
		$http.post('/api/authenticate', user)
			.success(function(data) {
				$scope.formData.$invalid = false;

				// The user has authenticated successfully, set their session
				req.session.authenticated = true;
				req.session.User = data;

				// Redirect to protected area
				return res.redirect('/dashboard');

			})
			.error(function(data) {
				$scope.formData.$invalid = true;
				$scope.formData.errorMessage = data;
			});
		*/

        };

    // when submitting the add form, send the text to the node API
    $scope.createUser = function(user) {
        debugger;
        userFactory.createUser(user).then(function(result) {
            // success: do something and resolve promiseB
            //          with the old or a new result
            debugger;
            $scope.formData.$invalid = false;
        }, function(reason) {
            // error: handle the error if possible and
            //        resolve promiseB with newPromiseOrValue,
            //        otherwise forward the rejection to promiseB
            debugger;
            $scope.formData.$invalid = true;
            $scope.formData.errorMessage = reason;
        });


        /*
        $http.post('/api/users', $scope.formData).success(function(data) {
            $scope.users = data;
        }).error(function(data) {
            console.log('Error: ' + data);
        });
        */
    };

    // delete a User after checking it
    $scope.deleteUser = function(id) {
        $http.delete('/api/users/' + id).success(function(data) {
            $scope.users = data;
        }).error(function(data) {
            console.log('Error: ' + data);
        });
    };

});

console.log('registErcontroller registered.');