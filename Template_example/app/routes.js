/**	app/routes.js
 */
/** Refer to following for more explanation on module.export
 * http://openmymind.net/2012/2/3/Node-Require-and-Exports/
 */
module.exports = function (app) {

    require('./routes/defaultroute.js')(app);

    require('./api/todoroutes.js')(app);
    console.log('Todo routes registered.');

    require('./api/userroutes.js')(app);
    console.log('User routes registered.');

    require('./api/locationroutes.js')(app);
    console.log('Location routes registered.');

}