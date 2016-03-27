;

'use strict';

/*
The App Module

Defines:


Refer:
https://docs.angularjs.org/tutorial/step_07
http://weblogs.asp.net/dwahlin/using-an-angularjs-factory-to-interact-with-a-restful-service

*/
var app = angular.module('sarabiStoreApp', ['ngRoute']);

app.config(['$routeProvider', function ($routeProvider) {

    $routeProvider
        .when('/account/:id/', { controller: 'accountController', templateUrl: '/account/dashboard' })
        .when('/account/register', { controller: 'accountController', templateUrl: '/account/register' })
        .otherwise({ redirectTo: '/' });

} ]);