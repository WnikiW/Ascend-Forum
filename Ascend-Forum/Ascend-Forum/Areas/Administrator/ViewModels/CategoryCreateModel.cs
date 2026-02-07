using System.ComponentModel.DataAnnotations;

namespace Ascend_Forum.Areas.Administrator.ViewModels
{
    public class CategoryCreateModel
    {
        [Required(ErrorMessage = "The '{0}' field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The '{0}' field is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The '{0}' field is required.")]
        public string ImageUrl { get; set; }
    }
}
