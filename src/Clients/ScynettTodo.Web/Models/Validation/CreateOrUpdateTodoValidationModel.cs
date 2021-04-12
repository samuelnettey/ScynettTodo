using System.ComponentModel.DataAnnotations;

namespace ScynettTodo.Web.Models.Validation
{
    public class CreateOrUpdateTodoValidationModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Your todo must have a title")]
        public string? Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Your todo must have a Description")]
        public string? Description { get; set; }
        
        [Required(ErrorMessage = "Status of this todo is required")]
        public bool Completed { get; set; }
        
    }
}