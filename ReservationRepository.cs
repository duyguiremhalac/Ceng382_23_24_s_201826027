using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class ReservationRepository : IReservationRepository
{
    private readonly string _filePath;
    private List<Reservation> _reservations;

    public ReservationRepository(string filePath)
    {
        _filePath = filePath;
        _reservations = File.Exists(_filePath) ? 
            JsonSerializer.Deserialize<List<Reservation>>(File.ReadAllText(_filePath)) ?? new List<Reservation>() 
            : new List<Reservation>();
    }

    public void AddReservation(Reservation reservation)
    {
        _reservations.Add(reservation);
        SaveReservations();
    }

    public void DeleteReservation(Reservation reservation)
    {
        _reservations.RemoveAll(r => r.Time == reservation.Time && r.Date == reservation.Date && r.ReserverName == reservation.ReserverName);
        SaveReservations();
    }

    public List<Reservation> GetAllReservations()
    {
        return _reservations;
    }

    private void SaveReservations()
    {
        File.WriteAllText(_filePath, JsonSerializer.Serialize(_reservations, new JsonSerializerOptions { WriteIndented = true }));
    }
}
