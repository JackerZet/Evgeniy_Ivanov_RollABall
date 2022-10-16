using System.Collections.Generic;
using System.Linq;

namespace RollABall
{
    public static class TestHelperClass
    {
        public static int MyLength(string str)
        {
            return str.Count();
        }
        public static int InCorrectLength(string str) // Genious, but not correct method of Length ;)
        {
            int length = 0;
            for (int i = 0; true; i++)
            {
                try
                {
                    //if (str[i] != null) length++;
                }
                catch
                {
                    return length;
                }
            }
        }
        public static Dictionary<T, int> SortingObjByQuantity<T>(List<T> list)
        {
            var dict = new Dictionary<T, int>();

            foreach (T element in list)
            {
                if (!dict.ContainsKey(element))
                    dict.Add(element, 1);
                else
                    dict[element] += 1;
            }

            return dict;
        }
    }
}
    
    

