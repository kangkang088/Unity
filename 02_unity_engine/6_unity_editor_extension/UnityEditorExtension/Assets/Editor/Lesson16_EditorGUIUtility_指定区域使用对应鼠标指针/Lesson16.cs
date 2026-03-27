using UnityEditor;
using UnityEngine;

namespace Editor.Lesson16_EditorGUIUtility_指定区域使用对应鼠标指针
{
    public class Lesson16 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson16/OpenWindow")]
        public static void ShowWindow()
        {
            var window = GetWindow(typeof(Lesson16));
            window.titleContent = new GUIContent("EditorGUIUtility Introduce Window");
            window.Show();
        }

        private void OnGUI()
        {
            EditorGUI.DrawRect(new Rect(0, 100, 100, 100), Color.green);
            EditorGUIUtility.AddCursorRect(new Rect(0, 150, 100, 100), MouseCursor.Link);
        }
    }
}