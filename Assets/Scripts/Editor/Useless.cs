using UnityEditor;
using UnityEngine;

namespace RollABall.Editor
{
    [CustomEditor(typeof(Test4), editorForChildClasses: true)]
    public class Useless : UnityEditor.Editor
    {
        private const string but_whatIsIt = "What is it?"; 
        private const string but_deleteAll = "Delete all";

        private GameObject _test;
        public void OnEnable()
        {
            _test = FindObjectOfType<Test4>().gameObject;
        }
        public override void OnInspectorGUI()
        {
            bool pressBut_whatIsIt = GUILayout.Button(but_whatIsIt);

            bool pressBut_deleteAll = GUILayout.Button(but_deleteAll);
            
            if (pressBut_whatIsIt)            
                AddComponent();                          
          
            if (pressBut_deleteAll)
                RemoveAllComponents();                           
        }
        private void AddComponent()
        {
            int len = _test.GetComponents<Test4>().Length;
            for (int i = 0; i < Random.Range(1, len); i++)
                Undo.AddComponent(_test, typeof(Test4));
        }
        private void RemoveAllComponents()
        {
            var tests = _test.GetComponents<Test4>();
            foreach (var t in tests)
                Undo.DestroyObjectImmediate(t);
        }
    }
}