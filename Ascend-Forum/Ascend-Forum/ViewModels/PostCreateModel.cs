using System.ComponentModel.DataAnnotations;

namespace Ascend_Forum.ViewModels
{
    public class PostCreateModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Selected category")]
        public int SelectedCategoryId { get; set; }

        public CategoryViewModel[]? Categories { get; set; }
    }
}
