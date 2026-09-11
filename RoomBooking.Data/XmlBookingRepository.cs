using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RoomBooking.Logic;

namespace RoomBooking.Data
{
    public class XmlBookingRepository : IBookingRepository
    {
        private readonly string _path;

        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(List<Booking>));

        public XmlBookingRepository (string path)
        {
            _path = path;
        }

        public List<Booking> GetAll() 
        {
        
            if (!File.Exists(_path))
            {
                return new List<Booking>();
            }

            using var reader = new StreamReader(_path);

            return _serializer.Deserialize(reader) as List<Booking> ?? new List<Booking>();

        }

        public void Add(Booking item)
        {
            List<Booking> items = GetAll();
            items.Add(item);

            using var writer = new StreamWriter(_path);
            _serializer.Serialize(writer, items);
        }

    }
}
