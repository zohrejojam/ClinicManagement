namespace ClinicManagement.Core.Models.Doctors
{
    public class Surgery : Doctor
    {
        public Surgery(Guid id, string firstName, string lastName) : base(id, firstName, lastName)
        {
        }
        public Doctor Doctor { get; set; }
    }
}
