using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Data
{
    public class Booking
    {
        public int Id { get; set; }
        public string Room {  get; set; }
        public int Hour { get; set; }
    }
}
