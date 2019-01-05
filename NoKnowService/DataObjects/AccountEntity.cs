using Microsoft.Azure.Mobile.Server;

namespace NoKnowService.DataObjects
{
    public class AccountEntity : EntityData
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}