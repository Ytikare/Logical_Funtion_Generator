namespace Core
{
    using System.Collections.Generic;
    using Text_Operators;

    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            var dic = new Dictionary<string, string>();

            string message = "";
            bool loop = true;

            while (loop) 
            {
                Console.WriteLine(message);
                Console.WriteLine("Avaiable commands:");
                Console.WriteLine("DEFINE - define function");
                Console.WriteLine("SOLVE - solve a function with specific name");
                Console.WriteLine("ALL - give all possible solutions for a given funtion");
                Console.WriteLine("EXIT - exit the application");
                Console.Write("Enter your command: ");
                string line = Console.ReadLine()!;

                string command = CommandParser.ReadCommand(line);

                switch (command) 
                {
                    case "DEFINE":
                        break;

                    case "ALL":
                        break;

                    case "SOLVE":
                        break;

                    case "EXIT":
                        loop = false;
                        break;

                    default:
                        message = "Invalid command";
                        break;
                }

                Console.Clear();
            }
        }
    }
}
