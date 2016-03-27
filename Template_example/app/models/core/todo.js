/**
* Modeling data with Mongoose
*/
var mongoose = require('mongoose'),
	Schema = mongoose.Schema,
	ObjectId = Schema.ObjectId;
 
/**
 * model : Todo
 */
module.exports = mongoose.model('Todo', new Schema({
	id: ObjectId,
	description: String,
	displayname: String,
	done : Boolean,
	name: String
}));

console.log('Todo exported.');

