using System;

class Program
{
    static void Main(string[] args)
    {
        var roomHandler = new RoomHandler("RoomData.json");
        var reservationRepository = new ReservationRepository("ReservationData.json");
        var logger = new FileLogger("LogData.json");
        var logHandler = new LogHandler(logger);

        var reservationHandler = new ReservationHandler(reservationRepository, logHandler, roomHandler);
        var reservationService = new ReservationService(reservationHandler);

        while (true)
        {
            Console.WriteLine("1. Add Reservation");
            Console.WriteLine("2. Delete Reservation");
            Console.WriteLine("3. Display Weekly Schedule");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Room Id: ");
                    string roomId = Console.ReadLine();
                    Console.Write("Enter Room Name: ");
                    string roomName = Console.ReadLine();
                    Console.Write("Enter Room Capacity: ");
                    int capacity = int.Parse(Console.ReadLine());

                    Room room = new Room(roomId, roomName, capacity);

                    Console.Write("Enter Reserver Name: ");
                    string reserverName = Console.ReadLine();
                    Console.Write("Enter Reservation Date (yyyy-mm-dd): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter Reservation Time (HH:mm): ");
                    DateTime time = DateTime.Parse(Console.ReadLine());

                    Reservation reservation = new Reservation(time, date, reserverName, room);
                    reservationService.AddReservation(reservation, reserverName);
                    break;

                case 2:
                    Console.Write("Enter Reservation Date (yyyy-mm-dd): ");
                    DateTime deleteDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter Reservation Time (HH:mm): ");
                    DateTime deleteTime = DateTime.Parse(Console.ReadLine());

                    Reservation deleteReservation = new Reservation(deleteTime, deleteDate, string.Empty, null);
                    reservationService.DeleteReservation(deleteReservation);
                    break;

                case 3:
                    reservationService.DisplayWeeklySchedule();
                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
