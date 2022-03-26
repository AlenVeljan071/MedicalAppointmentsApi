namespace MedicalAppointmentsApi.Repository
{
    public class Patient_Repository : IPatientRepository
    {
        private readonly DbInteractor _context;
        public Patient_Repository(DbInteractor context)
        {
            _context = context;
        }
        public async Task<bool> DeletePatient(string id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null) return false;
            _context.Patients.Remove(patient);
            try
            { 
               await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true; 
        }
        public async Task<Patient> GetPatient(string id)
        {
            var patient = await _context.Patients.Where(x => x.PatientId == id).FirstOrDefaultAsync();
            return patient;
        }
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            var patients = await _context.Patients.ToListAsync();
            return patients;
        }
        public async Task<Patient> PostPatient(Patient_Request_Model patient)
        {
            var dbPatient = new Patient
            {
                PatientId = Guid.NewGuid().ToString(),
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Phone = patient.Phone,
                CreatedBy = patient.CreatedBy,
                CreatedDate = DateTime.UtcNow,
                Allergies = patient.Allergies,
                Address = patient.Address,
                DateOfBirth = patient.DateOfBirth,
                Diagnosis = patient.Diagnosis,
                Email = patient.Email,
            };
            await _context.Patients.AddAsync(dbPatient);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return null;
            }
            
             return dbPatient;
        }
        public async Task<Patient> PutPatient(Patient_Response_Model patient)
        {
            var pat = await _context.Patients.Where(x => x.PatientId == patient.PatientId).FirstOrDefaultAsync();
            if(pat == null) return null;
            pat.PatientId = patient.PatientId;
            pat.FirstName = patient.FirstName;
            pat.LastName = patient.LastName;
            pat.Address = patient.Address;
            pat.Email = patient.Email;
            pat.Diagnosis = patient.Diagnosis;
            pat.UpdatedBy = patient.UpdatedBy;
            pat.UpdatedDate = DateTime.UtcNow;
            pat.Phone = patient.Phone;
            pat.Allergies = patient.Allergies;
          
            try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return null;
                }
                return pat;
        }
       
    }
}

