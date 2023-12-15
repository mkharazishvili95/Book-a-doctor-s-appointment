namespace DocVisitPro.Models
{
    public class Appointment
    {
        public int Id {  get; set; }
        public string Firstname {  get; set; }
        public string Lastname { get; set; }
        public string Doctor { get; set; }
        public DateTime AppointmentDateTime {  get; set; }
    }
}
