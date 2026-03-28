using Ascend_Forum.Core.Models.Post;

namespace Ascend_Forum.Core.Contracts
{
    public interface IPostService
    {
        int CreatePost(string title, string content, int categoryId, string creatorId);
        PostDetailsServiceModel GetPostDetails(int postId, string? userId);
    }
}
