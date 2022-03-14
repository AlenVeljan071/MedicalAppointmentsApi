namespace MedicalAppointmentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly DbInteractor _context;
        public AppointmentController(DbInteractor context)
        {
            _context = context;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            return await _context.Appointments.ToListAsync();
        }


        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public ActionResult<Appopintment_Response_Model> GetAppointment(string id)
        {
            var appointment = _context.Appointments.Where(x => x.AppointmentId == id).FirstOrDefault();

            if (appointment == null)
            {
                return NotFound();
            }
            var appRes = new Appopintment_Response_Model
            {
                AppointmentId = appointment.AppointmentId,
                Date_Time_App = appointment.Date_Time_App,
                DoctorId = appointment.DoctorId,
                PatientId = appointment.PatientId,
                CreatedBy = appointment.CreatedBy,
                CreatedDate = appointment.CreatedDate,
                UpdatedBy = appointment.UpdatedBy,
                UpdatedDate = appointment.UpdatedDate,
            };

            return appRes;
        }
        // GET: api/Appointments/Patient
        [HttpGet("AppByPatient")]
        public async Task<ActionResult<IEnumerable<Appopintment_Response_Model>>> GetAppointmentsByPatient([FromQuery] Patient_Response_Model patient)
        {
            var appointment = await _context.Appointments.Where(x => x.PatientId == patient.PatientId).ToListAsync();

            List<Appopintment_Response_Model> listApp = new List<Appopintment_Response_Model>();
            foreach (var appointmentItem in appointment)
            {
                var x = new Appopintment_Response_Model
                {
                    AppointmentId = appointmentItem.AppointmentId,
                    Date_Time_App = appointmentItem.Date_Time_App,
                    DoctorId = appointmentItem.DoctorId,
                    Note = appointmentItem.Note,
                    CreatedBy = appointmentItem.CreatedBy,
                    CreatedDate = appointmentItem.CreatedDate,
                    PatientId = appointmentItem.PatientId,
                    UpdatedBy = appointmentItem.UpdatedBy,
                    UpdatedDate = appointmentItem.UpdatedDate,
                };
                listApp.Add(x);
            }

            return listApp;
        }

        // GET: api/Appointments/Doctor
        [HttpGet("AppByDoctor")]
        public async Task<ActionResult<IEnumerable<Appopintment_Response_Model>>> GetAppointmentsByDoctor([FromQuery] Doctor_Response_Model doctor)
        {
            var appointment = await _context.Appointments.Where(x => x.DoctorId == doctor.DoctorId).ToListAsync();

            List<Appopintment_Response_Model> listApp = new List<Appopintment_Response_Model>();
            foreach (var appointmentItem in appointment)
            {
                var x = new Appopintment_Response_Model
                {
                    AppointmentId = appointmentItem.AppointmentId,
                    Date_Time_App = appointmentItem.Date_Time_App,
                    DoctorId = appointmentItem.DoctorId,
                    Note = appointmentItem.Note,
                    CreatedBy = appointmentItem.CreatedBy,
                    CreatedDate = appointmentItem.CreatedDate,
                    PatientId = appointmentItem.PatientId,
                    UpdatedBy = appointmentItem.UpdatedBy,
                    UpdatedDate = appointmentItem.UpdatedDate,
                };
                listApp.Add(x);
            }

            return listApp;
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutAppointment(Appopintment_Response_Model appointment)
        {
            if (appointment.AppointmentId == null)
            {
                return BadRequest();
            }
            if (_context.Appointments.Where(x => x.AppointmentId == appointment.AppointmentId).Any())
            {
                var app = _context.Appointments.Where(x => x.AppointmentId == appointment.AppointmentId).FirstOrDefault();
                app.UpdatedBy = appointment.UpdatedBy;
                app.UpdatedDate = appointment.UpdatedDate;
                app.Date_Time_App = app.Date_Time_App;
                app.PatientId = appointment.PatientId;
                app.DoctorId = appointment.DoctorId;
                app.Note = appointment.Note;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(appointment.AppointmentId))
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


        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appopintment_Response_Model>> PostAppointment(Appointment_Request_Model appointment)
        {
            var dbAppointment = new Appointment
            {
                AppointmentId = Guid.NewGuid().ToString(),
                Date_Time_App = appointment.Date_Time_App,
                DoctorId = appointment.DoctorId,
                PatientId = appointment.PatientId,
                Note = appointment.Note,
                CreatedBy = appointment.CreatedBy,
                CreatedDate = DateTime.UtcNow,
            };
            _context.Appointments.Add(dbAppointment);

            var appRes = new Appopintment_Response_Model
            {
                AppointmentId = dbAppointment.AppointmentId,
                Date_Time_App = dbAppointment.Date_Time_App,
                CreatedBy = dbAppointment.CreatedBy,
                CreatedDate = dbAppointment.CreatedDate,
                DoctorId = dbAppointment.DoctorId,
                Note = dbAppointment.Note,
                PatientId = dbAppointment.PatientId,
            };
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AppointmentExists(dbAppointment.AppointmentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAppointment", new { id = dbAppointment.AppointmentId }, appRes);
        }


        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(string id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentExists(string id)
        {
            return _context.Appointments.Any(e => e.AppointmentId == id);
        }
    }
}
