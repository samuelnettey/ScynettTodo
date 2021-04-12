using System.Threading.Tasks;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using ScynettTodo.Web.Store.Features.Todos.Actions.DeleteTodo;

namespace ScynettTodo.Web.Store.Features.Todos.Effects.DeleteTodo
{
    public class DeleteTodoSuccessEffect : Effect<DeleteTodoSuccessAction>
    {
        private readonly ILogger<DeleteTodoSuccessEffect> _logger;
        private readonly NavigationManager _navigation;

        public DeleteTodoSuccessEffect(ILogger<DeleteTodoSuccessEffect> logger, NavigationManager navigation) =>
            (_logger, _navigation) = (logger, navigation);

        public override Task HandleAsync(DeleteTodoSuccessAction action, IDispatcher dispatcher)
        {
            _logger.LogInformation("Deleted todo successfully, navigating back to todo listing...");
            _navigation.NavigateTo("todos");

            return Task.CompletedTask;
        }
    }
}