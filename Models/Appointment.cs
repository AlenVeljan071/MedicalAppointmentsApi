namespace MedicalAppointmentsApi.Models
{
    public class Appointment : DataTrail
    {
        [Key]
        [Required]
        [StringLength(36)]
        public string AppointmentId { get; set; }
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
