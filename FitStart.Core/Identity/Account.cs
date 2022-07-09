using FitStart.Core.Enums;
using System;

namespace FitStart.Core.Identity
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public Role Role { get; set; }
    }
}
