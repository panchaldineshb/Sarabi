/*
  * public/js/controllers/signinController.js
  *
  * Defines application module {templateApp} and also contoller {signinController}
  */
'use strict';

/*
var templateApp = angular.module('templateApp', []);
function signinController($scope, $http) {
*/

var templateApp = angular.module('templateApp');

templateApp.controller("signinController", ['$scope', '$cookieStore', '$http', 'userFactory', function($scope, $cookieStore, $http , userFactory) {
    console.log('Initialized signinController');

    /* Forms data
      */
    $scope.tagLine = 'The real people and real software development';

    /* Forms data
      */
    $scope.formData = {};
    $scope.formData.failedValidations = [];
    $scope.formData.$invalid = false;
    $scope.formData.errorMessage = '';

    // when submitting the add form, send the text to the node API
    // example was copied from -- https://docs.angularjs.org/api/ng/service/$q
    $scope.loginUser = function(user) {
        userFactory.authenticateUser(user).then(function(result) {
            debugger;
            $scope.formData.$invalid = false;
            $cookieStore.put('templateApp', JSON.stringify(result));
            window.location = "/dashboard";
        }, function(reason) {
            $cookieStore.put('templateApp', 'authorized==false');
            $scope.formData.$invalid = true;
            $scope.formData.errorMessage = 'Login failed. Incorrect Username or Password';
            console.log('Login failed');
        });

    };

    // when submitting the add form, send the text to the node API
    // example was copied from -- https://docs.angularjs.org/api/ng/service/$q
    $scope.logoutUser = function(user) {
        userFactory.logoutUser(user).then(function(result) {
            debugger;
            $scope.formData.$invalid = false;
            window.location = "/";
        }, function(reason) {
            $scope.formData.$invalid = true;
            $scope.formData.errorMessage = "Login failed. Incorrect Username or Password";
        });

    };

    // when submitting the add form, send the text to the node API
    $scope.createUser = function() {
        userFactory.createUser(user).then(function(result) {
            $scope.formData.$invalid = false;
        }, function(reason) {
            $scope.formData.$invalid = true;
            $scope.formData.errorMessage = reason;
        });

    };

    // delete a User after checking it
    $scope.deleteUser = function(id) {
        $http.delete('/api/users/' + id).success(function(data) {
            $scope.users = data;
        }).error(function(data) {
            console.log('Error: ' + data);
        });
    };

}]);
console.log('signinController registered.');