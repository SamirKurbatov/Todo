using TodoList;

var openLoopsRepositrory = new OpenLoopRepository();

Console.Write("Что вас беспокоит сейчас? ");
string? note = null;

do
{
    note = Console.ReadLine();
} while (string.IsNullOrWhiteSpace(note));

openLoopsRepositrory.Add(new OpenLoop(note));

var openLoops = openLoopsRepositrory.Get();
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