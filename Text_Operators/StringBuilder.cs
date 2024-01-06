namespace Text_Operators
{
    public class StringBuilder
    {
        private SBNode? first;
        private SBNode? last;
        private int lenght;

        public StringBuilder()
        {
            first= last = null;
            lenght = 0;
        }

        public StringBuilder(char c)
        {
            first = last = new SBNode
            {
                Next = null,
                Value = c
            };

            lenght = 1;
        }

        public void Append(string line) 
        {
            if (lenght == 0)
            {
                AppendEmptySB(line[0]);
                for (int i = 1; i < line.Length; i++)
                {
                    this.Append(line[i]);
                }
            }
            else
            {
                for (int i = 0; i < line.Length; i++)
                {
                    this.Append(line[i]);
                }
            }

        }

        public void Append(char c) 
        {
            if (lenght == 0)
            {
                AppendEmptySB(c);
            }
            else
            {
                last!.Next = new SBNode 
                { 
                    Next = null, 
                    Value = c 
                };

                last = last.Next;

                lenght++;
            }
        }
        public void Clear()
        {
            first = last = null;
            lenght = 0;
        }

        private void AppendEmptySB(char c) 
        {
            first = last = new SBNode
            {
                Next = null,
                Value = c
            };

            lenght = 1;
        }

        public override string ToString()
        {
            if (lenght == 0)
            {
                return string.Empty;
            }

            char[] chars = new char[lenght];

            int index = 0;
            SBNode temp = first!;

            while (index < lenght)
            {
                chars[index] = temp!.Value;

                temp = temp.Next!;
                index++;
            }

            return new string(chars);
        }

    }
}
