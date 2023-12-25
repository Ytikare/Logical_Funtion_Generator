namespace Data_Structures
{
    
    public class CustomNonGenericDictionary
    {
        private KeyValuePair<int, FuncData>? First;
        private KeyValuePair<int, FuncData>? Last;
        public int Count { get; private set; }

        public FuncData this[int key] => GetValue(key);

        public CustomNonGenericDictionary()
        {
            Count = 0;
        }

        public void Add(int key, FuncData value)
        {
            var temp = new KeyValuePair<int, FuncData>(key, value);

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

        private FuncData GetValue(int key) 
        {
            if (Count > 0)
            {
                KeyValuePair<int, FuncData> temp = First!;

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
