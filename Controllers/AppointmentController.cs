namespace MedicalAppointmentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentsRepository _repository;
        public AppointmentController(IAppointmentsRepository repository)
        {
            _repository = repository;
        }
        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            return Ok(await _repository.GetAppointments());
        }
        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appopintment_Response_Model>> GetAppointment(string id)
        {
            var appointment = await _repository.GetAppointment(id);
            return Ok(appointment.ResponseAppointment());

        }
        // GET: api/Appointments/Patient
        [HttpGet("AppByPatient")]
        public async Task<ActionResult<IEnumerable<Appopintment_Response_Model>>> GetAppointmentsByPatient(Patient_Response_Model patient)
        {
            var appointment = await _repository.GetAppointmentByPatient(patient.PatientId);
            return Ok(appointment.ResponseAppointment());
        }

        // GET: api/Appointments/Doctor
        [HttpGet("AppByDoctor")]
        public async Task<ActionResult<IEnumerable<Appopintment_Response_Model>>> GetAppointmentsByDoctor(Doctor_Response_Model doctor)
        {
            var appointment = await _repository.GetAppointmentByDoctor(doctor.DoctorId);
            return Ok(appointment.ResponseAppointment());
        }
        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public ActionResult PutAppointment(Appopintment_Response_Model appointment)
        {
            if (appointment.AppointmentId == null) return BadRequest();
            var response =_repository.PutAppointment(appointment);
            if(response == null)return BadRequest();
            return Ok();
        }
        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appopintment_Response_Model>> PostAppointment(Appointment_Request_Model appointment)
        {
            var appointmentRes = await _repository.PostAppointment(appointment);
            if (appointmentRes == null) return BadRequest();
            return CreatedAtAction("GetAppointment", new { id = appointmentRes.AppointmentId }, appointmentRes.ResponseAppointment());
        }
        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAppointment(string id)
        {
            var response = await _repository.DeleteAppointment(id);
            if (response == false) return BadRequest();
            return Ok();
        }
    }
}
