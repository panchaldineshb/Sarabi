/*
 * app/api/locationroutes.js
 *
 * Defines application module {templateApp} and also contoller {signinController}
 *
 * http://jsbeautifier.org/
 *
 */

'use strict';

var Location = require('../models/core/location');

module.exports = function(app) {

    // api ---------------------------------------------------------------------
    /** version # route
	*/
    version: '1.0',

    // authenticate location
    app.post('/api/authenticate', function(req, res) {
        console.log('Authenticate route called...');

        var email = req.param('email');
        var password = req.param('password');

        // No email/password entered
        if (! (email && password)) {
            return res.send('No locationname or password specified!', 500);
        }

        // use mongoose to get all locations in the database
        Location.findOne({
            'email': email
        }, {
            'password': 1
        }, function(err, location) {
            // if there is an error retrieving, send the error. nothing after res.send(err) will execute
            if (err)
                res.send(err)

                if (location == null) {
                console.log('Specified Location: ' + email + ' was not found');
                res.statusCode = 200;
                return res.send('Location was not found', 200);
            } else {
                console.log('Specified Location: ' + email + ' was found');
                res.json(location);
                // return all locations in JSON format
            }

        });
    });

    // get all locations
    app.get('/api/locations', function(req, res) {

        // use mongoose to get all locations in the database
        Location.find(function(err, locations) {

            // if there is an error retrieving, send the error. nothing after res.send(err) will execute
            if (err)
                res.send(err)

                res.json(locations);
            // return all locations in JSON format
            });
    });

    // create location and send back all locations after creation
    app.post('/api/locations', function(req, res) {
        console.log('Location.create route called...');

        /*
        var email = req.param('email');
        var displayname = req.param('displayname');
        var firstname = req.param('firstname');
        var lastname = req.param('lastname');
        var password = req.param('password');
        var dob = req.param('dob');

        var usr = new Location({
            email: req.param('email'),
            displayname: req.param('displayname'),
            firstname: req.param('firstname'),
            lastname: req.param('lastname'),
            password: req.param('password'),
            dob: req.param('dob'),
            hidden: false,
            purged: false,
            active: true
        });
        usr.save(function(err) {
            if (err) {
                console.log(err);
            } else {
                console.log('location: ' + usr.locationname + " saved.");
            }
        });
		*/
		
        // create a location, information comes from AJAX request from Angular
        Location.create({
            email: req.param('email'),
            displayname: req.param('displayname'),
            firstname: req.param('firstname'),
            lastname: req.param('lastname'),
            password: req.param('password'),
            dob: req.param('dob'),
            hidden: false,
            purged: false,
            active: true
        }, function(err, location) {
            if (err)
                res.send(err);

            // get and return all the locations after you create another
            Location.find(function(err, locations) {
                if (err)
                    res.send(err)
                    res.json(locations);
            });
        });

    });

    // delete a location
    app.delete('/api/locations/:id', function(req, res) {
        Location.remove({
            _id: req.params.todo_id
        }, function(err, location) {
            if (err)
                res.send(err);

            // get and return all the locations after you create another
            Location.find(function(err, locations) {
                if (err)
                    res.send(err)
                    res.json(locations);
            });
        });
    });

};

console.log('Location routes configured.');