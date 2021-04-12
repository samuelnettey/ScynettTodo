using ScynettTodo.Web.Models;
using ScynettTodo.Web.Models.Dtos;

namespace ScynettTodo.Web.Store.Features.Todos.Actions.LoadTodoDetail
{
    public class LoadTodoDetailSuccessAction
    {
        public LoadTodoDetailSuccessAction(TodoDto todo) => 
            Todo = todo;

        public TodoDto Todo { get; }
    }
}