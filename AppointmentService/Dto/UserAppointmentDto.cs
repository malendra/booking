using System;
namespace AppointmentData
{
    public class UserAppointmentDto
    {
        public string Id
        {
            get;
            set;
        }
        public string AppointmentId { get; set; }

        public AppointmentDto Appointment
        {
            get;
            set;
        }
        public string UserId { get; set; }

        public UserDto User
        {
            get;
            set;
        }

        public string Notes
        {
            get;
            set;
        }
 
    }
}
