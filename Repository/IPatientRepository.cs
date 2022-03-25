namespace MedicalAppointmentsApi.Repository
{
    public interface IPatientRepository
    {

        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatient(string id);
        void PutPatient(Patient_Response_Model patient);
        void SaveChanges();
        Patient PostPatient(Patient_Request_Model patient);
        bool DeletePatient(string id);
    }
}
