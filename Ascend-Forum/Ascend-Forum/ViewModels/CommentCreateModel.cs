namespace Ascend_Forum.ViewModels
{
    public class CommentCreateModel
    {
        public int PostId { get; set; }

        public int ParentId { get; set; }

        public string Content { get; set; }
    }
}
