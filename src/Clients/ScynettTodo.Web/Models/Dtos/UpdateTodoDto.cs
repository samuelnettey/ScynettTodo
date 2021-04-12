namespace ScynettTodo.Web.Models.Dtos
{
    public class UpdateTodoDto
    {
        public UpdateTodoDto(int id, string title, string description) =>
            (Id, Title, Description) = (id, title, description);

        public int Id { get;  }
        public string Title { get; }
        
        public string Description { get; }
    }
}