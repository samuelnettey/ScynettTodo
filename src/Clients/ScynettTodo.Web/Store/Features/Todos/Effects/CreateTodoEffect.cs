using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Fluxor;
using Microsoft.Extensions.Logging;
using ScynettTodo.Web.Models;
using ScynettTodo.Web.Models.Dtos;
using ScynettTodo.Web.Services;
using ScynettTodo.Web.Store.Features.Todos.Actions.CreateTodo;

namespace ScynettTodo.Web.Store.Features.Todos.Effects
{
    public class CreateTodoEffect : Effect<CreateTodoAction>
    {
        private readonly ILogger<CreateTodoEffect> _logger;
        private readonly DataService _apiService;

        public CreateTodoEffect(ILogger<CreateTodoEffect> logger, DataService httpClient) =>
            (_logger, _apiService) = (logger, httpClient);

        public override async Task HandleAsync(CreateTodoAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation($"Creating todo {action.Todo}...");
                var createResponse = await _apiService.PostAsync("ToDoItems", action.Todo);

                if (!createResponse.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error creating todo: {createResponse.ReasonPhrase}");
                }

                _logger.LogInformation("Todo created successfully!");
                var createdTodo = await createResponse.Content.ReadFromJsonAsync<TodoDto>();
                dispatcher.Dispatch(new CreateTodoSuccessAction(createdTodo));
            }
            catch (Exception e)
            {
                _logger.LogError($"Could not create todo, reason: {e.Message}");
                dispatcher.Dispatch(new CreateTodoFailureAction(e.Message));
            }
        }
    }
}