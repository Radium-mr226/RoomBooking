using RoomBooking.Logic;

var service = new BookingService();
Console.WriteLine("Отображенные записи: ");

foreach (var item in service.GetImportant())
{
    Console.WriteLine($"{item.Id}: {item.Room}");
}