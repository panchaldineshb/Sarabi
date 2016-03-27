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
 * model : Product
 */
module.exports = mongoose.model('Product', new Schema({
	id: ObjectId,
	description: String,
	displayname: String,
	name: String,
	price: Number
}));
console.log('Product exported.');
