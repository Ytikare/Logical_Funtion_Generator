using Data_Structures;
using static Common.Constants;

namespace Text_Operators
{
    public static class Hasher
    {
        public static int HashName(string name) 
        {
            var s = 34;
            var key = 0;
            var c = name.ReturnCharArray();

            for (var i = 0; i < c.Length; i++) 
            {
                key = (key * s + (int)c[i]) % HASHSET_SIZE;
            }

            return key;
        }
    }
}
