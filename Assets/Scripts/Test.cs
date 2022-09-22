using UnityEngine;
public class Test : MonoBehaviour
{
    private void Start()
    {        
        int a = 4,b = 89;//забавно, что решение этой задачи мельком проскакивало в одном из учебников 8 класса »нформатики
        Debug.Log($"a = {a}, b = {b}");
        a += b;
        b = a - b;
        a -= b;
        Debug.Log($"a = {a}, b = {b}");
    }
}
