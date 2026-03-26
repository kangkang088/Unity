using System;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson2_自定义窗口拓展
{
    public class Lesson2 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson2/ShowWindow")]
        private static void ShowWindow()
        {
            var window = GetWindow<Lesson2>();
            window.Show();
        }

        private void OnHierarchyChange()
        {
            Debug.Log("OnHierarchyChange");
        }

        private void OnFocus()
        {
            Debug.Log("OnFocus");
        }

        private void OnLostFocus()
        {
            Debug.Log("OnLostFocus");
        }

        private void OnProjectChange()
        {
            Debug.Log("OnProjectChange");
        }

        private void OnInspectorUpdate()
        {
            Debug.Log("OnInspectorUpdate");
        }

        private void OnSelectionChange()
        {
            Debug.Log("OnSelectionChange");
        }

        private void OnEnable()
        {
            Debug.Log("OnEnable");
        }

        private void OnDestroy()
        {
            Debug.Log("OnDestroy");
        }

        private void Update()
        {
            Debug.Log("Update");
        }

        private void OnGUI()
        {
            GUILayout.Label("Test Test");
            if (GUILayout.Button("TestButton"))
            {
                Debug.Log("TestButton");
            }
        }
    }
}
