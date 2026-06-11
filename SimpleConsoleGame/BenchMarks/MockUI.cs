namespace SimpleConsoleGame.BenchMarks;

public class MockUI
{
    private string _message = string.Empty;
    public void AddMessage(string message)
    {
        _message = message;
    }
}