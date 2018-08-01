using System;
using System.Collections.Generic;

namespace AppointmentModels
{
    public class AppointmentModel
    {
        public DateTime Date
        {
            get;
            set;
        }

        public IEnumerable<SlotModel> AppointmentList
        {
            get;
            set;
        }
    }
}