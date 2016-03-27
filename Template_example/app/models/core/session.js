/*
 * app/models/core/user.js
 *
 * Defines model Session
 *
 * http://jsbeautifier.org/
 *
 */

'use strict';

/*
* More details here http://mongoosejs.com/docs/guide.html
*/

/**
* Modeling Session with Mongoose
*/
 
var mongoose = require('mongoose'),
	Schema = mongoose.Schema,
	ObjectId = Schema.ObjectId;
 
/**
 * model : Session
 */
module.exports = mongoose.model('Session', new Schema({
	id: ObjectId,																						/* Id */
	administrator: { type : Number, min: 0, max: 1, required: true },									/* Session administrator */
	authorized: { type : Number, min: 0, max: 1, required: true },										/* Authorized */
	anonymous: { type : Number, min: 0, max: 1, required: true },										/* Anonymous */
	userid: { type : String, required: false },															/* User having session */
	email: { type : String, required: false },															/* User email */
	/**
	 * Model extended properties
	 */
	hidden: { type: Boolean, default: false },															/* hidden (can be active as well) */
	purged: { type: Boolean, default: false },															/* purged (active record cannot be pusged) */
	active: { type: Boolean, default: true }															/* active (can be hidden as well) */
}));

console.log("Created Session model");



