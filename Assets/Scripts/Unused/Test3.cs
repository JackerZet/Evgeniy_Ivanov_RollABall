using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Test3 : MonoBehaviour
{
    [SerializeField] private Dictionary<string, int> dictNums = new()
        {
            {"four",4 },
            {"two",2 },
            { "one",1 },
            {"three",3 },
        };
    private void Start()
    {
        var d = dictNums.OrderBy((pair) => pair.Value);        
        foreach (var pair in d)       
            Debug.Log($"{pair.Key} - {pair.Value}");       
    }
}
