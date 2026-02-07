namespace Ascend_Forum.ViewModels
{
    public class CategoryDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PostListViewModel[] Posts { get; set; }
    }
}
