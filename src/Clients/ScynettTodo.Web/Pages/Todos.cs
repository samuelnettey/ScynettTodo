using Fluxor;
using Microsoft.AspNetCore.Components;
using ScynettTodo.Web.Services;
using ScynettTodo.Web.Store.State;

namespace ScynettTodo.Web.Pages
{
    public partial class Todos
    {
        [Inject]
        public StateFacade Facade { get; set; }

        [Inject]
        public IState<TodosState> TodosState { get; set; }
        
        protected override void OnInitialized()
        {
            // Issue the load todos command, if no current todos have been loaded
            if (TodosState.Value.CurrentTodos is null)
            {
                Facade.LoadTodos();
            }

            base.OnInitialized();
        }
    }
}