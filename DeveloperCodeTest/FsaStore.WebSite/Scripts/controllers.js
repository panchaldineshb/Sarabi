﻿;

'use strict';

/* Controllers

    Defines:
        ListCtrl:

        TaskCtrl:

    Services Used:
        Lists:

        Tasks:

    Refer:
        https://docs.angularjs.org/tutorial/step_07
*/

debugger;

function ListCtrl($scope, $location, Lists) {
    $scope.lists = Lists.query();
    $scope.currentList = null;

    $scope.save = function () {
        $('#myModal').modal('hide');//THIS IS BAD!!!
        if ($scope.currentList.id === null) {
            Lists.add($scope.currentList, function(data) {
                $location.path('/list/' + data.Id);
            });
        } else {
            Lists.save($scope.currentList, function (data) {
                $location.path('/list/' + data.Id);
            });
        }
    };

    $scope.confirm = function() {
        $scope.currentList = this.list;
        $scope.currentList.preventDelete = this.list.Tasks.length > 0;
    };
    
    $scope.delete = function () {
        $('#confirm').modal('hide');
        var toDeleteId = $scope.currentList.Id;
        Lists.delete({ id: toDeleteId });
        var oldLists = $scope.lists;
        $scope.lists = [];
        angular.forEach(oldLists, function(list) {
            if (list.Id !== toDeleteId) {
                $scope.lists.push(list);
            }
        });
        
        $scope.currentList = null;
    };

    $scope.edit = function() {
        $scope.currentList = this.list;
        $scope.currentList.header = "Edit";
    };

    $scope.new = function() {
        $scope.currentList = new Object();
        $scope.currentList.header = "New List";
    };
}

function TaskCtrl($scope, $routeParams, Lists, Tasks) {
    $scope.list = Lists.get({ id: $routeParams.id });

    $scope.addTodo = function () {
        Tasks.add({ listId: $routeParams.id, Label: $scope.todoText }, function(data) {
            $scope.list.Tasks.push(data);
        });
        $scope.todoText = '';
    };

    $scope.remaining = function () {
        var count = 0;
        angular.forEach($scope.list.Tasks, function (todo) {
            count += todo.Complete ? 0 : 1;
        });
        return count;
    };

    $scope.markComplete = function () {
        Tasks.complete(this.todo);
    };

    $scope.archive = function () {
        $('#confirm').modal('hide');//THIS IS BAD!!!
        var oldTodos = $scope.list.Tasks;
        $scope.list.Tasks = [];
        angular.forEach(oldTodos, function (todo) {
            if (!todo.Complete) {
                $scope.list.Tasks.push(todo);
            } else {
                Tasks.delete({ id: todo.Id });
            }
        });
    };
}