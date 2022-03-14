namespace MedicalAppointmentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly DbInteractor _context;
        public PatientController(DbInteractor context)
        {
            _context = context;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            return await _context.Patients.ToListAsync();
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public ActionResult<Patient_Response_Model> GetPatient(string id)
        {
            var patient = _context.Patients.Where(x => x.PatientId == id).FirstOrDefault();

            if (patient == null)
            {
                return NotFound();
            }
            var patientRes = new Patient_Response_Model
            {
                PatientId = patient.PatientId,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Address = patient.Address,
                Email = patient.Email,
                DateOfBirth = patient.DateOfBirth,
                Allergies = patient.Allergies,
                Phone = patient.Phone,
                Diagnosis = patient.Diagnosis,
                CreatedBy = patient.CreatedBy,
                CreatedDate = patient.CreatedDate,
                UpdatedBy = patient.UpdatedBy,
                UpdatedDate = patient.UpdatedDate,
            };

            return patientRes;
        }

        // PUT: api/Patients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutPatient(Patient_Response_Model patient)
        {
            if (patient.PatientId == null)
            {
                return BadRequest();
            }
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
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(patient.PatientId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Patients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Patient_Response_Model>> PostDoctor(Patient_Request_Model patient)
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

            var patientRes = new Patient_Response_Model
            {
                PatientId = dbPatient.PatientId,
                FirstName = dbPatient.FirstName,
                LastName = dbPatient.LastName,
                Phone = dbPatient.Phone,
                CreatedBy = dbPatient.CreatedBy,
                CreatedDate = dbPatient.CreatedDate,
                Address = dbPatient.Address,
                Allergies = dbPatient.Allergies,
                Diagnosis = dbPatient.Diagnosis,
                DateOfBirth = dbPatient.DateOfBirth,
                Email = dbPatient.Email,
            };
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PatientExists(dbPatient.PatientId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPatient", new { id = dbPatient.PatientId }, patientRes);
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(string id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientExists(string id)
        {
            return _context.Patients.Any(e => e.PatientId == id);
        }
    }
}
