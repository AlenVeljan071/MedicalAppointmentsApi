using MedicalAppointmentsApi.Extensions;

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
            var patients = await _repository.GetPatients();
            return Ok(patients);
        }
        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient_Response_Model>>GetPatient(string id)
        {
           var patient = await _repository.GetPatient(id);
           return Ok(patient.ResponsePatient());
        }

        // PUT: api/Patients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public ActionResult PutPatient(Patient_Response_Model patient)
        {
            if (patient.PatientId == null)
            {
                return BadRequest();
            }
             _repository.PutPatient(patient);
            try
            {
                _repository.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest();
            }
             return Ok();    
        }

       // POST: api/Patients
       // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Patient_Response_Model> PostDoctor(Patient_Request_Model patient)
        {
            var patientRes = _repository.PostPatient(patient);
            try
            {
                _repository.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            return  CreatedAtAction("GetPatient", new { id = patientRes.PatientId }, patientRes.ResponsePatient());
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public ActionResult DeletePatient(string id)
        {
           var response = _repository.DeletePatient(id);
           if (response == false) return BadRequest();
            try
            {
                _repository.SaveChanges();
            }
            catch (Exception)
            {
               return BadRequest();
            }
            return Ok();
        }
       
    }
}
