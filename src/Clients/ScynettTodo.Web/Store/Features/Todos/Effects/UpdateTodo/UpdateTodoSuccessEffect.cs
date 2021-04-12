using System.Threading.Tasks;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using ScynettTodo.Web.Store.Features.Todos.Actions.UpdateTodo;

namespace ScynettTodo.Web.Store.Features.Todos.Effects.UpdateTodo
{
    public class UpdateTodoSuccessEffect : Effect<UpdateTodoSuccessAction>
    {
        private readonly ILogger<UpdateTodoSuccessEffect> _logger;
        private readonly NavigationManager _navigation;

        public UpdateTodoSuccessEffect(ILogger<UpdateTodoSuccessEffect> logger, NavigationManager navigation) =>
            (_logger, _navigation) = (logger, navigation);

        public  override Task HandleAsync(UpdateTodoSuccessAction action, IDispatcher dispatcher)
        {
            _logger.LogInformation("Updated todo successfully, navigating back to todo listing...");
            _navigation.NavigateTo("todos");

            return Task.CompletedTask;
        }
    }
}