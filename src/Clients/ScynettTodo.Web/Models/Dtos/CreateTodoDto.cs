namespace ScynettTodo.Web.Models.Dtos
{
    public class CreateTodoDto
    {
        public CreateTodoDto(string title, bool completed, string description) =>
            (Title, Completed, Description) = (title, completed, description);

        public string Title { get; }

        public bool Completed { get; }

        public string Description { get; }
    }
}