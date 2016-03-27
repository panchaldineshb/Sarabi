/*
 * app/api/userroutes.js
 *
 * Defines application module {templateApp} and also contoller {signinController}
 *
 * http://jsbeautifier.org/
 *
 */

'use strict';

var User = require('../models/core/user');

module.exports = function(app) {

    // api ---------------------------------------------------------------------
    /** version # route
	*/
    version: '1.0',

    // authenticate user
    app.post('/api/authenticate', function(req, res) {
        console.log('Authenticate route called...');

        var email = req.param('email');
        var password = req.param('password');

        // No email/password entered
        if (! (email && password)) {
            return res.send('No username or password specified!', 500);
        }

        // use mongoose to get all users in the database
        User.findOne({'email': req.body.email, password: req.body.password}, function(err, user) {
            
            // if there is an error retrieving, send the error. nothing after res.send(err) will execute
            if (err)
                res.send(err)

            if (user) {
                console.info('Login USER: ' + req.session.userId);
                res.json(200, {id: user._id.toHexString(), authorized: true});
            } else {
                console.log('Specified User: ' + email + ' was not found');
                res.json(200, {authorized: false});
            }

        });
    });

    // validate session
    app.get('/api/validsession/:id', function(req, res) {

        // use mongoose to get all users in the database
        User.findOne({_id: req.param('id')},function(err, user) {

            // if there is an error retrieving, send the error. nothing after res.send(err) will execute
            if (err)
                res.send(err)

            if (user) {
                console.log('Session is valid');
                res.json(200, {id: user._id.toHexString(), authorized: true});
            } else {
                console.log('Session is not valid');
                res.json(200, {authorized: false});
            }

        });

    });

    // get all users e.g. http://localhost:8082/api/users/53946d6ff62ff4a975000002
    app.get('/api/users/:id', function(req, res) {

        // use mongoose to get all users in the database
        User.findOne({_id: req.param('id')},function(err, user) {

            // if there is an error retrieving, send the error. nothing after res.send(err) will execute
            if (err)
                res.send(err)

                // return all users in JSON format
                res.json(user);
            });
    });

    // get all users
    app.get('/api/users', function(req, res) {

        // use mongoose to get all users in the database
        User.find(function(err, users) {

            // if there is an error retrieving, send the error. nothing after res.send(err) will execute
            if (err)
                res.send(err)

                res.json(users);
            // return all users in JSON format
            });
    });

    // create user and send back all users after creation
    app.post('/api/users', function(req, res) {
        console.log('User.create route called...');

        /*
        var email = req.param('email');
        var displayname = req.param('displayname');
        var firstname = req.param('firstname');
        var lastname = req.param('lastname');
        var password = req.param('password');
        var dob = req.param('dob');

        var usr = new User({
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
                console.log('user: ' + usr.username + " saved.");
            }
        });
		*/
		
        // create a user, information comes from AJAX request from Angular
        User.create({
            email: req.param('email'),
            displayname: req.param('displayname'),
            firstname: req.param('firstname'),
            lastname: req.param('lastname'),
            password: req.param('password'),
            dob: req.param('dob'),
            hidden: false,
            purged: false,
            active: true
        }, function(err, user) {
            if (err)
                res.send(err);

            // get and return all the users after you create another
            User.find(function(err, users) {
                if (err)
                    res.send(err)
                    res.json(users);
            });
        });

    });

    // delete a user
    app.delete('/api/users/:id', function(req, res) {
        User.remove({
            _id: req.params.todo_id
        }, function(err, user) {
            if (err)
                res.send(err);

            // get and return all the users after you create another
            User.find(function(err, users) {
                if (err)
                    res.send(err)
                    res.json(users);
            });
        });
    });

};

console.log('User routes configured.');