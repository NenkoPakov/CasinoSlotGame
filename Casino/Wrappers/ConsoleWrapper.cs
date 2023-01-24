namespace Casino.Wrappers
{
    public class ConsoleWrapper : IConsole
    {
        public string ReadLine() => Console.ReadLine();
        public void WriteLine(string message) => Console.WriteLine(message);
        public void Write(string message) => Console.Write(message);
    }
}
