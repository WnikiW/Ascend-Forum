using System.Collections.Generic;

namespace Ascend_Forum.Core.Models.Post
{
    public class PostDetailsServiceModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreatorUsername { get; set; }
        public string CreatedOn { get; set; }
        public IEnumerable<CommentServiceModel> Comments { get; set; }
    }
}
