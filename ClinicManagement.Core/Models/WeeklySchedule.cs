namespace ClinicManagement.Core.Models
{
    public class WeeklySchedule
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid DoctorId { get; set; }

        public WeeklySchedule()
        {

        }
        public WeeklySchedule(int id ,DateTime startTime, DateTime endTime,Guid doctorId)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            DoctorId = doctorId;
        }

    }
}
