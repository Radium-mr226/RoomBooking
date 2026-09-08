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
    }
}
