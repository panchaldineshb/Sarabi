/*
 * public/js/services/userService.js
 *
 * Defines application module {templateApp} and also contoller {signinController}
 *
 * http://jsbeautifier.org/
 *
 */
'use strict';

/*
var templateApp = angular.module('templateApp', []);
function signinController($scope, $http) {
*/

var templateApp = angular.module('templateApp', ['ngCookies']);
console.log('templateApp registered.');

/*
angular.module('templateApp').factory('userFactory', ['$http', function($http) {

    var factory = {};

    factory.authenticateUser = function (user) {
        debugger;

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

    };

    return factory;

}]);
*/

/*
angular.module('templateApp').factory('userFactory', ['$q', '$http', function($q, $http) {

    return {

        authenticateUser: function(user) {
            console.log('authenticateUser factory method called...');

            var deferred = $q.defer();
            $http.post('/api/authenticate', user).success(function(data, status, headers, config) {
                debugger;
                deferred.resolve(data);
            }).error(function(data, status, headers, config) {
                debugger;
                deferred.reject("/api/authenticate failed");
            });

            return deferred.promise;

        }

    }

}]);
*/

templateApp.factory('userFactory', ['$http', '$cookieStore', '$q', '$rootScope', function ($http, $cookieStore, $q, $rootScope) {

    return {
        authenticateUser: function (user) {
            var deferred = $q.defer();

            $http.post('/api/authenticate', user)
               .success(function (data, status, headers, config) {
                   debugger;
                   deferred.resolve(data);
               }).error(function (data, status, headers, config) {
                   deferred.reject(data);
               });

            return deferred.promise;
        },

        logoutUser: function (user) {
            debugger;
        },

        getUser: function (user) {
            debugger;
            var deferred = $q.defer();

            $http.get('/api/users/:id', user._id)
               .success(function (data, status, headers, config) {
                   deferred.resolve(data);
               }).error(function (data, status, headers, config) {
                   deferred.reject(data);
               });

            return deferred.promise;
        },

        findUsers: function (user) {
            debugger;
            var deferred = $q.defer();

            $http.get('/api/users', user)
               .success(function (data, status, headers, config) {
                   deferred.resolve(data);
               }).error(function (data, status, headers, config) {
                   deferred.reject(data);
               });

            return deferred.promise;
        },

        createUser: function (user) {
            debugger;

            var deferred = $q.defer();

            $http.post('/api/users', user)
               .success(function (data, status, headers, config) {
                   deferred.resolve(data);
               }).error(function (data, status, headers, config) {
                   deferred.reject(data);
               });

            return deferred.promise;
        }
    };

}]);

templateApp.service('MathService', function($http, $cookieStore, $q, $rootScope) {
    this.add = function(a, b) {
        return a + b
    };

    this.subtract = function(a, b) {
        return a - b
    };

    this.multiply = function(a, b) {
        return a * b
    };

    this.divide = function(a, b) {
        return a / b
    };
});
console.log('MathService registered.');

templateApp.service('CalculatorService', function($http, $cookieStore, $q, $rootScope, MathService) {

    this.square = function(a) {
        return MathService.multiply(a, a);
    };
    this.cube = function(a) {
        return MathService.multiply(a, MathService.multiply(a, a));
    };

});
console.log('CalculatorService registered.');