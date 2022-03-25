namespace MedicalAppointmentsApi.Repository
{
    public class Appointments_Repository : IAppointmentsRepository
    {
        private readonly DbInteractor _context;
        public Appointments_Repository(DbInteractor context)
        {
            _context = context;
        }
        public bool DeleteAppointment(string id)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment == null) return false;
            _context.Appointments.Remove(appointment);
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
        public Appointment PostAppointment(Appointment_Request_Model appointment)
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
            return dbAppointemnt;
        }
        public void PutAppointment(Appopintment_Response_Model appointment)
        {
            if (appointment.AppointmentId != null)
            {
                if (_context.Appointments.Where(x => x.AppointmentId == appointment.AppointmentId).Any())
                {
                    var app = _context.Appointments.Where(x => x.AppointmentId == appointment.AppointmentId).FirstOrDefault();
                    app.DoctorId = appointment.DoctorId;
                    app.Note = appointment.Note;
                    app.CreatedBy = appointment.CreatedBy;
                    app.CreatedDate = appointment.CreatedDate;
                    app.Date_Time_App = appointment.Date_Time_App;
                    app.PatientId = appointment.PatientId;
                    app.UpdatedDate = DateTime.UtcNow;
                    app.UpdatedBy = appointment.UpdatedBy;
                    _context.Appointments.Update(app);
                }
            }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

}
