using Ascend_Forum.Core.Contracts;
using System.Collections.Concurrent;

namespace Ascend_Forum.Core.Implementations
{
    public class SupportService : ISupportService
    {
        private readonly ConcurrentQueue<SupportUser> _userQueue;
        private readonly ConcurrentDictionary<string, string> _usersInQueue; 
        private readonly ConcurrentDictionary<string, byte> _availableAdmins;
        private readonly ConcurrentDictionary<string, string> _pairs;

        public SupportService()
        {
            _userQueue = new ConcurrentQueue<SupportUser>();
            _usersInQueue = new ConcurrentDictionary<string, string>();
            _availableAdmins = new ConcurrentDictionary<string, byte>();
            _pairs = new ConcurrentDictionary<string, string>();
        }

        public void AddUserToQueue(string connectionId, string username)
        {
            if (_usersInQueue.TryAdd(connectionId, username))
                _userQueue.Enqueue(new SupportUser(connectionId, username));
        }

        public SupportUser? TryGetNextUser()
        {
            while (_userQueue.TryDequeue(out var user))
            {
                if (_usersInQueue.TryRemove(user.ConnectionId, out _))
                    return user;
            }

            return null;
        }

        public void AddAdmin(string connectionId)
        => _availableAdmins.TryAdd(connectionId, 0);
        

        public void RemoveAdmin(string connectionId)
        => _availableAdmins.TryRemove(connectionId, out _);
        

        public string? GetAvailableAdmin()
        {
            foreach (var admin in _availableAdmins.Keys)
            {
                if (_availableAdmins.TryRemove(admin, out _))
                    return admin;
            }

            return null;
        }

        public void RemoveUserFromQueue(string connectionId)
        => _usersInQueue.TryRemove(connectionId, out _);
        

        public void PairUserWithAdmin(string userConnectionId, string adminConnectionId)
        {
            _pairs[userConnectionId] = adminConnectionId;
            _pairs[adminConnectionId] = userConnectionId;
        }

        public string? GetPair(string connectionId)
        => _pairs.TryGetValue(connectionId, out var partnerId) ? partnerId : null;
        

        public void EndChat(string connectionId)
        {
            if (_pairs.TryRemove(connectionId, out var partnerId))
                _pairs.TryRemove(partnerId, out _);
        }
    }
}
