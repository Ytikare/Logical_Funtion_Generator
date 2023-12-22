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


        public static bool Define(string line, out int functionName, out TreeNode root) 
        {
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
                throw new InvalidDataException();
            }

            root = stack.Pop();

            functionName = Hasher.HashName(fName);
        }
    }
}
