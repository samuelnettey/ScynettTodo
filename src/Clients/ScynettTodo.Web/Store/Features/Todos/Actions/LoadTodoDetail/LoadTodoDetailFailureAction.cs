using ScynettTodo.Web.Store.Features.Shared.Actions;

namespace ScynettTodo.Web.Store.Features.Todos.Actions.LoadTodoDetail
{
    public class LoadTodoDetailFailureAction : FailureAction
    {
        public LoadTodoDetailFailureAction(string errorMessage) 
            : base(errorMessage)
        {
        }
    }
}