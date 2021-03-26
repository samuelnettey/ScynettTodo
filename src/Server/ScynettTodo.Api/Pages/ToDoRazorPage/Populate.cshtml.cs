using Microsoft.AspNetCore.Mvc.RazorPages;
using ScynettTodo.Core;
using ScynettTodo.SharedKernel.Interfaces;

namespace ScynettTodo.Api.Pages.ToDoRazorPage
{
    public class PopulateModel : PageModel
    {
        private readonly IRepository _repository;

        public PopulateModel(IRepository repository)
        {
            _repository = repository;
        }

        public int RecordsAdded { get; set; }

        public void OnGet()
        {
            RecordsAdded = DatabasePopulator.PopulateDatabase(_repository);
        }
    }
}
