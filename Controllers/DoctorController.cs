namespace MedicalAppointmentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DbInteractor _context;
        public DoctorController(DbInteractor context)
        {
            _context = context;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            return await _context.Doctors.ToListAsync();
        }

        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public ActionResult<Doctor_Response_Model> GetDoctor(string id)
        {
            var doctor = _context.Doctors.Where(x => x.DoctorId == id).FirstOrDefault();

            if (doctor == null)
            {
                return NotFound();
            }
            var doctorRes = new Doctor_Response_Model
            {
                DoctorId = doctor.DoctorId,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Phone = doctor.Phone,
                Specialist = doctor.Specialist,
                CreatedBy = doctor.CreatedBy,
                CreatedDate = doctor.CreatedDate,
                UpdatedBy = doctor.UpdatedBy,
                UpdatedDate = doctor.UpdatedDate,
            };

            return doctorRes;
        }

        // PUT: api/Doctors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutDoctor(Doctor_Response_Model doctor)
        {
            if (doctor.DoctorId == null)
            {
                return BadRequest();
            }
            if (_context.Doctors.Where(x => x.DoctorId == doctor.DoctorId).Any())
            {
                var dr = _context.Doctors.Where(x => x.DoctorId == doctor.DoctorId).FirstOrDefault();
                dr.FirstName = doctor.FirstName;
                dr.LastName = doctor.LastName;
                dr.Phone = doctor.Phone;
                dr.Specialist = doctor.Specialist;
                dr.UpdatedBy = doctor.UpdatedBy;
                dr.UpdatedDate = doctor.UpdatedDate;
                _context.Update(dr);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(doctor.DoctorId))
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

        // POST: api/Doctors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Doctor_Response_Model>> PostDoctor(Doctor_Request_Model doctor)
        {
            var dbDoctor = new Doctor
            {
                DoctorId = Guid.NewGuid().ToString(),
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Phone = doctor.Phone,
                Specialist = doctor.Specialist,
                CreatedBy = doctor.CreatedBy,
                CreatedDate = doctor.CreatedDate,
            };
            _context.Doctors.Add(dbDoctor);

            var doctorRes = new Doctor_Response_Model
            {
                DoctorId = dbDoctor.DoctorId,
                FirstName = dbDoctor.FirstName,
                LastName = dbDoctor.LastName,
                Phone = dbDoctor.Phone,
                CreatedBy = dbDoctor.CreatedBy,
                CreatedDate = dbDoctor.CreatedDate,
                Specialist = dbDoctor.Specialist,
            };
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DoctorExists(dbDoctor.DoctorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDoctor", new { id = dbDoctor.DoctorId }, doctorRes);
        }

        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(string id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctorExists(string id)
        {
            return _context.Doctors.Any(e => e.DoctorId == id);
        }
    }
}
