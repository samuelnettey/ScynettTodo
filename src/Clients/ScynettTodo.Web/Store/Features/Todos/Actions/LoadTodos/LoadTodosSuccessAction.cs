using System.Collections.Generic;
using ScynettTodo.Web.Models;

namespace ScynettTodo.Web.Store.Features.Actions.LoadTodos
{
    public class LoadTodosSuccessAction
    {
        public LoadTodosSuccessAction(IEnumerable<TodoDto> todos) =>
            Todos = todos;

        public IEnumerable<TodoDto> Todos { get; }
    }
}