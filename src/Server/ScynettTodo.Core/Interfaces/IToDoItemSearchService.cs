using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Result;
using ScynettTodo.Core.Entities;

namespace ScynettTodo.Core.Interfaces
{
    public interface IToDoItemSearchService
    {
        Task<Result<ToDoItem>> GetNextIncompleteItemAsync();
        Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(string searchString);
    }
}
