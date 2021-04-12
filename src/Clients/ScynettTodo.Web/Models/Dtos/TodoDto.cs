namespace ScynettTodo.Web.Models
{
    public class TodoDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public bool IsDone { get; set; }
        
        public string Description { get; set; }

        public int UserId { get; set; }
    }
}