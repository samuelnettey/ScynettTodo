using ScynettTodo.Web.Models;

namespace ScynettTodo.Web.Store.Features.Todos.Actions.CreateTodo
{
    public class CreateTodoSuccessAction
    {
        public CreateTodoSuccessAction(TodoDto todo) => 
            Todo = todo;

        public TodoDto Todo { get; }
    }
}