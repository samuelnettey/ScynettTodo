using System;
using Fluxor;
using Microsoft.AspNetCore.Components;
using ScynettTodo.Web.Models.Validation;
using ScynettTodo.Web.Services;
using ScynettTodo.Web.Store.State;

namespace ScynettTodo.Web.Pages
{
    public partial class TodoDetail 
    {
        
        [Inject]
        public StateFacade Facade { get; set; }
        
        [Inject] 
        NavigationManager Navigation { get; set; }


        [Inject]
        public IState<TodosState> TodosState { get; set; }
        
        public CreateOrUpdateTodoValidationModel validationModel = new CreateOrUpdateTodoValidationModel();

        [Parameter]
        public string? TodoId { get; set; }
        
        protected override void OnInitialized()
        {
            // Load the todo detail on initial page navigation
            if (int.TryParse(TodoId, out var parsedId))
            {
                Facade.LoadTodoById(parsedId);
            }

            // Register a state change to assign the validation fields
            TodosState.StateChanged += (sender, state) =>
            {
                if (state.CurrentTodo is null)
                {
                    return;
                }

                validationModel.Title = state.CurrentTodo.Title;
                validationModel.Completed = state.CurrentTodo.IsDone;
                validationModel.Description = state.CurrentTodo.Description;

                StateHasChanged();
            };

            base.OnInitialized();
        }
        

        private void HandleValidSubmit()
        {
            // We use the bang operator (!) to tell the compiler we'll know this string field will not be null
            Facade.UpdateTodo(TodosState.Value.CurrentTodo!.Id, validationModel.Title!, validationModel.Description);
        }
        
    }
}