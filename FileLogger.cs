using System.IO;
using System.Text.Json;

public class FileLogger : ILogger
{
    private readonly string _filePath;

    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }

    public void Log(LogRecord log)
    {
        var logs = File.Exists(_filePath) ? 
            JsonSerializer.Deserialize<List<LogRecord>>(File.ReadAllText(_filePath)) ?? new List<LogRecord>() 
            : new List<LogRecord>();

        logs.Add(log);

        File.WriteAllText(_filePath, JsonSerializer.Serialize(logs, new JsonSerializerOptions { WriteIndented = true }));
    }
}
