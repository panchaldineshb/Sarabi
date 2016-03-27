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

/**
 * model : Location
 */
module.exports = mongoose.model('Location', new Schema({
	id: ObjectId,
	displayname: { type : String, validate: /\S+/, required: true },									/* Display-name */
	street: { type : String, validate: /\S+/, required: true },											/* Street */
	apt: { type : String, validate: /\S+/, required: true },											/* Apt # */
	city: { type : String, validate: /\S+/, required: true },											/* City */
	state: { type : String, validate: /\S+/, required: true },											/* State-code */
	zip: { type : String, validate: /\S+/, required: true },											/* Zip-code */
	/**
	 * Model extended properties
	 */
	hidden: { type: Boolean, default: false },															/* hidden (can be active as well) */
	purged: { type: Boolean, default: false },															/* purged (active record cannot be pusged) */
	active: { type: Boolean, default: true }															/* active (can be hidden as well) */
}));
console.log('Location exported.');



