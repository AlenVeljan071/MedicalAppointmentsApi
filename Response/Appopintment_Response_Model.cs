namespace MedicalAppointmentsApi.Response
{
    public class Appopintment_Response_Model : DataTrail_Response
    {
        public string AppointmentId { get; set; }
        public DateTime Date_Time_App { get; set; }
        public string Note { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
    }
}
