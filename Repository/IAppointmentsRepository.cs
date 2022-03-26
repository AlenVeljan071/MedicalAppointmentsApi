namespace MedicalAppointmentsApi.Repository
{
    public interface IAppointmentsRepository
    {
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment> GetAppointment(string id);
        Task<Appointment> GetAppointmentByDoctor(string id);
        Task<Appointment> GetAppointmentByPatient(string id);
        Task<Appointment> PutAppointment(Appopintment_Response_Model patient);
        Task<Appointment> PostAppointment(Appointment_Request_Model patient);
        Task<bool> DeleteAppointment(string id);
    }
}