using Microsoft.AspNetCore.SignalR;
using Ascend_Forum.Core.Contracts;
using Ascend_Forum.Infrastructure.Data;

namespace Ascend_Forum.Hubs
{
    public class SupportHub : Hub
    {
        private readonly ISupportService _supportService;

        public SupportHub(ISupportService supportService)
        {
            _supportService = supportService;
        }

        public async Task RequestSupport()
        {
            var username = Context.User?.Identity?.Name ?? "Guest";
            var adminConnectionId = _supportService.GetAvailableAdmin();

            if (adminConnectionId != null)
            {
                _supportService.PairUserWithAdmin(Context.ConnectionId, adminConnectionId);

                await Clients.Client(Context.ConnectionId).SendAsync("ChatStarted", "Admin");
                await Clients.Client(adminConnectionId).SendAsync("ChatStarted", username);
            }
            else
            {
                _supportService.AddUserToQueue(Context.ConnectionId, username);

                await Clients.Caller.SendAsync("WaitingInQueue");
            }
        }

        public async Task AdminJoin()
        {
            if (Context.User?.IsInRole(RoleType.Administrator) == true)
            {
                var user = _supportService.TryGetNextUser();

                if (user != null)
                {
                    _supportService.PairUserWithAdmin(user.ConnectionId, Context.ConnectionId);

                    await Clients.Client(user.ConnectionId).SendAsync("ChatStarted", "Admin");
                    await Clients.Client(Context.ConnectionId).SendAsync("ChatStarted", user.Username);
                }
                else
                {
                    _supportService.AddAdmin(Context.ConnectionId);

                    await Clients.Caller.SendAsync("NoUsersInQueue");
                }
            }
        }

        public async Task SendMessage(string message)
        {
            var partnerId = _supportService.GetPair(Context.ConnectionId);

            if (partnerId != null)
            {
                var sender = Context.User?.Identity?.Name ?? "User";

                await Clients.Client(partnerId).SendAsync("ReceiveMessage", sender, message);
                await Clients.Caller.SendAsync("ReceiveMessage", sender, message);
            }
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            _supportService.RemoveAdmin(Context.ConnectionId);
            _supportService.RemoveUserFromQueue(Context.ConnectionId);
            
            var partnerId = _supportService.GetPair(Context.ConnectionId);

            if (partnerId != null)
            {
                await Clients.Client(partnerId).SendAsync("PartnerDisconnected");

                _supportService.EndChat(Context.ConnectionId);
            }

            await base.OnDisconnectedAsync(exception);
        }
    }
}
