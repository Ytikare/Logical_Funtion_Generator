namespace Core
{
    using static Common.Constants;

    using Data_Structures;
    using Data_Structures.Collections;
    using Text_Operators;

    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            var hashset = new HashSet<int, FuncData>(HASHSET_SIZE);

            string message = "";
            bool loop = true;

            while (loop)
            {
                Console.WriteLine(message);

                Console.WriteLine();

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
                            string funcName;
                            var parameters = CommandParser.GetParameters(line);

                            CommandParser.Define(line, parameters.Count, out functionCode, out funcName, out root, hashset);

                            var temp = new Dictionary<string, bool>();

                            foreach (var param in parameters)
                            {
                                temp.Add(param, false);
                            }

                            FuncData el = new FuncData()
                            {
                                root = root,
                                numberOfParameters = parameters.Count,
                                parameters = temp,
                                funcName = funcName
                            };

                            hashset.Add(functionCode, functionCode, el);
                            message = $"Function {el.funcName} has been defined!";
                        }
                        catch (Exception e)
                        {
                            message = e.Message;
                        }
                        break;

                    case "ALL":

                        var results = CommandParser.All(line, hashset);

                        foreach (var item in results)
                        {
                            sb.Append($"{item}{Environment.NewLine}");
                        }

                        message = sb.ToString();
                        sb.Clear();
                        break;

                    case "SOLVE":
                        try
                        {
                            var result = CommandParser.Solve(line, hashset);

                            if (result)
                            {
                                message = "Result: 1";
                            }
                            else
                            {
                                message = "Result: 0";
                            }
                        }
                        catch (Exception e)
                        {
                            message = e.Message;
                        }
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
