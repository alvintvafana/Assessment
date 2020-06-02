using System;

namespace IdentityServerAspNetIdentity.Commands
{
    public class RegisterCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid AccountId { get; set; }
    }

}
