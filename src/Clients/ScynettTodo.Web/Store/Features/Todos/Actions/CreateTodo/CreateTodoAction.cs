using ScynettTodo.Web.Models;

namespace ScynettTodo.Web.Store.Features.Todos.Actions.CreateTodo
{
    public class CreateTodoAction
    {
        public CreateTodoAction(CreateOrUpdateTodoDto todo) =>
            Todo = todo;

        public CreateOrUpdateTodoDto Todo { get; }
    }
}