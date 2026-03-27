using System;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson15_EditorGUIUtility_窗口事件传递_坐标转换
{
    public class Lesson15Another : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson15Another/OpenWindow")]
        public static void ShowWindow()
        {
            var window = GetWindow(typeof(Lesson15Another));
            window.titleContent = new GUIContent("EditorGUIUtility Introduce Window");
            window.Show();
        }

        private void OnGUI()
        {
            if (Event.current.commandName == "Lesson15 Event")
            {
                Debug.Log("receive an event from Lesson15.");
            }
        }
    }
}