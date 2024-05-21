using System;
using System.Collections.Generic;

public class ReservationHandler
{
    private Reservation[,] reservations = new Reservation[7, 24]; 

    public void AddReservation(Reservation reservation)
    {
        int day = (int)reservation.Date.DayOfWeek;
        int hour = reservation.Time.Hour;

        if (reservations[day, hour] == null)
        {
            reservations[day, hour] = reservation;
            Console.WriteLine("Reservation added successfully.");
        }
        else
        {
            Console.WriteLine("Time slot is already booked.");
        }
    }

    public void DeleteReservation(DateTime date, DateTime time)
    {
        int day = (int)date.DayOfWeek;
        int hour = time.Hour;

        if (reservations[day, hour] != null)
        {
            reservations[day, hour] = null;
            Console.WriteLine("Reservation deleted successfully.");
        }
        else
        {
            Console.WriteLine("No reservation found at the specified time.");
        }
    }

    public void DisplayWeeklySchedule()
    {
        for (int day = 0; day < 7; day++)
        {
            for (int hour = 0; hour < 24; hour++)
            {
                if (reservations[day, hour] != null)
                {
                    var reservation = reservations[day, hour];
                    Console.WriteLine($"{(DayOfWeek)day}, {hour}:00 - {reservation.ReserverName} in {reservation.Room.RoomName}");
                }
            }
        }
    }
}
