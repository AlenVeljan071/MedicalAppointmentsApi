namespace MedicalAppointmentsApi.Response
{
    public class Patient_Response_Model : DataTrail_Response
    {

        public string PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Diagnosis { get; set; }
        public string Allergies { get; set; }
    }

    public class DataTrail_Response
    {
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
