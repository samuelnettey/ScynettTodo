using ScynettTodo.Web.Store.Features.Shared.Actions;

namespace ScynettTodo.Web.Store.Features.Actions.LoadTodos
{
    public class LoadTodosFailureAction : FailureAction
    {
        public LoadTodosFailureAction(string errorMessage) 
            : base(errorMessage)
        {
        }
    }
}