namespace MedicalAppointmentsApi.Repository
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctor(string id);
        void PutDoctor(Doctor_Response_Model patient);
        void SaveChanges();
        Doctor PostDoctor(Doctor_Request_Model patient);
        bool DeleteDoctor(string id);
    }
}