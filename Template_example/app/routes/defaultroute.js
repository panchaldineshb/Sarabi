/** app/routes/defaultroute.js
*/
var fs = require('fs');

module.exports = function(app) {

  /** version # route
  */
  version: '1.0',

  /** contactus route
  */
  app.get('/contactus', function (req, res) {
    console.log('Sending ./public/views/contactus.html');
    res.sendfile('./public/views/contactus.html'); // load our public/views/contactus.html file
  });

  /** signin route
  */
  app.get('/signin', function (req, res) {
    console.log('Sending ./public/views/signin.html');
    res.sendfile('./public/views/signin.html'); // load our public/views/signin.html file
  });

  /** contactus route
  */
  app.get('/register', function (req, res) {
    console.log('Sending ./public/views/register.html');
    res.sendfile('./public/views/register.html'); // load our public/views/register.html file
  });

  /** dashboard route
  */
  app.get('/dashboard', function (req, res) {
    console.log('Sending ./public/views/dashboard.html');
    res.sendfile('./public/views/dashboard.html'); // load our public/views/dashboard.html file
  });

  /** default root route
  */
  app.get('/', function (req, res) {
    console.log('geting index.html page');
    fs.stat('./public/views/index.html', function(err, stat) {
      if(err == null) {
        res.sendfile('./public/views/index.html'); // load our public/views/index.html file
      } else if(err.code == 'ENOENT') {
        res.sendfile('./public/index.html'); // load our public/index.html file
      } else {
        console.log('Other error: ', err.code);
      }
    });
  });

};

console.log('Default route registered.');