namespace ClinicManagement.Core.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public HashSet<Appointment> Appointments { get; set; }

        public Patient(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Appointments = new HashSet<Appointment>();
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
