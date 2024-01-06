namespace Data_Structures
{
    public class KeyValuePair<TKey, TValue> where TKey : IEquatable<TKey>
    {
        public TKey Key { get; set; } = default!;
        public TValue Value { get; set; } = default!;

        public KeyValuePair()
        { }

        public KeyValuePair(TKey key, TValue value)
        {
            Key = key; 
            Value = value;
        }
    }
}
