using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;
using static RollABall.TestHelperClass;

public class Test2 : MonoBehaviour
{
    [SerializeField] private string predlozhenie = "hi, player";
    [SerializeField] private List<float> list1;
    
    private void Start()
    {        
        Log($"correct method's result - {MyLength(predlozhenie)}, incorrect method's result - {InCorrectLength(predlozhenie)}");

        Dictionary<float, int> dict1 = SortingObjByQuantity(list1);
        foreach (var ele in dict1)        
            Log($"{ele.Key}=>{ele.Value}");        
    }    
}
