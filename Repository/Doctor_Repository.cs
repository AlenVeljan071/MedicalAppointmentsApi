namespace MedicalAppointmentsApi.Repository
{
    public class Doctor_Repository : IDoctorRepository
    {
        private readonly DbInteractor _context;
        public Doctor_Repository(DbInteractor context)
        {
            _context = context;
        }
        public async Task<bool> DeleteDoctor(string id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null) return false;
            _context.Doctors.Remove(doctor);
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
        public async Task<Doctor> GetDoctor(string id)
        {
            var doctor = await _context.Doctors.Where(x => x.DoctorId == id).Include(x=>x.Appointments).FirstOrDefaultAsync();
            return doctor;
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return doctors;
        }
        public async Task <Doctor> PostDoctor(Doctor_Request_Model doctor)
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
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }
            return dbDoctor;
        }
        public async Task<Doctor> PutDoctor(Doctor_Response_Model doctor)
        {
            var doc = await _context.Doctors.Where(x => x.DoctorId == doctor.DoctorId).FirstOrDefaultAsync();
            if (doc == null) return null;
            doc.DoctorId = doctor.DoctorId;
            doc.FirstName = doctor.FirstName;
            doc.LastName = doctor.LastName;
            doc.UpdatedBy = doctor.UpdatedBy;
            doc.UpdatedDate = DateTime.UtcNow;
            doc.Phone = doctor.Phone;
            doc.CreatedDate = doctor.CreatedDate;
            doc.Specialist = doctor.Specialist;
            doc.CreatedBy = doctor.CreatedBy;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }
            return doc;
        }
    }
}
