using System;
using System.Collections.Generic;
using AppointmentData;
using AppointmentModels;

namespace AppointmentBusiness
{
    public class BookingManager
    {
        private readonly IBookingRespository _bookingRespository;

        public BookingManager(IBookingRespository bookingRespository)
        {
            _bookingRespository = bookingRespository;
        }
        public AppointmentModel GetAllBookings(DateTime date)
        {
            AppointmentModel appointmentModel = new AppointmentModel();
            List<SlotModel> slots = new List<SlotModel>();
            IEnumerable<UserAppointmentDto> userAppointmentDtos =_bookingRespository.GetAllAppointments(date);
            appointmentModel.Date = date;
               
            foreach (var userAppointmentDto in userAppointmentDtos)
            {
                SlotModel slot = new SlotModel
                {
                    User = new UserModel
                    {
                        Name = userAppointmentDto.User.Name,
                        Contact = userAppointmentDto.User.Contact
                    },
                    Notes = userAppointmentDto.Notes,
                    Time = userAppointmentDto.Appointment.Time
                };
                slots.Add(slot);
            }
            appointmentModel.AppointmentList = slots;
            return appointmentModel;
        }
    }
}
