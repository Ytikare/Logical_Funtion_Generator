namespace Data_Structures
{
    public class KeyValuePair<TKey, TValue>
    {
        public TKey Key { get; set; } = default!;
        public TValue Value { get; set; } = default!;

        public KeyValuePair<TKey, TValue>? Next;

        public KeyValuePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public KeyValuePair()
        {
        }
    }
}
