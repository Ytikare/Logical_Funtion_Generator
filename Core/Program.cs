namespace Core
{
    using Data_Structures;
    using System.ComponentModel.Design.Serialization;
    using Text_Operators;

    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            var dictionary = new Dictionary<int, FuncData>();

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

                        try
                        {
                            TreeNode root;
                            int functionCode;
                            var parameters = CommandParser.GetParameters(line);

                            CommandParser.Define(line, parameters.Count, out functionCode, out root);

                            FuncData el = new FuncData() 
                            {
                                root = root,
                                numberOfParameters = parameters.Count,
                                parameters = parameters
                            };

                            dictionary.Add(functionCode, el);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
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
