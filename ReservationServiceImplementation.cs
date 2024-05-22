using System;
using System.Linq;

public class ReservationService : IReservationService
{
    private readonly ReservationHandler _reservationHandler;

    public ReservationService(ReservationHandler reservationHandler)
    {
        _reservationHandler = reservationHandler;
    }

    public void AddReservation(Reservation reservation, string reserverName)
    {
        _reservationHandler.AddReservation(reservation, reserverName);
    }

    public void DeleteReservation(Reservation reservation)
    {
        _reservationHandler.DeleteReservation(reservation);
    }

    public void DisplayWeeklySchedule()
    {
        var reservations = _reservationHandler.GetAllReservations();

        foreach (var reservation in reservations.OrderBy(r => r.Date).ThenBy(r => r.Time))
        {
            Console.WriteLine($"{reservation.Date.ToShortDateString()} {reservation.Time.ToShortTimeString()} - {reservation.ReserverName} in {reservation.Room.Name}");
        }
    }
}
