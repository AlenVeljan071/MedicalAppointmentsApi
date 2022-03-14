

namespace MedicalAppointmentsApi.Models
{
    public class Patient : DataTrail
    {
        [Key]
        [Required]
        [StringLength(36)]
        public string PatientId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        [StringLength(20)]
        public string Phone { get; set; }
        [Required]
        [StringLength(200)]
        public string Diagnosis { get; set; }
        [Required]
        [StringLength(200)]
        public string Allergies { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }

    public class DataTrail
    {
        [MaxLength(36)]
        public string CreatedBy { get; set; }
        [MaxLength(36)]
        public string UpdatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }


}
