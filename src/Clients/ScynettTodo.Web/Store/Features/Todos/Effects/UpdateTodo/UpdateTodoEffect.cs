using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Fluxor;
using Microsoft.Extensions.Logging;
using ScynettTodo.Web.Models.Dtos;
using ScynettTodo.Web.Services;
using ScynettTodo.Web.Store.Features.Todos.Actions.UpdateTodo;

namespace ScynettTodo.Web.Store.Features.Todos.Effects.UpdateTodo
{
    public class UpdateTodoEffect : Effect<UpdateTodoAction>
    {
        private readonly ILogger<UpdateTodoEffect> _logger;
        private readonly DataService _apiService;

        public UpdateTodoEffect(ILogger<UpdateTodoEffect> logger, DataService httpClient) =>
            (_logger, _apiService) = (logger, httpClient);

        public override async Task HandleAsync(UpdateTodoAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation($"Updating todo {action.Id}...");
                var updateResponse = await _apiService.PutAsync($"/ToDoItems", action.Todo);

                if (!updateResponse.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error updating todo: {updateResponse.ReasonPhrase}");
                }

                _logger.LogInformation("Todo updated successfully!");
                var updatedTodo = await updateResponse.Content.ReadFromJsonAsync<TodoDto>();
                dispatcher.Dispatch(new UpdateTodoSuccessAction(updatedTodo));
            }
            catch (Exception e)
            {
                _logger.LogError($"Could not update todo, reason: {e.Message}");
                dispatcher.Dispatch(new UpdateTodoFailureAction(e.Message));
            }
        }
    }
}