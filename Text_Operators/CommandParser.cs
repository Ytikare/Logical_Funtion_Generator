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
    }
}
