using Domain.Enums;

namespace Domain.Entities
{
    public class ExternalLogin : EntityBase
    {
        public Guid UserAccountId { get; private set; }
        public ExternalLoginProvider Provider { get; private set; }
        public string ProviderUserId { get; private set; }

        protected ExternalLogin() { }

        public ExternalLogin(
            Guid userAccountId,
            ExternalLoginProvider provider,
            string providerUserId)
        {
            if (userAccountId == Guid.Empty)
                throw new ArgumentException("User account id can't be empty.");

            if (string.IsNullOrWhiteSpace(providerUserId))
                throw new ArgumentException("Provider user id can't be empty.");

            UserAccountId = userAccountId;
            Provider = provider;
            ProviderUserId = providerUserId.Trim();
        }
    }
}