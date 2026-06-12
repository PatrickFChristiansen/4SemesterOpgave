using Domain.Enums;

namespace Domain.Entities
{
    public class UserAccount : EntityBase
    {
        private readonly List<ExternalLogin> _externalLogins = new();
     
        private readonly List<DeviceLogin> _deviceLogins = new();

        public Guid PersonId { get; private set; }
        public string PasswordHash { get; private set; }
        public UserRole Role { get; private set; }
        public bool IsActive { get; private set; }

        public DateTime? LastStrongAuthenticationAt { get; private set; }
        public DateTime? StrongAuthenticationExpiresAt { get; private set; }

        public IReadOnlyCollection<ExternalLogin> ExternalLogins
            => _externalLogins.AsReadOnly();
        public IReadOnlyCollection<DeviceLogin> DeviceLogins
    => _deviceLogins.AsReadOnly();

        protected UserAccount() { }

        public UserAccount(
            Guid personId,
            string passwordHash,
            UserRole role)
        {
            if (personId == Guid.Empty)
                throw new ArgumentException("User id can't be empty.");

            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("Password hash can't be empty.");

            PersonId = personId;
            PasswordHash = passwordHash;
            Role = role;
            IsActive = true;
        }

        public void ChangePasswordHash(string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("Password hash can't be empty.");

            PasswordHash = passwordHash;
        }

        public void RegisterStrongAuthentication(DateTime expiresAt)
        {
            LastStrongAuthenticationAt = DateTime.UtcNow;
            StrongAuthenticationExpiresAt = expiresAt;
        }

        public bool RequiresStrongAuthentication()
        {
            return StrongAuthenticationExpiresAt is null ||
                   DateTime.UtcNow > StrongAuthenticationExpiresAt;
        }

        public void ChangeRole(UserRole role)
        {
            Role = role;
        }

        public void AddExternalLogin(ExternalLogin externalLogin)
        {
            if (externalLogin is null)
                throw new ArgumentNullException(nameof(externalLogin));

            if (_externalLogins.Any(x => x.Provider == externalLogin.Provider))
                throw new InvalidOperationException("External login provider already exists.");

            _externalLogins.Add(externalLogin);
        }
        public void AddDeviceLogin(DeviceLogin deviceLogin)
        {
            if (deviceLogin is null)
                throw new ArgumentNullException(nameof(deviceLogin));

            if (_deviceLogins.Any(x => x.DeviceId == deviceLogin.DeviceId))
                throw new InvalidOperationException("Device is already registered.");

            _deviceLogins.Add(deviceLogin);
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void Activate()
        {
            IsActive = true;
        }
    }
}