namespace MedicalAppointmentsApi.Repository
{
    public class Patient_Repository : IPatientRepository
    {
        private readonly DbInteractor _context;
        public Patient_Repository(DbInteractor context)
        {
            _context = context;
        }
        public bool DeletePatient(string id)
        {
            var patient = _context.Patients.Find(id);
            if (patient == null) return false;
            _context.Patients.Remove(patient);
            return true;
        }
        public async Task<Patient> GetPatient(string id)
        {
            var patient = await _context.Patients.Where(x => x.PatientId == id).FirstOrDefaultAsync();

            if (patient == null)
            {
                return null;
            }
            return patient;
        }
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            var patients = await _context.Patients.ToListAsync();
            return patients;
        }
        public Patient PostPatient(Patient_Request_Model patient)
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
            _context.Patients.Add(dbPatient);
            return dbPatient;
        }
        public void PutPatient(Patient_Response_Model patient)
        {
            if (patient.PatientId != null)
            {
                if (_context.Patients.Where(x => x.PatientId == patient.PatientId).Any())
                {
                    var pat = _context.Patients.Where(x => x.PatientId == patient.PatientId).FirstOrDefault();
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
                    _context.Patients.Update(pat);
                }
            }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

