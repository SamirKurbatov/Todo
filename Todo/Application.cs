namespace TodoList;

public class Application
{
    // menu with operations
    private readonly Dictionary<string, IOperation> _menu;

    public Application()
    {
        _menu = new Dictionary<string, IOperation>
        {
            { "create", new CreateNewNoteOperation() },
            { "get", new GetNoteOperation() },
        };
    }

    public void Run(CancellationToken token)
    {
        Console.Clear();
        while (token.IsCancellationRequested == false)
        {
            PrintMenu();
            var operationName = Console.ReadLine() ?? string.Empty;

            if (token.IsCancellationRequested)
            {
                break;
            }
            
            if (_menu.TryGetValue(operationName, out var operation) == false || operation is null)
            {
                Console.WriteLine($"Команды '{operationName}' не существует");
                Console.WriteLine($"Нажмите любую клавишу, чтобы продолжить");
                Console.ReadKey(true);
                Console.Clear();
                continue;
            }

            operation.Invoke();
        }
    }

    private void PrintMenu()
    {
        Console.WriteLine("Список доступных операций над заметками:");
        foreach (var item in _menu)
        {
            Console.WriteLine($"- {item.Key}");
        }

        Console.WriteLine("Нажмите CTRL + C чтобы выйти из программы..");
    }
}