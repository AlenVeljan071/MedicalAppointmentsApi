namespace MedicalAppointmentsApi.Repository
{
    public interface IAppointmentsRepository
    {
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment> GetAppointment(string id);
        Task<Appointment> GetAppointmentByDoctor(string id);
        Task<Appointment> GetAppointmentByPatient(string id);
        void PutAppointment(Appopintment_Response_Model patient);
        void SaveChanges();
        Appointment PostAppointment(Appointment_Request_Model patient);
        bool DeleteAppointment(string id);
    }
}