using ScynettTodo.Web.Store.Features.Shared.Actions;

namespace ScynettTodo.Web.Store.Features.Todos.Actions.DeleteTodo
{
    public class DeleteTodoFailureAction : FailureAction
    {
        public DeleteTodoFailureAction(string errorMessage) 
            : base(errorMessage)
        {
        }
    }
}