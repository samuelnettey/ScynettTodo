using System.Collections.Generic;
using ScynettTodo.Web.Models.Dtos;

namespace ScynettTodo.Web.Store.Features.Todos.Actions.LoadTodos
{
    public class LoadTodosSuccessAction
    {
        public LoadTodosSuccessAction(IEnumerable<TodoDto> todos) =>
            Todos = todos;

        public IEnumerable<TodoDto> Todos { get; }
    }
}