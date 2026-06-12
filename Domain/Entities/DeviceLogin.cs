namespace Domain.Entities
{
    public class DeviceLogin : EntityBase
    {
        public Guid UserAccountId { get; private set; }
        public string DeviceId { get; private set; }
        public string PinHash { get; private set; }
        public bool IsTrusted { get; private set; }
        public DateTime TrustedUntil { get; private set; }
        public DateTime? LastUsedAt { get; private set; }

        protected DeviceLogin() { }

        public DeviceLogin(
            Guid userAccountId,
            string deviceId,
            string pinHash,
            DateTime trustedUntil)
        {
            if (userAccountId == Guid.Empty)
                throw new ArgumentException("User account id can't be empty.");

            if (string.IsNullOrWhiteSpace(deviceId))
                throw new ArgumentException("Device id can't be empty.");

            if (string.IsNullOrWhiteSpace(pinHash))
                throw new ArgumentException("Pin hash can't be empty.");

            if (trustedUntil <= DateTime.UtcNow)
                throw new ArgumentException("Trusted until must be in the future.");

            UserAccountId = userAccountId;
            DeviceId = deviceId.Trim();
            PinHash = pinHash;
            TrustedUntil = trustedUntil;
            IsTrusted = true;
        }

        public bool IsExpired()
        {
            return DateTime.UtcNow > TrustedUntil;
        }

        public void RegisterUse()
        {
            LastUsedAt = DateTime.UtcNow;
        }

        public void RevokeTrust()
        {
            IsTrusted = false;
        }

        public void ExtendTrust(DateTime trustedUntil)
        {
            if (trustedUntil <= DateTime.UtcNow)
                throw new ArgumentException("Trusted until must be in the future.");

            TrustedUntil = trustedUntil;
            IsTrusted = true;
        }

        public void ChangePinHash(string pinHash)
        {
            if (string.IsNullOrWhiteSpace(pinHash))
                throw new ArgumentException("Pin hash can't be empty.");

            PinHash = pinHash;
        }
    }
}