namespace ScynettTodo.Web.Store.Features.Actions.LoadTodoDetail
{
    public class LoadTodoDetailAction
    {
        public LoadTodoDetailAction(int id) => 
            Id = id;

        public int Id { get; set; }
    }
}