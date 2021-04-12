using System.Collections.Generic;
using System.Linq;
using Fluxor;
using ScynettTodo.Web.Models;
using ScynettTodo.Web.Store.Features.Todos.Actions.CreateTodo;
using ScynettTodo.Web.Store.State;

namespace ScynettTodo.Web.Store.Features.Todos.Reducers
{
    public static class CreateTodoActionsReducer
    {
        [ReducerMethod]
        public static TodosState ReduceCreateTodoAction(TodosState state, CreateTodoAction _) =>
            new TodosState(true, null, state.CurrentTodos, state.CurrentTodo);

        [ReducerMethod]
        public static TodosState ReduceCreateTodoSuccessAction(TodosState state, CreateTodoSuccessAction action)
        {
            // Grab a reference to the current todo list, or initialize one if we do not currently have any loaded
            var currentTodos = state.CurrentTodos is null ?
                new List<TodoDto>() :
                state.CurrentTodos.ToList();

            // Add the newly created todo to our list and sort by ID
            currentTodos.Add(action.Todo);
            currentTodos = currentTodos
                .OrderBy(t => t.Id)
                .ToList();

            return new TodosState(false, null, currentTodos, state.CurrentTodo);
        }

        [ReducerMethod]
        public static TodosState ReduceCreateTodoFailureAction(TodosState state, CreateTodoFailureAction action) =>
            new TodosState(false, action.ErrorMessage, state.CurrentTodos, state.CurrentTodo);
    }
}