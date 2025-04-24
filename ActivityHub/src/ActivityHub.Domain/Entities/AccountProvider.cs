using ActivityHub.Domain.Enums;

namespace ActivityHub.Domain.Entities
{
    public class AccountProvider : Base
    {
        public AccountProviderEnum provider { get; set; }
        public string providerAccountId { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User User { get; set; } = default!;

    }
}
