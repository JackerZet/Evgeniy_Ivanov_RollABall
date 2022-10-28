using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RollABall.Editor
{
    [CustomEditor(typeof(Test4), editorForChildClasses: true)]
    public class Autofill : UnityEditor.Editor
    {
        private const string but_whatIsIt = "What is it?";

        private Test4 test;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var pressButton = GUILayout.Button(but_whatIsIt);

            if (pressButton)
            {
                
            }
        }
    }
}
