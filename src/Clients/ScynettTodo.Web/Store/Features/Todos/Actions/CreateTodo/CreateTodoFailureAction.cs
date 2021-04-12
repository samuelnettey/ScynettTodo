using ScynettTodo.Web.Store.Features.Shared.Actions;

namespace ScynettTodo.Web.Store.Features.Todos.Actions.CreateTodo
{
    public class CreateTodoFailureAction : FailureAction
    {
        public CreateTodoFailureAction(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}