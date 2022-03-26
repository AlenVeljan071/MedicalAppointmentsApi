namespace MedicalAppointmentsApi.Repository
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatient(string id);
        Task<Patient> PutPatient(Patient_Response_Model patient);
        Task<Patient> PostPatient(Patient_Request_Model patient);
        Task<bool> DeletePatient(string id);
    }
}
