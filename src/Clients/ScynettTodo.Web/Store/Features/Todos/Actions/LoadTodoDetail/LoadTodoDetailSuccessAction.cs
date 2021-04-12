using ScynettTodo.Web.Models;

namespace ScynettTodo.Web.Store.Features.Actions.LoadTodoDetail
{
    public class LoadTodoDetailSuccessAction
    {
        public LoadTodoDetailSuccessAction(TodoDto todo) => 
            Todo = todo;

        public TodoDto Todo { get; }
    }
}