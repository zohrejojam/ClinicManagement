namespace ClinicManagement.Core.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HashSet<Appointment> Appointments { get; set; }

        public Room(int id, string name)
        {
            Id = id;
            Name = name;
            Appointments = new HashSet<Appointment>();
        }
    }
}
