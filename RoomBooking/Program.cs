using RoomBooking.Data;
using RoomBooking.Logic;

IBookingRepository repository = new BookingRepository();

var service = new BookingService(repository);

Console.WriteLine("Отображенные записи: ");

foreach (var item in service.GetImportant())
{
    Console.WriteLine($"{item.Id}: {item.Room}");
}