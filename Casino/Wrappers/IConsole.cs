﻿namespace Casino.Wrappers
{
    public interface IConsole
    {
        string ReadLine();
        void WriteLine(string message);
        void Write(string message);
    }
}
