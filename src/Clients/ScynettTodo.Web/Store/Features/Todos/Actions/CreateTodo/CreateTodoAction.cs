using ScynettTodo.Web.Models;
using ScynettTodo.Web.Models.Dtos;

namespace ScynettTodo.Web.Store.Features.Todos.Actions.CreateTodo
{
    public class CreateTodoAction
    {
        public CreateTodoAction(CreateTodoDto todo) =>
            Todo = todo;

        public CreateTodoDto Todo { get; }
    }
}