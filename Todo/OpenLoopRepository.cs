using System.Text.Json;

namespace TodoList;

public static class OpenLoopRepository
{
    internal delegate void ActionNotify(string message);

    internal static event ActionNotify Notify;

    private static string DirectoryName = "D:/OpenLoops/";

    public static bool Add(OpenLoop newOpenLoop)
    {
        Directory.CreateDirectory(DirectoryName);
        var json = JsonSerializer.Serialize(newOpenLoop, new JsonSerializerOptions { WriteIndented = true });
        var fileName = $"{Guid.NewGuid()}.json";
        var filePath = Path.Combine(DirectoryName, fileName);
        File.WriteAllText(filePath, json);
        Notify?.Invoke("Проблема добавлена!");
        return true;
    }

    public static OpenLoop[] Get()
    {
        var files = Directory.GetFiles(DirectoryName);
        var openLoops = new List<OpenLoop>();
        foreach (var file in files)
        {
            var json = File.ReadAllText(file);
            var openLoop = JsonSerializer.Deserialize<OpenLoop>(json);

            if (openLoop == null)
            {
                throw new Exception("OpenLoop cannot be deserialized.");
            }

            openLoops.Add(openLoop);
        }

        return openLoops.ToArray();
    }
}