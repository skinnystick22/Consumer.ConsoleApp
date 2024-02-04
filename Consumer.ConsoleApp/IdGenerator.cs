﻿namespace Consumer.ConsoleApp;

public class IdGenerator : IIdGenerator
{
    private readonly IConsoleWriter _consoleWriter;

    public IdGenerator(IConsoleWriter consoleWriter)
    {
        _consoleWriter = consoleWriter;
    }
    
    public Guid Id { get; } = Guid.NewGuid();

    public void PrintId()
    {
        _consoleWriter.WriteLine(Id.ToString());
    }
}