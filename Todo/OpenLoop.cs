namespace TodoList;

public class OpenLoop
{
    public OpenLoop(string title)
    {
        Id = Guid.NewGuid();
        Title = title;
    }

    public Guid Id { get; }
    public string Title { get; private set; }
    
    public DateTimeOffset Created { get; } = DateTimeOffset.Now;
}