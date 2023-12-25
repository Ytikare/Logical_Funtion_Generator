using Data_Structures;

using StringBuilder = Text_Operators.StringBuilder;

namespace Text_Operators
{
    public static class CommandParser
    {
        public static string ReadCommand(string line)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in line) 
            {
                if (c == ' ')
                {
                    break;
                }

                sb.Append(c);
            }

            return sb.ToString();
        }

        public static Data_Structures.List<string> GetParameters(string s) 
        {
            Data_Structures.List<string> parameters = new Data_Structures.List<string>();

            bool flag = false;
            StringBuilder sb = new StringBuilder();


            for (int i = s.IndexOfChar('('); i < s.IndexOfChar(')'); i++)
            {
                if (char.IsLetter(s[i]))
                {
                    flag = true;
                    sb.Append(s[i]);
                }
                else if (s[i] == ',')
                {
                    parameters.Add(sb.ToString());
                    sb.Clear();
                }
            }

            return parameters;
        }


        public static bool Define(string line,int parametersCount, out int functionCode, out TreeNode root) 
        {
            //example input 1: a b &
            //example input 2: 
            //example input 3:
            //example input 4:
            string fName, expression;


            StringBuilder sb = new StringBuilder();

            for (int i = line.IndexOfChar(' '); i < line.IndexOfChar('('); i++) 
            {
                sb.Append(line[i]);
            }
            fName = sb.ToString();
            sb.Clear();


            Data_Structures.Stack<TreeNode> stack = new Data_Structures.Stack<TreeNode>();


            for (int i = line.IndexOfChar('"'); i < line.Length; i++)
            {
                char c = line[i];


                if (c == ' ') 
                {
                    continue;
                }


                if (char.IsLetter(c))
                {
                    stack.Push(new TreeNode
                    {
                        IsOperator = false,
                        Name = c.ToString(),
                    });
                }
                else if (c == '&' || c == '|')
                {
                    TreeNode tempOne = stack.Pop();
                    TreeNode tempTwo = stack.Pop();

                    stack.Push(new TreeNode
                    {
                        IsOperator = true,
                        Left = tempOne,
                        Right = tempTwo,
                        Name = c.ToString()
                    });
                }
                else if (c == '!')
                {
                    TreeNode temp = stack.Pop();

                    stack.Push(new TreeNode
                    {
                        IsOperator = true,
                        Left = temp,
                        Name = c.ToString()
                    });
                }
            }


            if (stack.Count != 1)
            {
                throw new InvalidDataException("Invalid line sequence");
            }
            root = stack.Pop();

            if (TreeNode.GetLeafsCount(root) != parametersCount)
            {
                throw new InvalidOperationException();
            }

            functionCode = Hasher.HashName(fName);

            return true;
        }
    }
}
