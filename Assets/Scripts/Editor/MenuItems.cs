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
        [MenuItem("Tools/Creator of objects &c")]
        public static void CreateWalls()
        {
            EditorWindow.GetWindow(typeof(CreatorOfObjects), false, "Creator of objects");
        }
    }
}
