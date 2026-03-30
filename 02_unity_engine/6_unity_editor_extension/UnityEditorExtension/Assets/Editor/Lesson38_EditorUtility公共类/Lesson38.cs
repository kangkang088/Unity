using System;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson38_EditorUtility公共类
{
    public class Lesson38 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson38/OpenWindow")]
        public static void ShowWindow()
        {
            var window = GetWindow<Lesson38>();
            window.titleContent = new GUIContent("EditorUtility Introduce Window");
            window.Show();
        }

        private void OnGUI()
        {
            
        }
    }
}