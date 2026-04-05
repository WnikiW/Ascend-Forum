namespace Ascend_Forum.Core.Contracts
{
    public record SupportUser(string ConnectionId, string Username);

    public interface ISupportService
    {
        void AddUserToQueue(string connectionId, string username);
        SupportUser? TryGetNextUser();
        void AddAdmin(string connectionId);
        void RemoveAdmin(string connectionId);
        string? GetAvailableAdmin();
        void RemoveUserFromQueue(string connectionId);
        void PairUserWithAdmin(string userConnectionId, string adminConnectionId);
        string? GetPair(string connectionId);
        void EndChat(string connectionId);
    }
}
