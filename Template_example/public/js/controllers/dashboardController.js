/*
  * public/js/controllers/dashboardController.js
  *
  * Defines application module {templateApp} and also contoller {dashboardController}
  */
'use strict';

/*
var templateApp = angular.module('templateApp', []);
function dashboardController($scope, $http) {
*/

var templateApp = angular.module('templateApp');

templateApp.controller("dashboardController", ['$scope', '$cookieStore', '$http', 'userFactory', function($scope, $cookieStore, $http , userFactory) {
    console.log('Initialized dashboardController');

    /* Tag line
      */
    $scope.tagLine = 'The real people and real software development';

    /* Forms data
      */
    $scope.formData = {};
    $scope.formData.failedValidations = [];
    $scope.formData.$invalid = false;
    $scope.formData.errorMessage = '';

    /* Cookie values
      */
    debugger;
    $scope.cookie = JSON.parse($cookieStore.get('templateApp'));


    // when submitting the add form, send the text to the node API
    // example was copied from -- https://docs.angularjs.org/api/ng/service/$q
    $scope.getDashboardInfo = function(user) {
        userFactory.authenticateUser(user).then(function(result) {
            $scope.formData.$invalid = false;
        }, function(reason) {
            $scope.formData.$invalid = true;
            $scope.formData.errorMessage = "Login failed. Incorrect Username or Password";
        });

    };

}]);
console.log('dashboardController registered.');