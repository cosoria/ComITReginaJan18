using System;
using DataAccessLayer;
using DomainLayer;
using DomainLayer.Commands;
using DomainLayer.Contracts;

namespace ConsoleUI
{
    class Program
    {
        private static CommandParser _commandParser;

        static void Main(string[] args)
        {
            Init();

            Console.WriteLine("Welcome to ComIT Course Management App " + Constants.Version);
            Console.WriteLine("  Please type a command or help to start");

            var exit = false;

            while (!exit)
            {
                Console.Write(" :> ");
                var commandString = Console.ReadLine();
                
                exit = Process(commandString);
            }

            Console.WriteLine("Cya Later!!! ");
        }

        static void Init()
        {
            CommandFactory.Init(DatabaseFactory.Create(""));
        }

        static bool Process(string commandString)
        {
            var command = _commandParser.Parse(commandString);

            if (command == null)
            {
                Console.WriteLine("ERROR: Could not parse command, please try again or use help");
                return false;
            }
            
            var result  = command.Execute();

            if (result.Failed)
            {
                Console.WriteLine(result.ErrorText);
            }

            return result.Exit;
        }
    }
}
