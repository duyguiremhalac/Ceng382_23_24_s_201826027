using System.Collections.Generic;

public class ReservationHandler
{
    private readonly IReservationRepository _reservationRepository;
    private readonly LogHandler _logHandler;
    private readonly RoomHandler _roomHandler;

    public ReservationHandler(IReservationRepository reservationRepository, LogHandler logHandler, RoomHandler roomHandler)
    {
        _reservationRepository = reservationRepository;
        _logHandler = logHandler;
        _roomHandler = roomHandler;
    }

    public void AddReservation(Reservation reservation, string reserverName)
    {
        _reservationRepository.AddReservation(reservation);
        var log = new LogRecord(DateTime.Now, reserverName, reservation.Room.Name);
        _logHandler.AddLog(log);
    }

    public void DeleteReservation(Reservation reservation)
    {
        _reservationRepository.DeleteReservation(reservation);
        var log = new LogRecord(DateTime.Now, reservation.ReserverName, reservation.Room.Name);
        _logHandler.AddLog(log);
    }

    public List<Reservation> GetAllReservations()
    {
        return _reservationRepository.GetAllReservations();
    }

    public List<Room> GetRooms()
    {
        return _roomHandler.GetRooms();
    }

    public void SaveRooms(List<Room> rooms)
    {
        _roomHandler.SaveRooms(rooms);
    }
}
