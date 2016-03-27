/**
 * Defines all models
 */
var mongoose = require('mongoose');

/**
* Modeling data with Mongoose
*/
 
var mongoose = require('mongoose'),
	Schema = mongoose.Schema,
	ObjectId = Schema.ObjectId;
 
mongoose.connect('mongodb://localhost/test');
console.log('Database connected.');

/**
 * model : Company
 */
module.exports = mongoose.model('Company', new Schema({
	id: ObjectId,
	displayname: String,
	accountno: String,
	name: String
}));
console.log('Company exported.');


