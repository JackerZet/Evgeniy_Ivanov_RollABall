using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace RollABall.Editor
{
    public enum Direction
    {
        Right,
        Left,
        Up,
        Down,
    }
    public class CreatorOfWalls : EditorWindow
    {
        [SerializeField] private GameObject wall;
        [SerializeField] private Transform parent;

        [SerializeField] private Vector3 startPosition = Vector3.zero;        
        [SerializeField] private int quantity = 1;
        [SerializeField] private Direction direction = Direction.Right;


        private void OnGUI()
        {
            GUILayout.Label("Base settings", EditorStyles.boldLabel);
            wall = EditorGUILayout.ObjectField("Wall", wall, typeof(GameObject), true) as GameObject;
            parent = EditorGUILayout.ObjectField("Parent where to put object", parent, typeof(Transform), true) as Transform;
            startPosition = EditorGUILayout.Vector3Field("First wall position", startPosition);
            
            quantity = EditorGUILayout.IntSlider("Quantity of objects", quantity, 1, 100);
            direction = (Direction)EditorGUILayout.EnumPopup("Direction(regarding the game)", direction);
            

            bool button = GUILayout.Button("Create walls");
            if (button)
            {
                if (wall == null) return;

                var scale = wall.GetComponentInChildren<MeshRenderer>().gameObject.transform.localScale;
                
                if(scale == null) scale = wall.transform.localScale;

                for (int i = 0; i < quantity; i++)
                {
                    var curePosition = direction switch// I couldn't get rid of copying the code
                    {
                        Direction.Right => new Vector3(startPosition.x, startPosition.y, startPosition.z + i * scale.z),  
                        Direction.Left => new Vector3(startPosition.x, startPosition.y, startPosition.z - i * scale.z),
                        Direction.Down => new Vector3(startPosition.x + i * scale.x, startPosition.y, startPosition.z),
                        Direction.Up => new Vector3(startPosition.x - i * scale.x, startPosition.y, startPosition.z),
                        _ => throw new System.NotImplementedException()
                    };
                    if (parent)                   
                        Instantiate(wall, curePosition, Quaternion.identity, parent);
                    
                    else                   
                        Instantiate(wall, curePosition, Quaternion.identity);
                  
                }                                                                                                            
            }
        }
    }
}
