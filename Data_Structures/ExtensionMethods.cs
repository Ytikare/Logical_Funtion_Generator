namespace Data_Structures
{
    public static class ExtensionMethods
    {
        public static bool StringCompare(this string str, string str2)
        {
            if (str.Length != str2.Length)
            {
                return false;
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != str2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static int IndexOfChar(this string str, char c)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int IndexOfChar(this string str, char c, int startIndex)
        {
            if (startIndex < 0)
            {
                throw new InvalidOperationException();
            }

            for (int i = startIndex; i < str.Length; i++)
            {
                if (str[i] == c)
                {
                    return i;
                }
            }

            return -1;
        }

        public static char[] ReturnCharArray(this string str) 
        {
            char[] arr = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                arr[i] = str[i];
            }
            return arr;
        }


        public static string SubstringExtension(this string str, int range) 
        {
            if (range > str.Length)
            {
                throw new InvalidOperationException("Range is bigger than string lenght!");
            }
            else if (range == str.Length)
            {
                return str;
            }

            char[] temp = new char[range];
            for (int i = 0; i < range; i++)
            {
                temp[i] = str[i];
            }

            return new string(temp);
        }
    }
}
