;

'use strict';

/* Controllers

Defines:
ListCtrl:

TaskCtrl:

Services Used:
Lists:

Tasks:

Refer:
https://docs.angularjs.org/tutorial/step_07
*/
angular.module('sarabiStoreApp')
    .controller('accountController', ['$scope', '$location', 'accountFactory',
        function ($scope, $location, accountFactory) {

            $scope.status;

            $scope.accountDashboard = function (id) {

                debugger;
                $scope.status = 'Welcome to Dashboard.';

            };

            $scope.updateAccount = function (account) {

                accountFactory.updateAccount(account).then(function (result) {
                    debugger;
                    $scope.status = 'Updated Account! Refreshing customer list.';
                    $location.path('/account/' + result.Id);
                }, function (error) {
                    debugger;
                    $scope.status = 'Unable to update customer: ' + error.message;
                });

            };

            $scope.insertAccount = function (account) {

                accountFactory.insertAccount(account).then(function (result) {
                    debugger;
                    $scope.status = 'Inserted Account! Refreshing customer list.';
                    $location.path('/account/' + result.Id);
                }, function (error) {
                    debugger;
                    $scope.status = 'Unable to insert customer: ' + error.message;
                });

            };

            $scope.deleteAccount = function (id) {

                accountFactory.deleteAccount(id).then(function (result) {
                    debugger;
                    $scope.status = 'Deleted Account! Refreshing customer list.';
                    $location.path('/');
                }, function (error) {
                    debugger;
                    $scope.status = 'Unable to delete customer: ' + error.message;
                });

            };
        } ]);