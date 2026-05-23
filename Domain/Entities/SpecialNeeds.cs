using System;

using Domain.Enums;

namespace Domain.Entities
{
    public class SpecialNeed : EntityBase
    {
        public SpecialNeedType Type { get; private set; }
        public string Description { get; private set; }

        protected SpecialNeed() { }

        public SpecialNeed(SpecialNeedType type, string description)
        {
            Update(type, description);
        }

        public void Update(SpecialNeedType type, string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description can't be empty.");

            Type = type;
            Description = description.Trim();
        }
    }
}