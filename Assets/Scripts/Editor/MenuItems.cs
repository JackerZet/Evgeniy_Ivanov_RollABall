using UnityEditor;
using UnityEngine;

namespace RollABall.Editor
{
    public class MenuItems
    {
        [MenuItem("Tools/what?.. why?.. &F4")]
        public static void Thing()
        {
            Debug.Log("Good luck");
            Debug.LogWarning("Good luck");
        }
    }
}
