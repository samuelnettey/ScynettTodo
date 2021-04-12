using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fluxor;
using Microsoft.Extensions.Logging;
using ScynettTodo.Web.Models;
using ScynettTodo.Web.Models.Dtos;
using ScynettTodo.Web.Services;
using ScynettTodo.Web.Store.Features.Todos.Actions.LoadTodos;

namespace ScynettTodo.Web.Store.Features.Todos.Effects
{
    public class LoadTodosEffect : Effect<LoadTodosAction>
    {
        private readonly ILogger<LoadTodosEffect> _logger;
        private readonly DataService _apiService;
        
        public LoadTodosEffect(ILogger<LoadTodosEffect> logger, DataService httpClient) =>
            (_logger, _apiService) = (logger, httpClient);
        
        public override async Task HandleAsync(LoadTodosAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation("Loading todos...");
                
                var todosResponse = await _apiService.GetAsync<IEnumerable<TodoDto>>("ToDoItems");

                _logger.LogInformation("Todos loaded successfully!");
                dispatcher.Dispatch(new LoadTodosSuccessAction(todosResponse));
            }
            catch (Exception e)
            {
                _logger.LogError($"Error loading todos, reason: {e.Message}");
                dispatcher.Dispatch(new LoadTodosFailureAction(e.Message));
            }

        }
    }
}