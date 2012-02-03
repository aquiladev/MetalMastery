using System;

namespace MetalMastery.Core.Domain
{
    public class User
    {
        public Guid Id { get; protected set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Guid RoleId { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
        }
    }
}
