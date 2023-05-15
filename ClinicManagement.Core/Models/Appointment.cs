namespace ClinicManagement.Core.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int? RoomId { get; set; }

        public Appointment(Guid doctorId , int patientId ,DateTime start,DateTime end)
        {
            Id = Guid.NewGuid();
            DoctorId = doctorId;
            PatientId = patientId;
            Start = start;
            End = end;
        }
    }
}
