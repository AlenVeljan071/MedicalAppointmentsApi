namespace MedicalAppointmentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _repository;
        public PatientController(IPatientRepository repository)
        {
            _repository = repository;
        }
        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            return Ok(await _repository.GetPatients());
        }
        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient_Response_Model>> GetPatient(string id)
        {
            var patient = await _repository.GetPatient(id);
            if (patient == null) return BadRequest();
            return Ok(patient.ResponsePatient());
        }
        // PUT: api/Patients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<ActionResult> PutPatient(Patient_Response_Model patient)
        {
            if (patient.PatientId == null) return BadRequest();
            var response = await _repository.PutPatient(patient);
            if (response == null) return BadRequest();
            return Ok();
        }
        // POST: api/Patients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Patient_Response_Model>> PostPatient(Patient_Request_Model patient)
        {
            var patientRes = await _repository.PostPatient(patient);
            if (patientRes == null)return BadRequest();
            return CreatedAtAction("GetPatient", new { id = patientRes.PatientId }, patientRes.ResponsePatient());
        }
        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public ActionResult DeletePatient(string id)
        {
            var response = _repository.DeletePatient(id);
            if (response == null) return BadRequest();
            return Ok();
        }
    }
}
