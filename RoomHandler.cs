using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class RoomHandler
{
    private readonly string _filePath;

    public RoomHandler(string filePath)
    {
        _filePath = filePath;
    }

    public List<Room> GetRooms()
    {
        return File.Exists(_filePath) ? 
            JsonSerializer.Deserialize<List<Room>>(File.ReadAllText(_filePath)) ?? new List<Room>() 
            : new List<Room>();
    }

    public void SaveRooms(List<Room> rooms)
    {
        File.WriteAllText(_filePath, JsonSerializer.Serialize(rooms, new JsonSerializerOptions { WriteIndented = true }));
    }
}
