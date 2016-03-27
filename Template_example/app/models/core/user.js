/*
 * app/models/core/user.js
 *
 * Defines application module {templateApp} and also contoller {signinController}
 *
 * http://jsbeautifier.org/
 *
 */

'use strict';

/*
* More details here http://mongoosejs.com/docs/guide.html
*/

/**
* Modeling User with Mongoose
*/
 
var mongoose = require('mongoose'),
	Schema = mongoose.Schema,
	ObjectId = Schema.ObjectId;
 
/**
 * model : User
 */
module.exports = mongoose.model('User', new Schema({
	id: ObjectId,																						/* Id */
	email: { type : String, validate: /\S+/, required: true, index : { unique : true } },				/* Email-address (must be unique) */
	displayname: { type : String, validate: /\S+/, required: true },									/* Display-name */
	firstname: { type : String, validate: /\S+/, required: true },										/* Firstname */
	lastname: { type : String, validate: /\S+/, required: true },										/* Lastname */
	password: { type : String, validate: /\S+/, required: true },										/* Password */
	dob: { type: Date, default: Date.now },																/* Date of birth */
	/**
	 * Model extended properties
	 */
	hidden: { type: Boolean, default: false },															/* hidden (can be active as well) */
	purged: { type: Boolean, default: false },															/* purged (active record cannot be pusged) */
	active: { type: Boolean, default: true }															/* active (can be hidden as well) */
}));

console.log("Created User model");



