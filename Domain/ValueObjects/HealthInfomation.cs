using System;



namespace Domain.ValueObjects
{
    public class HealthInformation
    {
        public string? Allergies { get; private set; }
        public string? Medication { get; private set; }
        public string? Notes { get; private set; }

        protected HealthInformation() { }

        public HealthInformation(
            string? allergies,
            string? medication,
            string? notes)
        {
            Allergies = allergies?.Trim();
            Medication = medication?.Trim();
            Notes = notes?.Trim();
        }
    }
}
