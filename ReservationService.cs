public interface IReservationService
{
    void AddReservation(Reservation reservation, string reserverName);
    void DeleteReservation(Reservation reservation);
    void DisplayWeeklySchedule();
}
