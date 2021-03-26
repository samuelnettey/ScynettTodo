using MediatR;
using ScynettTodo.Core.Entities;
using ScynettTodo.SharedKernel;

namespace ScynettTodo.Core.Events
{
    public class ToDoItemCompletedEvent : BaseDomainEvent, INotification
    {
        public ToDoItem CompletedItem { get; set; }

        public ToDoItemCompletedEvent(ToDoItem completedItem)
        {
            CompletedItem = completedItem;
        }
    }
}