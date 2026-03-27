using System;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson15_EditorGUIUtility_窗口事件传递_坐标转换
{
    public class Lesson15 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson15/OpenWindow")]
        public static void ShowWindow()
        {
            var window = GetWindow(typeof(Lesson15));
            window.titleContent = new GUIContent("EditorGUIUtility Introduce Window");
            window.Show();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Create An Event"))
            {
                var e = EditorGUIUtility.CommandEvent("Lesson15 Event");
                var anotherWindow = GetWindow<Lesson15Another>();
                anotherWindow.SendEvent(e);
            }
            
            if (GUILayout.Button("Coordinate Transform"))
            {
                var guiPoint = new Vector2(10, 10);
                var screenPoint = EditorGUIUtility.GUIToScreenPoint(guiPoint);
                Debug.Log(screenPoint);
            }
        }
    }
}