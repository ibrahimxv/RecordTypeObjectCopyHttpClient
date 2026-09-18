namespace ConsoleApp2.Exceptons;

public class ConflictExceptions : Exception
{
    public ConflictExceptions (string message)
        : base (message)
    {
    }
}
