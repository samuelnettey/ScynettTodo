using ScynettTodo.Web.Store.Features.Shared.Actions;

namespace ScynettTodo.Web.Store.Features.Todos.Actions.UpdateTodo
{
    public class UpdateTodoFailureAction : FailureAction
    {
        public UpdateTodoFailureAction(string errorMessage) 
            : base(errorMessage)
        {
        }
    }
}