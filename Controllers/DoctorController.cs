namespace MedicalAppointmentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _repository;
        public DoctorController(IDoctorRepository doctorRepository)
        {
            _repository = doctorRepository;
        }
        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            var doctors = await _repository.GetDoctors();
            return Ok(doctors);
        }
        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor_Response_Model>> GetDoctor(string id)
        {
            var patient = await _repository.GetDoctor(id);
            return Ok(patient.ResponseDoctor());
        }
        // PUT: api/Doctors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public ActionResult PutDoctor(Doctor_Response_Model doctor)
        {
            if (doctor.DoctorId == null)
            {
                return BadRequest();
            }
            _repository.PutDoctor(doctor);
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
        // POST: api/Doctors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Doctor_Response_Model> PostDoctor(Doctor_Request_Model doctor)
        {
            var doctorRes = _repository.PostDoctor(doctor);
            try
            {
                _repository.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetDoctor", new { id = doctorRes.DoctorId }, doctorRes.ResponseDoctor());
        }
        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public ActionResult DeleteDoctor(string id)
        {
            var response = _repository.DeleteDoctor(id);
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
