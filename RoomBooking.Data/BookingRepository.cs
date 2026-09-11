using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBooking.Logic;

namespace RoomBooking.Data
{
    public class BookingRepository : IBookingRepository
    {
        private readonly List<Booking> _Rooms = new List<Booking>()
        {
            new Booking { Id = 1, Room = "101", Hour = 15},
            new Booking { Id = 2, Room = "102", Hour = 17 },
            new Booking { Id = 3, Room = "103", Hour = 10 }
        };

        public List<Booking> GetAll()
        {
            return _Rooms;
        }

        public void Add(Booking item)
        {
            _Rooms.Add(item);
        }
    }
}
