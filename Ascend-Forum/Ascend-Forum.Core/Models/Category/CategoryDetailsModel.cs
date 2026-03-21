namespace Ascend_Forum.Core.Models.Category
{
    public class CategoryDetailsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PostListModel[] Posts { get; set; }
    }
}
