using Fluxor;
using ScynettTodo.Web.Store.State;

namespace ScynettTodo.Web.Store.Features.Todos
{
    public class TodosFeature : Feature<TodosState>
    {
        public override string GetName() => "Todos";

        protected override TodosState GetInitialState() =>
            new TodosState(false, null, null, null);
    }
}