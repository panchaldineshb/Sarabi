;

'use strict';

/* Services */
angular.module('sarabiStoreApp')
    .factory('accountFactory', ['$http', '$q', function($http, $q) {

    //var urlBase = 'http://localhost:23424/api/account';
    var urlBase = '/api/account';

    var accountFactory = {};

    accountFactory.getAccounts = function () {
        var deferred = $q.defer();

        $http.get(urlBase)
            .success(function (data, status, headers, config) {
                debugger;
                deferred.resolve(data);
            }).error(function (data, status, headers, config) {
                debugger;
                deferred.reject(data);
            });

        return deferred.promise;
    };

    accountFactory.getAccount = function (id) {
        var deferred = $q.defer();

        $http.get(urlBase + '/' + id)
            .success(function (data, status, headers, config) {
                debugger;
                deferred.resolve(data);
            }).error(function (data, status, headers, config) {
                debugger;
                deferred.reject(data);
            });

        return deferred.promise;
    };

    accountFactory.insertAccount = function (account) {
        var deferred = $q.defer();

        $http.post(urlBase, account)
            .success(function (data, status, headers, config) {
                debugger;
                deferred.resolve(data);
            }).error(function (data, status, headers, config) {
                debugger;
                deferred.reject(data);
            });

        return deferred.promise;
    };

    accountFactory.updateAccount = function (account) {
        var deferred = $q.defer();

        $http.put(urlBase + '/' + account.Id, account)
            .success(function (data, status, headers, config) {
                debugger;
                deferred.resolve(data);
            }).error(function (data, status, headers, config) {
                debugger;
                deferred.reject(data);
            });

        return deferred.promise;
    };

    accountFactory.deleteAccount = function (id) {
        var deferred = $q.defer();

        $http.delete(urlBase + '/' + id)
            .success(function (data, status, headers, config) {
                debugger;
                deferred.resolve(data);
            }).error(function (data, status, headers, config) {
                debugger;
                deferred.reject(data);
            });

        return deferred.promise;
    };

    return accountFactory;
}]);