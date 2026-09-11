using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBooking.Logic;

namespace RoomBooking.Data
{
    public class DemoBookingRepository : IBookingRepository
    {
        public List<Booking> GetAll()
        {
            return new List<Booking>
            {
                new Booking { Id = 100, Room = "509", Hour = 22 }
            };
        }

        public void Add(Booking item)
        {
            
        }
    }
}
