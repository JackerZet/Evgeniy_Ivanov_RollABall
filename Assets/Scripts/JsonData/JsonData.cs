using RollABall.Interfaces;
using UnityEngine;

namespace RollABall.Data
{
    public class JsonData<T> : IData<T>
    {
        public void Save(T data, string path = null)
        {
            var str = JsonUtility.ToJson(data);
            System.IO.File.WriteAllText(path, str);
        }
       
        public T Load(string path = null)
        {
            var str = System.IO.File.ReadAllText(path);
            return JsonUtility.FromJson<T>(str);

        }
        private string CryptoXOR(string str, int key = 42)
        {
            var result = string.Empty;
            foreach(char symbol in str)
            {
                result += (char)(symbol ^ key);
            }
            return result;
        }
    }
}
