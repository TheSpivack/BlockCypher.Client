namespace BlockCypher.Client.SampleConsole;

public interface IConsoleApplication
{
    /// <summary>
    /// Execute the application and return the result code.  0 is success, anything else means fail.  Unless you're robocopy
    /// </summary>
    Task<int> ExecuteAsync(string[] args);
}