using System;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson26_Scene_Handles公共类
{
    public class Lesson26Window : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson26/OpenWindow")]
        public static void ShowWindow()
        {
            var window = GetWindow<Lesson26Window>();
            window.titleContent = new GUIContent("Custom Window Can Receive Scene Event");
            window.Show();
        }

        private void OnEnable()
        {
            SceneView.duringSceneGui += SceneUpdate;
        }

        private void SceneUpdate(SceneView view)
        {
            Debug.Log("自定义窗口响应Scene");
        }

        private void OnDestroy()
        {
            SceneView.duringSceneGui -= SceneUpdate;
        }
    }
}