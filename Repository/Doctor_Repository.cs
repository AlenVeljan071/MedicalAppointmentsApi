namespace MedicalAppointmentsApi.Repository
{
    public class Doctor_Repository : IDoctorRepository
    {
        private readonly DbInteractor _context;
        public Doctor_Repository(DbInteractor context)
        {
            _context = context;
        }
        public bool DeleteDoctor(string id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor == null) return false;
            _context.Doctors.Remove(doctor);
            return true;
        }
        public async Task<Doctor> GetDoctor(string id)
        {
            var doctor = await _context.Doctors.Where(x => x.DoctorId == id).FirstOrDefaultAsync();

            if (doctor == null)
            {
                return null;
            }
            return doctor;
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return doctors;
        }
        public Doctor PostDoctor(Doctor_Request_Model doctor)
        {
            var dbDoctor = new Doctor
            {
                DoctorId = Guid.NewGuid().ToString(),
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Phone = doctor.Phone,
                CreatedBy = doctor.CreatedBy,
                CreatedDate = DateTime.UtcNow,
                Specialist = doctor.Specialist,
            };
            _context.Doctors.Add(dbDoctor);
            return dbDoctor;
        }
        public void PutDoctor(Doctor_Response_Model doctor)
        {
            if (doctor.DoctorId != null)
            {
                if (_context.Doctors.Where(x => x.DoctorId == doctor.DoctorId).Any())
                {
                    var doc = _context.Doctors.Where(x => x.DoctorId == doctor.DoctorId).FirstOrDefault();
                    doc.DoctorId = doctor.DoctorId;
                    doc.FirstName = doctor.FirstName;
                    doc.LastName = doctor.LastName;
                    doc.UpdatedBy = doctor.UpdatedBy;
                    doc.UpdatedDate = DateTime.UtcNow;
                    doc.Phone = doctor.Phone;
                    doc.CreatedDate = doctor.CreatedDate;
                    doc.Specialist = doctor.Specialist;
                    doc.CreatedBy = doctor.CreatedBy;
                    _context.Doctors.Update(doc);
                }
            }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
