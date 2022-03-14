namespace MedicalAppointmentsApi
{
    public class DbInteractor : DbContext
    {
        public DbInteractor(DbContextOptions<DbInteractor> options) : base(options)
        {

        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
    }
}
