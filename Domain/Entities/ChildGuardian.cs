using Domain.Enums;
using System;

namespace Domain.Entities
{
    public class ChildGuardian : EntityBase
    {
        public Guid ChildId { get; private set; }

        public Guid GuardianId { get; private set; }

        public GuardianRelationType RelationType { get; private set; }

        public bool IsPrimaryContact { get; private set; }

        public bool CanReceiveMessages { get; private set; }

        public bool CanReportAbsence { get; private set; }

        protected ChildGuardian()
        {
        }

        public ChildGuardian(
            Guid childId,
            Guid guardianId,
            GuardianRelationType relationType,
            bool isPrimaryContact,
            bool canReceiveMessages,
            bool canReportAbsence)
        {
            ChildId = childId;
            GuardianId = guardianId;
            RelationType = relationType;
            IsPrimaryContact = isPrimaryContact;
            CanReceiveMessages = canReceiveMessages;
            CanReportAbsence = canReportAbsence;
        }

        public void SetPrimaryContact(bool isPrimaryContact)
        {
            IsPrimaryContact = isPrimaryContact;
        }

        public void UpdatePermissions(
            bool canReceiveMessages,
            bool canReportAbsence)
        {
            CanReceiveMessages = canReceiveMessages;
            CanReportAbsence = canReportAbsence;
        }
    }
}
