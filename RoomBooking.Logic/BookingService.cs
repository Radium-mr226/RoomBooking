using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBooking.Data;

namespace RoomBooking.Logic
{
    public class BookingService
    {
        private readonly BookingRepository _repository = new();

        public List<Booking> GetImportant()
        {
            return _repository.GetAll()
                .Where(item => item.Hour > 14)
                .ToList();
        }
    }
}
