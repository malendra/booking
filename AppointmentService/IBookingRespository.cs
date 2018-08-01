using System.Collections.Generic;
using System;
namespace AppointmentData
{
    public interface IBookingRespository
    {
        IEnumerable<UserAppointmentDto> GetAllAppointments(DateTime date);
    }
}
