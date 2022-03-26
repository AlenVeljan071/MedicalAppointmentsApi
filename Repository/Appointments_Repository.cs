namespace MedicalAppointmentsApi.Repository
{
    public class Appointments_Repository : IAppointmentsRepository
    {
        private readonly DbInteractor _context;
        public Appointments_Repository(DbInteractor context)
        {
            _context = context;
        }
        public async Task<bool> DeleteAppointment(string id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return false;
            _context.Appointments.Remove(appointment);
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
        public async Task<Appointment> GetAppointment(string id)
        {
            var appointment = await _context.Appointments.Where(x => x.AppointmentId == id).FirstOrDefaultAsync();

            if (appointment == null)
            {
                return null;
            }
            return appointment;
        }

        public async Task<Appointment> GetAppointmentByDoctor(string id)
        {
            var appointment = await _context.Appointments.Where(x => x.DoctorId == id).FirstOrDefaultAsync();

            if (appointment == null)
            {
                return null;
            }
            return appointment;
        }

        public async Task<Appointment> GetAppointmentByPatient(string id)
        {
            var appointment = await _context.Appointments.Where(x => x.PatientId == id).FirstOrDefaultAsync();

            if (appointment == null)
            {
                return null;
            }
            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            var appointments = await _context.Appointments.ToListAsync();
            return appointments;
        }
        public async Task<Appointment> PostAppointment(Appointment_Request_Model appointment)
        {
            var dbAppointemnt = new Appointment
            {
                AppointmentId = Guid.NewGuid().ToString(),
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                Note = appointment.Note,
                CreatedBy = appointment.CreatedBy,
                CreatedDate = DateTime.UtcNow,
                Date_Time_App = appointment.Date_Time_App,
            };
             _context.Appointments.Add(dbAppointemnt);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }
            return dbAppointemnt;
        }
        public async Task<Appointment> PutAppointment(Appopintment_Response_Model appointment)
        {
            var app = _context.Appointments.Where(x => x.AppointmentId == appointment.AppointmentId).FirstOrDefault();
            if (app == null) return null;
            app.DoctorId = appointment.DoctorId;
            app.Note = appointment.Note;
            app.CreatedBy = appointment.CreatedBy;
            app.CreatedDate = appointment.CreatedDate;
            app.Date_Time_App = appointment.Date_Time_App;
            app.PatientId = appointment.PatientId;
            app.UpdatedDate = DateTime.UtcNow;
            app.UpdatedBy = appointment.UpdatedBy;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }
            return app;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

}
