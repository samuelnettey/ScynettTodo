using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Fluxor;
using Microsoft.Extensions.Logging;
using ScynettTodo.Web.Models;
using ScynettTodo.Web.Store.Features.Actions.LoadTodos;

namespace ScynettTodo.Web.Store.Features.Effects
{
    public class LoadTodosEffect : Effect<LoadTodosAction>
    {
        private readonly ILogger<LoadTodosEffect> _logger;
        private readonly HttpClient _httpClient;

        public LoadTodosEffect(ILogger<LoadTodosEffect> logger, HttpClient httpClient) =>
            (_logger, _httpClient) = (logger, httpClient);

        public override async Task HandleAsync(LoadTodosAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation("Loading todos...");
                
                var todosResponse = await _httpClient.GetFromJsonAsync<IEnumerable<TodoDto>>("ToDoItems");

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