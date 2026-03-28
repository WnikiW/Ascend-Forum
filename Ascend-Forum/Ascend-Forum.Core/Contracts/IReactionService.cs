using Ascend_Forum.Infrastructure.Data.Enums;

namespace Ascend_Forum.Core.Contracts
{
    public interface IReactionService
    {
        void React(int commentId, string userId, ReactionType reactionType);
    }
}
