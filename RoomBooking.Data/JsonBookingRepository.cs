using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using RoomBooking.Logic;

namespace RoomBooking.Data
{
    public class JsonBookingRepository : IBookingRepository
    {
        private readonly string _path;

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public JsonBookingRepository (string path)
        {
            _path = path;
        }

        public List<Booking> GetAll()
        {
            if (!File.Exists(_path))
            {
                return new List<Booking>();
            }

            string text = File.ReadAllText(_path);
            try
            {
                return JsonSerializer.Deserialize<List<Booking>>(text) ?? new List<Booking>();
            }
            catch (JsonException)
            { 
                return new List<Booking>(); 
            }
        }

        public void Add(Booking item)
        {
            List<Booking> items = GetAll();
            items.Add(item);

            string text = JsonSerializer.Serialize(items, _options);
            File.WriteAllText(_path, text);

        }
    }
}
