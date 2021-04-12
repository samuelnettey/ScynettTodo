using System;
using System.Threading.Tasks;
using Fluxor;
using Microsoft.Extensions.Logging;
using ScynettTodo.Web.Models;
using ScynettTodo.Web.Models.Dtos;
using ScynettTodo.Web.Services;
using ScynettTodo.Web.Store.Features.Todos.Actions.LoadTodoDetail;

namespace ScynettTodo.Web.Store.Features.Todos.Effects
{
    public class LoadTodoDetailEffect : Effect<LoadTodoDetailAction>
    {
        private readonly ILogger<LoadTodoDetailEffect> _logger;
        private readonly DataService _apiService;

        public LoadTodoDetailEffect(ILogger<LoadTodoDetailEffect> logger, DataService httpClient) =>
            (_logger, _apiService) = (logger, httpClient);

        public override async Task HandleAsync(LoadTodoDetailAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation($"Loading todo {action.Id}...");
                var todoResponse = await _apiService.GetAsync<TodoDto>($"/ToDoItems/{action.Id}");

                _logger.LogInformation($"Todo {action.Id} loaded successfully!");
                dispatcher.Dispatch(new LoadTodoDetailSuccessAction(todoResponse));
            }
            catch (Exception e)
            {
                _logger.LogError($"Error loading todo {action.Id}, reason: {e.Message}");
                dispatcher.Dispatch(new LoadTodoDetailFailureAction(e.Message));
            }

        }    
    }
}