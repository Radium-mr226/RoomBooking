using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBooking.Logic;

namespace RoomBooking.Logic
{
    public class BookingService
    {
        private readonly IBookingRepository _repository;

        public BookingService(IBookingRepository repository)
        {
            _repository = repository;
        }
        public List<Booking> GetImportant()
        {
            return _repository.GetAll()
                .Where(item => item.Hour > 14)
                .ToList();
        }
        public void AddBooking(string room, int hour)
        {
            if (string.IsNullOrEmpty(room))
            {
                return;
            }

            int nexId = _repository.GetAll().Count + 1;

            _repository.Add(new Booking
            {
                Id = nexId,
                Room = room,
                Hour = hour
            });
        }

        public bool IsRoomOccupied(string room, int hour)
        {
            List<Booking> allBookings = _repository.GetAll();

            return allBookings.Any(b => b.Room == room && b.Hour == hour);
        }
    }
}
