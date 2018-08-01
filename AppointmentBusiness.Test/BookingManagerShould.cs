using Xunit;
using Moq;
using AppointmentData;
using System.Collections.Generic;
using AppointmentModels;
using System;
using System.Linq;
using FluentAssertions;

namespace AppointmentBusiness.Test
{
    public class BookingManagerShould
    {
        [Fact]
        public void GetAllAppointments()
        {
            Mock<IBookingRespository> mockRepository = new Mock<IBookingRespository>();
            string mockNoteUser1 = "mockNote - User - 1";
            string mockNoteUser2 = "mockNote - User - 2";
            const string blue = "Blue user";
            const string green = "Green user";
            UserDto blueUser = new UserDto { Id ="1", Contact = "098", Name = blue };
            UserDto greenUser = new UserDto { Id = "2" , Contact = "021", Name = green };

            AppointmentDto appointment10AM = new AppointmentDto { Id = "1", Date = DateTime.Today, Time = new TimeSpan(10, 00, 00).ToString() };
            AppointmentDto appointment10_30AM = new AppointmentDto { Id = "1", Date = DateTime.Today, Time = new TimeSpan(10, 30, 00).ToString() };

            UserAppointmentDto userAppointmentDto1 = new UserAppointmentDto { Id = "1", AppointmentId = "1", UserId = "1", Notes = mockNoteUser1 };
            UserAppointmentDto userAppointmentDto2 = new UserAppointmentDto { Id = "2", AppointmentId = "2", UserId = "2", Notes = mockNoteUser2 };

            List<UserAppointmentDto> appointmentDtos = new List<UserAppointmentDto> { userAppointmentDto1, userAppointmentDto2 };
            mockRepository.Setup(m => m.GetAllAppointments(It.IsAny<DateTime>())).Returns(appointmentDtos);
            BookingManager bookingManager = new BookingManager(mockRepository.Object);
            AppointmentModel appointmentModel = bookingManager.GetAllBookings(DateTime.Now);

            appointmentModel.AppointmentList.Count().Should().Be(2);
            appointmentModel.AppointmentList.Where(a => a.User.Name == blue).Single().Notes.Should().Be(mockNoteUser1);
            appointmentModel.AppointmentList.Where(a => a.User.Name == blue).Single().Notes.Should().Be(mockNoteUser1);
        }
    }
}
