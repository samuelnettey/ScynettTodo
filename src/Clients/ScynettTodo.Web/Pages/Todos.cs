using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ScynettTodo.Web.Services;
using ScynettTodo.Web.Store.State;

namespace ScynettTodo.Web.Pages
{
    public partial class Todos
    {
        [Inject]
        public StateFacade Facade { get; set; }
        
        [Inject] 
        NavigationManager Navigation { get; set; }


        [Inject]
        public IState<TodosState> TodosState { get; set; }
        
        protected override void OnInitialized()
        {
            if (TodosState.Value.CurrentTodos is null)
            {
                Facade.LoadTodos();
            }
            base.OnInitialized();
        }
        public void NavigateToTodoDetail(int id)
        {
            Navigation.NavigateTo($"todos/{id}");
        }
    }
}