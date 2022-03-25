namespace MedicalAppointmentsApi.Extensions
{
    public static class Extension
    {
        public static Patient_Response_Model ResponsePatient(this Patient patient)
        {
            return new Patient_Response_Model
            {
                PatientId = patient.PatientId,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Address = patient.Address,
                Email = patient.Email,
                DateOfBirth = patient.DateOfBirth,
                Allergies = patient.Allergies,
                Phone = patient.Phone,
                Diagnosis = patient.Diagnosis,
                CreatedBy = patient.CreatedBy,
                CreatedDate = patient.CreatedDate,
                UpdatedBy = patient.UpdatedBy,
                UpdatedDate = patient.UpdatedDate,
            };
        }
        public static Doctor_Response_Model ResponseDoctor(this Doctor doctor)
        {
            return new Doctor_Response_Model
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
        }

        public static Appopintment_Response_Model ResponseAppointment(this Appointment appopintment)
        {
            return new Appopintment_Response_Model
            {
                AppointmentId = appopintment.AppointmentId,
                Date_Time_App = appopintment.Date_Time_App,
                DoctorId = appopintment.DoctorId,
                Note = appopintment.Note,
                CreatedBy = appopintment.CreatedBy,
                CreatedDate = appopintment.CreatedDate,
                PatientId = appopintment.PatientId,
                UpdatedBy = appopintment.UpdatedBy,
                UpdatedDate = appopintment.UpdatedDate,
            };
        }
    }
}
