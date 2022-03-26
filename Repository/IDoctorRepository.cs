namespace MedicalAppointmentsApi.Repository
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctor(string id);
        Task<Doctor> PutDoctor(Doctor_Response_Model patient);
        Task<Doctor> PostDoctor(Doctor_Request_Model patient);
        Task<bool> DeleteDoctor(string id);
    }
}