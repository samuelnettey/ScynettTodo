using Microsoft.AspNetCore.Components;
using ScynettTodo.Web.Models.Validation;
using ScynettTodo.Web.Services;

namespace ScynettTodo.Web.Components
{
    public partial class CreateTodoForm
    {
        [Inject]
        public StateFacade Facade { get; set; }
        
        private CreateOrUpdateTodoValidationModel validationModel = new CreateOrUpdateTodoValidationModel();

        protected override void OnInitialized()
        {

            base.OnInitialized();
        }

        private void HandleValidSubmit()
        {
            // We use the bang operator (!) to tell the compiler we'll know this string field will not be null
            Facade.CreateTodo(validationModel.Title!, validationModel.Completed, validationModel.Description);
        }
        
    }
}