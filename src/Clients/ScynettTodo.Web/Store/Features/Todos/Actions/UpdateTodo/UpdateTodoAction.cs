using ScynettTodo.Web.Models;
using ScynettTodo.Web.Models.Dtos;

namespace ScynettTodo.Web.Store.Features.Todos.Actions.UpdateTodo
{
    public class UpdateTodoAction
    {
        public UpdateTodoAction(int id, UpdateTodoDto todo) => 
            (Id, Todo) = (id, todo);

        public int Id { get; }

        public UpdateTodoDto Todo { get; }
    }
}