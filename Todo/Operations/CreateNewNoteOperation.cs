namespace TodoList;

public class CreateNewNoteOperation : IOperation
{
    public void Invoke()
    {
        Console.Write("Что вас беспокоит сейчас? ");
        
        string? note;
        do
        {
            note = Console.ReadLine();
            // openLoopsRepositrory.Notify += PrintMessage;
        } while (string.IsNullOrWhiteSpace(note));

        OpenLoopRepository.Add(new OpenLoop(note));
        // openLoopsRepositrory.Notify += PrintMessage;
    }
}