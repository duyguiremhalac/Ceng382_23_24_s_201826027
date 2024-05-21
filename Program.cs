using System;

class Program
{
    static void Main(string[] args)
    {
        ReservationHandler handler = new ReservationHandler();

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
                    Console.Write("Enter Reservation Time (hh:mm): ");
                    DateTime time = DateTime.Parse(Console.ReadLine());

                    Reservation reservation = new Reservation(time, date, reserverName, room);
                    handler.AddReservation(reservation);
                    break;

                case 2:
                    Console.Write("Enter Reservation Date (yyyy-mm-dd): ");
                    DateTime deleteDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter Reservation Time (hh:mm): ");
                    DateTime deleteTime = DateTime.Parse(Console.ReadLine());

                    handler.DeleteReservation(deleteDate, deleteTime);
                    break;

                case 3:
                    handler.DisplayWeeklySchedule();
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
