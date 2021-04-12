using System;
using System.Collections.Generic;
using ScynettTodo.Web.Models;

namespace ScynettTodo.Web.Store.State
{
    public class TodosState : RootState
    {
        public TodosState(bool isLoading, string? currentErrorMessage, IEnumerable<TodoDto>? currentTodos, TodoDto? currentTodo) 
            : base(isLoading, currentErrorMessage)
        {
            CurrentTodos = currentTodos;
            CurrentTodo = currentTodo;
        }

        public IEnumerable<TodoDto>? CurrentTodos { get; }

        public TodoDto? CurrentTodo { get; }
    }
}