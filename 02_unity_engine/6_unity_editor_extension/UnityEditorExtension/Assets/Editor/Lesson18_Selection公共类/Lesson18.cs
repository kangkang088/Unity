using UnityEditor;
using UnityEngine;

namespace Editor.Lesson18_Selection公共类
{
    public class Lesson18 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson18/OpenWindow")]
        public static void ShowWindow()
        {
            var window = GetWindow(typeof(Lesson18));
            window.titleContent = new GUIContent("EditorGUIUtility Introduce Window");
            window.Show();
        }

        private void OnGUI()
        {
        }
    }
}