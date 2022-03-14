namespace MedicalAppointmentsApi.Request
{
    public class Patient_Request_Model : DataTrail
    {
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
    }
}
