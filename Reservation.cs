using System;

public class Room
{
    public string RoomId { get; set; }
    public string RoomName { get; set; }
    public int Capacity { get; set; }

    public Room(string roomId, string roomName, int capacity)
    {
        RoomId = roomId;
        RoomName = roomName;
        Capacity = capacity;
    }
}

public class Reservation
{
    public DateTime Time { get; set; }
    public DateTime Date { get; set; }
    public string ReserverName { get; set; }
    public Room Room { get; set; }

    public Reservation(DateTime time, DateTime date, string reserverName, Room room)
    {
        Time = time;
        Date = date;
        ReserverName = reserverName;
        Room = room;
    }
}
