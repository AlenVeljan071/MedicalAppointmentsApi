namespace MedicalAppointmentsApi.Request
{
    public class Doctor_Request_Model : DataTrail
    {
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
    }
}
