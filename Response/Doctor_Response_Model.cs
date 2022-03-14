namespace MedicalAppointmentsApi.Response
{
    public class Doctor_Response_Model : DataTrail_Response
    {
        public string DoctorId { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string LastName { get; set; }
        public string Specialist { get; set; }
    }
}
