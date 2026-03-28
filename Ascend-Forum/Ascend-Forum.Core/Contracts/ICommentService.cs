namespace Ascend_Forum.Core.Contracts
{
    public interface ICommentService
    {
        void CreateComment(string content, int postId, string creatorId, int? parentId);
    }
}
