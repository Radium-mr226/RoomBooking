using RoomBooking.Data;
using RoomBooking.Logic;

string jsonPath = Path.Combine(AppContext.BaseDirectory, "Booking.json");
string xmlPath = Path.Combine(AppContext.BaseDirectory, "Booking.xml");

string kind = args.Length > 0 ? args[0] : "json";


IBookingRepository repository = kind switch
{
    "xml" => new XmlBookingRepository(xmlPath),
    "memory" => new BookingRepository(),
    _ => new JsonBookingRepository(jsonPath),
};

Console.WriteLine($"Хранилище: {kind}");

var service = new BookingService(repository);

Console.Write("новая комната номер:");
string room = Console.ReadLine() ?? "";

Console.Write("на какое время:");
int hour = Convert.ToInt32( Console.ReadLine() ?? "");

if (!service.IsRoomOccupied(room, hour))
{
    service.AddBooking(room, hour);
}
else
{
    Console.WriteLine("Данная аудитория занята в это время");
}

Console.WriteLine("Отображенные записи: ");

foreach (var item in service.GetImportant())
{
    Console.WriteLine($"{item.Id}: {item.Room}");
}