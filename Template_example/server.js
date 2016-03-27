/*
 * server.js
 *
 * Defines application module {templateApp} and also contoller {signinController}
 *
 * http://jsbeautifier.org/
 *
 */

'use strict';

//	server.js
// modules ======================================================================
var express = require('express');
var app = express(); // create our app w/ express
var mongoose = require('mongoose'); // mongoose for mongodb

// configuration ================================================================
var database = require('./config/db');
console.log("Database configuration complete");

// set the port =================================================================
var port = process.env.PORT || 8082;

// connect to DB ================================================================
mongoose.connect(database.url);

// app configuration ============================================================
app.configure(function () {
    app.use(express.static(__dirname + '/public')); // set the static files location /public/img will be /img for users
    app.use(express.cookieParser());				// since sessions are implemented using cookies
    app.use(express.session({						//  initializing Session
        secret: "lalala"
    })); // secret key
    app.use(express.json());
    app.use(express.logger('dev')); // log every request to the console
    app.use(express.bodyParser()); // pull information from html in POST
    app.use(express.methodOverride()); // simulate DELETE and PUT
});
console.log("Configuration complete");

// development only
if ('development' == app.get('env')) {
    app.use(express.errorHandler());
}

// routes ======================================================================
require('./app/routes')(app);
console.log("Routes registered");

// listen (start app with node server.js) ======================================
app.listen(port);
console.log("App listening on port " + port);