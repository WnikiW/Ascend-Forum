namespace Ascend_Forum.ViewModels
{
    public class PostListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CreatorAscendName { get; set; }
        public string DateCreated { get; set; }
        public int CommentsCount { get; set; } = 0;
    }
}
