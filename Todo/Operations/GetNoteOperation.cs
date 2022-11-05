namespace TodoList;

public class GetNoteOperation : IOperation
{
    public void Invoke()
    {
        var openLoops = OpenLoopRepository.Get();
        var groupOfOpenLoops = openLoops
            .GroupBy(x => new DateTime(x.Created.Year, x.Created.Month, x.Created.Day));

        foreach (var item in groupOfOpenLoops)
        {
            Console.WriteLine($"Ваши заботы за: {item.Key:yyyy-M-d dddd}");
            foreach (var openLoop in item.ToArray())
            {
                Console.WriteLine(openLoop.Title);
            }
        }

        void PrintMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}