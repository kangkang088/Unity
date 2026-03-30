using System;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson42_AssetDatabase公共类
{
    public class Lesson42 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson42/OpenWindow")]
        private static void OpenWindow()
        {
            var window = GetWindow<Lesson42>();
            window.titleContent = new GUIContent("AssetDatabase Introduce Window");
            window.Show();
        }

        private void OnGUI()
        {
        }
    }
}