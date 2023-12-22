namespace Data_Structures
{
    
    public class CustomNonGenericDictionary
    {
        private KeyValuePair<string, FuncData>? First;
        private KeyValuePair<string, FuncData>? Last;
        public int Count { get; private set; }

        public FuncData this[string key] => GetValue(key);

        public CustomNonGenericDictionary()
        {
            Count = 0;
        }

        public void Add(string key, FuncData value)
        {
            var temp = new KeyValuePair<string, FuncData>(key, value);

            if (Count == 0)
            {
                First = Last = temp;
            }
            else
            {
                Last!.Next = temp;
                Last = temp;
            }
            Count++;
        }

        private FuncData GetValue(string key) 
        {
            if (Count > 0)
            {
                KeyValuePair<string, FuncData> temp = First!;

                while (true)
                {
                    if (key.StringCompare(temp.Key))
                    {
                        return temp.Value;
                    }

                    if (First == Last)
                    {
                        break;
                    }
                }
            }
            return null;
        }
    }
}
