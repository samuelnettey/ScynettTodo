namespace ScynettTodo.Web.Models
{
    public class CreateOrUpdateTodoDto
    {
        public CreateOrUpdateTodoDto(string title, bool completed, string description) =>
            (Title, Completed, Description) = (title, completed, description);

        public string Title { get; }

        public bool Completed { get; }

        public string Description { get; }
    }
}