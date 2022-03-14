namespace MedicalAppointmentsApi.Models
{
    public class Doctor : DataTrail
    {
        [Key]
        [Required]
        [StringLength(36)]
        public string DoctorId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(200)]
        public string Specialist { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
