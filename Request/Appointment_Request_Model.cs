namespace MedicalAppointmentsApi.Request
{
    public class Appointment_Request_Model : DataTrail
    {
        [Required]
        public DateTime Date_Time_App { get; set; }
        [Required]
        public string Note { get; set; }
        [Required]
        public string DoctorId { get; set; }
        [Required]
        public string PatientId { get; set; }
    }
}
