using UnityEditor;
using UnityEngine;

namespace Editor.Lesson12_EditorGUIUtility公共类
{
    public class Lesson12 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson12/OpenWindow")]
        public static void ShowWindow()
        {
            var window = GetWindow(typeof(Lesson12));
            window.titleContent = new GUIContent("EditorGUIUtility Introduce Window");
            window.Show();
        }

        private void OnGUI()
        {
        }
    }
}