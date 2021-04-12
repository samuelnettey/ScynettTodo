using Fluxor;
using Microsoft.Extensions.Logging;
using ScynettTodo.Web.Models;
using ScynettTodo.Web.Models.Dtos;
using ScynettTodo.Web.Store.Features.Actions.LoadTodoDetail;
using ScynettTodo.Web.Store.Features.Actions.LoadTodos;
using ScynettTodo.Web.Store.Features.Todos.Actions.CreateTodo;
using ScynettTodo.Web.Store.Features.Todos.Actions.UpdateTodo;

namespace ScynettTodo.Web.Services
{
    public class StateFacade
    {
        private readonly ILogger<StateFacade> _logger;
        private readonly IDispatcher _dispatcher;

        public StateFacade(ILogger<StateFacade> logger, IDispatcher dispatcher) =>
            (_logger, _dispatcher) = (logger, dispatcher);

        public void LoadTodos()
        {
            _logger.LogInformation("Issuing action to load todos...");
            _dispatcher.Dispatch(new LoadTodosAction());
        }
        
        public void CreateTodo(string title, bool completed, string description)
        {
            // Construct our validated todo
            var todoDto = new CreateTodoDto(title, completed, description);

            _logger.LogInformation($"Issuing action to create todo [{title}]");
            _dispatcher.Dispatch(new CreateTodoAction(todoDto));
        }
        
        public void UpdateTodo(int id, string title, string description)
        {
            // Construct our validated todo
            var todoDto = new UpdateTodoDto(id, title, description);

            _logger.LogInformation($"Issuing action to update todo {id}");
            _dispatcher.Dispatch(new UpdateTodoAction(id, todoDto));
        }
        
        
        public void LoadTodoById(int id)
        {
            _logger.LogInformation($"Issuing action to load todo {id}...");
            _dispatcher.Dispatch(new LoadTodoDetailAction(id));
        }
    }
}