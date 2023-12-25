namespace Data_Structures
{
    
    public class CustomNonGenericDictionary<TKey, TValue> where TKey : IEquatable<TKey>
    {
        private KeyValuePair<TKey, TValue>? First;
        private KeyValuePair<TKey, TValue>? Last;
        public int Count { get; private set; }

        public TValue? this[TKey key] => GetValue(key);

        public CustomNonGenericDictionary()
        {
            Count = 0;
        }

        public void Add(TKey key, TValue value)
        {
            var temp = new KeyValuePair<TKey, TValue>(key, value);

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

        private TValue? GetValue(TKey key) 
        {
            if (Count > 0)
            {
                KeyValuePair<TKey, TValue> temp = First!;

                while (true)
                {
                    if (temp.Key.Equals(key))
                    {
                        return temp.Value;
                    }

                    if (First == Last)
                    {
                        break;
                    }
                }
            }
            return default;
        }
    }
}
