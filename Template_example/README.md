# Node Todo App

A Node app built with MongoDB and Angular. For demonstration purposes and a tutorial.

Node provides the RESTful API. Angular provides the frontend and accesses the API. MongoDB stores like a hoarder.

## Requirements

- [Node and npm](http://nodejs.org)

## Installation

1. Clone the repository: `git clone git@github.com:scotch-io/node-todo`
2. Install the application: `npm install`
3. Start the server: `node server.js`
4. View in browser at `http://localhost:8080`

## Tutorial Series

This repo corresponds to the Node Todo Tutorial Series on [scotch.io](http://scotch.io)

Each branch represents a certain tutorial.
- tut1-starter: [Creating a Single Page Todo App with Node and Angular](http://scotch.io/tutorials/javascript/creating-a-single-page-todo-app-with-node-and-angular)
- tut2-services: Coming Soon
- tut3-auth: Coming Soon
- tut4-sockets: Coming Soon
- tut5-redis: Coming Soon
- tut6-organization: Coming Soon

Happy Todo-ing!

![Todo-aholic](http://i.imgur.com/ikyqgrn.png)


[Folder structure]

	- app    						<!-- holds application specific files such as models -->
	----- routes.js 				<!-- all routes of our app -->

	- config   						<!-- holds application configuration files -->
	----- db.js						<!-- database settings of our app -->

	- node_modules					<!-- created by npm install -->

	- public 						<!-- holds all our files for our frontend angular application -->
	----- css	 					<!-- all style sheets -->
	----- js	 						<!-- all javascripts -->
	---------- controllers		<!-- angular controllers -->
	---------- services			<!-- angular services -->
	---------- app.js				<!-- angular application -->
	---------- approutes.js		<!-- angular routes -->

	- views	 						<!-- angular views -->
	----- home.html
	----- nerd.html
	----- geek.html

	----- README.MD 				<!-- readme -->

	----- models 					<!-- all models for our app -->

	- index.html	 				<!-- npm configuration to install dependencies/modules -->

	- .bowerrc 						<!-- tells brower where to put files (public/libs) -->
	- bower.json 					<!-- tells bower which files we need -->

	- package.json 				<!-- tells npm which packages we need -->

	- server.js 					<!-- setup our node application -->




