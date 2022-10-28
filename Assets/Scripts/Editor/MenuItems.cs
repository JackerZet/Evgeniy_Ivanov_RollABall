using UnityEditor;
using UnityEditor.PackageManager.UI;
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
        [MenuItem("Tools/Creator of walls &_c")]
        public static void CreateWalls()
        {
            EditorWindow.GetWindow(typeof(CreatorOfWalls), false, "Creator of walls");
        }
    }
}
