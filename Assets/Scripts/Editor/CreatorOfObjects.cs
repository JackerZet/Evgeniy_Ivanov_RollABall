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
    public enum TypeOfStaging
    {
        PieceByPiece,
        OnePiece
    }
    public class CreatorOfObjects : EditorWindow
    {
        [SerializeField] private GameObject wall;
        [SerializeField] private Transform parent;

        [SerializeField] private TypeOfStaging staging;
        [SerializeField] private Vector3 startPosition = Vector3.zero;        
        [SerializeField] private int quantity = 1;
        [SerializeField] private Direction direction = Direction.Right;
        [SerializeField] private bool byMeshRendererScale = false;

        private void OnGUI()
        {
            GUILayout.Label("Base settings", EditorStyles.boldLabel);

            wall = EditorGUILayout.ObjectField("Wall", wall, typeof(GameObject), true) as GameObject;
            
            parent = EditorGUILayout.ObjectField("Parent where to put object", parent, typeof(Transform), true) as Transform;
            
            startPosition = EditorGUILayout.Vector3Field("First wall position", startPosition);
            
            staging = (TypeOfStaging)EditorGUILayout.EnumPopup("Type of staging", staging);

            byMeshRendererScale = EditorGUILayout.Toggle("By Mesh Renderer scaling", byMeshRendererScale);
            
            quantity = EditorGUILayout.IntSlider("Quantity of objects", quantity, 1, 30);
            
            direction = (Direction)EditorGUILayout.EnumPopup("Direction(regarding the game)", direction);
            
            bool button = GUILayout.Button("Create walls");
            if (button)
            {
                if (wall == null) return;

                switch (staging)
                {
                    case TypeOfStaging.PieceByPiece:
                        StagePieceByPiece();
                        break;
                    case TypeOfStaging.OnePiece:
                        StageOnePiece();
                        break;
                }                                                                                                                               
            }
        }
        private void StageOnePiece()
        {
            var scale = wall.transform.localScale;

            var cureScale = direction switch// I couldn't get rid of copying the code
            {
                Direction.Right => new Vector3(scale.x, scale.y, scale.z * quantity),
                Direction.Left => new Vector3(scale.x, scale.y, scale.z * -quantity),
                Direction.Down => new Vector3(scale.x * quantity, scale.y, scale.z),
                Direction.Up => new Vector3(scale.x * -quantity, scale.y, scale.z),
                _ => throw new System.NotImplementedException()
            };

            GameObject obj;
            
            obj = Instantiate(wall, startPosition, Quaternion.identity, parent);         

            obj.transform.localScale = cureScale;
        }
        private void StagePieceByPiece()
        {
            var scale = wall.GetComponentInChildren<MeshRenderer>().gameObject.transform.localScale;
            if (scale == null || !byMeshRendererScale) scale = wall.transform.localScale;

            for(int i = 0; i < quantity; i++)
            {
                var curePosition = direction switch// I couldn't get rid of copying the code
                {
                    Direction.Right => new Vector3(startPosition.x, startPosition.y, startPosition.z + i * scale.z),
                    Direction.Left => new Vector3(startPosition.x, startPosition.y, startPosition.z - i * scale.z),
                    Direction.Down => new Vector3(startPosition.x + i * scale.x, startPosition.y, startPosition.z),
                    Direction.Up => new Vector3(startPosition.x - i * scale.x, startPosition.y, startPosition.z),
                    _ => throw new System.NotImplementedException()
                };
                
                Instantiate(wall, curePosition, Quaternion.identity, parent);                                 
            }
        }
    }
}
